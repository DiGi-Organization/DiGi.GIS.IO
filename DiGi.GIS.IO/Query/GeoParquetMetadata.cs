using DiGi.Geometry.Planar.Classes;
using Parquet.Schema;

namespace DiGi.GIS.IO
{
    public static partial class Query
    {
        /// <summary>
        /// The file-level GeoParquet facts a read needs in one place: the spatial reference identifier, the primary geometry column, the covering columns resolved against the schema for row-group pruning, and the column's declared bounding box.
        /// </summary>
        private sealed class GeoParquetMetadata
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="GeoParquetMetadata"/> class.
            /// </summary>
            /// <param name="srid">The spatial reference identifier declared by the file.</param>
            /// <param name="geometryColumn">The primary geometry column name.</param>
            /// <param name="coveringMinX">The covering column holding each row's minimum X, or null when the file carries no covering.</param>
            /// <param name="coveringMaxX">The covering column holding each row's maximum X, or null when the file carries no covering.</param>
            /// <param name="coveringMinY">The covering column holding each row's minimum Y, or null when the file carries no covering.</param>
            /// <param name="coveringMaxY">The covering column holding each row's maximum Y, or null when the file carries no covering.</param>
            /// <param name="boundingBox2D">The bounding box the primary geometry column declares in the file's own coordinate reference system, or null when the file declares none.</param>
            public GeoParquetMetadata(int srid, string geometryColumn, DataField? coveringMinX, DataField? coveringMaxX, DataField? coveringMinY, DataField? coveringMaxY, BoundingBox2D? boundingBox2D)
            {
                this.srid = srid;
                this.geometryColumn = geometryColumn;
                this.coveringMinX = coveringMinX;
                this.coveringMaxX = coveringMaxX;
                this.coveringMinY = coveringMinY;
                this.coveringMaxY = coveringMaxY;
                this.boundingBox2D = boundingBox2D;
            }

            /// <summary>
            /// Gets the bounding box the primary geometry column declares in the file's own coordinate reference system (the optional <c>bbox</c> of the GeoParquet column metadata), or null when the file declares none.
            /// </summary>
            public BoundingBox2D? BoundingBox2D
            {
                get
                {
                    return boundingBox2D;
                }
            }

            /// <summary>
            /// Gets the spatial reference identifier declared by the file.
            /// </summary>
            public int Srid
            {
                get
                {
                    return srid;
                }
            }

            /// <summary>
            /// Gets the primary geometry column name.
            /// </summary>
            public string GeometryColumn
            {
                get
                {
                    return geometryColumn;
                }
            }

            /// <summary>
            /// Gets the covering column holding each row's minimum X, or null when the file carries no covering.
            /// </summary>
            public DataField? CoveringMinX
            {
                get
                {
                    return coveringMinX;
                }
            }

            /// <summary>
            /// Gets the covering column holding each row's maximum X, or null when the file carries no covering.
            /// </summary>
            public DataField? CoveringMaxX
            {
                get
                {
                    return coveringMaxX;
                }
            }

            /// <summary>
            /// Gets the covering column holding each row's minimum Y, or null when the file carries no covering.
            /// </summary>
            public DataField? CoveringMinY
            {
                get
                {
                    return coveringMinY;
                }
            }

            /// <summary>
            /// Gets the covering column holding each row's maximum Y, or null when the file carries no covering.
            /// </summary>
            public DataField? CoveringMaxY
            {
                get
                {
                    return coveringMaxY;
                }
            }

            /// <summary>
            /// Gets whether all four covering columns resolved against the schema, which is what makes row-group pruning possible.
            /// </summary>
            public bool HasCovering
            {
                get
                {
                    return coveringMinX != null && coveringMaxX != null && coveringMinY != null && coveringMaxY != null;
                }
            }

            private readonly int srid;
            private readonly string geometryColumn;
            private readonly DataField? coveringMinX;
            private readonly DataField? coveringMaxX;
            private readonly DataField? coveringMinY;
            private readonly DataField? coveringMaxY;
            private readonly BoundingBox2D? boundingBox2D;
        }
    }
}
