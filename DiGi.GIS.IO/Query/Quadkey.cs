using System;

namespace DiGi.GIS.IO
{
    public static partial class Query
    {
        /// <summary>
        /// Reads the quadkey a Microsoft Global ML Building Footprints chunk was published under from its path - the <c>quadkey=&lt;digits&gt;</c> directory segment of Microsoft's own layout (<c>…/RegionName=Poland/quadkey=120213101/part-….csv.gz</c>) - so a run over several chunks can identify each file by its own quadkey (DiGi-Organization/DiGi.GIS.PostgreSQL#132).
        /// <para>Only a directory segment counts, never the file name, and the innermost one wins when a path nests several. A segment whose value is not made of the quadkey digits 0-3 is not a quadkey and yields null rather than a wrong source identity.</para>
        /// </summary>
        /// <param name="path">The file path, with Windows or POSIX separators, or null.</param>
        /// <returns>The quadkey, or null when the path carries no valid <c>quadkey=</c> directory segment.</returns>
        public static string? Quadkey(string? path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                return null;
            }

            string[] segments = path!.Split(['\\', '/'], StringSplitOptions.RemoveEmptyEntries);

            // The last segment is the file itself; walk the directories innermost-outwards.
            for (int i = segments.Length - 2; i >= 0; i--)
            {
                string segment = segments[i];
                if (!segment.StartsWith("quadkey=", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                string value = segment.Substring("quadkey=".Length);
                if (value.Length == 0)
                {
                    return null;
                }

                foreach (char @char in value)
                {
                    if (@char < '0' || @char > '3')
                    {
                        return null;
                    }
                }

                return value;
            }

            return null;
        }
    }
}
