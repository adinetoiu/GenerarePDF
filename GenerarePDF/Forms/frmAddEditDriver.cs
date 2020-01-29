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
    public partial class frmAddEditDriver : Form
    {
        public Driver Driver { get { return _driver; } }

        Driver _driver;
        public frmAddEditDriver()
        {
            InitializeComponent();
        }

        public void Init(Driver driver)
        {
            if (driver != null)
            {
                _driver = driver;
                txtDriverAddress.Text = driver.Address;
                txtDriverName.Text = driver.Name;
            }
            else
            {
                _driver = new Driver();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _driver.Name = txtDriverName.Text;
            _driver.Address = txtDriverAddress.Text;
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
