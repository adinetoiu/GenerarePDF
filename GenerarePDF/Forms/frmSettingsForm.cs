using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

        private void AddTable()
        {
            ucTableSettings table = new ucTableSettings();
            table.OnTableAdded += Table_OnTableAdded; ;
            table.OnTableDeleted += Table_OnTableDeleted;
            table.OnColumnSizeChanged += Table_OnColumnSizeChanged;
            pnlContent.Controls.Add(table);
            table.Dock = DockStyle.Bottom;
            pnlContent.Height += table.Height;
        }

        private void Table_OnColumnSizeChanged(int size)
        {
            pnlContent.Height += size;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                AppSettings settings = new AppSettings();
                foreach (var control in pnlContent.Controls)
                {
                    if (control is ucTableSettings)
                    {
                        settings.Tables.Add((control as ucTableSettings).GetTable());
                    }
                }
                string stringSettings = JsonConvert.SerializeObject(settings);
                File.WriteAllText("appsettings.txt", stringSettings);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
