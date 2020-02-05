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
            try
            {
                AddTable(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDriver_Click(object sender, EventArgs e)
        {
            try
            {
                AddEditDriver(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddEditDriver(Driver driver)
        {
            frmAddEditDriver form = new frmAddEditDriver();
            form.Init(driver);
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(form.Driver.ID))
                {
                    form.Driver.ID = Guid.NewGuid().ToString();
                    _settings.Drivers.Add(form.Driver);
                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = _settings.Drivers;
                }
                else
                {
                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = _settings.Drivers;
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 2)
                {
                    var selecteddriver = dataGridView1.Rows[e.RowIndex].DataBoundItem as Driver;
                    if (selecteddriver != null)
                    {
                        AddEditDriver(selecteddriver);
                    }
                }
                else if (e.ColumnIndex == 3)
                {
                    var selecteddriver = dataGridView1.Rows[e.RowIndex].DataBoundItem as Driver;
                    if (selecteddriver != null)
                    {
                        _settings.Drivers.Remove(selecteddriver);
                        dataGridView1.AutoGenerateColumns = false;
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = _settings.Drivers;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox2_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                LoadLogo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadLogo()
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    pictureBox2.Image = Image.FromFile(dlg.FileName);
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                LoadLogo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
