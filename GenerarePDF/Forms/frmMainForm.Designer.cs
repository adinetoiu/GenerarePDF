namespace GenerarePDF
{
    partial class frmMainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelMain = new System.Windows.Forms.Panel();
            this.pnlBotton = new System.Windows.Forms.Panel();
            this.datCurrentDate = new System.Windows.Forms.DateTimePicker();
            this.txtStatement = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDrivers = new System.Windows.Forms.ComboBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.pnlBotton.SuspendLayout();
            this.pnlContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1337, 48);
            this.panelMain.TabIndex = 0;
            // 
            // pnlBotton
            // 
            this.pnlBotton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBotton.Controls.Add(this.datCurrentDate);
            this.pnlBotton.Controls.Add(this.txtStatement);
            this.pnlBotton.Controls.Add(this.label2);
            this.pnlBotton.Controls.Add(this.label1);
            this.pnlBotton.Controls.Add(this.cmbDrivers);
            this.pnlBotton.Controls.Add(this.lblDate);
            this.pnlBotton.Controls.Add(this.btnSettings);
            this.pnlBotton.Controls.Add(this.btnPrint);
            this.pnlBotton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotton.Location = new System.Drawing.Point(0, 474);
            this.pnlBotton.Name = "pnlBotton";
            this.pnlBotton.Size = new System.Drawing.Size(1337, 53);
            this.pnlBotton.TabIndex = 1;
            // 
            // datCurrentDate
            // 
            this.datCurrentDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.datCurrentDate.Location = new System.Drawing.Point(1032, 18);
            this.datCurrentDate.Name = "datCurrentDate";
            this.datCurrentDate.Size = new System.Drawing.Size(200, 20);
            this.datCurrentDate.TabIndex = 8;
            // 
            // txtStatement
            // 
            this.txtStatement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStatement.Location = new System.Drawing.Point(650, 21);
            this.txtStatement.Name = "txtStatement";
            this.txtStatement.Size = new System.Drawing.Size(48, 20);
            this.txtStatement.TabIndex = 7;
            this.txtStatement.Text = "1";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(581, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Statement #";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(760, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Driver";
            // 
            // cmbDrivers
            // 
            this.cmbDrivers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDrivers.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbDrivers.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDrivers.DisplayMember = "Name";
            this.cmbDrivers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDrivers.FormattingEnabled = true;
            this.cmbDrivers.Location = new System.Drawing.Point(801, 18);
            this.cmbDrivers.Name = "cmbDrivers";
            this.cmbDrivers.Size = new System.Drawing.Size(185, 21);
            this.cmbDrivers.TabIndex = 4;
            // 
            // lblDate
            // 
            this.lblDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(996, 21);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(30, 13);
            this.lblDate.TabIndex = 3;
            this.lblDate.Text = "Data";
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(12, 18);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(75, 23);
            this.btnSettings.TabIndex = 1;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(1257, 13);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // pnlContainer
            // 
            this.pnlContainer.AutoScroll = true;
            this.pnlContainer.Controls.Add(this.panelMain);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(1337, 474);
            this.pnlContainer.TabIndex = 2;
            // 
            // frmMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1337, 527);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.pnlBotton);
            this.Name = "frmMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlBotton.ResumeLayout(false);
            this.pnlBotton.PerformLayout();
            this.pnlContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel pnlBotton;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDrivers;
        private System.Windows.Forms.TextBox txtStatement;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker datCurrentDate;
    }
}

