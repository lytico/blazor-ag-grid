﻿using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AgGrid.Blazor
{
    /// <summary>
    /// Strongly-typed representation of:
    ///   https://www.ag-grid.com/javascript-grid-properties/
    /// </summary>
    public partial class GridOptions
    {
        public RowModelType? RowModelType { get; set; }

        // Selection
        //    https://www.ag-grid.com/javascript-grid-properties/#selection

        /// Type of Row Selection, set to either 'single' or 'multiple'.
        public RowSelection? RowSelection { get; set; }
        /// Set to true to allow multiple rows to be selected
        /// using single click.See Multi Select Single Click.
        [JsonPropertyName("rowMultiSelectWithClick")]
        public bool? EnableRowMultiSelectWithClick { get; set; }
        /// If true then rows will be deselected
        /// if you hold down ctrl + click the row.
        [JsonPropertyName("suppressRowDeselection")]
        public bool? SuppressRowDeselection { get; set; }
        /// If true, row selection won't happen when rows are clicked.
        /// Use when you want checkbox selection exclusively.
        public bool? SuppressRowClickSelection { get; set; }
        /// If true, cells won't be selectable. This means cells will
        /// not get keyboard focus when you click on them.
        public bool? SuppressCellSelection { get; set; }
        /// Set to true to enable Range Selection.
        public bool? EnableRangeSelection { get; set; }

        // Editing https://www.ag-grid.com/documentation/javascript/grid-properties/#reference-editing
        [JsonPropertyName("editType")]
        public EditType? EditType { get; set; }

        // Row Block Loading: Infinite & Enterprise Row Models
        //    https://www.ag-grid.com/javascript-grid-properties/#row-block-loading-infinite-enterprise-row-models

        /// How many concurrent data requests are allowed.Default is 2,
        /// so server is only ever hit with 2 concurrent requests.
        public int? MaxConcurrentDatasourceRequests { get; set; }
        /// How many pages to hold in the cache.
        public int? MaxBlocksInCache { get; set; }
        /// How many rows to seek ahead when unknown data size.
        public int? CacheOverflowSize { get; set; }
        /// How many rows to initially allow scrolling to in the grid.
        public int? InfiniteInitialRowCount { get; set; }

        // Scrolling https://www.ag-grid.com/documentation/javascript/grid-properties/#reference-scrolling

        /// <summary>
        /// Set to true to always show the vertical scrollbar.
        /// Default: false
        /// </summary>
        public bool AlwaysShowVerticalScroll { get; set; }
        /// <summary>
        /// Set to true to debounce the vertical scrollbar. Can provide smoother scrolling on older browsers, eg IE.
        /// Default: false
        /// </summary>
        public bool DebounceVerticalScrollbar { get; set; }
        /// <summary>
        /// Set to true to never show the horizontal scroll. This is useful if the grid is aligned with another
        /// grid and will scroll when the other grid scrolls. See Aligned Grid as Footer.
        /// Default: false
        /// </summary>
        public bool SuppressHorizontalScroll { get; set; }

        // Pagination https://www.ag-grid.com/javascript-grid-properties/#pagination

        /// True - Pagination is enabled. False (Default) - Pagination is disabled.
        [JsonPropertyName("pagination")]
        public bool? EnablePagination { get; set; }
        /// Number. How many rows to load per page. Default value = 100.
        /// If paginationAutoPageSize is specified, this property is ignored.
        /// See example Customising Pagination.
        public int? PaginationPageSize { get; set; }
        /// True - The number of rows to load per page is automatically adjusted
        /// by ag-Grid so each page shows enough rows to just fill the area
        /// designated for the grid. False (Default) - paginationPageSize is used.
        /// See example Auto Page Size.
        [JsonPropertyName("paginationAutoPageSize")]
        public bool? EnablePaginationAutoPageSize { get; set; }
        /// True - The out of the box ag-Grid controls for navigation are hidden.
        /// This is useful if pagination=true and you want to provide your own
        /// pagination controls. False (Default) - when pagination=true It automatically
        /// shows at the bottom the necessary controls so that the user can navigate through
        /// the different pages. See example Custom Pagination Controls.
        public bool? SuppressPaginationPanel { get; set; }
        /// Set to true to have pages split children of groups when Row Grouping or
        /// detail rows with Master Detail. Pagination & Child Rows
        [JsonPropertyName("paginateChildRows")]
        public bool? EnablePaginateChildRows { get; set; }

        // Localisation https://www.ag-grid.com/documentation/javascript/grid-properties/#reference-localisation
        
        public object LocaleText { get; set; }

        // Selection
        //    https://www.ag-grid.com/javascript-grid-properties/#selection

        /// Type of Row Selection, set to either 'single' or 'multiple'.
        public RowSelection? RowSelection { get; set; }
        /// Set to true to allow multiple rows to be selected
        /// using single click.See Multi Select Single Click.
        [JsonPropertyName("rowMultiSelectWithClick")]
        public bool? EnableRowMultiSelectWithClick { get; set; }
        /// If true then rows will be deselected
        /// if you hold down ctrl + click the row.
        [JsonPropertyName("rowDeselection")]
        public bool? EnableRowDeselection { get; set; }
        /// If true, row selection won't happen when rows are clicked.
        /// Use when you want checkbox selection exclusively.
        public bool? SuppressRowClickSelection { get; set; }
        /// If true, cells won't be selectable. This means cells will
        /// not get keyboard focus when you click on them.
        public bool? SuppressCellSelection { get; set; }
        /// Set to true to enable Range Selection.
        public bool? EnableRangeSelection { get; set; }

        [JsonPropertyName("singleClickEdit")]
        public bool? SingleClickEdit { get; set; }

        [JsonPropertyName("editType")]
        public EditType? EditType { get; set; }
        
        /// Enables Tree Data:
        ///   https://www.ag-grid.com/javascript-grid-tree-data/
        public bool? TreeData { get; set; }

        // Tooltip https://www.ag-grid.com/javascript-grid/component-tooltip/
        /// <summary>
        /// Tooltip Show Delay
        /// By default, when you hover on an item, it will take 2 seconds for the tooltip to be displayed.If you need to change this delay, the tooltipShowDelay config should be used, which is set in milliseconds.
        /// </summary>
        public int? TooltipShowDelay { get; set; }

        public bool? TooltipMouseTrack { get; set; }
    }

    [JsonConverter(typeof(EnumConverter))]
    public enum RowModelType
    {
        ClientSide = 0,
        Infinite = 1,
    }

    [JsonConverter(typeof(EnumConverter))]
    public enum RowSelection
    {
        Single = 0,
        Multiple = 1,
    }

    [JsonConverter(typeof(EnumConverter))]
    public enum EditType
    {
        FullRow = 1,
    }

    internal class EnumConverter : JsonConverterFactory
    {
        private JsonConverterFactory _inner = new JsonStringEnumConverter(
            JsonNamingPolicy.CamelCase, false);

        public override bool CanConvert(Type typeToConvert) => _inner.CanConvert(typeToConvert);

        public override JsonConverter CreateConverter(Type typeToConvert,
            JsonSerializerOptions options) => _inner.CreateConverter(typeToConvert, options);
    }
}
