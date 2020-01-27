using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerarePDF
{
    public class AppSettings
    {
        public List<TableSettings> Tables { get; set; }

        public AppSettings()
        {
            Tables = new List<TableSettings>();
        }
    }

    public class TableSettings
    {
        public string Header { get; set; }
        public string Description { get; set; }
        public List<ColumnSettings> Columns { get; set; }

        public TableSettings()
        {
            Columns = new List<ColumnSettings>();
        }
    }

    public class ColumnSettings
    {
        private string Name { get; set; }
        private float Percentage { get; set; }

        public ColumnSettings(string name, float percentage)
        {
            Name = name;
            Percentage = percentage;
        }
    }
}
