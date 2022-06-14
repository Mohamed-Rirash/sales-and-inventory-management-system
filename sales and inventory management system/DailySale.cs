﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sales_and_inventory_management_system
{
    public partial class DailySale : Form
    {
        SqlConnection cn = new SqlConnection();
        private UserPreferenceChangedEventHandler UserPreferenceChanged;
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        public string solduser;
        mainform main;
        public DailySale(mainform mn)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            UserPreferenceChanged = new UserPreferenceChangedEventHandler(SystemEvents_UserPreferenceChanged);
            SystemEvents.UserPreferenceChanged += UserPreferenceChanged;
            this.Disposed += new EventHandler(Form_Disposed);
            LoadTheme();
            main = mn;
            LoadCashier();
        }

        #region theme 

        //load theme after change
        private void SystemEvents_UserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
        {
            if (e.Category == UserPreferenceCategory.General || e.Category == UserPreferenceCategory.VisualStyle)
            {
                LoadTheme();
            }
        }
        //system dispose
        private void Form_Disposed(object sender, EventArgs e)
        {
            SystemEvents.UserPreferenceChanged -= UserPreferenceChanged;
        }
        // load theme
        private void LoadTheme()
        {
            var themeColor = WinTheme.GetAccentColor();//Windows Accent Color
            var lightColor = ControlPaint.Light(themeColor);
            var darkColor = ControlPaint.Dark(themeColor);

            panel1.BackColor = lightColor;
           


            //Buttons
            foreach (Button button in this.Controls.OfType<Button>())
            {
                button.BackColor = themeColor;
            }
            foreach (Button button in this.Controls.OfType<Button>())
            {
                button.FlatAppearance.MouseOverBackColor = themeColor;
                button.FlatAppearance.MouseDownBackColor = lightColor;
            }
        }



        #endregion
        public void LoadCashier()
        {
            cboCashier.Items.Clear();
            cboCashier.Items.Add("All Cashier");
            cn.Open();
            cm = new SqlCommand("SELECT * FROM tbUser WHERE role LIKE 'Cashier'", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                cboCashier.Items.Add(dr["username"].ToString());
            }
            dr.Close();
            cn.Close();
        }
        public void LoadSold()
        {
            int i = 0;
            double total = 0;
            dgvSold.Rows.Clear();
            cn.Open();
            if (cboCashier.Text == "All Cashier")
            {
                cm = new SqlCommand("select c.id, c.transno, c.pcode, p.pdesc, c.price, c.qty, c.disc, c.total from tbCart as c inner join tbProduct as p on c.pcode = p.pcode where status like 'Sold' and sdate between '" + dtFrom.Value + "' and '" + dtTo.Value + "'", cn);
            }
            else
            {
                cm = new SqlCommand("select c.id, c.transno, c.pcode, p.pdesc, c.price, c.qty, c.disc, c.total from tbCart as c inner join tbProduct as p on c.pcode = p.pcode where status like 'Sold' and sdate between '" + dtFrom.Value + "' and '" + dtTo.Value + "' and cashier like '" + cboCashier.Text + "'", cn);
            }
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                total += double.Parse(dr["total"].ToString());
                dgvSold.Rows.Add(i, dr["id"].ToString(), dr["transno"].ToString(), dr["pcode"].ToString(), dr["pdesc"].ToString(), dr["price"].ToString(), dr["qty"].ToString(), dr["disc"].ToString(), dr["total"].ToString());
            }
            dr.Close();
            cn.Close();
            lblTotal.Text = total.ToString("#,##0.00");
        }

        private void cboCashier_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSold();
        }

        private void dtFrom_ValueChanged(object sender, EventArgs e)
        {
            LoadSold();
        }

        private void dtTo_ValueChanged(object sender, EventArgs e)
        {
            LoadSold();
        }

        private void DailySale_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }

        private void dgvSold_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Cashier cashier = new Cashier();
            string colName = dgvSold.Columns[e.ColumnIndex].Name;
            if (colName == "Cancel")
            {
                CancelOrder cancelOrder = new CancelOrder(this);
                cancelOrder.txtId.Text = dgvSold.Rows[e.RowIndex].Cells[1].Value.ToString();
                cancelOrder.txtTransno.Text = dgvSold.Rows[e.RowIndex].Cells[2].Value.ToString();
                cancelOrder.txtPcode.Text = dgvSold.Rows[e.RowIndex].Cells[3].Value.ToString();
                cancelOrder.txtDesc.Text = dgvSold.Rows[e.RowIndex].Cells[4].Value.ToString();
                cancelOrder.txtPrice.Text = dgvSold.Rows[e.RowIndex].Cells[5].Value.ToString();
                cancelOrder.txtQty.Text = dgvSold.Rows[e.RowIndex].Cells[6].Value.ToString();
                cancelOrder.txtDisc.Text = dgvSold.Rows[e.RowIndex].Cells[7].Value.ToString();
                cancelOrder.txtTotal.Text = dgvSold.Rows[e.RowIndex].Cells[8].Value.ToString();
                cancelOrder.txtCancelBy.Text = solduser;
                cancelOrder.ShowDialog();
            }
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            SalesReport report = new SalesReport();
            string param = "Date From: " + dtFrom.Value.ToShortDateString() + " To: " + dtTo.Value.ToShortDateString();

            if (cboCashier.Text == "All Cashier")
            {
                report.LoadDailyReport("select c.id, c.transno, c.pcode, p.pdesc, c.price, c.qty, c.disc as discount, c.total from tbCart as c inner join tbProduct as p on c.pcode = p.pcode where status like 'Sold' and sdate between '" + dtFrom.Value + "' and '" + dtTo.Value + "'", param, cboCashier.Text);
            }
            else
            {
                report.LoadDailyReport("select c.id, c.transno, c.pcode, p.pdesc, c.price, c.qty, c.disc as discount, c.total from tbCart as c inner join tbProduct as p on c.pcode = p.pcode where status like 'Sold' and sdate between '" + dtFrom.Value + "' and '" + dtTo.Value + "' and cashier like '" + cboCashier.Text + "'", param, cboCashier.Text);
            }
            report.ShowDialog();
        }
    }
}
