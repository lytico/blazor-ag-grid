using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace AgGrid.Blazor
{
    public partial class GridColumn : ComponentBase
    {
        [CascadingParameter(Name = nameof(GridOptions.ColumnDefinitions))]
        public List<ColumnDefinition> ColumnDefinitions { get; set; } = new List<ColumnDefinition>();
        
        [Parameter] public string Field { get; set; }
        [Parameter] public string Header { get; set; }
        [Parameter] public bool IsResizable { get; set; }
        [Parameter] public bool IsSortable { get; set; }
        [Parameter] public bool IsFiltered { get; set; }
        [Parameter] public bool IsEditable { get; set; }

        protected override void OnInitialized()
        {
            ColumnDefinitions.Add(new ColumnDefinition
            {
                Field = Field,
                HeaderName = Header,
                IsResizable = IsResizable,
                IsSortable = IsSortable,
                IsFiltrable = IsFiltered,
                IsEditable = IsEditable,
            }); ;
        }
    }
}
