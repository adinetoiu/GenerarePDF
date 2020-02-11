using GenerarePDF.UserControls;
using Newtonsoft.Json;
using PDFTech;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenerarePDF
{
    public partial class frmMainForm : Form
    {
        public AppSettings _settings;

        public frmMainForm()
        {
            try
            {
                PDFDocument.License = "UOEIOBIR-2051-191-P0050";
                InitializeComponent();
                _settings = new AppSettings();
                string stringSettings = File.ReadAllText("appsettings.txt");
                _settings = JsonConvert.DeserializeObject<AppSettings>(stringSettings);

                foreach (var table in _settings.Tables)
                {
                    AddTable(table);
                }
                cmbDrivers.DataSource = _settings.Drivers;
                if (_settings.LastDriver != null)
                {
                    cmbDrivers.SelectedItem = _settings.Drivers.Find(p => p.ID == _settings.LastDriver.ID);
                }
                cmbDrivers.SelectedIndexChanged += CmbDrivers_SelectedIndexChanged;

                txtCurrentDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void AddTable(TableSettings table)
        {
            ucTable ucControl = new ucTable();
            //ucControl.OnRowDeleted += UcControl_OnRowDeleted;
            //ucControl.OnRowAdded += UcControl_OnRowAdded;
            panelMain.Controls.Add(ucControl);
            ucControl.Dock = DockStyle.Top;
            ucControl.BringToFront();
            panelMain.Height += ucControl.Height;
            ucControl.Init(table);
        }

        private void UcControl_OnRowAdded(ucRowTable item)
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

        private void UcControl_OnRowDeleted(ucRowTable item)
        {
            try
            {
                panelMain.Controls.Remove(item);
                panelMain.Height -= item.Height;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] pdfOutput = null;
                byte[] pdfInput = File.ReadAllBytes("Template.pdf");
                using (var ms = new MemoryStream(pdfInput))
                {
                    using (var outputMs = new MemoryStream())
                    {
                        var options = new PDFCreationOptions();
                        options.Viewer.ViewerPreferences = ViewerPreference.CenterWindow;
                        var document = new PDFDocument(outputMs, options);
                        document.Pages.Delete(document.CurrentPage);
                        document.LoadPdf(ms, "");


                        #region Logo
                        TypeConverter tc = TypeDescriptor.GetConverter(typeof(Bitmap));
                        Bitmap bitmap1 = (Bitmap)tc.ConvertFrom(Convert.FromBase64String(_settings.LogoBase64));
                        PDFImage logo = new PDFImage(bitmap1);
                        logo.Width = 100;
                        logo.Height = 100;
                        logo.KeepAspectRatio = true;
                        document.Pages[0].Body.AddImage(logo, -50, -30);
                        #endregion

                        #region Company Details
                        document.Pages[0].Body.SetTextAlignment(TextAlign.Left);
                        document.Pages[0].Body.SetActiveFont("Tahoma", PDFFontStyles.Regular, 8.25);
                        document.Pages[0].Body.AddTextArea(new RectangleF(-50, 50, 200, 200), _settings.CompanyDetails, true);
                        #endregion

                        #region Driver
                        document.Pages[0].Body.SetTextAlignment(TextAlign.Left);
                        document.Pages[0].Body.SetActiveFont("Tahoma", PDFFontStyles.Regular, 14.25);
                        document.Pages[0].Body.AddTextArea(new RectangleF(450, -50, 200, 200), "Statement #1", true);
                        document.Pages[0].Body.AddTextArea(new RectangleF(450, -20, 200, 200), _settings.LastDriver.Name, true);
                        document.Pages[0].Body.AddTextArea(new RectangleF(450, 10, 200, 200), txtCurrentDate.Text.ToString(), true);

                        document.Pages[0].Body.SetTextAlignment(TextAlign.Left);
                        document.Pages[0].Body.SetActiveFont("Tahoma", PDFFontStyles.Bold, 10);
                        document.Pages[0].Body.AddTextArea(new RectangleF(50, 150, 200, 200), _settings.LastDriver.Name, true);
                        document.Pages[0].Body.AddTextArea(new RectangleF(50, 170, 200, 200), _settings.LastDriver.Address, true);
                        #endregion

                        #region footer
                        document.PageFooter.SetActiveFont("Tahoma", PDFFontStyles.Regular, 9);
                        if (!string.IsNullOrEmpty(_settings.CompanyDetails))
                        {
                            var lines = _settings.CompanyDetails.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                            string display = string.Empty;
                            if (lines.Length > 0)
                            {
                                display = lines[0];
                            }
                            else
                            {
                                display = _settings.CompanyDetails;
                            }
                            display += System.Environment.NewLine + txtCurrentDate.Text;
                            document.PageFooter.AddTextArea(new RectangleF(0, 0, 150, 30), display, false);
                        }
                        document.PageFooter.AddTextArea(new RectangleF(240, 0, 250, 50), _settings.SoftwareProvider, false);
                        document.PageFooter.AddTextArea(new RectangleF(513, 0, 100, 30), "page 1 Of 1", false);
                        #endregion

                        double lastHeigth = 300f;
                        double tableHeight = 0;

                        float totalTrips = 0;
                        float totalAdvancedAndDeductions = 0;
                        float totalCredits = 0;
                        float totalScheduledDeductions = 0;
                        float totalCheckAmount = 0;

                        for (int j = panelMain.Controls.Count - 1; j >= 0; j--)
                        {
                            var control = panelMain.Controls[j];
                            if (control is ucTable)
                            {
                                string header = (control as ucTable).GetHeader();
                                List<ColumnSettings> columns = (control as ucTable).GetColumns();
                                List<List<string>> rows = (control as ucTable).GetRowsValues();

                                document.Pages[0].Body.SetTextAlignment(TextAlign.Left);
                                document.Pages[0].Body.SetActiveFont("Tahoma", PDFFontStyles.Bold, 10);
                                document.Pages[0].Body.AddTextArea(new RectangleF(-60, (int)lastHeigth - 20, 700, 20), header, true);

                                Table table = new Table(columns.Count);
                                table.width = 700;
                                table.DisplayHeader = true;
                                table.headerStyle.fontStyle = TableFontStyle.bold;
                                table.headerStyle.fontSize = 8.5;
                                table.headerStyle.fontName = "Tahoma";
                                table.headerStyle.fontStyle = TableFontStyle.bold;
                                table.headerStyle.backgroundColor = Color.LightGray;

                                for (int row = 0; row < rows.Count; row++)
                                {
                                    table.addRow();
                                    for (int column = 0; column < columns.Count; column++)
                                    {
                                        if (row == 0)
                                        {
                                            table.column(column).width = table.width * (double)columns[column].Percentage / 100;
                                            table.column(column).header.SetValue(columns[column].Name);
                                            table.column(column).header.style.textAlign = TextAlignment.center;
                                        }
                                        if (columns[column].Name.Equals("Amount"))
                                        {
                                            if (header.Contains("Trips"))
                                            {
                                                totalTrips += float.Parse(rows[row][column]);
                                            }
                                            if (header.Contains("Advances"))
                                            {
                                                totalAdvancedAndDeductions += float.Parse(rows[row][column]);
                                            }
                                            if (header.Contains("Credits"))
                                            {
                                                totalCredits += float.Parse(rows[row][column]);
                                            }
                                            if (header.Contains("Scheduled"))
                                            {
                                                totalScheduledDeductions += float.Parse(rows[row][column]);
                                            }
                                        }
                                        var cel = table.cell(row, column);
                                        cel.SetValue(rows[row][column]);
                                        cel.style.textAlign = TextAlignment.center;
                                    }
                                    tableHeight += 25;
                                }
                                int tableXStart = -60;
                                document.Pages[0].Body.DrawTable(table, tableXStart, lastHeigth);
                                Table totalTable = new Table(2);
                                totalTable.width = table.column(table.columnCount - 1).width + table.column(table.columnCount - 2).width + 3;
                                totalTable.DisplayHeader = false;
                                totalTable.addRow();
                                var cel1 = table.cell(0, 0);
                                cel1.SetValue("a");
                                var cel2 = table.cell(0, 1);
                                cel2.SetValue("b");
                                document.Pages[0].Body.DrawTable(totalTable, table.width - totalTable.width + tableXStart + 3, lastHeigth + table.rowCount * 25 + 26);
                            }
                            lastHeigth += tableHeight + 140;
                        }
                        document.Save();
                        pdfOutput = outputMs.ToArray();
                    }
                }
                try
                {
                    File.WriteAllBytes("out.pdf", pdfOutput);
                    Process.Start("out.pdf");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("The file is already open!");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            try
            {
                frmSettingsForm form = new frmSettingsForm();
                form.Init(_settings);
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CmbDrivers_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbDrivers.SelectedItem != null)
                {
                    _settings.LastDriver = cmbDrivers.SelectedItem as Driver;

                    string stringSettings = JsonConvert.SerializeObject(_settings);
                    File.WriteAllText("appsettings.txt", stringSettings);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
