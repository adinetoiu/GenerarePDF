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
            tableSettings.Description = txtDescription.Text;
            foreach (var control in grpName.Controls)
            {
                if (control is ucColumnSettings)
                {
                    tableSettings.Columns.Add((control as ucColumnSettings).GetColumnSettings());
                }
            }
            return tableSettings;
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
                AddColumn();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddColumn()
        {
            ucColumnSettings column = new ucColumnSettings();
            column.OnColumnAdded += Column_OnColumnAdded;
            column.OnColumnDeleted += Column_OnColumnDeleted;
            grpName.Controls.Add(column);
            column.Dock = DockStyle.Bottom;
            grpName.Height += column.Height;

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
