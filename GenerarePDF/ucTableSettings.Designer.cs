namespace GenerarePDF
{
    partial class ucTableSettings
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpName = new System.Windows.Forms.GroupBox();
            this.ucColumnSettings1 = new GenerarePDF.ucColumnSettings();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnRemoveGroup = new System.Windows.Forms.Button();
            this.btnAddTable = new System.Windows.Forms.Button();
            this.grpName.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpName
            // 
            this.grpName.Controls.Add(this.ucColumnSettings1);
            this.grpName.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpName.Location = new System.Drawing.Point(0, 20);
            this.grpName.Name = "grpName";
            this.grpName.Size = new System.Drawing.Size(788, 47);
            this.grpName.TabIndex = 0;
            this.grpName.TabStop = false;
            this.grpName.Text = "Table Name";
            // 
            // ucColumnSettings1
            // 
            this.ucColumnSettings1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucColumnSettings1.Location = new System.Drawing.Point(3, 18);
            this.ucColumnSettings1.Name = "ucColumnSettings1";
            this.ucColumnSettings1.Size = new System.Drawing.Size(782, 26);
            this.ucColumnSettings1.TabIndex = 0;
            this.ucColumnSettings1.OnColumnDeleted += new GenerarePDF.ucColumnSettings.ColumnDeleted(this.Column_OnColumnDeleted);
            this.ucColumnSettings1.OnColumnAdded += new GenerarePDF.ucColumnSettings.ColumnAdded(this.Column_OnColumnAdded);
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlTop.Controls.Add(this.btnAddTable);
            this.pnlTop.Controls.Add(this.btnRemoveGroup);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(788, 20);
            this.pnlTop.TabIndex = 1;
            // 
            // btnRemoveGroup
            // 
            this.btnRemoveGroup.Location = new System.Drawing.Point(763, -1);
            this.btnRemoveGroup.Name = "btnRemoveGroup";
            this.btnRemoveGroup.Size = new System.Drawing.Size(20, 20);
            this.btnRemoveGroup.TabIndex = 0;
            this.btnRemoveGroup.Text = "X";
            this.btnRemoveGroup.UseVisualStyleBackColor = true;
            this.btnRemoveGroup.Click += new System.EventHandler(this.btnRemoveGroup_Click);
            // 
            // btnAddTable
            // 
            this.btnAddTable.Location = new System.Drawing.Point(737, -1);
            this.btnAddTable.Name = "btnAddTable";
            this.btnAddTable.Size = new System.Drawing.Size(20, 20);
            this.btnAddTable.TabIndex = 1;
            this.btnAddTable.Text = "+";
            this.btnAddTable.UseVisualStyleBackColor = true;
            this.btnAddTable.Click += new System.EventHandler(this.btnAddTable_Click);
            // 
            // ucTableSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.grpName);
            this.Controls.Add(this.pnlTop);
            this.Name = "ucTableSettings";
            this.Size = new System.Drawing.Size(788, 322);
            this.grpName.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpName;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btnRemoveGroup;
        private ucColumnSettings ucColumnSettings1;
        private System.Windows.Forms.Button btnAddTable;
    }
}
