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
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnbackup = new System.Windows.Forms.Button();
            this.btnbrows = new System.Windows.Forms.Button();
            this.txtpath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.ForeColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1082, 46);
            this.panel2.TabIndex = 20;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.Maroon;
            this.panel1.Location = new System.Drawing.Point(353, 171);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(346, 2);
            this.panel1.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(287, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 24);
            this.label1.TabIndex = 18;
            this.label1.Text = "path";
            // 
            // btnbackup
            // 
            this.btnbackup.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnbackup.Location = new System.Drawing.Point(518, 228);
            this.btnbackup.Name = "btnbackup";
            this.btnbackup.Size = new System.Drawing.Size(140, 56);
            this.btnbackup.TabIndex = 16;
            this.btnbackup.Text = "BackUp";
            this.btnbackup.UseVisualStyleBackColor = true;
            this.btnbackup.Click += new System.EventHandler(this.btnbackup_Click);
            // 
            // btnbrows
            // 
            this.btnbrows.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnbrows.Location = new System.Drawing.Point(327, 228);
            this.btnbrows.Name = "btnbrows";
            this.btnbrows.Size = new System.Drawing.Size(140, 56);
            this.btnbrows.TabIndex = 17;
            this.btnbrows.Text = "Brawse";
            this.btnbrows.UseVisualStyleBackColor = true;
            this.btnbrows.Click += new System.EventHandler(this.btnbrows_Click);
            // 
            // txtpath
            // 
            this.txtpath.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtpath.BackColor = System.Drawing.SystemColors.Control;
            this.txtpath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtpath.Location = new System.Drawing.Point(353, 141);
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
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
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

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnbackup;
        private System.Windows.Forms.Button btnbrows;
        private System.Windows.Forms.TextBox txtpath;
    }
}