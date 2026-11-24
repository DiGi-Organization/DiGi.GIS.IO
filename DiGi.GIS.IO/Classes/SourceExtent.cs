using DiGi.Core.Classes;
using DiGi.Core.Interfaces;
using DiGi.Geometry.Planar.Classes;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.GIS.IO.Classes
{
    /// <summary>
    /// The area an open building source file can hold footprints in, as the file itself states it without being read row by row: a bounding box in the file's own coordinate reference system (DiGi-Organization/DiGi.GIS.PostgreSQL#170).
    /// <para>Like a <see cref="Footprint"/>, the box is never converted: <see cref="Srid"/> states the reference system it is expressed in, and a caller comparing it with an area in another system transforms explicitly. An extent is an envelope of the footprints, not of the footprints' area, so a caller testing it against a scope must allow for the footprints that reach a little beyond it (the Microsoft tile a building is filed under need not contain the whole building).</para>
    /// </summary>
    public class SourceExtent : SerializableObject
    {
        [JsonInclude, JsonPropertyName("Srid")]
        private readonly int srid;

        [JsonInclude, JsonPropertyName("BoundingBox2D")]
        private readonly BoundingBox2D? boundingBox2D;

        /// <summary>
        /// Initializes a new instance of the <see cref="SourceExtent"/> class.
        /// </summary>
        /// <param name="srid">The spatial reference identifier the bounding box is expressed in.</param>
        /// <param name="boundingBox2D">The bounding box of the file's footprints in that reference system.</param>
        public SourceExtent(int srid, BoundingBox2D? boundingBox2D)
        {
            this.srid = srid;
            this.boundingBox2D = boundingBox2D;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SourceExtent"/> class by copying another instance.
        /// </summary>
        /// <param name="sourceExtent">The source extent to copy from.</param>
        public SourceExtent(SourceExtent? sourceExtent)
            : base(sourceExtent)
        {
            if (sourceExtent != null)
            {
                srid = sourceExtent.srid;
                boundingBox2D = Core.Query.Clone(sourceExtent.boundingBox2D);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SourceExtent"/> class from a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the extent data.</param>
        public SourceExtent(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Creates a deep copy of this <see cref="SourceExtent"/> instance.
        /// </summary>
        /// <returns>A new <see cref="SourceExtent"/> instance with the same data.</returns>
        public override ISerializableObject? Clone()
        {
            return new SourceExtent(this);
        }

        /// <summary>
        /// Gets the spatial reference identifier the bounding box is expressed in.
        /// </summary>
        [JsonIgnore]
        public int Srid
        {
            get
            {
                return srid;
            }
        }

        /// <summary>
        /// Gets the bounding box of the file's footprints in the reference system of <see cref="Srid"/>.
        /// </summary>
        [JsonIgnore]
        public BoundingBox2D? BoundingBox2D
        {
            get
            {
                return boundingBox2D;
            }
        }
    }
}
