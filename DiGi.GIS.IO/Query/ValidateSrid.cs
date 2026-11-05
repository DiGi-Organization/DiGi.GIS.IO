using System;

namespace DiGi.GIS.IO
{
    public static partial class Query
    {
        /// <summary>
        /// Throws when a source file declares a spatial reference identifier outside the supported set (EPSG:4326, EPSG:3035).
        /// <para>Readers return footprints in the source coordinate reference system, so anything outside the two supported identifiers cannot be labelled honestly: failing loudly at enumeration start names the file, the identifier found and the set accepted, instead of silently reinterpreting coordinates that were never converted.</para>
        /// </summary>
        /// <param name="srid">The spatial reference identifier declared by the file.</param>
        /// <param name="path">The path of the file being read, used in the exception message.</param>
        /// <exception cref="System.NotSupportedException">Thrown when the identifier is neither 4326 nor 3035.</exception>
        private static void ValidateSrid(int srid, string path)
        {
            if (srid == 4326 || srid == 3035)
            {
                return;
            }

            throw new NotSupportedException($"File '{path}' declares SRID {srid}; only 4326 and 3035 are supported.");
        }
    }
}
