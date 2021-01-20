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

        public string HeaderName { get; set; }

        [JsonPropertyName("resizable")]
        public bool IsResizable { get; set; }

        [JsonPropertyName("sortable")]
        public bool IsSortable { get; set; }

        [JsonPropertyName("filter")]
        public bool IsFiltered { get; set; }

        [JsonPropertyName("editable")]
        public bool IsEditable { get; set; }

        public int Width { get; set; }
        public int MinWidth { get; set; }
        public int MaxWidth { get; set; }
        public int Flex { get; set; }

        public bool Hide { get; set; }

        public object CellStyle { get; set; }
        public string[] CellClass { get; set; }

        public string CellRenderer { get; set; }
        public object CellRendererParams { get; set; }

        public string CellEditor { get; set; }
        public object CellEditorParams { get; set; }

        public bool SuppressMenu { get; set; }
        public bool AutoHeight { get; set; }
        public bool WrapText { get; set; }
        public bool SingleClickEdit { get; set; }
    }
}
