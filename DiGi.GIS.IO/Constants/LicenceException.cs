namespace DiGi.GIS.IO.Constants
{
    /// <summary>
    /// Provides the regional licence exceptions that apply on top of the EUBUCCO ODbL licence.
    /// </summary>
    public static class LicenceException
    {
        /// <summary>
        /// Share-Alike exception flagged on EUBUCCO rows whose geometry comes from the Prague government source.
        /// </summary>
        public const string ShareAlike = "CC-BY-SA";

        /// <summary>
        /// Non-Commercial exception flagged on EUBUCCO rows whose geometry comes from the Abruzzo government source.
        /// </summary>
        public const string NonCommercial = "CC-BY-NC";
    }
}
