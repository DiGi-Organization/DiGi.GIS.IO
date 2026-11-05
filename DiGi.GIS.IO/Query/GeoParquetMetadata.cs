using Parquet.Schema;

namespace DiGi.GIS.IO
{
    public static partial class Query
    {
        /// <summary>
        /// The file-level GeoParquet facts a read needs in one place: the spatial reference identifier, the primary geometry column and the covering columns resolved against the schema for row-group pruning.
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
            public GeoParquetMetadata(int srid, string geometryColumn, DataField? coveringMinX, DataField? coveringMaxX, DataField? coveringMinY, DataField? coveringMaxY)
            {
                this.srid = srid;
                this.geometryColumn = geometryColumn;
                this.coveringMinX = coveringMinX;
                this.coveringMaxX = coveringMaxX;
                this.coveringMinY = coveringMinY;
                this.coveringMaxY = coveringMaxY;
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
        }
    }
}
