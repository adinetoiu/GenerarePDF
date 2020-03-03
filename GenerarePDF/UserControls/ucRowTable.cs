using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenerarePDF
{
    public partial class ucRowTable : UserControl
    {
        public delegate void RowDeleted(ucRowTable item);
        public event RowDeleted OnRowDeleted;

        public List<string> GetRowValues()
        {
            List<string> rowValues = new List<string>();

            for (int j = 0; j <= tlpColumns.Controls.Count - 1; j++)
            {
                var ctrl = tlpColumns.Controls[j];
                if (ctrl is TextBox)
                {
                    rowValues.Add((ctrl as TextBox).Text);
                }
                if (ctrl is DateTimePicker)
                {
                    rowValues.Add((ctrl as DateTimePicker).Value.ToString("MM/dd/yyyy"));
                }
            }
            return rowValues;
        }


        public ucRowTable()
        {
            InitializeComponent();
        }

        internal void Init(TableSettings table)
        {
            tlpColumns.ColumnStyles.Clear();
            tlpColumns.RowStyles.Clear();
            for (int i = 0; i < table.Columns.Count; i++)
            {
                this.tlpColumns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, table.Columns[i].Percentage));
                tlpColumns.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
                if (table.Columns[i].Name.Equals("Date"))
                {
                    DateTimePicker textbox = new DateTimePicker();
                    textbox.Format = DateTimePickerFormat.Short;
                    tlpColumns.Controls.Add(textbox);
                    tlpColumns.SetColumn(textbox, i);
                    tlpColumns.SetRow(textbox, 0);
                    textbox.Dock = DockStyle.Fill;
                }
                else
                {
                    TextBox textbox = new TextBox();
                    tlpColumns.Controls.Add(textbox);
                    tlpColumns.SetColumn(textbox, i);
                    tlpColumns.SetRow(textbox, 0);
                    textbox.Dock = DockStyle.Fill;
                }
            }
        }




        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (OnRowDeleted != null)
            {
                OnRowDeleted(this);
            }
        }
    }
}
