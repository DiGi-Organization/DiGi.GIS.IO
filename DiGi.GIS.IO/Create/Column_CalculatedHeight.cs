using DiGi.Core.IO.Table.Classes;

namespace DiGi.GIS.IO
{
    public static partial class Create
    {
        /// <summary>
        /// Creates the calculated height column - the Z extent of the stored building model's bounding box, written beside the external components area columns (DiGi-Organization/DiGi.GIS.IO#20).
        /// </summary>
        /// <returns>A <see cref="Column"/> whose cell holds the building height in meters, and is null when the model carries no component geometry. It is not one of the columns of <c>Columns_ExternalComponentsArea</c>, whose order the classification indexes.</returns>
        public static Column Column_CalculatedHeight()
        {
            return Constants.Column.CalculatedHeight;
        }
    }
}
