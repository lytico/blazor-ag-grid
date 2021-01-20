using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AgGrid.Blazor
{
    public partial class GridOptions
    {
        private List<ColumnDefinition> _InternalColumnDefinitions;

        /// <summary>
        /// Array of Column Definitions.
        /// </summary>
        [JsonPropertyName("columnDefs")]
        public IEnumerable<ColumnDefinition> ColumnDefinitions { get; set; }

        /// <summary>
        /// A default column definition.
        /// </summary>
        public ColumnDefinition DefaultColDef { get; set; }
        /// <summary>
        /// Set to true to show the 'no sort' icon. See Example Custom Sorting.
        /// Default: false
        /// </summary>
        public bool UnSortIcon { get; set; }
        /// <summary>
        /// Set to true to always show the column menu button, rather than only showing when the mouse is over the column header.
        /// Default: false
        /// </summary>
        public bool SuppressMenuHide { get; set; }

        [JsonIgnore]
        internal List<ColumnDefinition> InternalColumnDefinitions
        {
            get => _InternalColumnDefinitions;
            set
            {
                if (_InternalColumnDefinitions != value)
                {
                    if (value != null)
                        PrepareForInterop += PrepareColumns;
                    else
                        PrepareForInterop -= PrepareColumns;
                }
                _InternalColumnDefinitions = value;
            }
        }

        private void PrepareColumns(object source, GridOptions.PrepareForInteropEventArgs args)
        {
            Console.WriteLine("Preparing Columns");
            // Merge declared and programatic if neeeded
            if (_InternalColumnDefinitions?.Count > 0)
            {
                if (ColumnDefinitions != null)
                    _InternalColumnDefinitions.AddRange(ColumnDefinitions);
                ColumnDefinitions = _InternalColumnDefinitions;
            }
        }
    }
}
