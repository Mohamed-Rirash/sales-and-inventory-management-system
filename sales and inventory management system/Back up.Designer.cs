namespace sales_and_inventory_management_system
{
    partial class Back_up
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
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnbackup = new System.Windows.Forms.Button();
            this.btnbrows = new System.Windows.Forms.Button();
            this.txtpath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.ForeColor = System.Drawing.Color.White;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1082, 34);
            this.panel8.TabIndex = 20;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Maroon;
            this.panel6.Location = new System.Drawing.Point(425, 175);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(346, 2);
            this.panel6.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(359, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 24);
            this.label1.TabIndex = 18;
            this.label1.Text = "path";
            // 
            // btnbackup
            // 
            this.btnbackup.Location = new System.Drawing.Point(590, 232);
            this.btnbackup.Name = "btnbackup";
            this.btnbackup.Size = new System.Drawing.Size(140, 56);
            this.btnbackup.TabIndex = 16;
            this.btnbackup.Text = "BackUp";
            this.btnbackup.UseVisualStyleBackColor = true;
            this.btnbackup.Click += new System.EventHandler(this.btnbackup_Click);
            // 
            // btnbrows
            // 
            this.btnbrows.Location = new System.Drawing.Point(399, 232);
            this.btnbrows.Name = "btnbrows";
            this.btnbrows.Size = new System.Drawing.Size(140, 56);
            this.btnbrows.TabIndex = 17;
            this.btnbrows.Text = "Brawse";
            this.btnbrows.UseVisualStyleBackColor = true;
            this.btnbrows.Click += new System.EventHandler(this.btnbrows_Click);
            // 
            // txtpath
            // 
            this.txtpath.BackColor = System.Drawing.SystemColors.Control;
            this.txtpath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtpath.Location = new System.Drawing.Point(425, 145);
            this.txtpath.Multiline = true;
            this.txtpath.Name = "txtpath";
            this.txtpath.Size = new System.Drawing.Size(344, 32);
            this.txtpath.TabIndex = 15;
            // 
            // Back_up
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 518);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnbackup);
            this.Controls.Add(this.btnbrows);
            this.Controls.Add(this.txtpath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Back_up";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Back_up";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnbackup;
        private System.Windows.Forms.Button btnbrows;
        private System.Windows.Forms.TextBox txtpath;
    }
}