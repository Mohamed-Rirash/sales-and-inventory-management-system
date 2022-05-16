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
    public partial class Cashier : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;

        int qty;
        string id;
        string price;

        string stitle = "Point Of Sales";

        public Cashier()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
           // GetTranNo();
            lblDate.Text = DateTime.Now.ToShortDateString();
        }
        public void slide(Button button)
        {

            panelSlide.Location = new Point(0, button.Location.Y);
            panelSlide.BackColor = Color.White;
            panelSlide.Height = button.Height;
        }
        #region buttons
        private void btnNTran_Click(object sender, EventArgs e)
        {
            slide(btnNTran);
            GetTranNo();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            slide(btnSearch);
            LookUpProduct lookUp = new LookUpProduct(this);
            lookUp.LoadProduct();
            lookUp.ShowDialog();

        }

        private void btnDiscount_Click(object sender, EventArgs e)
        {
            slide(btnDiscount);

        }

        private void btnSettle_Click(object sender, EventArgs e)
        {
            slide(btnSettle);

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            slide(btnClear);

        }

        private void btnDSales_Click(object sender, EventArgs e)
        {
            slide(btnDSales);

        }

        private void btncustomers_Click(object sender, EventArgs e)
        {
            slide(btncustomers);


        }

        private void btnDepts_Click(object sender, EventArgs e)
        {
            slide(btnDepts);

        }

        private void btnPass_Click(object sender, EventArgs e)
        {
            slide(btnPass);

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            slide(btnLogout);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTimer.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }
        #endregion

        public void LoadCart()
        {
            try
            {
                Boolean hascart = false;
                int i = 0;
                double total = 0;
                double discount = 0;
                dgvCash.Rows.Clear();
                cn.Open();
                cm = new SqlCommand("SELECT c.id, c.pcode, p.pdesc, c.price, c.qty, c.disc, c.total FROM tbCart AS c INNER JOIN tbProduct AS p ON c.pcode=p.pcode WHERE c.transno LIKE @transno and c.status LIKE 'Pending'", cn);
                cm.Parameters.AddWithValue("@transno", lblTranNo.Text);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {

                    i++;
                    total += Convert.ToDouble(dr["total"].ToString());
                    discount += Convert.ToDouble(dr["disc"].ToString());
                    dgvCash.Rows.Add(i, dr["id"].ToString(), dr["pcode"].ToString(), dr["pdesc"].ToString(), dr["price"].ToString(), dr["qty"].ToString(), dr["disc"].ToString(), double.Parse(dr["total"].ToString()).ToString("#,##0.00"));//
                    hascart = true;
                }
                dr.Close();
                cn.Close();
                lblSaleTotal.Text = total.ToString("#,##0.00");
                lblDiscount.Text = discount.ToString("#,##0.00");
                GetCartTotal();
                if (hascart) { btnClear.Enabled = true; btnSettle.Enabled = true; btnDiscount.Enabled = true; }
                else { btnClear.Enabled = false; btnSettle.Enabled = false; btnDiscount.Enabled = false; }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, stitle);
            }
        }
        public void GetCartTotal()
        {
            double discount = double.Parse(lblDiscount.Text);
            double sales = double.Parse(lblSaleTotal.Text) - discount;
            double vat = sales * 0.12;//VAT: 12% of VAT Payable (Output Tax less Input Tax)
            double vatable = sales - vat;

            lblVat.Text = vat.ToString("#,##0.00");
            lblVatable.Text = vatable.ToString("#,##0.00");
            lblDisplayTotal.Text = sales.ToString("#,##0.00");
        }

        public void GetTranNo()
        {
            try
            {
                string sdate = DateTime.Now.ToString("yyyyMMdd");
                int count;
                string transno;
                cn.Open();
                cm = new SqlCommand("SELECT TOP 1 transno FROM tbCart WHERE transno LIKE '" + sdate + "%' ORDER BY id desc", cn);
                dr = cm.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    transno = dr[0].ToString();
                    count = int.Parse(transno.Substring(8, 4));
                    lblTranNo.Text = sdate + (count + 1);
                }
                else
                {
                    transno = sdate + "1001";
                    lblTranNo.Text = transno;
                }
                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {

                cn.Close();
                MessageBox.Show(ex.Message, stitle);

            }

        }
    }
}
