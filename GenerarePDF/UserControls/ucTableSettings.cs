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
    public partial class ucTableSettings : UserControl
    {
        public TableSettings GetTable()
        {
            TableSettings tableSettings = new TableSettings();
            tableSettings.Header = txtHeader.Text;
            if (cmbSeScade.SelectedIndex < 0)
            {
                cmbSeScade.SelectedIndex = 0;
            }
            tableSettings.SeScade = Convert.ToBoolean(cmbSeScade.SelectedIndex);
            for (int i = grpName.Controls.Count - 1; i >= 0; i--)
            {
                var control = grpName.Controls[i];
                if (control is ucColumnSettings)
                {
                    tableSettings.Columns.Add((control as ucColumnSettings).GetColumnSettings());
                }
            }
            return tableSettings;
        }

        internal void Init(TableSettings tableSett)
        {
            if (tableSett != null)
            {
                cmbSeScade.SelectedIndex = tableSett.SeScade ? 1 : 0;
                txtHeader.Text = tableSett.Header;

                foreach (var col in tableSett.Columns)
                {
                    AddColumn(col);
                }
            }
            else
            {
                AddColumn(null);
            }
        }

        public delegate void TableDeleted(ucTableSettings item);
        public event TableDeleted OnTableDeleted;

        public delegate void TableAdded(ucTableSettings item);
        public event TableAdded OnTableAdded;

        public delegate void ColumnSizeChanged(int size);
        public event ColumnSizeChanged OnColumnSizeChanged;

        public ucTableSettings()
        {
            InitializeComponent();
        }

        private void Column_OnColumnDeleted(ucColumnSettings item)
        {
            grpName.Controls.Remove(item);
            if (OnColumnSizeChanged != null)
            {
                OnColumnSizeChanged(-item.Height);
            }
        }

        private void Column_OnColumnAdded(ucColumnSettings item)
        {
            try
            {
                AddColumn(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddColumn(ColumnSettings colSett)
        {
            ucColumnSettings column = new ucColumnSettings();
            column.OnColumnAdded += Column_OnColumnAdded;
            column.OnColumnDeleted += Column_OnColumnDeleted;
            grpName.Controls.Add(column);
            column.Dock = DockStyle.Top;
            column.BringToFront();
            grpName.Height += column.Height;

            if (colSett != null)
            {
                column.init(colSett);
            }

            if (OnColumnSizeChanged != null)
            {
                OnColumnSizeChanged(column.Height);
            }
        }

        private void btnAddTable_Click(object sender, EventArgs e)
        {
            if (OnTableAdded != null)
            {
                OnTableAdded(this);
            }
        }

        private void btnRemoveGroup_Click(object sender, EventArgs e)
        {
            if (OnTableDeleted != null)
            {
                OnTableDeleted(this);
            }
        }

    }
}
