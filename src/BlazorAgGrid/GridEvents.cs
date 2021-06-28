using System;
using System.Text.Json;

namespace AgGrid.Blazor
{
    /// <summary>
    /// Strongly-typed counterpart of:
    ///    https://www.ag-grid.com/javascript-grid-events/
    /// </summary>
    public partial class GridEvents
    {
        /// <summary>
        /// Row selection is changed. Use the grid API to get the new row selected.
        /// </summary>
        public Action<RowNode[]> SelectionChanged { set => Set(value); }
        /// <summary>
        /// Value has changed after editing.
        /// </summary>
        public Action<CellValueChangedDetail> CellValueChanged { set => Set(value); }
        /// <summary>
        /// A cell's value within a row has changed. This event corresponds to Full Row Editing only.
        /// </summary>
        public Action<RowValueChangedEvent> RowValueChanged { set => Set(value); }

        /// <summary>
        /// Cell is clicked.
        /// </summary>
        public Action<CellClickedEvent> CellClicked { set => Set(value); }

        /// <summary>
        /// Fired the first time data is rendered into the grid.
        /// </summary>
        public Action FirstDataRendered { set => Set(value); }

        /// <summary>
        /// The grid has initialised. The name 'ready' was influenced by the author's time programming the Commodore 64.
        /// Use this event if, for example, you need to use the grid's API to fix the columns to size.
        /// </summary>
        public Action GridReady { set => Set(value); }
    }

    /// <summary>
    /// Value has changed after editing.
    /// </summary>
    public class CellValueChangedDetail
    {
        public JsonElement Data { get; set; }
        public string RowNodeId { get; set; }

        public string Field { get; set; }

        public string ColumnId { get; set; }

        public int RowIndex { get; set; }

        public JsonElement OldValue { get; set; }

        public JsonElement NewValue { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class CellClickedEvent : CellEvent { }

    /// <summary>
    /// A cell's value within a row has changed. This event corresponds to Full Row Editing only.
    /// </summary>
    public class RowValueChangedEvent : RowEvent { }

    public class RowEvent
    {
        public JsonElement Data { get; set; }
        public string RowNodeId { get; set; }
        public int RowIndex { get; set; }
        public string RowPinned { get; set; }
        public dynamic Context { get; set; }
        public dynamic Event { get; set; }
    }

    public class CellEvent : RowEvent
    {
        ///// <summary>
        ///// the column for the cell in question
        ///// </summary>
        //public dynamic Column { get; set; }
        ///// <summary>
        ///// the column definition for the cell in question
        ///// </summary>
        //public dynamic ColDef { get; set;}

        public string Field { get; set; }

        public string ColumnId { get; set; }

        /// <summary>
        /// the value for the cell in question
        /// </summary>
        public dynamic Value { get; set; }
    }

    public class FirstDataRenderedEvent
    {
        public string Type { get; set; }
    }
}
