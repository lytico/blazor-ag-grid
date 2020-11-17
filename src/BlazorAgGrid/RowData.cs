using System.Collections.Generic;

namespace AgGrid.Blazor
{
    public class RowData
    {
        private List<object> _Rows = new List<object>();

        public bool HasRows => _Rows != null;

        public int Count => _Rows?.Count ?? 0;

        public IEnumerable<object> Rows => _Rows;

        public void Add(object row) => _Rows.Add(row);

        public void AddRange(IEnumerable<object> rows) => _Rows.AddRange(rows);
    }
}
