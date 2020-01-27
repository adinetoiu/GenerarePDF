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

        private void AddTable(TableSettings tableSett)
        {
            ucTableSettings table = new ucTableSettings();
            table.OnTableDeleted += Table_OnTableDeleted;
            table.OnColumnSizeChanged += Table_OnColumnSizeChanged;
            pnlContent.Controls.Add(table);
            table.Dock = DockStyle.Top;
            table.BringToFront();
            pnlContent.Height += table.Height;
            table.Init(tableSett);
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
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        internal void Init(AppSettings settings)
        {
            foreach (var sett in settings.Tables)
            {
                AddTable(sett);
            }
        }

        private void btnAddTable_Click(object sender, EventArgs e)
        {
            AddTable(null);
        }
    }
}
