using DiGi.GIS.IO.Classes;
using DiGi.GIS.IO.Enums;
using DiGi.Geometry.Planar.Classes;
using Microsoft.Data.Sqlite;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json.Nodes;
using System.Threading;

namespace DiGi.GIS.IO
{
    public static partial class Query
    {
        /// <summary>
        /// Streams building footprints from a GeoPackage file (EUBUCCO, DBSM, GHS-OBAT centroids) as an asynchronous sequence, returning each footprint in the file's own coordinate reference system.
        /// <para>The file is opened read-only and walked row by row: no country file is ever materialised, so a multi-gigabyte EUBUCCO release costs one row of memory at a time. The spatial reference identifier comes from <c>gpkg_geometry_columns</c> joined to <c>gpkg_spatial_ref_sys</c> (an EPSG organisation code wins over the local srs_id) and is validated against the supported set at enumeration start, so an unexpected reference system fails loudly before the first row is interpreted.</para>
        /// <para>Every column except the geometry blob becomes an entry in <see cref="Footprint.Attributes"/>, provenance and the EUBUCCO licence exception are derived per row, and <paramref name="boundingBox"/> - expressed in the file's coordinate reference system - filters on the decoded geometry envelope.</para>
        /// </summary>
        /// <param name="path">The path of the GeoPackage file, or null or whitespace to return null.</param>
        /// <param name="buildingDataset">The dataset the file holds; Eubucco, Dbsm or GhsObat.</param>
        /// <param name="boundingBox">An optional bounding box, in the file's coordinate reference system, that footprints must intersect.</param>
        /// <param name="tableName">The geometry table to read; required only when the file registers more than one.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The streaming sequence, or null when <paramref name="path"/> is null or whitespace.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="buildingDataset"/> is not a GeoPackage dataset, or when the file registers several geometry tables and no table name was given.</exception>
        /// <exception cref="NotSupportedException">Thrown at enumeration start when the file declares an SRID other than 4326 or 3035.</exception>
        /// <exception cref="InvalidDataException">Thrown when the file has no geometry table, the registered geometry column is missing, or a row carries no geometry.</exception>
        public static IAsyncEnumerable<Footprint>? Footprints_GeoPackageAsync(string? path, BuildingDataset buildingDataset, BoundingBox2D? boundingBox = null, string? tableName = null, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                return null;
            }

            if (buildingDataset != BuildingDataset.Eubucco && buildingDataset != BuildingDataset.Dbsm && buildingDataset != BuildingDataset.GhsObat)
            {
                throw new ArgumentException($"The GeoPackage reader reads Eubucco, Dbsm or GhsObat; got {buildingDataset}.", nameof(buildingDataset));
            }

            return Footprints_GeoPackage_Iterator(path!, buildingDataset, boundingBox, tableName, cancellationToken);
        }

        /// <summary>
        /// Walks a GeoPackage geometry table row by row, yielding one <see cref="Footprint"/> per row.
        /// </summary>
        /// <param name="path">The path of the GeoPackage file.</param>
        /// <param name="buildingDataset">The dataset the file holds.</param>
        /// <param name="boundingBox">An optional bounding box, in the file's coordinate reference system.</param>
        /// <param name="tableName">The geometry table to read, or null to use the file's only one.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The streaming sequence.</returns>
        private static async IAsyncEnumerable<Footprint> Footprints_GeoPackage_Iterator(string path, BuildingDataset buildingDataset, BoundingBox2D? boundingBox, string? tableName, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            SqliteConnectionStringBuilder sqliteConnectionStringBuilder = new()
            {
                DataSource = path,
                Mode = SqliteOpenMode.ReadOnly
            };

            using SqliteConnection sqliteConnection = new(sqliteConnectionStringBuilder.ConnectionString);
            await sqliteConnection.OpenAsync(cancellationToken);

            string resolvedTableName;
            if (string.IsNullOrWhiteSpace(tableName))
            {
                List<string> tableNames = [];
                using (SqliteCommand sqliteCommand = new("SELECT table_name FROM gpkg_geometry_columns ORDER BY table_name", sqliteConnection))
                {
                    using DbDataReader dbDataReader = await sqliteCommand.ExecuteReaderAsync(cancellationToken);
                    while (await dbDataReader.ReadAsync(cancellationToken))
                    {
                        tableNames.Add(dbDataReader.GetString(0));
                    }
                }

                if (tableNames.Count == 0)
                {
                    throw new InvalidDataException($"File '{path}' registers no geometry tables.");
                }

                if (tableNames.Count > 1)
                {
                    throw new ArgumentException($"File '{path}' registers {tableNames.Count} geometry tables ({string.Join(", ", tableNames)}); pass tableName to select one.", nameof(tableName));
                }

                resolvedTableName = tableNames[0];
            }
            else
            {
                resolvedTableName = tableName!;
            }

            int srid;
            string geometryColumnName;
            using (SqliteCommand sqliteCommand = new("SELECT g.column_name, CASE WHEN UPPER(s.organization) = 'EPSG' THEN s.organization_coordsys_id ELSE g.srs_id END AS srid FROM gpkg_geometry_columns AS g INNER JOIN gpkg_spatial_ref_sys AS s ON g.srs_id = s.srs_id WHERE g.table_name = @table_name", sqliteConnection))
            {
                sqliteCommand.Parameters.AddWithValue("@table_name", resolvedTableName);
                using DbDataReader dbDataReader = await sqliteCommand.ExecuteReaderAsync(cancellationToken);
                if (!await dbDataReader.ReadAsync(cancellationToken))
                {
                    throw new InvalidDataException($"File '{path}' registers no geometry column for table '{resolvedTableName}'.");
                }

                geometryColumnName = dbDataReader.GetString(0);
                srid = System.Convert.ToInt32(dbDataReader.GetValue(1), System.Globalization.CultureInfo.InvariantCulture);
            }

            ValidateSrid(srid, path);

            GeoPackageGeoReader geoPackageGeoReader = new();

            string quotedTableName = "\"" + resolvedTableName.Replace("\"", "\"\"") + "\"";
            using SqliteCommand selectCommand = new($"SELECT * FROM {quotedTableName}", sqliteConnection);
            using DbDataReader dataReader = await selectCommand.ExecuteReaderAsync(cancellationToken);

            int geometryOrdinal = -1;
            for (int i = 0; i < dataReader.FieldCount; i++)
            {
                if (string.Equals(dataReader.GetName(i), geometryColumnName, StringComparison.Ordinal))
                {
                    geometryOrdinal = i;
                    break;
                }
            }

            if (geometryOrdinal < 0)
            {
                throw new InvalidDataException($"Table '{resolvedTableName}' in '{path}' does not contain its registered geometry column '{geometryColumnName}'.");
            }

            long rowIndex = 0;
            while (await dataReader.ReadAsync(cancellationToken))
            {
                if (dataReader.IsDBNull(geometryOrdinal) || dataReader.GetValue(geometryOrdinal) is not byte[] blob)
                {
                    throw new InvalidDataException($"Row {rowIndex} of table '{resolvedTableName}' in '{path}' carries no geometry blob.");
                }

                NetTopologySuite.Geometries.Geometry geometry = geoPackageGeoReader.Read(blob);
                if (geometry == null)
                {
                    throw new InvalidDataException($"Row {rowIndex} of table '{resolvedTableName}' in '{path}' carries an unreadable geometry blob.");
                }

                if (boundingBox != null)
                {
                    Envelope envelope = geometry.EnvelopeInternal;
                    BoundingBox2D geometryBoundingBox = new(new Point2D(envelope.MinX, envelope.MinY), new Point2D(envelope.MaxX, envelope.MaxY));
                    if (!boundingBox.InRange(geometryBoundingBox))
                    {
                        rowIndex++;
                        continue;
                    }
                }

                JsonObject attributes = new();
                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    if (i == geometryOrdinal)
                    {
                        continue;
                    }

                    attributes[dataReader.GetName(i)] = dataReader.IsDBNull(i) ? null : AttributeValue(dataReader.GetValue(i));
                }

                string? licenceException = null;
                if (buildingDataset == BuildingDataset.Eubucco
                    && attributes.TryGetPropertyValue("geometry_source", out JsonNode? geometrySourceNode)
                    && geometrySourceNode is JsonValue geometrySourceValue
                    && geometrySourceValue.TryGetValue<string>(out string? geometrySource))
                {
                    licenceException = LicenceException(geometrySource);
                }

                yield return new Footprint(SourceId(attributes), srid, DiGi.Geometry.Planar.Convert.ToDiGi(geometry), attributes, Provenance(buildingDataset, attributes, null), licenceException);

                rowIndex++;
            }
        }
    }
}
