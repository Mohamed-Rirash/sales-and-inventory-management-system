namespace sales_and_inventory_management_system
{
    partial class mainform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainform));
            this.panelLogo = new System.Windows.Forms.Panel();
            this.btnMenu = new FontAwesome.Sharp.IconButton();
            this.lblName = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnProduct = new System.Windows.Forms.Button();
            this.btnCategory = new System.Windows.Forms.Button();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.active = new System.Windows.Forms.Panel();
            this.panelSubSetting = new System.Windows.Forms.Panel();
            this.brnbackup = new System.Windows.Forms.Button();
            this.btnStore = new System.Windows.Forms.Button();
            this.btnUser = new System.Windows.Forms.Button();
            this.btnSetting = new System.Windows.Forms.Button();
            this.panelSubRecord = new System.Windows.Forms.Panel();
            this.btnPosRecord = new System.Windows.Forms.Button();
            this.btnSaleHist = new System.Windows.Forms.Button();
            this.btnRecord = new System.Windows.Forms.Button();
            this.btnSupplier = new System.Windows.Forms.Button();
            this.panelSubStock = new System.Windows.Forms.Panel();
            this.btnStockAdjustment = new System.Windows.Forms.Button();
            this.btnStockEntry = new System.Windows.Forms.Button();
            this.btnInStock = new System.Windows.Forms.Button();
            this.panelSubProduct = new System.Windows.Forms.Panel();
            this.btnBrand = new System.Windows.Forms.Button();
            this.btnProductList = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.brnminimize = new FontAwesome.Sharp.IconButton();
            this.btn = new FontAwesome.Sharp.IconButton();
            this.btnclose = new FontAwesome.Sharp.IconButton();
            this.lblTitle = new System.Windows.Forms.Label();
            this.htmlToolTip1 = new MetroFramework.Drawing.Html.HtmlToolTip();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelMenu.SuspendLayout();
            this.panelSubSetting.SuspendLayout();
            this.panelSubRecord.SuspendLayout();
            this.panelSubStock.SuspendLayout();
            this.panelSubProduct.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(111)))), ((int)(((byte)(61)))));
            this.panelLogo.Controls.Add(this.btnMenu);
            this.panelLogo.Controls.Add(this.lblName);
            this.panelLogo.Controls.Add(this.lblUsername);
            this.panelLogo.Controls.Add(this.lblRole);
            this.panelLogo.Controls.Add(this.pictureBox1);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(181, 122);
            this.panelLogo.TabIndex = 1;
            // 
            // btnMenu
            // 
            this.btnMenu.BackColor = System.Drawing.Color.Transparent;
            this.btnMenu.FlatAppearance.BorderSize = 0;
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu.IconChar = FontAwesome.Sharp.IconChar.Bars;
            this.btnMenu.IconColor = System.Drawing.Color.White;
            this.btnMenu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMenu.IconSize = 40;
            this.btnMenu.Location = new System.Drawing.Point(132, 6);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(51, 51);
            this.btnMenu.TabIndex = 5;
            this.htmlToolTip1.SetToolTip(this.btnMenu, "Menu");
            this.btnMenu.UseVisualStyleBackColor = false;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(1, 62);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(24, 18);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Ln";
            this.lblName.Visible = false;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.ForeColor = System.Drawing.Color.White;
            this.lblUsername.Location = new System.Drawing.Point(35, 69);
            this.lblUsername.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(80, 18);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "UserName";
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.ForeColor = System.Drawing.Color.White;
            this.lblRole.Location = new System.Drawing.Point(25, 89);
            this.lblRole.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(95, 18);
            this.lblRole.TabIndex = 0;
            this.lblRole.Text = "Administrator";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(21, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(109, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btnLogout
            // 
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Image = ((System.Drawing.Image)(resources.GetObject("btnLogout.Image")));
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new System.Drawing.Point(0, 822);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnLogout.Size = new System.Drawing.Size(181, 45);
            this.btnLogout.TabIndex = 9;
            this.btnLogout.Tag = "Logout";
            this.btnLogout.Text = "Logout";
            this.btnLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.htmlToolTip1.SetToolTip(this.btnLogout, "Log out");
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnProduct
            // 
            this.btnProduct.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProduct.FlatAppearance.BorderSize = 0;
            this.btnProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProduct.ForeColor = System.Drawing.Color.White;
            this.btnProduct.Image = ((System.Drawing.Image)(resources.GetObject("btnProduct.Image")));
            this.btnProduct.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProduct.Location = new System.Drawing.Point(0, 167);
            this.btnProduct.Margin = new System.Windows.Forms.Padding(0);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnProduct.Size = new System.Drawing.Size(181, 45);
            this.btnProduct.TabIndex = 2;
            this.btnProduct.Tag = "Product";
            this.btnProduct.Text = "Product";
            this.btnProduct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProduct.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.htmlToolTip1.SetToolTip(this.btnProduct, "Products");
            this.btnProduct.UseVisualStyleBackColor = true;
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // btnCategory
            // 
            this.btnCategory.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCategory.FlatAppearance.BorderSize = 0;
            this.btnCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategory.ForeColor = System.Drawing.Color.White;
            this.btnCategory.Image = ((System.Drawing.Image)(resources.GetObject("btnCategory.Image")));
            this.btnCategory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategory.Location = new System.Drawing.Point(0, 45);
            this.btnCategory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCategory.Name = "btnCategory";
            this.btnCategory.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnCategory.Size = new System.Drawing.Size(181, 45);
            this.btnCategory.TabIndex = 4;
            this.btnCategory.Tag = "Category";
            this.btnCategory.Text = "Category";
            this.btnCategory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.htmlToolTip1.SetToolTip(this.btnCategory, "Add Category");
            this.btnCategory.UseVisualStyleBackColor = true;
            this.btnCategory.Click += new System.EventHandler(this.btnCategory_Click);
            // 
            // panelMenu
            // 
            this.panelMenu.AutoScroll = true;
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(111)))), ((int)(((byte)(61)))));
            this.panelMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMenu.Controls.Add(this.active);
            this.panelMenu.Controls.Add(this.btnLogout);
            this.panelMenu.Controls.Add(this.panelSubSetting);
            this.panelMenu.Controls.Add(this.btnSetting);
            this.panelMenu.Controls.Add(this.panelSubRecord);
            this.panelMenu.Controls.Add(this.btnRecord);
            this.panelMenu.Controls.Add(this.btnSupplier);
            this.panelMenu.Controls.Add(this.panelSubStock);
            this.panelMenu.Controls.Add(this.btnInStock);
            this.panelMenu.Controls.Add(this.panelSubProduct);
            this.panelMenu.Controls.Add(this.btnProduct);
            this.panelMenu.Controls.Add(this.btnDashboard);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(200, 612);
            this.panelMenu.TabIndex = 3;
            // 
            // active
            // 
            this.active.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.active.Location = new System.Drawing.Point(0, 122);
            this.active.Name = "active";
            this.active.Size = new System.Drawing.Size(10, 45);
            this.active.TabIndex = 0;
            // 
            // panelSubSetting
            // 
            this.panelSubSetting.BackColor = System.Drawing.Color.SeaGreen;
            this.panelSubSetting.Controls.Add(this.brnbackup);
            this.panelSubSetting.Controls.Add(this.btnStore);
            this.panelSubSetting.Controls.Add(this.btnUser);
            this.panelSubSetting.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSubSetting.Location = new System.Drawing.Point(0, 693);
            this.panelSubSetting.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelSubSetting.Name = "panelSubSetting";
            this.panelSubSetting.Size = new System.Drawing.Size(181, 129);
            this.panelSubSetting.TabIndex = 8;
            // 
            // brnbackup
            // 
            this.brnbackup.Dock = System.Windows.Forms.DockStyle.Top;
            this.brnbackup.FlatAppearance.BorderSize = 0;
            this.brnbackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.brnbackup.ForeColor = System.Drawing.Color.White;
            this.brnbackup.Image = ((System.Drawing.Image)(resources.GetObject("brnbackup.Image")));
            this.brnbackup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.brnbackup.Location = new System.Drawing.Point(0, 90);
            this.brnbackup.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.brnbackup.Name = "brnbackup";
            this.brnbackup.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.brnbackup.Size = new System.Drawing.Size(181, 45);
            this.brnbackup.TabIndex = 6;
            this.brnbackup.Tag = "Back up & Restore";
            this.brnbackup.Text = "Back up & Restore";
            this.brnbackup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.htmlToolTip1.SetToolTip(this.brnbackup, "Data Recovey");
            this.brnbackup.UseVisualStyleBackColor = true;
            this.brnbackup.Click += new System.EventHandler(this.brnbackup_Click);
            // 
            // btnStore
            // 
            this.btnStore.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStore.FlatAppearance.BorderSize = 0;
            this.btnStore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStore.ForeColor = System.Drawing.Color.White;
            this.btnStore.Image = ((System.Drawing.Image)(resources.GetObject("btnStore.Image")));
            this.btnStore.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStore.Location = new System.Drawing.Point(0, 45);
            this.btnStore.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStore.Name = "btnStore";
            this.btnStore.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnStore.Size = new System.Drawing.Size(181, 45);
            this.btnStore.TabIndex = 5;
            this.btnStore.Tag = "Store";
            this.btnStore.Text = "Store";
            this.btnStore.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.htmlToolTip1.SetToolTip(this.btnStore, "Store Information");
            this.btnStore.UseVisualStyleBackColor = true;
            this.btnStore.Click += new System.EventHandler(this.btnStore_Click);
            // 
            // btnUser
            // 
            this.btnUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUser.FlatAppearance.BorderSize = 0;
            this.btnUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUser.ForeColor = System.Drawing.Color.White;
            this.btnUser.Image = ((System.Drawing.Image)(resources.GetObject("btnUser.Image")));
            this.btnUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUser.Location = new System.Drawing.Point(0, 0);
            this.btnUser.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnUser.Name = "btnUser";
            this.btnUser.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnUser.Size = new System.Drawing.Size(181, 45);
            this.btnUser.TabIndex = 4;
            this.btnUser.Tag = "User";
            this.btnUser.Text = "User";
            this.btnUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.htmlToolTip1.SetToolTip(this.btnUser, "Usser Settings");
            this.btnUser.UseVisualStyleBackColor = true;
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // btnSetting
            // 
            this.btnSetting.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSetting.FlatAppearance.BorderSize = 0;
            this.btnSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetting.ForeColor = System.Drawing.Color.White;
            this.btnSetting.Image = ((System.Drawing.Image)(resources.GetObject("btnSetting.Image")));
            this.btnSetting.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSetting.Location = new System.Drawing.Point(0, 648);
            this.btnSetting.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnSetting.Size = new System.Drawing.Size(181, 45);
            this.btnSetting.TabIndex = 7;
            this.btnSetting.Tag = "Setting";
            this.btnSetting.Text = "Setting";
            this.btnSetting.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.htmlToolTip1.SetToolTip(this.btnSetting, "Settings");
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // panelSubRecord
            // 
            this.panelSubRecord.BackColor = System.Drawing.Color.SeaGreen;
            this.panelSubRecord.Controls.Add(this.btnPosRecord);
            this.panelSubRecord.Controls.Add(this.btnSaleHist);
            this.panelSubRecord.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSubRecord.Location = new System.Drawing.Point(0, 563);
            this.panelSubRecord.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelSubRecord.Name = "panelSubRecord";
            this.panelSubRecord.Size = new System.Drawing.Size(181, 85);
            this.panelSubRecord.TabIndex = 6;
            // 
            // btnPosRecord
            // 
            this.btnPosRecord.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPosRecord.FlatAppearance.BorderSize = 0;
            this.btnPosRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPosRecord.ForeColor = System.Drawing.Color.White;
            this.btnPosRecord.Image = ((System.Drawing.Image)(resources.GetObject("btnPosRecord.Image")));
            this.btnPosRecord.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPosRecord.Location = new System.Drawing.Point(0, 45);
            this.btnPosRecord.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPosRecord.Name = "btnPosRecord";
            this.btnPosRecord.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnPosRecord.Size = new System.Drawing.Size(181, 45);
            this.btnPosRecord.TabIndex = 5;
            this.btnPosRecord.Tag = "POS Record";
            this.btnPosRecord.Text = "POS Record";
            this.btnPosRecord.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPosRecord.UseVisualStyleBackColor = true;
            this.btnPosRecord.Click += new System.EventHandler(this.btnPosRecord_Click);
            // 
            // btnSaleHist
            // 
            this.btnSaleHist.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSaleHist.FlatAppearance.BorderSize = 0;
            this.btnSaleHist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaleHist.ForeColor = System.Drawing.Color.White;
            this.btnSaleHist.Image = ((System.Drawing.Image)(resources.GetObject("btnSaleHist.Image")));
            this.btnSaleHist.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaleHist.Location = new System.Drawing.Point(0, 0);
            this.btnSaleHist.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSaleHist.Name = "btnSaleHist";
            this.btnSaleHist.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnSaleHist.Size = new System.Drawing.Size(181, 45);
            this.btnSaleHist.TabIndex = 4;
            this.btnSaleHist.Tag = "Sale History";
            this.btnSaleHist.Text = "Sale History";
            this.btnSaleHist.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSaleHist.UseVisualStyleBackColor = true;
            this.btnSaleHist.Click += new System.EventHandler(this.btnSaleHist_Click);
            // 
            // btnRecord
            // 
            this.btnRecord.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRecord.FlatAppearance.BorderSize = 0;
            this.btnRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecord.ForeColor = System.Drawing.Color.White;
            this.btnRecord.Image = ((System.Drawing.Image)(resources.GetObject("btnRecord.Image")));
            this.btnRecord.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRecord.Location = new System.Drawing.Point(0, 518);
            this.btnRecord.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnRecord.Size = new System.Drawing.Size(181, 45);
            this.btnRecord.TabIndex = 5;
            this.btnRecord.Tag = "Record";
            this.btnRecord.Text = "Record";
            this.btnRecord.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.htmlToolTip1.SetToolTip(this.btnRecord, "Reports");
            this.btnRecord.UseVisualStyleBackColor = true;
            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
            // 
            // btnSupplier
            // 
            this.btnSupplier.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSupplier.FlatAppearance.BorderSize = 0;
            this.btnSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupplier.ForeColor = System.Drawing.Color.White;
            this.btnSupplier.Image = ((System.Drawing.Image)(resources.GetObject("btnSupplier.Image")));
            this.btnSupplier.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSupplier.Location = new System.Drawing.Point(0, 473);
            this.btnSupplier.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSupplier.Name = "btnSupplier";
            this.btnSupplier.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnSupplier.Size = new System.Drawing.Size(181, 45);
            this.btnSupplier.TabIndex = 4;
            this.btnSupplier.Tag = "Supplier";
            this.btnSupplier.Text = "Supplier";
            this.btnSupplier.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.htmlToolTip1.SetToolTip(this.btnSupplier, "Suppliers");
            this.btnSupplier.UseVisualStyleBackColor = true;
            this.btnSupplier.Click += new System.EventHandler(this.btnSupplier_Click);
            // 
            // panelSubStock
            // 
            this.panelSubStock.BackColor = System.Drawing.Color.SeaGreen;
            this.panelSubStock.Controls.Add(this.btnStockAdjustment);
            this.panelSubStock.Controls.Add(this.btnStockEntry);
            this.panelSubStock.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSubStock.Location = new System.Drawing.Point(0, 388);
            this.panelSubStock.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelSubStock.Name = "panelSubStock";
            this.panelSubStock.Size = new System.Drawing.Size(181, 85);
            this.panelSubStock.TabIndex = 0;
            // 
            // btnStockAdjustment
            // 
            this.btnStockAdjustment.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStockAdjustment.FlatAppearance.BorderSize = 0;
            this.btnStockAdjustment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStockAdjustment.ForeColor = System.Drawing.Color.White;
            this.btnStockAdjustment.Image = ((System.Drawing.Image)(resources.GetObject("btnStockAdjustment.Image")));
            this.btnStockAdjustment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStockAdjustment.Location = new System.Drawing.Point(0, 45);
            this.btnStockAdjustment.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStockAdjustment.Name = "btnStockAdjustment";
            this.btnStockAdjustment.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnStockAdjustment.Size = new System.Drawing.Size(181, 45);
            this.btnStockAdjustment.TabIndex = 5;
            this.btnStockAdjustment.Tag = "Stock Adjustment";
            this.btnStockAdjustment.Text = "Stock Adjustment";
            this.btnStockAdjustment.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.htmlToolTip1.SetToolTip(this.btnStockAdjustment, "Edit Stock");
            this.btnStockAdjustment.UseVisualStyleBackColor = true;
            this.btnStockAdjustment.Click += new System.EventHandler(this.btnStockAdjustment_Click);
            // 
            // btnStockEntry
            // 
            this.btnStockEntry.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStockEntry.FlatAppearance.BorderSize = 0;
            this.btnStockEntry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStockEntry.ForeColor = System.Drawing.Color.White;
            this.btnStockEntry.Image = ((System.Drawing.Image)(resources.GetObject("btnStockEntry.Image")));
            this.btnStockEntry.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStockEntry.Location = new System.Drawing.Point(0, 0);
            this.btnStockEntry.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStockEntry.Name = "btnStockEntry";
            this.btnStockEntry.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnStockEntry.Size = new System.Drawing.Size(181, 45);
            this.btnStockEntry.TabIndex = 4;
            this.btnStockEntry.Tag = "Stock Entry";
            this.btnStockEntry.Text = "Stock Entry";
            this.btnStockEntry.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.htmlToolTip1.SetToolTip(this.btnStockEntry, "Add New Stock");
            this.btnStockEntry.UseVisualStyleBackColor = true;
            this.btnStockEntry.Click += new System.EventHandler(this.btnStockEntry_Click);
            // 
            // btnInStock
            // 
            this.btnInStock.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInStock.FlatAppearance.BorderSize = 0;
            this.btnInStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInStock.ForeColor = System.Drawing.Color.White;
            this.btnInStock.Image = ((System.Drawing.Image)(resources.GetObject("btnInStock.Image")));
            this.btnInStock.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInStock.Location = new System.Drawing.Point(0, 343);
            this.btnInStock.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnInStock.Name = "btnInStock";
            this.btnInStock.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnInStock.Size = new System.Drawing.Size(181, 45);
            this.btnInStock.TabIndex = 3;
            this.btnInStock.Tag = "In Stock";
            this.btnInStock.Text = "In Stock";
            this.btnInStock.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInStock.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.htmlToolTip1.SetToolTip(this.btnInStock, "Stock In");
            this.btnInStock.UseVisualStyleBackColor = true;
            this.btnInStock.Click += new System.EventHandler(this.btnInStock_Click);
            // 
            // panelSubProduct
            // 
            this.panelSubProduct.BackColor = System.Drawing.Color.SeaGreen;
            this.panelSubProduct.Controls.Add(this.btnBrand);
            this.panelSubProduct.Controls.Add(this.btnCategory);
            this.panelSubProduct.Controls.Add(this.btnProductList);
            this.panelSubProduct.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSubProduct.Location = new System.Drawing.Point(0, 212);
            this.panelSubProduct.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelSubProduct.Name = "panelSubProduct";
            this.panelSubProduct.Size = new System.Drawing.Size(181, 131);
            this.panelSubProduct.TabIndex = 0;
            // 
            // btnBrand
            // 
            this.btnBrand.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBrand.FlatAppearance.BorderSize = 0;
            this.btnBrand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrand.ForeColor = System.Drawing.Color.White;
            this.btnBrand.Image = ((System.Drawing.Image)(resources.GetObject("btnBrand.Image")));
            this.btnBrand.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBrand.Location = new System.Drawing.Point(0, 90);
            this.btnBrand.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBrand.Name = "btnBrand";
            this.btnBrand.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnBrand.Size = new System.Drawing.Size(181, 45);
            this.btnBrand.TabIndex = 5;
            this.btnBrand.Tag = "Brand";
            this.btnBrand.Text = "Brand";
            this.btnBrand.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.htmlToolTip1.SetToolTip(this.btnBrand, "Add New Brand");
            this.btnBrand.UseVisualStyleBackColor = true;
            this.btnBrand.Click += new System.EventHandler(this.btnBrand_Click);
            // 
            // btnProductList
            // 
            this.btnProductList.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProductList.FlatAppearance.BorderSize = 0;
            this.btnProductList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductList.ForeColor = System.Drawing.Color.White;
            this.btnProductList.Image = ((System.Drawing.Image)(resources.GetObject("btnProductList.Image")));
            this.btnProductList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductList.Location = new System.Drawing.Point(0, 0);
            this.btnProductList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnProductList.Name = "btnProductList";
            this.btnProductList.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnProductList.Size = new System.Drawing.Size(181, 45);
            this.btnProductList.TabIndex = 3;
            this.btnProductList.Tag = "  Product List";
            this.btnProductList.Text = "  Product List";
            this.btnProductList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.htmlToolTip1.SetToolTip(this.btnProductList, "Add Product");
            this.btnProductList.UseVisualStyleBackColor = true;
            this.btnProductList.Click += new System.EventHandler(this.btnProductList_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Image = ((System.Drawing.Image)(resources.GetObject("btnDashboard.Image")));
            this.btnDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.Location = new System.Drawing.Point(0, 122);
            this.btnDashboard.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnDashboard.Size = new System.Drawing.Size(181, 45);
            this.btnDashboard.TabIndex = 0;
            this.btnDashboard.Tag = "Dashboard";
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.htmlToolTip1.SetToolTip(this.btnDashboard, "Dashboard");
            this.btnDashboard.UseVisualStyleBackColor = true;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.brnminimize);
            this.panel1.Controls.Add(this.btn);
            this.panel1.Controls.Add(this.btnclose);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(200, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(925, 40);
            this.panel1.TabIndex = 4;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // brnminimize
            // 
            this.brnminimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.brnminimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(202)))), ((int)(((byte)(211)))));
            this.brnminimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.brnminimize.FlatAppearance.BorderSize = 0;
            this.brnminimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.brnminimize.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            this.brnminimize.IconColor = System.Drawing.Color.White;
            this.brnminimize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.brnminimize.IconSize = 38;
            this.brnminimize.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.brnminimize.Location = new System.Drawing.Point(806, 1);
            this.brnminimize.Name = "brnminimize";
            this.brnminimize.Size = new System.Drawing.Size(41, 33);
            this.brnminimize.TabIndex = 5;
            this.htmlToolTip1.SetToolTip(this.brnminimize, "Minimize");
            this.brnminimize.UseVisualStyleBackColor = false;
            this.brnminimize.Click += new System.EventHandler(this.brnminimize_Click);
            // 
            // btn
            // 
            this.btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(155)))), ((int)(((byte)(255)))));
            this.btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn.FlatAppearance.BorderSize = 0;
            this.btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize;
            this.btn.IconColor = System.Drawing.Color.White;
            this.btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn.IconSize = 38;
            this.btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn.Location = new System.Drawing.Point(846, 1);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(41, 33);
            this.btn.TabIndex = 5;
            this.htmlToolTip1.SetToolTip(this.btn, "Maximaze");
            this.btn.UseVisualStyleBackColor = false;
            this.btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnclose
            // 
            this.btnclose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnclose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(74)))), ((int)(((byte)(130)))));
            this.btnclose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnclose.FlatAppearance.BorderSize = 0;
            this.btnclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnclose.IconChar = FontAwesome.Sharp.IconChar.WindowClose;
            this.btnclose.IconColor = System.Drawing.Color.White;
            this.btnclose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnclose.IconSize = 38;
            this.btnclose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnclose.Location = new System.Drawing.Point(882, 1);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(40, 33);
            this.btnclose.TabIndex = 5;
            this.htmlToolTip1.SetToolTip(this.btnclose, "Exit ");
            this.btnclose.UseCompatibleTextRendering = true;
            this.btnclose.UseVisualStyleBackColor = false;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(7, 6);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(110, 28);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "TitleName";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // htmlToolTip1
            // 
            this.htmlToolTip1.OwnerDraw = true;
            this.htmlToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(200, 40);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(925, 572);
            this.panelMain.TabIndex = 5;
            // 
            // mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1125, 612);
            this.ControlBox = false;
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(800, 425);
            this.Name = "mainform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainform_FormClosing);
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.Resize += new System.EventHandler(this.Dashboard_Resize);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelMenu.ResumeLayout(false);
            this.panelSubSetting.ResumeLayout(false);
            this.panelSubRecord.ResumeLayout(false);
            this.panelSubStock.ResumeLayout(false);
            this.panelSubProduct.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLogo;
        private FontAwesome.Sharp.IconButton btnMenu;
        public System.Windows.Forms.Label lblName;
        public System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.Button btnCategory;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelSubSetting;
        private System.Windows.Forms.Button btnStore;
        private System.Windows.Forms.Button btnUser;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.Panel panelSubRecord;
        private System.Windows.Forms.Button btnPosRecord;
        private System.Windows.Forms.Button btnSaleHist;
        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.Button btnSupplier;
        private System.Windows.Forms.Panel panelSubStock;
        private System.Windows.Forms.Button btnStockAdjustment;
        private System.Windows.Forms.Button btnStockEntry;
        private System.Windows.Forms.Button btnInStock;
        private System.Windows.Forms.Panel panelSubProduct;
        private System.Windows.Forms.Button btnBrand;
        private System.Windows.Forms.Button btnProductList;
        public System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitle;
        private FontAwesome.Sharp.IconButton brnminimize;
        private FontAwesome.Sharp.IconButton btn;
        private FontAwesome.Sharp.IconButton btnclose;
        private System.Windows.Forms.Button brnbackup;
        private MetroFramework.Drawing.Html.HtmlToolTip htmlToolTip1;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel active;
    }
}