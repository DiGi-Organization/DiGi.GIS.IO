using System.Text.Json.Nodes;

namespace DiGi.GIS.IO
{
    public static partial class Query
    {
        /// <summary>
        /// The source columns tried, in order, when deriving a source identifier from a row.
        /// </summary>
        private static readonly string[] sourceIdKeys = ["id", "overture_id", "unique_id", "fid"];

        /// <summary>
        /// Returns the source identifier for a row from its attribute bag, trying the columns the open building datasets use, in order.
        /// <para>The chain covers <c>id</c> (EUBUCCO, Overture, GHS-OBAT), <c>overture_id</c> (GHS-OBAT variants keyed on the Overture identifier), <c>unique_id</c> (DBSM R2025, which has no <c>id</c> - DiGi-Organization/DiGi.GIS.PostgreSQL#133) and <c>fid</c> (GeoPackage feature tables; the file's row number, the last resort). Microsoft features carry no identifier at all, so that reader synthesizes one instead of calling this method.</para>
        /// </summary>
        /// <param name="attributes">The attribute bag built from the source row.</param>
        /// <returns>The identifier as text, or null when the row carries none of the columns.</returns>
        private static string? SourceId(JsonObject? attributes)
        {
            if (attributes == null)
            {
                return null;
            }

            foreach (string key in sourceIdKeys)
            {
                if (!attributes.TryGetPropertyValue(key, out JsonNode? jsonNode) || jsonNode == null)
                {
                    continue;
                }

                if (jsonNode is JsonValue jsonValue)
                {
                    if (jsonValue.TryGetValue<string>(out string? text))
                    {
                        return text;
                    }

                    return jsonValue.ToJsonString();
                }

                return jsonNode.ToJsonString();
            }

            return null;
        }
    }
}
