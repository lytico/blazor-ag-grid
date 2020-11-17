using System.Text.Json.Serialization;

namespace AgGrid.Blazor
{
    public class SortModel
    {
        [JsonPropertyName("colId")]
        public string ColumnId { get; set; }

        [JsonPropertyName("sort")]
        public string Direction { get; set; }
    }
}
