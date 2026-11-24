using DiGi.Geometry.Planar.Classes;
using System;

namespace DiGi.GIS.IO
{
    public static partial class Query
    {
        /// <summary>
        /// Computes the area a Bing Maps quadkey tile covers - the tile a Microsoft Global ML Building Footprints chunk is published under - as a bounding box in EPSG:4326, longitude in X and latitude in Y (DiGi-Organization/DiGi.GIS.PostgreSQL#170).
        /// <para>Each digit halves the tile of the previous level in both directions (0 north-west, 1 north-east, 2 south-west, 3 south-east), so the quadkey's length is its level of detail. The edges follow the Web Mercator tiling: longitudes are linear, latitudes are the inverse Mercator of the tile's row. The box is the tile, not the buildings: Microsoft files a building under the tile its geometry falls in, and a building can reach a little beyond that tile's edge.</para>
        /// </summary>
        /// <param name="quadkey">The quadkey: digits 0-3 only, at least one and at most 30 of them (the level the integer tile arithmetic carries exactly).</param>
        /// <returns>The tile's bounding box in EPSG:4326, or null when <paramref name="quadkey"/> is null, empty, longer than 30 digits or holds a character other than 0-3.</returns>
        public static BoundingBox2D? QuadkeyBoundingBox2D(string? quadkey)
        {
            if (string.IsNullOrEmpty(quadkey) || quadkey!.Length > 30)
            {
                return null;
            }

            long x = 0;
            long y = 0;

            foreach (char @char in quadkey)
            {
                if (@char < '0' || @char > '3')
                {
                    return null;
                }

                int digit = @char - '0';

                x = (x << 1) | (long)(digit & 1);
                y = (y << 1) | (long)((digit >> 1) & 1);
            }

            double count = Math.Pow(2, quadkey.Length);

            double longitude_Min = (x / count * 360.0) - 180.0;
            double longitude_Max = ((x + 1) / count * 360.0) - 180.0;

            // Row y counts from the north, so its top edge is the larger latitude.
            double latitude_Max = Math.Atan(Math.Sinh(Math.PI * (1 - (2 * y / count)))) * 180.0 / Math.PI;
            double latitude_Min = Math.Atan(Math.Sinh(Math.PI * (1 - (2 * (y + 1) / count)))) * 180.0 / Math.PI;

            return new BoundingBox2D(new Point2D(longitude_Min, latitude_Min), new Point2D(longitude_Max, latitude_Max));
        }
    }
}
