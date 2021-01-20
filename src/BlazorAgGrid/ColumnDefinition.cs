using System.Text.Json.Serialization;

namespace AgGrid.Blazor
{
    /// <summary>
    /// Strongly-typed representation of:
    ///   https://www.ag-grid.com/javascript-grid-column-properties/
    /// </summary>
    public partial class ColumnDefinition
    {
        public string Field { get; set; }
        /// <summary>
        /// The name to render in the column header. If not specified and field is specified, the field name will be used as the header name.
        /// </summary>
        public string HeaderName { get; set; }
        /// <summary>
        /// Class to use for the header cell. Can be a string, array of strings, or function.
        /// </summary>
        public string[] HeaderClass { get; set; }
        /// <summary>
        /// Class to use for the tool panel cell. Can be a string, array of strings, or function.
        /// </summary>
        public string[] ToolPanelClass { get; set; }
        /// <summary>
        /// Set to true if you do not want this column or group to appear in the Columns Tool Panel.
        /// Default: false
        /// </summary>
        public bool SuppressColumnsToolPanel { get; set; }
        /// <summary>
        /// Set to true if you do not want this column (filter) or group (filter group) to appear in the Filters Tool Panel.
        /// Default: false
        /// </summary>
        public bool SuppressFiltersToolPanel { get; set; }

        [JsonPropertyName("resizable")]
        public bool IsResizable { get; set; }

        [JsonPropertyName("sortable")]
        public bool IsSortable { get; set; }

        [JsonPropertyName("filter")]
        public bool IsFiltered { get; set; }

        [JsonPropertyName("editable")]
        public bool IsEditable { get; set; }

        public int? Width { get; set; }
        public int? MinWidth { get; set; }
        public int? MaxWidth { get; set; }
        /// <summary>
        /// Used instead of width when the goal is to fill the remaining empty space of the grid. See Column Flex.
        /// </summary>
        public int? Flex { get; set; }
        /// <summary>
        /// Set to true for this column to be hidden. You might think it would make more sense to call this field visible
        /// and mark it false to hide, but we want all default values to be false and we want columns to be visible by default.
        /// Default: false
        /// </summary>
        public bool Hide { get; set; }
        /// <summary>
        /// The style to give a particular cell. See Cell Style.
        /// </summary>
        public object CellStyle { get; set; }
        /// <summary>
        /// The class to give a particular cell. See Cell Class.
        /// </summary>
        public string[] CellClass { get; set; }
        /// <summary>
        /// cellRenderer to use for this column.
        /// </summary>
        public string CellRenderer { get; set; }
        /// <summary>
        /// Params to be passed to cell renderer component.
        /// </summary>
        public object CellRendererParams { get; set; }
        /// <summary>
        /// cellEditor to use for this column.
        /// </summary>
        public string CellEditor { get; set; }
        /// <summary>
        /// Params to be passed to cell editor component.
        /// </summary>
        public object CellEditorParams { get; set; }
        /// <summary>
        /// Set to true if no menu should be shown for this column header.
        /// Default: false
        /// </summary>
        public bool SuppressMenu { get; set; }
        /// <summary>
        /// Set to true to have the grid calculate the height of a row based on contents of this column.
        /// Default: false
        /// </summary>
        public bool AutoHeight { get; set; }
        /// <summary>
        /// Set to true to have the text wrap inside the cell.
        /// Default: false
        /// </summary>
        public bool WrapText { get; set; }
        /// <summary>
        /// Set to true to have cells under this column enter edit mode after single click.
        /// Default: false
        /// </summary>
        public bool SingleClickEdit { get; set; }
    }
}
