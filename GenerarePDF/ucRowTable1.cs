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
    public partial class ucRowTable1 : UserControl
    {
        public delegate void RowDeleted(ucRowTable1 item);
        public event RowDeleted OnRowDeleted;

        public delegate void RowAdded(ucRowTable1 item);
        public event RowAdded OnRowAdded;

        public string GetValue(int index)
        {
            int i = 0;
            for (int j = this.Controls.Count - 1; j >= 0; j--)
            {
                var ctrl = Controls[j];
                if (ctrl is TextBox)
                {
                    i++;
                    if (i == index)
                    {
                        return ctrl.Text;
                    }
                }
            }
            return string.Empty;
        }

        internal double GetColumnWidth(int index)
        {
            switch (index)
            {
                case 1:
                    return 80;
                case 2:
                    return 370;
                case 3:
                    return 80;
                case 4:
                    return 85;
                case 5:
                    return 85;
            }
            return 100;
        }


        internal string GetHeaderName(int index)
        {
            switch (index)
            {
                case 1:
                    return "Trip No.";
                case 2:
                    return "Description";
                case 3:
                    return "Mileage";
                case 4:
                    return "Date";
                case 5:
                    return "Amount";
            }
            return string.Empty;
        }

        public ucRowTable1()
        {
            InitializeComponent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (OnRowDeleted != null)
            {
                OnRowDeleted(this);
            }
        }

        private void btnAddRowTable1_Click(object sender, EventArgs e)
        {
            if (OnRowAdded != null)
            {
                OnRowAdded(this);
            }
        }
    }
}
