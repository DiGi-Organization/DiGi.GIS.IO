using DiGi.GIS.IO.Enums;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace DiGi.GIS.IO
{
    public static partial class Query
    {
        /// <summary>
        /// Builds the per-object provenance for a row from its attribute bag, in the shape the building_dataset release register expects (DiGi-Organization/DiGi.GIS.PostgreSQL#125).
        /// <para>Each dataset states its geometry origin differently: EUBUCCO carries every column whose name contains <c>_source</c>; DBSM carries the <c>source</c> column plus its per-source link columns - <c>eub_data</c>, <c>osm_data</c> and <c>msb_data</c> in R2025 - and the older <c>eub_json</c> link blob, parsed to an object when it parses and kept as raw text otherwise; GHS-OBAT links through the Overture identifier, exposed under the single key <c>overture_id</c> whether the source column is named <c>overture_id</c> or <c>id</c>; Overture carries <c>id</c> and the full <c>sources</c> array; Microsoft features carry no origin at all, so the quadkey the file was fetched under plus any <c>capture</c> properties stand in as provenance.</para>
        /// <para>The attribute bag keeps every column as well: provenance is an additional view, not a move, so no consumer loses a column by this method running.</para>
        /// </summary>
        /// <param name="buildingDataset">The dataset being read.</param>
        /// <param name="attributes">The attribute bag built from the source row, or null.</param>
        /// <param name="quadkey">The quadkey a Microsoft line-delimited GeoJSON file was fetched under; used only for that dataset.</param>
        /// <returns>The provenance object, or null when the row carries nothing provenance-worthy.</returns>
        private static JsonObject? Provenance(BuildingDataset buildingDataset, JsonObject? attributes, string? quadkey)
        {
            static JsonNode? ParseEubJson(string text)
            {
                try
                {
                    return JsonNode.Parse(text);
                }
                catch (JsonException)
                {
                    return JsonValue.Create(text);
                }
            }

            JsonObject result = new();

            switch (buildingDataset)
            {
                case BuildingDataset.Eubucco:
                    if (attributes != null)
                    {
                        foreach (KeyValuePair<string, JsonNode?> pair in attributes)
                        {
                            if (pair.Key.IndexOf("_source", StringComparison.OrdinalIgnoreCase) >= 0)
                            {
                                result[pair.Key] = pair.Value?.DeepClone();
                            }
                        }
                    }
                    break;

                case BuildingDataset.Dbsm:
                    if (attributes != null)
                    {
                        if (attributes.TryGetPropertyValue("source", out JsonNode? source) && source != null)
                        {
                            result["source"] = source.DeepClone();
                        }

                        // DBSM R2025 carries its per-source links as eub_data / osm_data / msb_data
                        // (DiGi-Organization/DiGi.GIS.PostgreSQL#133); older releases used eub_json.
                        string[] keys_Data = ["eub_data", "osm_data", "msb_data"];
                        foreach (string key in keys_Data)
                        {
                            if (attributes.TryGetPropertyValue(key, out JsonNode? data) && data != null)
                            {
                                result[key] = data.DeepClone();
                            }
                        }

                        if (attributes.TryGetPropertyValue("eub_json", out JsonNode? eubJson) && eubJson != null)
                        {
                            result["eub_json"] = eubJson is JsonValue jsonValue && jsonValue.TryGetValue<string>(out string? text) && text != null
                                ? ParseEubJson(text)
                                : eubJson.DeepClone();
                        }
                    }
                    break;

                case BuildingDataset.GhsObat:
                    if (attributes != null)
                    {
                        string key = attributes.ContainsKey("overture_id") ? "overture_id" : "id";
                        if (attributes.TryGetPropertyValue(key, out JsonNode? overtureId) && overtureId != null)
                        {
                            result["overture_id"] = overtureId.DeepClone();
                        }
                    }
                    break;

                case BuildingDataset.Overture:
                    if (attributes != null)
                    {
                        if (attributes.TryGetPropertyValue("id", out JsonNode? id) && id != null)
                        {
                            result["id"] = id.DeepClone();
                        }

                        if (attributes.TryGetPropertyValue("sources", out JsonNode? sources) && sources != null)
                        {
                            result["sources"] = sources.DeepClone();
                        }
                    }
                    break;

                case BuildingDataset.Microsoft:
                    if (!string.IsNullOrWhiteSpace(quadkey))
                    {
                        result["quadkey"] = quadkey;
                    }

                    if (attributes != null)
                    {
                        foreach (KeyValuePair<string, JsonNode?> pair in attributes)
                        {
                            if (pair.Key.StartsWith("capture", StringComparison.OrdinalIgnoreCase))
                            {
                                result[pair.Key] = pair.Value?.DeepClone();
                            }
                        }
                    }
                    break;
            }

            return result.Count == 0 ? null : result;
        }
    }
}
