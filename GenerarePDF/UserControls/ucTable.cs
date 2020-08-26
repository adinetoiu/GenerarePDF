using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenerarePDF.UserControls
{
    public partial class ucTable : UserControl
    {
        TableSettings _table;

        public string GetHeader()
        {
            return txtHeader.Text;
        }

        public bool SeScade()
        {
            return _table.SeScade;
        }

        public List<ColumnSettings> GetColumns()
        {
            return _table.Columns;
        }

        public List<List<string>> GetRowsValues()
        {
            List<List<string>> rows = new List<List<string>>();
            for (int j = pnlContainer.Controls.Count - 1; j >= 0; j--)
            {
                var control = pnlContainer.Controls[j];

                if (control is ucRowTable)
                {
                    rows.Add((control as ucRowTable).GetRowValues());
                }
            }
            return rows;
        }

        public ucTable()
        {
            InitializeComponent();
        }

        public void Init(TableSettings table)
        {
            _table = table;
            txtHeader.Text = table.Header;
            tableLayoutPanel.ColumnStyles.Clear();
            tableLayoutPanel.ColumnCount = table.Columns.Count;
            for (int i = 0; i < table.Columns.Count; i++)
            {
                this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, table.Columns[i].Percentage));
                Label label = new Label();
                label.Text = table.Columns[i].Name;
                tableLayoutPanel.Controls.Add(label);
                tableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
                tableLayoutPanel.SetColumn(label, i);
                label.TextAlign = ContentAlignment.MiddleCenter;
            }
            AddRow();
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            AddRow();
        }

        private void AddRow()
        {
            ucRowTable row = new ucRowTable();
            pnlContainer.Controls.Add(row);
            row.OnRowDeleted += Row_OnRowDeleted;
            row.BringToFront();
            row.Dock = DockStyle.Top;
            row.Init(_table);
        }

        private void Row_OnRowDeleted(ucRowTable item)
        {
            pnlContainer.Controls.Remove(item);
        }

        internal void FillData(ExportData.ExportTable exportTable)
        {
            pnlContainer.Controls.Clear();
            for (int i = 0; i <= exportTable.Rows.Count - 1; i++)
            {
                AddRow();
                var control = pnlContainer.Controls[0];
                var ucTablerow = control as ucRowTable;
                if (ucTablerow != null)
                {
                    ucTablerow.FillData(exportTable.Rows[i]);
                }
            }
        }
    }
}
