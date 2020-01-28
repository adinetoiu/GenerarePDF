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

        public ucTable()
        {
            InitializeComponent();
        }

        public void Init(TableSettings table)
        {
            _table = table;
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
            row.Init(_table);
            row.OnRowDeleted += Row_OnRowDeleted;
            pnlContainer.Controls.Add(row);
            row.BringToFront();
            row.Dock = DockStyle.Top;
        }

        private void Row_OnRowDeleted(ucRowTable item)
        {
            pnlContainer.Controls.Remove(item);
        }
    }
}
