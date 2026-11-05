using DiGi.Geometry.Planar.Classes;
using Parquet;
using Parquet.Data;
using Parquet.Schema;
using System;
using System.Globalization;

namespace DiGi.GIS.IO
{
    public static partial class Query
    {
        /// <summary>
        /// Decides whether a Parquet row group can hold rows inside a bounding box, using only the row group's min/max statistics on the covering columns.
        /// <para>This is the pruning half of a spatial read: the statistics travel in the file footer, so the decision costs four footer lookups and a disjointness test, and a group judged disjoint is never opened or decompressed. A group whose statistics are missing or unreadable counts as intersecting, because the failure mode of pruning must always be extra work rather than a dropped row.</para>
        /// </summary>
        /// <param name="parquetRowGroupReader">The open row group reader supplying statistics.</param>
        /// <param name="coveringMinX">The covering column holding each row's minimum X, or null.</param>
        /// <param name="coveringMaxX">The covering column holding each row's maximum X, or null.</param>
        /// <param name="coveringMinY">The covering column holding each row's minimum Y, or null.</param>
        /// <param name="coveringMaxY">The covering column holding each row's maximum Y, or null.</param>
        /// <param name="boundingBox">The bounding box, in the source coordinate reference system, being queried.</param>
        /// <returns>True when the row group may contain rows inside the box and should be read; false when it can be skipped.</returns>
        private static bool RowGroup_InRange(ParquetRowGroupReader parquetRowGroupReader, DataField? coveringMinX, DataField? coveringMaxX, DataField? coveringMinY, DataField? coveringMaxY, BoundingBox2D boundingBox)
        {
            if (coveringMinX == null || coveringMaxX == null || coveringMinY == null || coveringMaxY == null)
            {
                // No covering columns: there are no per-row bounding boxes in the file to prune on, so every row group is read.
                return true;
            }

            static (double? min, double? max)? Range(ParquetRowGroupReader rowGroupReader, DataField dataField)
            {
                try
                {
                    DataColumnStatistics? dataColumnStatistics = rowGroupReader.GetStatistics(dataField);
                    if (dataColumnStatistics?.MinValue == null || dataColumnStatistics.MaxValue == null)
                    {
                        return null;
                    }

                    return (System.Convert.ToDouble(dataColumnStatistics.MinValue, CultureInfo.InvariantCulture), System.Convert.ToDouble(dataColumnStatistics.MaxValue, CultureInfo.InvariantCulture));
                }
                catch (Exception)
                {
                    // Statistics that were never written come back as an exception rather than a null in some files; either way the group cannot be pruned.
                    return null;
                }
            }

            (double? min, double? max)? range_MinX = Range(parquetRowGroupReader, coveringMinX);
            (double? min, double? max)? range_MaxX = Range(parquetRowGroupReader, coveringMaxX);
            (double? min, double? max)? range_MinY = Range(parquetRowGroupReader, coveringMinY);
            (double? min, double? max)? range_MaxY = Range(parquetRowGroupReader, coveringMaxY);

            if (range_MinX == null || range_MaxX == null || range_MinY == null || range_MaxY == null)
            {
                return true;
            }

            double tolerance = DiGi.Core.Constants.Tolerance.Distance;
            double minX = range_MinX.Value.min ?? double.MinValue;
            double maxX = range_MaxX.Value.max ?? double.MaxValue;
            double minY = range_MinY.Value.min ?? double.MinValue;
            double maxY = range_MaxY.Value.max ?? double.MaxValue;

            bool disjoint = maxX + tolerance < boundingBox.Min.X
                || minX - tolerance > boundingBox.Max.X
                || maxY + tolerance < boundingBox.Min.Y
                || minY - tolerance > boundingBox.Max.Y;

            return !disjoint;
        }
    }
}
