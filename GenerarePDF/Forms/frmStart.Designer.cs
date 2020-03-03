namespace GenerarePDF.Forms
{
    partial class frmStart
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
            this.chkTrips = new System.Windows.Forms.CheckBox();
            this.chkAdvanced = new System.Windows.Forms.CheckBox();
            this.chkSheduledDeductions = new System.Windows.Forms.CheckBox();
            this.chkCredits = new System.Windows.Forms.CheckBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chkTrips
            // 
            this.chkTrips.AutoSize = true;
            this.chkTrips.Location = new System.Drawing.Point(21, 12);
            this.chkTrips.Name = "chkTrips";
            this.chkTrips.Size = new System.Drawing.Size(49, 17);
            this.chkTrips.TabIndex = 0;
            this.chkTrips.Tag = "1";
            this.chkTrips.Text = "Trips";
            this.chkTrips.UseVisualStyleBackColor = true;
            // 
            // chkAdvanced
            // 
            this.chkAdvanced.AutoSize = true;
            this.chkAdvanced.Location = new System.Drawing.Point(21, 50);
            this.chkAdvanced.Name = "chkAdvanced";
            this.chkAdvanced.Size = new System.Drawing.Size(154, 17);
            this.chkAdvanced.TabIndex = 1;
            this.chkAdvanced.Tag = "2";
            this.chkAdvanced.Text = "Advanced And Deductions";
            this.chkAdvanced.UseVisualStyleBackColor = true;
            // 
            // chkSheduledDeductions
            // 
            this.chkSheduledDeductions.AutoSize = true;
            this.chkSheduledDeductions.Location = new System.Drawing.Point(21, 92);
            this.chkSheduledDeductions.Name = "chkSheduledDeductions";
            this.chkSheduledDeductions.Size = new System.Drawing.Size(128, 17);
            this.chkSheduledDeductions.TabIndex = 2;
            this.chkSheduledDeductions.Tag = "3";
            this.chkSheduledDeductions.Text = "Sheduled Deductions";
            this.chkSheduledDeductions.UseVisualStyleBackColor = true;
            // 
            // chkCredits
            // 
            this.chkCredits.AutoSize = true;
            this.chkCredits.Location = new System.Drawing.Point(21, 134);
            this.chkCredits.Name = "chkCredits";
            this.chkCredits.Size = new System.Drawing.Size(58, 17);
            this.chkCredits.TabIndex = 3;
            this.chkCredits.Tag = "4";
            this.chkCredits.Text = "Credits";
            this.chkCredits.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(180, 269);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(128, 40);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // frmStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 343);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.chkCredits);
            this.Controls.Add(this.chkSheduledDeductions);
            this.Controls.Add(this.chkAdvanced);
            this.Controls.Add(this.chkTrips);
            this.Name = "frmStart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmStart";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkTrips;
        private System.Windows.Forms.CheckBox chkAdvanced;
        private System.Windows.Forms.CheckBox chkSheduledDeductions;
        private System.Windows.Forms.CheckBox chkCredits;
        private System.Windows.Forms.Button btnStart;
    }
}