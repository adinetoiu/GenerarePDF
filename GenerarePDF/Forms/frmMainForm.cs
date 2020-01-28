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
                foreach(var table in _settings.Tables)
                {
                    AddTable(table);
                }

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

                        int i = 0;

                        Table table = new Table(5);
                        table.width = 800;
                        table.DisplayHeader = true;
                        table.headerStyle.fontStyle = TableFontStyle.bold;
                        table.headerStyle.fontSize = 9;
                        table.headerStyle.fontName = "Arial";
                        table.headerStyle.backgroundColor = Color.LightGray;

                        foreach (var ctrl in panelMain.Controls)
                        {
                            ucRowTable control = ctrl as ucRowTable;
                            if (control != null)
                            {
                                table.addRow();
                                for (int column = 0; column < 5; column++)
                                {
                                    if (i == 0)
                                    {
                                        //string headerColumnName = control.GetHeaderName(column + 1);
                                        //table.column(column).width = control.GetColumnWidth(column + 1); ;
                                        //table.column(column).header.SetValue(headerColumnName);
                                    }

                                    var cel = table.cell(i, column);
                                    cel.SetValue(control.GetValue(column + 1));
                                }
                                i++;
                            }
                        }
                        document.Pages[0].Body.DrawTable(table, -60, 500);
                        document.Save();
                        pdfOutput = outputMs.ToArray();
                    }
                }
                File.WriteAllBytes("out.pdf", pdfOutput);
                Process.Start("out.pdf");
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
