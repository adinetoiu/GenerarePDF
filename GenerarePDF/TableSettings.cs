using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerarePDF
{
    public class AppSettings
    {
        List<TableSettings> Tables { get; set; }

        public AppSettings()
        {
            Tables = new List<TableSettings>();
        }
    }

    public class TableSettings
    {
        public string Header { get; set; }
        public string Description { get; set; }
        List<ColumnSettings> Columns { get; set; }

        public TableSettings()
        {
            Columns = new List<ColumnSettings>();
        }
    }

    public class ColumnSettings
    {
        private string Name { get; set; }
        private float Percentage { get; set; }
    }
}
