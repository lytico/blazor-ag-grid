using System;

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
        public dynamic Data { get; set; }
        public string RowNodeId { get; set; }

        public string Field { get; set; }

        public string ColumnId { get; set; }

        public int RowIndex { get; set; }

        public object OldValue { get; set; }

        public object NewValue { get; set; }
    }

    /// <summary>
    /// A cell's value within a row has changed. This event corresponds to Full Row Editing only.
    /// </summary>
    public class RowValueChangedEvent
    {
        public dynamic Data { get; set; }
        public string RowNodeId { get; set; }
        public int RowIndex { get; set; }
        public string RowPinned { get; set; }
        public dynamic Context { get; set; }
        public dynamic Event { get; set; }
    }

    public class FirstDataRenderedEvent
    {
        public string Type { get; set; }
    }
}
