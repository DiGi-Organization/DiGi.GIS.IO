using System;

namespace DiGi.GIS.IO
{
    public static partial class Query
    {
        /// <summary>
        /// Returns the regional licence exception that applies to an EUBUCCO geometry_source value, or null when the source carries none.
        /// <para>The two flagged sources are Prague (CC-BY-SA, share-alike) and Abruzzo (CC-BY-NC, non-commercial); every other source stays under the plain ODbL licence. The lookup is a comparison rather than a filter so a flagged row travels on with its exception attached instead of being dropped from a read.</para>
        /// </summary>
        /// <param name="geometrySource">The geometry_source column value, or null.</param>
        /// <returns>The licence exception string, or null when no exception applies.</returns>
        private static string? LicenceException(string? geometrySource)
        {
            if (string.IsNullOrWhiteSpace(geometrySource))
            {
                return null;
            }

            if (string.Equals(geometrySource, Constants.GeometrySource.GovCzechiaPrague, StringComparison.OrdinalIgnoreCase))
            {
                return Constants.LicenceException.ShareAlike;
            }

            if (string.Equals(geometrySource, Constants.GeometrySource.GovItalyAbruzzo, StringComparison.OrdinalIgnoreCase))
            {
                return Constants.LicenceException.NonCommercial;
            }

            return null;
        }
    }
}
