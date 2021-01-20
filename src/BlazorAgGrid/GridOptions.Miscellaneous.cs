namespace AgGrid.Blazor
{
    public partial class GridOptions
    {
        // Miscellaneous https://www.ag-grid.com/documentation/javascript/grid-properties/#reference-miscellaneous

        /// <summary>
        /// If true, mouse wheel events will be passed to the browser. Useful if your grid has no vertical scrolls and you want the mouse to scroll the browser page.
        /// Default: false
        /// </summary>
        public bool SuppressPreventDefaultOnMouseWheel { get; set; }
        /// <summary>
        /// Set to true to use the browser's default tooltip instead of using ag-Grid's Tooltip Component.
        /// Default: false
        /// </summary>
        public bool EnableBrowserTooltips { get; set; }
        /// <summary>
        /// Switch between layout options. See Printing and Auto Height.
        /// Default: 'normal'
        /// Options: 'normal', 'autoHeight', 'print'
        /// </summary>
        public string DomLayout { get; set; }
        /// <summary>
        /// When true, the order of rows and columns in the DOM are consistent with what is on screen. See Accessibility - Row and Column Order.
        /// Default: false
        /// </summary>
        public bool EnsureDomOrder { get; set; }
        /// <summary>
        /// A list of grids to treat as Aligned Grids. If grids are aligned then the columns and horizontal scrolling will be kept in sync.
        /// </summary>
        public bool AlignedGrids { get; set; }
        /// <summary>
        /// Set to true to not show context menu. Use if you don't want to use the default 'right click' context menu.
        /// Default: false
        /// </summary>
        public bool SuppressContextMenu { get; set; }
        /// <summary>
        /// When using suppressContextMenu, you can use the onCellContextMenu function to provide your own code to handle cell contextmenu events. This flag is useful to prevent the browser from showing its default context menu.
        /// Default: false
        /// </summary>
        public bool PreventDefaultOnContextMenu { get; set; }
        /// <summary>
        /// Allows context menu to show, even when Ctrl key is held down.
        /// </summary>
        public bool AllowContextMenuWithControlKey { get; set; }
    }
}
