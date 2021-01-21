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
        /// Tooltip for the column header
        /// </summary>
        public string HeaderTooltip { get; set; }
        /// <summary>
        /// Custom header component to use for this column.
        /// </summary>
        public string HeaderComponentFramework { get; set; }
        /// <summary>
        /// Params to be passed to header component.
        /// </summary>
        public object HeaderComponentParams { get; set; }

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
        public Sorts? Sort { get; set; }
        /// <summary>
        /// Set to true to use the default filter. Use the FilterFramework for custom filter. 
        /// </summary>
        [JsonIgnore]
        public bool? IsFiltered { get => Filtered != null || FilterFramework != null; set { if (value == true) FilterFramework = true; } }

        /// <summary>
        /// Set standard filter. Use the FilterFramework for custom filter. 
        /// </summary>
        public ColumnFilters? Filtered { get; set; }

        /// <summary>
        /// Filter component to use for this column. Set to true to use the default filter.
        /// true for default filter or name your custom filter 
        /// </summary>
        public object FilterFramework { get; set; }
        /// <summary>
        /// Custom params to be passed to filter component.
        /// </summary>
        public object FilterParams { get; set; }
        
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
        /// Set standard cellRenderer to use for this column. Use the CellRendererFramework for custom cell renderer. 
        /// </summary>
        public CellRenderers? CellRenderer { get; set; }
        /// <summary>
        /// Custom cellRenderer name to use for this column.
        /// </summary>
        public string CellRendererFramework { get; set; } 
        /// <summary>
        /// Params to be passed to cell renderer component.
        /// </summary>
        public object CellRendererParams { get; set; }

        /// <summary>
        /// Set to true if this column is editable, otherwise false. Can also be a function to have different rows editable.
        /// Default: false
        /// </summary>
        [JsonPropertyName("editable")]
        public bool IsEditable { get; set; }
        /// <summary>
        /// Set standard cellEditor to use for this column. Use the CellEditorFramework for custom cell editor. 
        /// </summary>
        public CellEditors? CellEditor { get; set; }
        /// <summary>
        /// Custom cellEditor to use for this column.
        /// </summary>
        public string CellEditorFramework { get; set; }
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
    /// <summary>
    /// Sorting options
    /// </summary>
    [JsonConverter(typeof(EnumConverter))]
    public enum Sorts
    {
        Asc,
        Desc
    }

    /// <summary>
    /// Provided cell renderers
    /// </summary>
    [JsonConverter(typeof(EnumConverter))]
    public enum CellRenderers
    {
        /// <summary>
        /// The previous value is temporarily shown beside the old value with a directional arrow showing increase or decrease in value. The old value is then faded out.
        /// </summary>
        AgAnimateShowChangeCellRendere,
        /// <summary>
        /// The previous value shown in a faded fashion and slides, giving a ghosting effect as the old value fades and slides away.
        /// </summary>
        AgAnimateSlideCellRenderer,
        /// <summary>
        ///  (ag-Grid Enterprise only): Group Cell Renderer
        /// </summary>
        AgGroupCellRenderer
    }

    /// <summary>
    /// Provided cell editors
    /// </summary>
    [JsonConverter(typeof(EnumConverter))]
    public enum CellEditors
    {
        /// <summary>
        /// Simple text editor that uses a standard HTML input. This is the default.
        /// </summary>
        AgTextCellEditor,
        /// <summary>
        /// Same as 'text' but as popup.
        /// </summary>
        AgPopupTextCellEditor,
        /// <summary>
        /// A text popup for inputting larger, multi-line text.
        /// </summary>
        AgLargeTextCellEditor,
        /// <summary>
        /// Simple editor that uses a standard HTML select.
        /// </summary>
        AgSelectCellEditor,
        /// <summary>
        /// Same as 'select' but as popup.
        /// </summary>
        AgPopupSelectCellEditor,
        /// <summary>
        /// (ag-Grid Enterprise only): A rich select popup that uses row virtualisation.
        /// </summary>
        AgRichSelectCellEditor,
    }

    /// <summary>
    /// Types simple filters
    /// </summary>
    [JsonConverter(typeof(EnumConverter))]
    public enum ColumnFilters{
        AgTextColumnFilter,
        AgNumberColumnFilter,
        AgDateColumnFilter,
        AgSetColumnFilter
    }
}
