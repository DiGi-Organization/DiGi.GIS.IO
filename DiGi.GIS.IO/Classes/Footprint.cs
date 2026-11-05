using DiGi.Core.Classes;
using DiGi.Core.Interfaces;
using DiGi.Geometry.Planar.Interfaces;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.GIS.IO.Classes
{
    /// <summary>
    /// One building footprint read from an open building dataset, carrying the source identifier, the source coordinate reference system, the full source attributes and the per-object provenance.
    /// <para>The readers never convert the source geometry and never renumber the source identifiers: <see cref="SourceSrid"/> states the coordinate reference system the geometry is expressed in, so a footprint read from an EPSG:3035 file stays in EPSG:3035 and one read from an EPSG:4326 file stays in EPSG:4326. A caller that needs a common coordinate reference system transforms explicitly.</para>
    /// <para><see cref="Attributes"/> holds every source column verbatim, including columns that also appear in <see cref="Provenance"/>. <see cref="Provenance"/> holds the subset that states where the geometry came from, in the shape the building_dataset release register expects (DiGi-Organization/DiGi.GIS.PostgreSQL#125), so provenance travels with the object instead of being re-derived from the dataset name later.</para>
    /// <para><see cref="LicenceException"/> is set only for EUBUCCO rows whose <c>geometry_source</c> carries a regional licence exception (Prague, Abruzzo). Such rows are flagged, never dropped, so a country file reads back at full row count while a consumer can still filter down to the ODbL-only subset.</para>
    /// </summary>
    public class Footprint : SerializableObject
    {
        [JsonInclude, JsonPropertyName("SourceId")]
        private readonly string? sourceId;

        [JsonInclude, JsonPropertyName("SourceSrid")]
        private readonly int sourceSrid;

        [JsonInclude, JsonPropertyName("Geometry")]
        private readonly IGeometry2D? geometry;

        // The attribute and provenance bags are held as SerializableObjectWrapper rather than JsonObject: a JsonObject member is written by the serializer as a Key/Value pair array and reads back empty, while the wrapper passes the raw JSON through unchanged, so numbers stay numbers and nested arrays stay arrays across a round trip.
        [JsonInclude, JsonPropertyName("Attributes")]
        private readonly SerializableObjectWrapper? attributes;

        [JsonInclude, JsonPropertyName("Provenance")]
        private readonly SerializableObjectWrapper? provenance;

        [JsonInclude, JsonPropertyName("LicenceException")]
        private readonly string? licenceException;

        /// <summary>
        /// Initializes a new instance of the <see cref="Footprint"/> class.
        /// </summary>
        /// <param name="sourceId">The identifier the source dataset gives the footprint, or a synthesized one when the source gives none (Microsoft).</param>
        /// <param name="sourceSrid">The spatial reference identifier the geometry is expressed in.</param>
        /// <param name="geometry">The footprint geometry in the source coordinate reference system, or null when the source row has none.</param>
        /// <param name="attributes">All source attributes, or null when the source row has none.</param>
        /// <param name="provenance">Per-object provenance, or null when the dataset defines none.</param>
        /// <param name="licenceException">The regional licence exception flagged on the row, or null when none applies.</param>
        public Footprint(string? sourceId, int sourceSrid, IGeometry2D? geometry, JsonObject? attributes, JsonObject? provenance, string? licenceException)
        {
            this.sourceId = sourceId;
            this.sourceSrid = sourceSrid;
            this.geometry = geometry;
            this.attributes = attributes == null ? null : new SerializableObjectWrapper(attributes);
            this.provenance = provenance == null ? null : new SerializableObjectWrapper(provenance);
            this.licenceException = licenceException;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Footprint"/> class by copying another instance.
        /// </summary>
        /// <param name="footprint">The source footprint to copy from.</param>
        public Footprint(Footprint? footprint)
            : base(footprint)
        {
            if (footprint != null)
            {
                sourceId = footprint.sourceId;
                sourceSrid = footprint.sourceSrid;
                geometry = Core.Query.Clone(footprint.geometry);
                attributes = footprint.attributes == null ? null : new SerializableObjectWrapper(footprint.attributes);
                provenance = footprint.provenance == null ? null : new SerializableObjectWrapper(footprint.provenance);
                licenceException = footprint.licenceException;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Footprint"/> class from a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the footprint data.</param>
        public Footprint(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Creates a deep copy of this <see cref="Footprint"/> instance.
        /// </summary>
        /// <returns>A new <see cref="Footprint"/> instance with the same data, or null if cloning fails.</returns>
        public override ISerializableObject? Clone()
        {
            return new Footprint(this);
        }

        /// <summary>
        /// Gets the identifier the source dataset gives the footprint, or the synthesized one when the source gives none.
        /// </summary>
        [JsonIgnore]
        public string? SourceId
        {
            get
            {
                return sourceId;
            }
        }

        /// <summary>
        /// Gets the spatial reference identifier the geometry is expressed in.
        /// </summary>
        [JsonIgnore]
        public int SourceSrid
        {
            get
            {
                return sourceSrid;
            }
        }

        /// <summary>
        /// Gets the footprint geometry in the source coordinate reference system, or null when the source row has none.
        /// </summary>
        [JsonIgnore]
        public IGeometry2D? Geometry
        {
            get
            {
                return geometry;
            }
        }

        /// <summary>
        /// Gets a deep copy of all source attributes, keyed by source column name.
        /// </summary>
        [JsonIgnore]
        public JsonObject? Attributes
        {
            get
            {
                return attributes?.ToJsonObject();
            }
        }

        /// <summary>
        /// Gets a deep copy of the per-object provenance, or null when the dataset defines none.
        /// </summary>
        [JsonIgnore]
        public JsonObject? Provenance
        {
            get
            {
                return provenance?.ToJsonObject();
            }
        }

        /// <summary>
        /// Gets the regional licence exception flagged on the row (CC-BY-SA for Prague, CC-BY-NC for Abruzzo), or null when none applies.
        /// </summary>
        [JsonIgnore]
        public string? LicenceException
        {
            get
            {
                return licenceException;
            }
        }
    }
}
