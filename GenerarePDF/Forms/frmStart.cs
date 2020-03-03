using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        private void btnStart_Click(object sender, EventArgs e)
        {
            frmMainForm form = new frmMainForm();
            List<int> tables = new List<int>();
            foreach (var control in this.Controls)
            {
                if (control is CheckBox && (control as CheckBox).Checked)
                {
                    tables.Add(int.Parse((control as CheckBox).Tag.ToString()));
                }
            }
            form.Init(tables);
            form.ShowDialog();
        }
    }
}
