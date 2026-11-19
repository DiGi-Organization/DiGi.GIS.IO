using DiGi.Core.IO.Table.Classes;
using DiGi.GIS.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DiGi.GIS.IO
{
    public static partial class Modify
    {
        /// <summary>
        /// Writes one census year built to every given building 2D of a county in the table (<see cref="Constants.Column.CensusYearBuilt"/>, DiGi-Organization/DiGi.GIS.IO#19).
        /// <para>A building's row is found by county id and reference, or added. A null year clears the cell rather than writing 0, so a municipality without census data leaves its buildings empty and a re-run over a municipality that lost its data clears what an earlier run wrote.</para>
        /// </summary>
        /// <param name="table">The table to update.</param>
        /// <param name="countyId">The unique identifier of the county.</param>
        /// <param name="building2Ds">The building 2D geometries of one municipality.</param>
        /// <param name="censusYearBuilt">The census year built of their municipality, or null when it has no census data.</param>
        public static void Update_Building2D_CensusYearBuilt(this Table? table, int countyId, IEnumerable<Building2D>? building2Ds, short? censusYearBuilt)
        {
            if (table is null || building2Ds is null || !building2Ds.Any())
            {
                return;
            }

            Column? column_Reference = table.UpdateColumn<Column>(Constants.Column.Reference);
            if (column_Reference is null)
            {
                return;
            }

            Column? column_CountyId = table.UpdateColumn<Column>(Constants.Column.CountyId);
            if (column_CountyId is null)
            {
                return;
            }

            Column? column_CensusYearBuilt = table.UpdateColumn<Column>(Constants.Column.CensusYearBuilt);
            if (column_CensusYearBuilt is null)
            {
                return;
            }

            Dictionary<string, Building2D> dictionary = [];
            foreach (Building2D building2D in building2Ds)
            {
                if (building2D?.Reference is not string reference || string.IsNullOrWhiteSpace(reference))
                {
                    continue;
                }

                dictionary[reference] = building2D;
            }

            if (dictionary.Count == 0)
            {
                return;
            }

            List<Tuple<Row, Building2D>> tuples = [];

            int count = table.RowCount;
            for (int i = count - 1; i >= 0; i--)
            {
                Row? row = table.GetRow(i);
                if (row is null)
                {
                    continue;
                }

                if (!row.TryGetValue(column_CountyId.Index, out int countyId_Row) || countyId_Row != countyId)
                {
                    continue;
                }

                if (!row.TryGetValue(column_Reference.Index, out string? reference_Row) || string.IsNullOrWhiteSpace(reference_Row))
                {
                    continue;
                }

                if (!dictionary.TryGetValue(reference_Row!, out Building2D building2D))
                {
                    continue;
                }

                tuples.Add(new Tuple<Row, Building2D>(row, building2D));
                dictionary.Remove(reference_Row!);
            }

            foreach (Building2D building2D in dictionary.Values)
            {
                Row row = table.AddRow();

                SetValue(row, column_Reference, building2D.Reference);
                SetValue(row, column_CountyId, countyId);

                tuples.Add(new Tuple<Row, Building2D>(row, building2D));
            }

            foreach (Tuple<Row, Building2D> tuple in tuples)
            {
                Row row = tuple.Item1;

                if (censusYearBuilt is short censusYearBuilt_Value && censusYearBuilt_Value > 0)
                {
                    SetValue(row, column_CensusYearBuilt, (ushort)censusYearBuilt_Value);
                }
                else
                {
                    row.RemoveValue(column_CensusYearBuilt.Index);
                }

                table.AddRow(row, false);
            }
        }

        /// <summary>
        /// Writes the census year built of a municipality, computed from its statistical data with <c>GIS.Query.CensusYearBuilt</c> (the NSP 2021 dwellings by construction period up to 2008), to every given building 2D of a county in the table (DiGi-Organization/DiGi.GIS.IO#19).
        /// <para>A null collection, or one without a positive dwelling count up to 2008, clears the cell.</para>
        /// </summary>
        /// <param name="table">The table to update.</param>
        /// <param name="countyId">The unique identifier of the county.</param>
        /// <param name="building2Ds">The building 2D geometries of one municipality.</param>
        /// <param name="statisticalDataCollection">The statistical data of their municipality's statistical unit.</param>
        public static void Update_Building2D_CensusYearBuilt(this Table? table, int countyId, IEnumerable<Building2D>? building2Ds, StatisticalDataCollection? statisticalDataCollection)
        {
            Update_Building2D_CensusYearBuilt(table, countyId, building2Ds, GIS.Query.CensusYearBuilt(statisticalDataCollection));
        }
    }
}
