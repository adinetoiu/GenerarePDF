﻿using System;
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
    public partial class ucRowTable : UserControl
    {
        public delegate void RowDeleted(ucRowTable item);
        public event RowDeleted OnRowDeleted;

        public ucRowTable()
        {
            InitializeComponent();
        }

        internal void Init(TableSettings table)
        {
            tableLayoutPanel.ColumnStyles.Clear();
            tableLayoutPanel.RowStyles.Clear();
            for (int i = 0; i < table.Columns.Count; i++)
            {
                this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, table.Columns[i].Percentage));
                tableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
                TextBox textbox = new TextBox();
                tableLayoutPanel.Controls.Add(textbox);
                tableLayoutPanel.SetColumn(textbox, i);
                tableLayoutPanel.SetRow(textbox, 0);
            }
        }

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



        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (OnRowDeleted != null)
            {
                OnRowDeleted(this);
            }
        }
    }
}