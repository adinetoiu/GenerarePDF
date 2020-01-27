using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenerarePDF
{
    public partial class frmSettingsForm : Form
    {
        public frmSettingsForm()
        {
            InitializeComponent();
        }

        private void ucTableSettings1_OnTableAdded(ucTableSettings item)
        {

        }

        private void ucTableSettings1_OnTableDeleted(ucTableSettings item)
        {

        }

        private void AddTable()
        {
            ucTableSettings table = new ucTableSettings();
            table.OnTableAdded += Table_OnTableAdded; ;
            table.OnTableDeleted += Table_OnTableDeleted;
            pnlContent.Controls.Add(table);
            table.Dock = DockStyle.Bottom;
            pnlContent.Height += table.Height;
        }

        private void Table_OnTableDeleted(ucTableSettings item)
        {
            if (MessageBox.Show("Are you sure you want to delete table?") == DialogResult.Yes)
            {
                pnlContent.Controls.Remove(item);
            }
        }

        private void Table_OnTableAdded(ucTableSettings item)
        {
            try
            {
                AddTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
