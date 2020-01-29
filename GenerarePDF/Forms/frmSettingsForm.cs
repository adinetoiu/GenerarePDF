using GenerarePDF.Forms;
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
        AppSettings _settings;
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
            if (MessageBox.Show("Are you sure you want to delete table?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                pnlContent.Controls.Remove(item);
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                _settings.Tables.Clear();
                for (int i = pnlContent.Controls.Count - 1; i >= 0; i--)
                {
                    var control = pnlContent.Controls[i];
                    if (control is ucTableSettings)
                    {
                        _settings.Tables.Add((control as ucTableSettings).GetTable());
                    }
                }
                string stringSettings = JsonConvert.SerializeObject(_settings);
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
            _settings = settings;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = _settings.Drivers;

            foreach (var sett in settings.Tables)
            {
                AddTable(sett);
            }
        }

        private void btnAddTable_Click(object sender, EventArgs e)
        {
            AddTable(null);
        }

        private void btnDriver_Click(object sender, EventArgs e)
        {
            frmAddEditDriver form = new frmAddEditDriver();
            form.Init(null);
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(form.Driver.ID))
                {
                    form.Driver.ID = Guid.NewGuid().ToString();
                    _settings.Drivers.Add(form.Driver);
                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.DataSource = _settings.Drivers;
                }
                else
                {
                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.DataSource = _settings.Drivers;
                }

            }
        }
    }
}
