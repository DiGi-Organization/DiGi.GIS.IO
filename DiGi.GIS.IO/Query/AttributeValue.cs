using System;
using System.Globalization;
using System.Text.Json.Nodes;

namespace DiGi.GIS.IO
{
    public static partial class Query
    {
        /// <summary>
        /// Converts a raw column value read from a source file into a <see cref="JsonNode"/> for the attribute bag, preserving the value's JSON type.
        /// <para>Numeric columns stay numbers and boolean columns stay booleans so a round trip through the serializer compares equal; binary columns become base64 text because JSON has no byte type. Text is kept as text even when it looks numeric - identifiers such as 32-hex GERS ids would otherwise be corrupted by a numeric parse.</para>
        /// </summary>
        /// <param name="value">The raw column value, or null for a null column.</param>
        /// <returns>The value as a <see cref="JsonNode"/>, or null when the column is null.</returns>
        private static JsonNode? AttributeValue(object? value)
        {
            static DateTimeOffset ToDateTimeOffset(DateTime dateTime)
            {
                // Parquet timestamps are UTC by specification; an Unspecified kind is treated as UTC rather than local so the same file reads back identically in any timezone.
                return dateTime.Kind == DateTimeKind.Unspecified ? new DateTimeOffset(DateTime.SpecifyKind(dateTime, DateTimeKind.Utc)) : new DateTimeOffset(dateTime);
            }

            return value switch
            {
                null => null,
                JsonValue jsonValue => jsonValue,
                string text => JsonValue.Create(text),
                bool boolean => JsonValue.Create(boolean),
                long integer => JsonValue.Create(integer),
                int integer32 => JsonValue.Create((long)integer32),
                double real => JsonValue.Create(real),
                float single => JsonValue.Create((double)single),
                decimal decimalNumber => JsonValue.Create(decimalNumber),
                byte[] bytes => JsonValue.Create(System.Convert.ToBase64String(bytes)),
                DateTime dateTime => JsonValue.Create(ToDateTimeOffset(dateTime)),
                DateTimeOffset dateTimeOffset => JsonValue.Create(dateTimeOffset),
                _ => JsonValue.Create(value.ToString())
            };
        }
    }
}
