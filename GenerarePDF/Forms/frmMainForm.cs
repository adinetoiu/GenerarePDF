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


                        document.Pages[0].Body.SetTextAlignment(TextAlign.Left);
                        document.CurrentPage.Body.SetActiveFont("Tahoma", PDFFontStyles.Regular, 14);
                        document.Pages[0].Body.AddTextArea(new RectangleF(415, 50, 100, 20), txtCurrentDate.Text, true);

                        double lastHeigth = 500f;
                        double tableHeight = 0;
                        for (int j = panelMain.Controls.Count - 1; j >= 0; j--)
                        {
                            var control = panelMain.Controls[j];
                            if (control is ucTable)
                            {
                                string header = (control as ucTable).GetHeader();
                                List<ColumnSettings> columns = (control as ucTable).GetColumns();
                                List<List<string>> rows = (control as ucTable).GetRowsValues();

                                document.Pages[0].Body.SetTextAlignment(TextAlign.Left);
                                document.CurrentPage.Body.SetActiveFont("Tahoma", PDFFontStyles.Bold, 10);
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

                                        var cel = table.cell(row, column);
                                        cel.SetValue(rows[row][column]);
                                        cel.style.textAlign = TextAlignment.center;
                                    }
                                    tableHeight += 30;
                                }
                                document.Pages[0].Body.DrawTable(table, -60, lastHeigth);
                            }
                            lastHeigth += tableHeight + 100;
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
    }
}
