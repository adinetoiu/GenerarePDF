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
            this.label1 = new System.Windows.Forms.Label();
            this.txtHeader = new System.Windows.Forms.TextBox();
            this.btnRemoveGroup = new System.Windows.Forms.Button();
            this.cmbSeScade = new System.Windows.Forms.ComboBox();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpName
            // 
            this.grpName.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpName.Location = new System.Drawing.Point(0, 27);
            this.grpName.Name = "grpName";
            this.grpName.Size = new System.Drawing.Size(784, 39);
            this.grpName.TabIndex = 0;
            this.grpName.TabStop = false;
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlTop.Controls.Add(this.cmbSeScade);
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Controls.Add(this.txtHeader);
            this.pnlTop.Controls.Add(this.btnRemoveGroup);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(784, 27);
            this.pnlTop.TabIndex = 1;
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
            // txtHeader
            // 
            this.txtHeader.Location = new System.Drawing.Point(151, 3);
            this.txtHeader.Name = "txtHeader";
            this.txtHeader.Size = new System.Drawing.Size(449, 20);
            this.txtHeader.TabIndex = 2;
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
            // cmbSeScade
            // 
            this.cmbSeScade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSeScade.FormattingEnabled = true;
            this.cmbSeScade.Items.AddRange(new object[] {
            "+",
            "-"});
            this.cmbSeScade.Location = new System.Drawing.Point(622, 3);
            this.cmbSeScade.Name = "cmbSeScade";
            this.cmbSeScade.Size = new System.Drawing.Size(70, 21);
            this.cmbSeScade.TabIndex = 5;
            // 
            // ucTableSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.grpName);
            this.Controls.Add(this.pnlTop);
            this.Name = "ucTableSettings";
            this.Size = new System.Drawing.Size(784, 300);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpName;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btnRemoveGroup;
        private System.Windows.Forms.TextBox txtHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbSeScade;
    }
}
