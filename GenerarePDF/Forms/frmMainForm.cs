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
        List<string> _tableIDs;

        public frmMainForm()
        {
            try
            {
                PDFDocument.License = "UOEIOBIR-2051-191-P0050";
                InitializeComponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmMainForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadSettings();
                cmbDrivers.SelectedIndexChanged += CmbDrivers_SelectedIndexChanged;

                datCurrentDate.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Init(List<string> tables)
        {
            _tableIDs = tables;
        }

        private void LoadSettings()
        {
            _settings = new AppSettings();
            string stringSettings = File.ReadAllText("appsettings.txt");
            _settings = JsonConvert.DeserializeObject<AppSettings>(stringSettings);

            foreach (var table in _settings.Tables)
            {
                if (_tableIDs.Contains(table.Header))
                {
                    AddTable(table);
                }
            }
            cmbDrivers.DataSource = _settings.Drivers;
            if (_settings.LastDriver != null)
            {
                cmbDrivers.SelectedItem = _settings.Drivers.Find(p => p.ID == _settings.LastDriver.ID);
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

        private void btnSettings_Click(object sender, EventArgs e)
        {
            try
            {
                frmSettingsForm form = new frmSettingsForm();
                form.Init(_settings);
                form.ShowDialog();
                form.FormClosed += Form_FormClosed;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                LoadSettings();
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
                        document.Pages.Insert(1);

                        #region Logo
                        TypeConverter tc = TypeDescriptor.GetConverter(typeof(Bitmap));
                        Bitmap bitmap1 = (Bitmap)tc.ConvertFrom(Convert.FromBase64String(_settings.LogoBase64));
                        PDFImage logo = new PDFImage(bitmap1);
                        logo.Width = 100;
                        logo.Height = 100;
                        logo.KeepAspectRatio = true;
                        document.CurrentPage.Body.AddImage(logo, -50, -20);
                        #endregion

                        #region Company Details
                        document.CurrentPage.Body.SetTextAlignment(TextAlign.Left);
                        document.CurrentPage.Body.SetActiveFont("Tahoma", PDFFontStyles.Regular, 8.25);
                        document.CurrentPage.Body.AddTextArea(new RectangleF(-50, 50, 200, 200), _settings.CompanyDetails, true);
                        #endregion

                        #region Driver
                        document.CurrentPage.Body.SetTextAlignment(TextAlign.Left);
                        document.CurrentPage.Body.SetActiveFont("Tahoma", PDFFontStyles.Regular, 14.25);
                        document.CurrentPage.Body.AddTextArea(new RectangleF(480, -40, 200, 200), "Statement #" + txtStatement.Text, true);
                        document.CurrentPage.Body.AddTextArea(new RectangleF(450, -20, 200, 200), _settings.LastDriver.Name, true);
                        document.CurrentPage.Body.AddTextArea(new RectangleF(490, 0, 200, 200), datCurrentDate.Value.ToString("MM/dd/yyyy"), true);

                        document.CurrentPage.Body.SetTextAlignment(TextAlign.Left);
                        document.CurrentPage.Body.SetActiveFont("Tahoma", PDFFontStyles.Bold, 10);
                        document.CurrentPage.Body.AddTextArea(new RectangleF(50, 150, 200, 200), _settings.LastDriver.Name, true);
                        document.CurrentPage.Body.AddTextArea(new RectangleF(50, 165, 200, 200), _settings.LastDriver.Address, true);
                        #endregion

                        double lastHeigth = 270;
                        double totalGridWidth = 0;
                        double totalTableEndX = 0;
                        int totalRowsCount = 0;
                        float totalCheckAmount = 0;
                        int tabelIndex = 0;
                        int currentPage = 0;
                        int tableXStart = -60;
                        double checkAmountWidth = 0;
                        double checkAmountValueWidth = 0;

                        for (int j = panelMain.Controls.Count - 1; j >= 0; j--)
                        {
                            var control = panelMain.Controls[j];
                            if (control is ucTable)
                            {
                                tabelIndex++;
                                string header = (control as ucTable).GetHeader();
                                List<ColumnSettings> columns = (control as ucTable).GetColumns();
                                List<List<string>> rows = (control as ucTable).GetRowsValues();
                                if (rows == null || rows.Count == 0)
                                {
                                    continue;
                                }

                                Table table = new Table(columns.Count);
                                table.width = 700;
                                table.DisplayHeader = true;
                                table.headerStyle.fontStyle = TableFontStyle.bold;
                                table.headerStyle.fontSize = 8.5;
                                table.headerStyle.fontName = "Tahoma";
                                table.headerStyle.fontStyle = TableFontStyle.bold;
                                table.headerStyle.backgroundColor = Color.LightGray;
                                table.style.borderBottomType = borderType.none;
                                table.style.borderLeftType = borderType.none;
                                table.style.borderRightType = borderType.none;

                                float totalTable = 0;
                                for (int row = 0; row < rows.Count; row++)
                                {
                                    if (string.IsNullOrEmpty(rows[row][columns.Count - 1]))
                                    {
                                        continue;
                                    }
                                    table.addRow();
                                    for (int column = 0; column < columns.Count; column++)
                                    {
                                        Cell cell = table.cell(row, column);
                                        cell.style.borderType = borderType.solid;
                                        cell.style.borderWidth = 1;
                                        cell.style.borderColor = Color.Black;
                                        if (row == 0)
                                        {
                                            table.column(column).width = table.width * (double)columns[column].Percentage / 100;
                                            table.column(column).header.SetValue(columns[column].Name);
                                            table.column(column).header.style.textAlign = TextAlignment.center;
                                            if (column == columns.Count - 2)
                                            {
                                                checkAmountWidth = table.column(column).width;
                                            }
                                            if (column == columns.Count - 1)
                                            {
                                                checkAmountValueWidth = table.column(column).width;
                                            }
                                        }
                                        if (columns[column].Name.Equals("Amount"))
                                        {
                                            var cel = table.cell(row, column);
                                            cel.style.fontStyle = TableFontStyle.bold;
                                            totalTable += float.Parse(rows[row][column]);
                                            cel.SetValue("$" + rows[row][column]);
                                            cel.style.textAlign = TextAlignment.center;
                                            cel.style.fontColor = Color.Black;
                                            cell.style.borderColor = Color.Black;
                                        }
                                        else
                                        {
                                            var cel = table.cell(row, column);
                                            cel.SetValue(rows[row][column]);
                                            cel.style.textAlign = TextAlignment.center;
                                            cell.style.borderColor = Color.Black;
                                        }
                                    }
                                }


                                #region Add row for total
                                table.addRow();
                                for (int column = 0; column < columns.Count; column++)
                                {
                                    var cell = table.cell(table.rowCount - 1, column);
                                    cell.style.fontStyle = TableFontStyle.bold;
                                    if (column == columns.Count - 2)
                                    {
                                        cell.SetValue("Total:");
                                        cell.style.textAlign = TextAlignment.right;
                                        cell.style.borderType = borderType.solid;
                                        cell.style.borderType = borderType.solid;
                                        cell.style.borderWidth = 1;
                                        cell.style.borderColor = Color.Black;
                                    }
                                    else if (column == columns.Count - 1)
                                    {
                                        cell.SetValue("$" + totalTable.ToString());
                                        cell.style.textAlign = TextAlignment.center;
                                        cell.style.borderType = borderType.solid;
                                        cell.style.borderWidth = 1;
                                        cell.style.borderColor = Color.Black;
                                        cell.style.fontColor = Color.DarkRed;
                                        cell.style.borderType = borderType.solid;
                                    }
                                    else
                                    {
                                        cell.style.borderType = borderType.none;
                                        // cell.style.borderBottomColor = Color.White;
                                    }
                                }
                                //table.addRow();//???
                                //for (int column = 0; column < columns.Count; column++)
                                //{
                                //    var cell = table.cell(table.rowCount - 1, column);
                                //    cell.style.borderType = borderType.none;
                                //}
                                #endregion


                                #region Add Check Amount

                                if ((control as ucTable).SeScade())
                                {
                                    totalCheckAmount -= totalTable;
                                }
                                else
                                {
                                    totalCheckAmount += totalTable;
                                }


                                #endregion
                                totalRowsCount += table.rowCount;
                                if (totalRowsCount > 15 && currentPage == 0)
                                {
                                    document.SetCurrentPage(1);
                                    currentPage = 1;
                                    lastHeigth = 0;
                                }


                                document.CurrentPage.Body.SetTextAlignment(TextAlign.Left);
                                document.CurrentPage.Body.SetActiveFont("Tahoma", PDFFontStyles.Bold, 10);
                                document.CurrentPage.Body.AddTextArea(new RectangleF(-60, (int)lastHeigth - 20, 700, 20), header, true);

                                document.Pages[currentPage].Body.DrawTable(table, tableXStart, lastHeigth);
                                lastHeigth += table.rowCount * 25 + 65;
                                totalGridWidth = table.column(table.columnCount - 1).width + table.column(table.columnCount - 2).width;
                                totalTableEndX = 0;
                                for (int i = 0; i <= table.columnCount - 3; i++)
                                {
                                    totalTableEndX += table.column(i).width;
                                }
                            }

                        }

                        //???
                        Table tableTOTAL = new Table(2);
                        tableTOTAL.width = totalGridWidth;
                        tableTOTAL.DisplayHeader = false;
                        tableTOTAL.headerStyle.fontStyle = TableFontStyle.bold;
                        tableTOTAL.headerStyle.fontSize = 8.5;
                        tableTOTAL.headerStyle.fontName = "Tahoma";
                        tableTOTAL.headerStyle.fontStyle = TableFontStyle.bold;
                        tableTOTAL.headerStyle.backgroundColor = Color.LightGray;
                        tableTOTAL.column(0).width = checkAmountWidth;
                        tableTOTAL.column(1).width = checkAmountValueWidth;

                        tableTOTAL.addRow();

                        var cellTotalAmount = tableTOTAL.cell(tableTOTAL.rowCount - 1, 0);
                        cellTotalAmount.style.fontStyle = TableFontStyle.bold;
                        cellTotalAmount.SetValue("Check Amount:");
                        cellTotalAmount.style.textAlign = TextAlignment.right;
                        cellTotalAmount.style.borderColor = Color.Black;

                        var cellTotalValue = tableTOTAL.cell(tableTOTAL.rowCount - 1, 1);
                        cellTotalValue.style.fontStyle = TableFontStyle.bold;
                        cellTotalValue.style.fontColor = Color.DarkRed;
                        cellTotalValue.style.textAlign = TextAlignment.center;
                        cellTotalValue.style.borderColor = Color.Black;
                        cellTotalValue.SetValue("$" + totalCheckAmount.ToString());
                        cellTotalValue.style.fontColor = Color.DarkRed;

                        lastHeigth -= 28;


                        //double pageHeigth = document.PageSetupInfo.PageHeight - document.PageSetupInfo.TopMargin - document.PageSetupInfo.BottomMargin;
                        //if (totalRowsCount <= 15)
                        //{
                        document.CurrentPage.Body.DrawTable(tableTOTAL, totalTableEndX + tableXStart, lastHeigth);
                        //}
                        //else if (totalRowsCount > 15 && totalRowsCount <= 18)
                        //{
                        //    document.Pages[1].Body.DrawTable(tableTOTAL, totalTableEndX, 300);
                        //}
                        //else //count >15
                        //{
                        //    double yPosition = (totalRowsCount - 15) * 24 + 20;
                        //    document.Pages[1].Body.DrawTable(tableTOTAL, totalTableEndX, yPosition);
                        //}



                        //???


                        //end table
                        #region footer
                        for (int i = 0; i < document.PageCount; i++)
                        {
                            document.Pages[i].Footer.SetActiveFont("Tahoma", PDFFontStyles.Regular, 9);
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
                                display += System.Environment.NewLine + datCurrentDate.Value.ToString("MM/dd/yyyy");
                                document.Pages[i].Footer.AddTextArea(new RectangleF(0, 0, 150, 30), display, false);
                            }
                            document.Pages[i].Footer.AddTextArea(new RectangleF(240, 0, 250, 50), _settings.SoftwareProvider, false);
                            document.Pages[i].Footer.AddTextArea(new RectangleF(513, 0, 100, 30), string.Format("page {0} of {1}", i + 1, document.PageCount), false);
                        }
                        #endregion

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


    }
}
