using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace AgGrid.Blazor
{
    /// <summary>
    /// Strongly-typed access to:
    ///   https://www.ag-grid.com/javascript-grid-api/
    /// </summary>
    public class GridApi
    {
        internal string CallGridApi = "BlazorAgGrid.gridOptions_callGridApi";

        private IJSRuntime _js;
        private string _id;

        internal GridApi(IJSRuntime js, string id)
        {
            _js = js;
            _id = id;
        }

        public Task SizeColumnsToFit()
        {
            return CallApi("sizeColumnsToFit");
        }

        public Task RefreshCells(RefreshCellsParams @params = null)
        {
            if (@params == null)
                return CallApi("refreshCells");
            else
                return CallApi("refreshCells", @params);
        }

        public Task RedrawRows(RedrawRowsParams @params = null)
        {
            if (@params == null)
                return CallApi("redrawRows");
            else
                return CallApi("redrawRows", @params);
        }

        public Task RefreshInfiniteCache()
        {
            return CallApi("refreshInfiniteCache");
        }

        public Task PurgeInfiniteCache()
        {
            return CallApi("purgeInfiniteCache");
        }

        // https://www.ag-grid.com/javascript-grid/grid-api/

        /// <summary>
        /// Set rows
        /// </summary>
        /// <param name="rows">Data of rows</param>
        public Task SetRowData(IEnumerable<object> rows)
        {
            return CallApi("setRowData", rows);
        }

        /// <summary>
        /// Set new datasource for Infinite Row Model.
        /// </summary>
        /// <param name="datasource">New datasource</param>
        public Task SetDatasource(IGridDatasource datasource = null)
        {
            return _js.InvokeVoidAsync("BlazorAgGrid.gridOptions_setDatasource", _id, datasource).AsTask();
        }

        /// <summary>
        /// Starts editing the provided cell. If another cell is editing, the editing will be stopped in that other cell.
        /// </summary>
        /// <param name="params">Editing parameters.</param>
        public Task StartEditingCell(StartEditingCellParams @params)
        {
            if (@params == null)
            {
                throw new ArgumentNullException(nameof(@params));
            }
            return CallApi("startEditingCell", @params);
        }

        public Task StopEditing(bool cancel = false)
        {
            return CallApi("stopEditing", cancel);
        }

        /// <summary>
        /// Sets the focus to the specified cell.
        /// </summary>
        /// <param name="rowIndex">row index</param>
        /// <param name="colKey">col key</param>
        /// <param name="floating">'top' | 'bottom'</param>
        public Task SetFocusedCell(long rowIndex, string colKey, string? floating = null)
        {
            if (floating == null)
            {
                return CallApi("startEditingCell", rowIndex, colKey);
            }
            if (floating == "top" || floating == "bottom")
            {
                return CallApi("startEditingCell", rowIndex, colKey, floating);
            }
            throw new ArgumentException($"illegal value: \"{floating}\"", nameof(floating));
        }

        private Task CallApi(string name, params object[] args)
        {
            return _js.InvokeVoidAsync(CallGridApi, _id, name, args).AsTask();
        }

        public class RefreshCellsParams
        {
            /// specify rows, or all rows by default
            public RowNode[] RowNodes { get; set; }
            /// specify columns, or all columns by default
            public string[] Columns { get; set; }
            /// skips change detection, refresh everything
            public bool Force { get; set; }
        }

        public class RedrawRowsParams
        {
            /// the row nodes to redraw
            public RowNode[] RowNodes { get; set; }
        }


        /// <summary>
        /// Editing parameters.
        /// </summary>
        public class StartEditingCellParams {
            /// <summary>
            /// The row index of the row to start editing.
            /// </summary>
            public long RowIndex { get; set; }
            /// <summary>
            /// The column key of the column to start editing.
            /// </summary>
            public string ColKey { get; set; }
            /// <summary>
            ///  Set to 'top' or 'bottom' to started editing a pinned row.
            /// </summary>
            public string? RowPinned { get; set; }
            /// <summary>
            /// The keyPress that are passed to the cell editor.
            /// </summary>
            public long? KeyPress { get; set; }
            /// <summary>
            /// The charPress that are passed to the cell editor.
            /// </summary>
            public string? CharPress { get; set; }
        }
}
}
