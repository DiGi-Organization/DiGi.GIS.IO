using DiGi.Geometry.Planar.Classes;
using DiGi.GIS.IO.Classes;
using DiGi.GIS.IO.Enums;
using Microsoft.Data.Sqlite;
using Parquet;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace DiGi.GIS.IO
{
    public static partial class Query
    {
        /// <summary>
        /// Reads the area an open building source file can hold footprints in, as the file states it without being read row by row, so an import scoped to a few counties can leave out the files of a nationwide release that cannot reach them (DiGi-Organization/DiGi.GIS.PostgreSQL#170).
        /// <para>Only an extent the format keeps exact is used:</para>
        /// <para>- Microsoft (line-delimited GeoJSON): the tile of the path's <c>quadkey=</c> directory (<see cref="Quadkey(string?)"/>, <see cref="QuadkeyBoundingBox2D(string?)"/>), in EPSG:4326.</para>
        /// <para>- GeoPackage (EUBUCCO, DBSM, GHS-OBAT): the root of the geometry column's R-tree, <c>rtree_&lt;table&gt;_&lt;column&gt;</c>, and only when <c>gpkg_extensions</c> registers the <c>gpkg_rtree_index</c> extension for that column - the triggers of the extension keep the index equal to the rows. The extent in <c>gpkg_contents</c> is informative in the specification and may be stale, so it is never used.</para>
        /// <para>- GeoParquet (Overture): the <c>bbox</c> the primary geometry column declares in the <c>geo</c> metadata.</para>
        /// <para>Absence is never a reason to skip a file: a file whose format keeps no extent (CSV, an unregistered or missing R-tree, no declared <c>bbox</c>), that cannot be opened, that registers several geometry tables, or that declares a reference system the readers do not support answers null, and the caller reads it whole - the reader then reports whatever is wrong with it.</para>
        /// </summary>
        /// <param name="path">The source file.</param>
        /// <param name="buildingDataset">The dataset the file belongs to; it selects the format as the import task does.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to monitor for cancellation requests.</param>
        /// <returns>A task whose result is the file's extent in its own coordinate reference system, or null when the file states none that can be trusted.</returns>
        public static async Task<SourceExtent?> SourceExtentAsync(string? path, BuildingDataset buildingDataset, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
            {
                return null;
            }

            if (buildingDataset == BuildingDataset.Microsoft)
            {
                BoundingBox2D? boundingBox2D_Quadkey = QuadkeyBoundingBox2D(Quadkey(path));
                return boundingBox2D_Quadkey is null ? null : new SourceExtent(4326, boundingBox2D_Quadkey);
            }

            if (buildingDataset == BuildingDataset.Overture)
            {
                try
                {
                    using FileStream fileStream = new(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                    using ParquetReader parquetReader = await ParquetReader.CreateAsync(fileStream, new ParquetOptions(), false, cancellationToken);

                    GeoParquetMetadata geoParquetMetadata = Metadata_GeoParquet(path!, parquetReader);
                    if (geoParquetMetadata.BoundingBox2D is null || (geoParquetMetadata.Srid != 4326 && geoParquetMetadata.Srid != 3035))
                    {
                        return null;
                    }

                    return new SourceExtent(geoParquetMetadata.Srid, geoParquetMetadata.BoundingBox2D);
                }
                catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
                {
                    throw;
                }
                catch (Exception exception) when (exception is IOException || exception is InvalidDataException || exception is UnauthorizedAccessException || exception is NotSupportedException || exception is System.Text.Json.JsonException)
                {
                    return null;
                }
            }

            bool isGeoPackage = buildingDataset == BuildingDataset.Eubucco
                || buildingDataset == BuildingDataset.Dbsm
                || (buildingDataset == BuildingDataset.GhsObat && !path!.EndsWith(".csv", StringComparison.OrdinalIgnoreCase));

            if (!isGeoPackage)
            {
                return null;
            }

            try
            {
                SqliteConnectionStringBuilder sqliteConnectionStringBuilder = new()
                {
                    DataSource = path,
                    Mode = SqliteOpenMode.ReadOnly
                };

                using SqliteConnection sqliteConnection = new(sqliteConnectionStringBuilder.ConnectionString);
                await sqliteConnection.OpenAsync(cancellationToken);

                // Exactly one geometry table, as the reader requires when no table name is given (the import never gives one).
                List<(string TableName, string ColumnName, int Srid)> geometryColumns = [];
                using (SqliteCommand sqliteCommand = new("SELECT g.table_name, g.column_name, CASE WHEN UPPER(s.organization) = 'EPSG' THEN s.organization_coordsys_id ELSE g.srs_id END FROM gpkg_geometry_columns AS g INNER JOIN gpkg_spatial_ref_sys AS s ON g.srs_id = s.srs_id", sqliteConnection))
                {
                    using DbDataReader dbDataReader = await sqliteCommand.ExecuteReaderAsync(cancellationToken);
                    while (await dbDataReader.ReadAsync(cancellationToken))
                    {
                        geometryColumns.Add((dbDataReader.GetString(0), dbDataReader.GetString(1), System.Convert.ToInt32(dbDataReader.GetValue(2), CultureInfo.InvariantCulture)));
                    }
                }

                if (geometryColumns.Count != 1)
                {
                    return null;
                }

                (string tableName, string columnName, int srid) = geometryColumns[0];
                if (srid != 4326 && srid != 3035)
                {
                    return null;
                }

                // The index counts only while the extension that keeps it in step with the rows is registered for
                // this very column; an index left behind by a renamed table (DBSM R2025 carries one) is not it.
                const string commandText_Extension = "SELECT count(*) FROM sqlite_master WHERE type = 'table' AND name = 'gpkg_extensions'";
                using (SqliteCommand sqliteCommand = new(commandText_Extension, sqliteConnection))
                {
                    if (System.Convert.ToInt64(await sqliteCommand.ExecuteScalarAsync(cancellationToken), CultureInfo.InvariantCulture) == 0)
                    {
                        return null;
                    }
                }

                using (SqliteCommand sqliteCommand = new("SELECT count(*) FROM gpkg_extensions WHERE table_name = @table_name AND column_name = @column_name AND extension_name = 'gpkg_rtree_index'", sqliteConnection))
                {
                    sqliteCommand.Parameters.AddWithValue("@table_name", tableName);
                    sqliteCommand.Parameters.AddWithValue("@column_name", columnName);
                    if (System.Convert.ToInt64(await sqliteCommand.ExecuteScalarAsync(cancellationToken), CultureInfo.InvariantCulture) == 0)
                    {
                        return null;
                    }
                }

                string rtreeName = "rtree_" + tableName + "_" + columnName;
                using (SqliteCommand sqliteCommand = new("SELECT count(*) FROM sqlite_master WHERE type = 'table' AND name = @name", sqliteConnection))
                {
                    sqliteCommand.Parameters.AddWithValue("@name", rtreeName);
                    if (System.Convert.ToInt64(await sqliteCommand.ExecuteScalarAsync(cancellationToken), CultureInfo.InvariantCulture) == 0)
                    {
                        return null;
                    }
                }

                // The R-tree stores its boxes as 32-bit floats rounded outwards, so the extent can only be larger
                // than the rows' true one - never smaller.
                string quotedRtreeName = "\"" + rtreeName.Replace("\"", "\"\"") + "\"";
                using (SqliteCommand sqliteCommand = new($"SELECT min(minx), min(miny), max(maxx), max(maxy) FROM {quotedRtreeName}", sqliteConnection))
                {
                    using DbDataReader dbDataReader = await sqliteCommand.ExecuteReaderAsync(cancellationToken);
                    if (!await dbDataReader.ReadAsync(cancellationToken) || dbDataReader.IsDBNull(0) || dbDataReader.IsDBNull(1) || dbDataReader.IsDBNull(2) || dbDataReader.IsDBNull(3))
                    {
                        return null;
                    }

                    double minX = dbDataReader.GetDouble(0);
                    double minY = dbDataReader.GetDouble(1);
                    double maxX = dbDataReader.GetDouble(2);
                    double maxY = dbDataReader.GetDouble(3);

                    if (double.IsNaN(minX) || double.IsNaN(minY) || double.IsNaN(maxX) || double.IsNaN(maxY) || double.IsInfinity(minX) || double.IsInfinity(minY) || double.IsInfinity(maxX) || double.IsInfinity(maxY) || minX > maxX || minY > maxY)
                    {
                        return null;
                    }

                    return new SourceExtent(srid, new BoundingBox2D(new Point2D(minX, minY), new Point2D(maxX, maxY)));
                }
            }
            catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
            {
                throw;
            }
            catch (SqliteException)
            {
                return null;
            }
        }
    }
}
