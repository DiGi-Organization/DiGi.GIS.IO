using DiGi.GIS.IO.Classes;
using DiGi.GIS.IO.Enums;
using DiGi.Geometry.Planar.Classes;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using Parquet;
using Parquet.Data;
using Parquet.Schema;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json.Nodes;
using System.Threading;

namespace DiGi.GIS.IO
{
    public static partial class Query
    {
        /// <summary>
        /// Streams building footprints from a GeoParquet file (Overture Buildings) as an asynchronous sequence, returning each footprint in the file's own coordinate reference system.
        /// <para>The file is walked one row group at a time and never materialised as a whole. When a bounding box is given and the file carries a <c>covering.bbox</c>, the read is pruned with the row group's footer statistics on the covering columns: a group judged disjoint is never opened or decompressed. The row-level filter still runs on the decoded geometry envelope, so a corrupt geometry sitting in a pruned group never gets decoded - and the same file read without a bounding box fails loudly instead of hiding it.</para>
        /// <para>The spatial reference identifier comes from the <c>geo</c> metadata (<c>srs_id</c>, else the PROJJSON CRS code, else the format default of 4326) and is validated at enumeration start. Every column becomes an entry in <see cref="Footprint.Attributes"/> except the geometry column and the covering columns, which are derived rather than source data; repeated columns such as Overture's <c>sources</c> are grouped back into JSON arrays row by row.</para>
        /// </summary>
        /// <param name="path">The path of the GeoParquet file, or null or whitespace to return null.</param>
        /// <param name="buildingDataset">The dataset the file holds; Overture.</param>
        /// <param name="boundingBox">An optional bounding box, in the file's coordinate reference system, that footprints must intersect.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The streaming sequence, or null when <paramref name="path"/> is null or whitespace.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="buildingDataset"/> is not Overture.</exception>
        /// <exception cref="NotSupportedException">Thrown at enumeration start when the file declares an SRID other than 4326 or 3035.</exception>
        /// <exception cref="InvalidDataException">Thrown when the file carries no <c>geo</c> metadata, declares an unparsable CRS, or has no geometry column.</exception>
        public static IAsyncEnumerable<Footprint>? Footprints_GeoParquetAsync(string? path, BuildingDataset buildingDataset, BoundingBox2D? boundingBox = null, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                return null;
            }

            if (buildingDataset != BuildingDataset.Overture)
            {
                throw new ArgumentException($"The GeoParquet reader reads Overture; got {buildingDataset}.", nameof(buildingDataset));
            }

            return Footprints_GeoParquet_Iterator(path!, buildingDataset, boundingBox, cancellationToken);
        }

        /// <summary>
        /// Walks a GeoParquet file row group by row group, yielding one <see cref="Footprint"/> per row.
        /// </summary>
        /// <param name="path">The path of the GeoParquet file.</param>
        /// <param name="buildingDataset">The dataset the file holds.</param>
        /// <param name="boundingBox">An optional bounding box, in the file's coordinate reference system.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The streaming sequence.</returns>
        private static async IAsyncEnumerable<Footprint> Footprints_GeoParquet_Iterator(string path, BuildingDataset buildingDataset, BoundingBox2D? boundingBox, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            using FileStream fileStream = new(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            using ParquetReader parquetReader = await ParquetReader.CreateAsync(fileStream, new ParquetOptions(), false, cancellationToken);

            GeoParquetMetadata geoParquetMetadata = Metadata_GeoParquet(path, parquetReader);
            ValidateSrid(geoParquetMetadata.Srid, path);

            DataField? geometryField = null;
            foreach (DataField dataField in parquetReader.Schema.GetDataFields())
            {
                if (dataField.MaxRepetitionLevel == 0 && string.Equals(dataField.Name, geoParquetMetadata.GeometryColumn, StringComparison.Ordinal))
                {
                    geometryField = dataField;
                    break;
                }
            }

            if (geometryField == null)
            {
                throw new InvalidDataException($"File '{path}' has no geometry column named '{geoParquetMetadata.GeometryColumn}'.");
            }

            string geometryFieldPath = geometryField.Path.ToString();
            HashSet<string> excludedPaths = [geometryFieldPath];
            if (geoParquetMetadata.HasCovering)
            {
                excludedPaths.Add(geoParquetMetadata.CoveringMinX!.Path.ToString());
                excludedPaths.Add(geoParquetMetadata.CoveringMaxX!.Path.ToString());
                excludedPaths.Add(geoParquetMetadata.CoveringMinY!.Path.ToString());
                excludedPaths.Add(geoParquetMetadata.CoveringMaxY!.Path.ToString());
            }

            WKBReader wkbReader = new();

            for (int rowGroupIndex = 0; rowGroupIndex < parquetReader.RowGroupCount; rowGroupIndex++)
            {
                cancellationToken.ThrowIfCancellationRequested();

                if (boundingBox != null)
                {
                    using ParquetRowGroupReader parquetRowGroupReader = parquetReader.OpenRowGroupReader(rowGroupIndex);
                    if (!RowGroup_InRange(parquetRowGroupReader, geoParquetMetadata.CoveringMinX, geoParquetMetadata.CoveringMaxX, geoParquetMetadata.CoveringMinY, geoParquetMetadata.CoveringMaxY, boundingBox))
                    {
                        continue;
                    }
                }

                DataColumn[] dataColumns = await parquetReader.ReadEntireRowGroupAsync(rowGroupIndex, cancellationToken);

                DataColumn? geometryColumn = null;
                List<DataColumn> scalarColumns = [];
                List<(string key, List<DataColumn> leaves)> listGroups = [];

                foreach (DataColumn dataColumn in dataColumns)
                {
                    DataField field = dataColumn.Field;
                    string fieldPath = field.Path.ToString();

                    if (string.Equals(fieldPath, geometryFieldPath, StringComparison.Ordinal))
                    {
                        geometryColumn = dataColumn;
                        continue;
                    }

                    if (excludedPaths.Contains(fieldPath))
                    {
                        continue;
                    }

                    if (field.MaxRepetitionLevel > 0)
                    {
                        string key = field.Path[0];
                        int groupIndex = -1;
                        for (int i = 0; i < listGroups.Count; i++)
                        {
                            if (string.Equals(listGroups[i].key, key, StringComparison.Ordinal))
                            {
                                groupIndex = i;
                                break;
                            }
                        }

                        if (groupIndex < 0)
                        {
                            listGroups.Add((key, [dataColumn]));
                        }
                        else
                        {
                            listGroups[groupIndex].leaves.Add(dataColumn);
                        }
                    }
                    else
                    {
                        scalarColumns.Add(dataColumn);
                    }
                }

                if (geometryColumn == null)
                {
                    throw new InvalidDataException($"Row group {rowGroupIndex} of '{path}' carries no geometry column data.");
                }

                // Row boundaries for repeated columns: each group's starts array maps a row index to its first list entry, with one sentinel entry past the last row. Rows whose list is empty have a zero-width span.
                List<(string key, List<DataColumn> leaves, int[] rowStarts)> groups = [];
                foreach ((string key, List<DataColumn> leaves) in listGroups)
                {
                    DataColumn boundaryColumn = leaves[0];
                    int[]? repetitionLevels = boundaryColumn.RepetitionLevels;
                    List<int> starts = [];
                    if (repetitionLevels != null)
                    {
                        for (int level = 0; level < repetitionLevels.Length; level++)
                        {
                            if (repetitionLevels[level] == 0)
                            {
                                starts.Add(level);
                            }
                        }
                    }

                    starts.Add(boundaryColumn.Data.Length);
                    groups.Add((key, leaves, [.. starts]));
                }

                int rowCount = geometryColumn.Data.Length;

                for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                {
                    if (geometryColumn.Data.GetValue(rowIndex) is not byte[] wkb)
                    {
                        throw new InvalidDataException($"Row {rowIndex} of row group {rowGroupIndex} in '{path}' carries no geometry.");
                    }

                    NetTopologySuite.Geometries.Geometry geometry = wkbReader.Read(wkb);

                    if (boundingBox != null)
                    {
                        Envelope envelope = geometry.EnvelopeInternal;
                        BoundingBox2D geometryBoundingBox = new(new Point2D(envelope.MinX, envelope.MinY), new Point2D(envelope.MaxX, envelope.MaxY));
                        if (!boundingBox.InRange(geometryBoundingBox))
                        {
                            continue;
                        }
                    }

                    JsonObject attributes = new();

                    foreach (DataColumn dataColumn in scalarColumns)
                    {
                        DataField field = dataColumn.Field;
                        JsonNode? jsonNode = AttributeValue(dataColumn.Data.GetValue(rowIndex));

                        if (field.Path.Length == 1)
                        {
                            attributes[field.Name] = jsonNode;
                        }
                        else
                        {
                            JsonObject current = attributes;
                            for (int level = 0; level < field.Path.Length - 1; level++)
                            {
                                if (current[field.Path[level]] is not JsonObject nested)
                                {
                                    nested = new JsonObject();
                                    current[field.Path[level]] = nested;
                                }

                                current = nested;
                            }

                            current[field.Name] = jsonNode;
                        }
                    }

                    foreach ((string key, List<DataColumn> leaves, int[] rowStarts) in groups)
                    {
                        int entryCount = leaves[0].Data.Length;
                        int start = rowIndex < rowStarts.Length ? rowStarts[rowIndex] : entryCount;
                        int end = rowIndex + 1 < rowStarts.Length ? rowStarts[rowIndex + 1] : entryCount;
                        if (end <= start)
                        {
                            continue;
                        }

                        JsonArray? jsonArray = null;
                        for (int entry = start; entry < end; entry++)
                        {
                            JsonObject item = new();
                            bool present = false;
                            foreach (DataColumn leaf in leaves)
                            {
                                if (entry >= leaf.Data.Length)
                                {
                                    continue;
                                }

                                int[]? definitionLevels = leaf.DefinitionLevels;
                                if (definitionLevels != null && entry < definitionLevels.Length && definitionLevels[entry] != leaf.Field.MaxDefinitionLevel)
                                {
                                    continue;
                                }

                                item[leaf.Field.Name] = AttributeValue(leaf.Data.GetValue(entry));
                                present = true;
                            }

                            if (present)
                            {
                                jsonArray ??= new JsonArray();
                                jsonArray.Add(item);
                            }
                        }

                        if (jsonArray != null)
                        {
                            attributes[key] = jsonArray;
                        }
                    }

                    yield return new Footprint(SourceId(attributes), geoParquetMetadata.Srid, DiGi.Geometry.Planar.Convert.ToDiGi(geometry), attributes, Provenance(buildingDataset, attributes, null), null);
                }
            }
        }
    }
}
