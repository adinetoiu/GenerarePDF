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

namespace GenerarePDF.Forms
{
    public partial class frmStart : Form
    {
        public frmStart()
        {
            InitializeComponent();
        }

        private void frmStart_Load(object sender, EventArgs e)
        {
            AppSettings settings = new AppSettings();
            string stringSettings = File.ReadAllText("appsettings.txt");
            settings = JsonConvert.DeserializeObject<AppSettings>(stringSettings);

            foreach (var header in settings.Tables)
            {
                checkedListBox1.Items.Add(header.Header.ToString());
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            List<string> headers = new List<string>();
            foreach (var item in checkedListBox1.CheckedItems)
            {
                headers.Add(item.ToString());
            }
            frmMainForm form = new frmMainForm();
            form.Init(headers);
            form.FormClosed += Form_FormClosed;
            form.Show();
            this.Hide();
        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }


    }
}
