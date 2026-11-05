using Parquet;
using Parquet.Schema;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.Json;

namespace DiGi.GIS.IO
{
    public static partial class Query
    {
        /// <summary>
        /// Parses the <c>geo</c> metadata of a GeoParquet file into the facts a read needs: the spatial reference identifier, the primary geometry column and the covering columns.
        /// <para>The identifier comes from <c>srs_id</c> when the writer supplies one, otherwise from the PROJJSON <c>crs.id</c> code, and a missing or null <c>crs</c> means the default of the format, CRS84 (EPSG:4326). A CRS that is present but carries no parseable identifier fails loudly: an unknown reference system can be neither validated against the supported set nor labelled honestly.</para>
        /// <para>Covering columns are resolved against the schema here as well, so a covering path that names a column absent from the file degrades to a full scan rather than to a crash mid-read.</para>
        /// </summary>
        /// <param name="path">The path of the file being read, used in exception messages.</param>
        /// <param name="parquetReader">The open reader supplying the custom metadata and schema.</param>
        /// <returns>The parsed metadata.</returns>
        /// <exception cref="InvalidDataException">Thrown when the file has no <c>geo</c> metadata, or a CRS that cannot be reduced to an identifier.</exception>
        private static GeoParquetMetadata Metadata_GeoParquet(string path, ParquetReader parquetReader)
        {
            static int? ParseIdentifier(JsonElement jsonElement)
            {
                if (jsonElement.ValueKind == JsonValueKind.Number && jsonElement.TryGetInt32(out int number))
                {
                    return number;
                }

                if (jsonElement.ValueKind == JsonValueKind.String)
                {
                    string? text = jsonElement.GetString();
                    if (!string.IsNullOrWhiteSpace(text) && int.TryParse(text, NumberStyles.Integer, CultureInfo.InvariantCulture, out int value))
                    {
                        return value;
                    }
                }

                return null;
            }

            static int? ParseCrsId(JsonElement idElement)
            {
                if (idElement.ValueKind == JsonValueKind.Object)
                {
                    // PROJJSON identifies a CRS with { "authority": "EPSG", "code": 4326 }; older variants used { "type": "Authority", "name": "EPSG", "code": 4326 } - both carry the code under "code".
                    return idElement.TryGetProperty("code", out JsonElement codeElement) ? ParseIdentifier(codeElement) : null;
                }

                if (idElement.ValueKind == JsonValueKind.String)
                {
                    string? text = idElement.GetString();
                    if (!string.IsNullOrWhiteSpace(text))
                    {
                        string identifierText = text!;
                        int index = identifierText.LastIndexOf(':');
                        string candidate = index >= 0 ? identifierText.Substring(index + 1) : identifierText;
                        if (int.TryParse(candidate, NumberStyles.Integer, CultureInfo.InvariantCulture, out int value))
                        {
                            return value;
                        }
                    }
                }

                return null;
            }

            static DataField? FindCoveringField(ParquetSchema parquetSchema, JsonElement bboxElement, string name)
            {
                if (!bboxElement.TryGetProperty(name, out JsonElement pathElement) || pathElement.ValueKind != JsonValueKind.Array)
                {
                    return null;
                }

                List<string> segments = [];
                foreach (JsonElement segmentElement in pathElement.EnumerateArray())
                {
                    if (segmentElement.ValueKind != JsonValueKind.String)
                    {
                        return null;
                    }

                    string? segment = segmentElement.GetString();
                    if (string.IsNullOrEmpty(segment))
                    {
                        return null;
                    }

                    segments.Add(segment!);
                }

                if (segments.Count == 0)
                {
                    return null;
                }

                try
                {
                    return parquetSchema.FindDataField(new FieldPath([.. segments]));
                }
                catch (ArgumentException)
                {
                    return null;
                }
            }

            if (!parquetReader.CustomMetadata.TryGetValue("geo", out string? geo) || string.IsNullOrWhiteSpace(geo))
            {
                throw new InvalidDataException($"File '{path}' carries no 'geo' metadata; it is not a GeoParquet file.");
            }

            using JsonDocument jsonDocument = JsonDocument.Parse(geo);
            JsonElement rootElement = jsonDocument.RootElement;

            string geometryColumn = "geometry";
            if (rootElement.TryGetProperty("primary_column", out JsonElement primaryColumnElement) && primaryColumnElement.ValueKind == JsonValueKind.String)
            {
                string? primaryColumn = primaryColumnElement.GetString();
                if (!string.IsNullOrWhiteSpace(primaryColumn))
                {
                    geometryColumn = primaryColumn!;
                }
            }

            int srid = 4326;
            JsonElement columnElement = default;
            bool hasColumn = rootElement.TryGetProperty("columns", out JsonElement columnsElement)
                && columnsElement.ValueKind == JsonValueKind.Object
                && columnsElement.TryGetProperty(geometryColumn, out columnElement);

            if (hasColumn)
            {
                if (columnElement.TryGetProperty("srs_id", out JsonElement srsIdElement))
                {
                    srid = ParseIdentifier(srsIdElement) ?? throw new InvalidDataException($"File '{path}' declares an unparsable 'srs_id' in its geo metadata.");
                }
                else if (columnElement.TryGetProperty("crs", out JsonElement crsElement) && crsElement.ValueKind == JsonValueKind.Object)
                {
                    if (!crsElement.TryGetProperty("id", out JsonElement idElement))
                    {
                        throw new InvalidDataException($"File '{path}' declares a CRS without an identifier in its geo metadata.");
                    }

                    srid = ParseCrsId(idElement) ?? throw new InvalidDataException($"File '{path}' declares an unparsable CRS identifier in its geo metadata.");
                }
            }

            DataField? coveringMinX = null;
            DataField? coveringMaxX = null;
            DataField? coveringMinY = null;
            DataField? coveringMaxY = null;

            if (hasColumn
                && columnElement.TryGetProperty("covering", out JsonElement coveringElement) && coveringElement.ValueKind == JsonValueKind.Object
                && coveringElement.TryGetProperty("bbox", out JsonElement bboxElement) && bboxElement.ValueKind == JsonValueKind.Object)
            {
                coveringMinX = FindCoveringField(parquetReader.Schema, bboxElement, "xmin");
                coveringMaxX = FindCoveringField(parquetReader.Schema, bboxElement, "xmax");
                coveringMinY = FindCoveringField(parquetReader.Schema, bboxElement, "ymin");
                coveringMaxY = FindCoveringField(parquetReader.Schema, bboxElement, "ymax");
            }

            return new GeoParquetMetadata(srid, geometryColumn, coveringMinX, coveringMaxX, coveringMinY, coveringMaxY);
        }
    }
}
