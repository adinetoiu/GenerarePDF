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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnAddTable = new System.Windows.Forms.Button();
            this.btnRemoveGroup = new System.Windows.Forms.Button();
            this.txtHeader = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Description = new System.Windows.Forms.Label();
            this.ucColumnSettings1 = new GenerarePDF.ucColumnSettings();
            this.grpName.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpName
            // 
            this.grpName.Controls.Add(this.ucColumnSettings1);
            this.grpName.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpName.Location = new System.Drawing.Point(0, 79);
            this.grpName.Name = "grpName";
            this.grpName.Size = new System.Drawing.Size(784, 39);
            this.grpName.TabIndex = 0;
            this.grpName.TabStop = false;
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlTop.Controls.Add(this.Description);
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Controls.Add(this.txtDescription);
            this.pnlTop.Controls.Add(this.txtHeader);
            this.pnlTop.Controls.Add(this.btnAddTable);
            this.pnlTop.Controls.Add(this.btnRemoveGroup);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(784, 79);
            this.pnlTop.TabIndex = 1;
            // 
            // btnAddTable
            // 
            this.btnAddTable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddTable.Location = new System.Drawing.Point(733, -1);
            this.btnAddTable.Name = "btnAddTable";
            this.btnAddTable.Size = new System.Drawing.Size(20, 20);
            this.btnAddTable.TabIndex = 1;
            this.btnAddTable.Text = "+";
            this.btnAddTable.UseVisualStyleBackColor = true;
            this.btnAddTable.Click += new System.EventHandler(this.btnAddTable_Click);
            // 
            // btnRemoveGroup
            // 
            this.btnRemoveGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveGroup.Location = new System.Drawing.Point(759, -1);
            this.btnRemoveGroup.Name = "btnRemoveGroup";
            this.btnRemoveGroup.Size = new System.Drawing.Size(20, 20);
            this.btnRemoveGroup.TabIndex = 0;
            this.btnRemoveGroup.Text = "X";
            this.btnRemoveGroup.UseVisualStyleBackColor = true;
            this.btnRemoveGroup.Click += new System.EventHandler(this.btnRemoveGroup_Click);
            // 
            // txtHeader
            // 
            this.txtHeader.Location = new System.Drawing.Point(151, 3);
            this.txtHeader.Name = "txtHeader";
            this.txtHeader.Size = new System.Drawing.Size(535, 20);
            this.txtHeader.TabIndex = 2;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(151, 29);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(535, 44);
            this.txtDescription.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Header Name";
            // 
            // Description
            // 
            this.Description.AutoSize = true;
            this.Description.Location = new System.Drawing.Point(3, 32);
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(73, 13);
            this.Description.TabIndex = 5;
            this.Description.Text = "Header Name";
            // 
            // ucColumnSettings1
            // 
            this.ucColumnSettings1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucColumnSettings1.Location = new System.Drawing.Point(3, 10);
            this.ucColumnSettings1.Name = "ucColumnSettings1";
            this.ucColumnSettings1.Size = new System.Drawing.Size(778, 26);
            this.ucColumnSettings1.TabIndex = 0;
            this.ucColumnSettings1.OnColumnDeleted += new GenerarePDF.ucColumnSettings.ColumnDeleted(this.Column_OnColumnDeleted);
            this.ucColumnSettings1.OnColumnAdded += new GenerarePDF.ucColumnSettings.ColumnAdded(this.Column_OnColumnAdded);
            // 
            // ucTableSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.grpName);
            this.Controls.Add(this.pnlTop);
            this.Name = "ucTableSettings";
            this.Size = new System.Drawing.Size(784, 126);
            this.grpName.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpName;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btnRemoveGroup;
        private ucColumnSettings ucColumnSettings1;
        private System.Windows.Forms.Button btnAddTable;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtHeader;
        private System.Windows.Forms.Label Description;
        private System.Windows.Forms.Label label1;
    }
}
