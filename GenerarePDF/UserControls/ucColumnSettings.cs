using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenerarePDF
{
    public partial class ucColumnSettings : UserControl
    {
        public delegate void ColumnDeleted(ucColumnSettings item);
        public event ColumnDeleted OnColumnDeleted;

        public delegate void ColumnAdded(ucColumnSettings item);
        public event ColumnAdded OnColumnAdded;

        public ucColumnSettings()
        {
            InitializeComponent();
        }

        private void btnAddColumn_Click(object sender, EventArgs e)
        {
            if (OnColumnAdded != null)
            {
                OnColumnAdded(this);
            }
        }

        private void btnDeleteColumn_Click(object sender, EventArgs e)
        {
            if (OnColumnDeleted != null)
            {
                OnColumnDeleted(this);
            }
        }

        public ColumnSettings GetColumnSettings()
        {
            return new ColumnSettings(txtName.Text, float.Parse(txtPercentage.Text));
        }

        internal void init(ColumnSettings colSett)
        {
            txtName.Text = colSett.Name;
            txtPercentage.Text = colSett.Percentage.ToString();
        }
    }
}
