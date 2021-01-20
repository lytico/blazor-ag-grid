namespace AgGrid.Blazor
{
    public partial class GridOptions
    {
        // Rendering and Styling https://www.ag-grid.com/documentation/javascript/grid-properties/#reference-scrolling

        /// <summary>
        /// Icons to use inside the grid instead of the grid's default icons.
        /// </summary>
        public object Icons { get; set; }
        /// <summary>
        /// Default Row Height in pixels.
        /// Default: 25
        /// </summary>
        public int RowHeight { get; set; }
        /// <summary>
        /// Set to true to enable Row Animation.
        /// Default: false
        /// </summary>
        public bool AnimateRows { get; set; }
        /// <summary>
        /// The style to give a particular row. See Row Style.
        /// </summary>
        public object RowStyle { get; set; }
        /// <summary>
        /// The class to give a particular row. See Row Class.
        /// </summary>
        public string[] RowClass { get; set; }
        /// <summary>
        /// Tell the grid how wide the scrollbar is, which is used in grid width calculations.
        /// Set only if using non-standard browser-provided scrollbars, so the grid can use the non-standard size in its calculations.
        /// </summary>
        public int ScrollbarWidth { get; set; }
        /// <summary>
        /// Set to true to not highlight rows by adding the ag-row-hover CSS class.
        /// Default: false
        /// </summary>
        public bool SuppressRowHoverHighlight { get; set; }
    }
}
