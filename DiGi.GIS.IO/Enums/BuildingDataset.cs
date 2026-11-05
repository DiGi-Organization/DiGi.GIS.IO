using System.ComponentModel;

namespace DiGi.GIS.IO.Enums
{
    /// <summary>
    /// Identifies an open building dataset read by the DiGi.GIS.IO streaming readers.
    /// <para>The values match the <c>dataset_key</c> vocabulary of the building_dataset release register (DiGi-Organization/DiGi.GIS.PostgreSQL#125) so the reader-side and register-side names cannot drift. OpenStreetMap is deliberately absent: its PBF reader lives in DiGi.OSM (DiGi-Organization/DiGi.OSM#1).</para>
    /// </summary>
    public enum BuildingDataset
    {
        /// <summary>
        /// EUBUCCO v0.2 building footprints, GeoPackage, EPSG:3035.
        /// </summary>
        [Description("eubucco")]
        Eubucco,

        /// <summary>
        /// Overture Maps Buildings release, GeoParquet, EPSG:4326.
        /// </summary>
        [Description("overture")]
        Overture,

        /// <summary>
        /// JRC DBSM R2025 settlement layer, GeoPackage.
        /// </summary>
        [Description("dbsm")]
        Dbsm,

        /// <summary>
        /// Microsoft Global ML Building Footprints, line-delimited GeoJSON in gzip, EPSG:4326.
        /// </summary>
        [Description("microsoft")]
        Microsoft,

        /// <summary>
        /// GHS-OBAT R2024A building attribute table: GPKG centroids and the CSV attribute table, EPSG:4326.
        /// </summary>
        [Description("ghs_obat")]
        GhsObat
    }
}
