﻿namespace GenerarePDF
{
    partial class frmSettingsForm
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
            this.pnlBotton = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.ucTableSettings1 = new GenerarePDF.ucTableSettings();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBotton
            // 
            this.pnlBotton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotton.Location = new System.Drawing.Point(0, 401);
            this.pnlBotton.Name = "pnlBotton";
            this.pnlBotton.Size = new System.Drawing.Size(800, 49);
            this.pnlBotton.TabIndex = 3;
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.ucTableSettings1);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlContent.Location = new System.Drawing.Point(0, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(800, 259);
            this.pnlContent.TabIndex = 5;
            // 
            // ucTableSettings1
            // 
            this.ucTableSettings1.AutoSize = true;
            this.ucTableSettings1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucTableSettings1.Location = new System.Drawing.Point(0, 0);
            this.ucTableSettings1.Name = "ucTableSettings1";
            this.ucTableSettings1.Size = new System.Drawing.Size(800, 67);
            this.ucTableSettings1.TabIndex = 0;
            this.ucTableSettings1.OnTableDeleted += new GenerarePDF.ucTableSettings.TableDeleted(this.ucTableSettings1_OnTableDeleted);
            this.ucTableSettings1.OnTableAdded += new GenerarePDF.ucTableSettings.TableAdded(this.ucTableSettings1_OnTableAdded);
            // 
            // frmSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlBotton);
            this.Name = "frmSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings Form";
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlBotton;
        private System.Windows.Forms.Panel pnlContent;
        private ucTableSettings ucTableSettings1;
    }
}