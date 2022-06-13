using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sales_and_inventory_management_system
{
    public partial class Debtsmodule : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        string stitle = "Point Of Sales";
        Depts debts;
        Settle_Payment settle = new Settle_Payment(new Cashier());
        Cashier cashier = new Cashier();

        public Debtsmodule(Depts debt)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            debts = debt;
            fillcustomer();
            Getcustomerinfo();
            
           
              
            

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string moneyPattern = @"^[0-9.]+$";

                if (cmbname.Text == String.Empty)
                {
                    cmbname.Focus();
                    MessageBox.Show("Please  Choose Customer Name", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


                else if (txtamount.Text == String.Empty)
                {
                    txtamount.Focus();
                    MessageBox.Show("Please Enter Amount", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }


                else if (Regex.IsMatch(txtamount.Text, moneyPattern) == false)
                {
                    txtamount.Focus();
                    MessageBox.Show("Please Enter Numberic Values", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                else
                {

                    if (MessageBox.Show("Are you sure want to save this product?", "Save Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cm = new SqlCommand("INSERT INTO Depts(CustomerName, Type, transNo, Date, Phone, AmountDept)VALUES (@CustomerName,@Type,@transNo,@Date,@Phone,@AmountDept)", cn);
                        cm.Parameters.AddWithValue("@CustomerName", cmbname.Text);
                        cm.Parameters.AddWithValue("@Type", txttype.Text);
                        cm.Parameters.AddWithValue("@transNo", cashier.lblTranNo.Text);
                        cm.Parameters.AddWithValue("@Date", cashier.lblDate.Text);
                        cm.Parameters.AddWithValue("@Phone", txtphone.Text);
                        cm.Parameters.AddWithValue("@AmountDept", double.Parse(txtamount.Text));
                        cn.Open();
                        cm.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show("Product has been successfully saved.", stitle);
                        Clear();
                        debts.LoadDepts();

                       
                        this.Dispose();
                        cashier.Show();
                        for (int i = 0; i < cashier.dgvCash.Rows.Count; i++)
                        {
                            cn.Open();
                            cm = new SqlCommand("UPDATE tbProduct SET qty = qty - " + int.Parse(cashier.dgvCash.Rows[i].Cells[5].Value.ToString()) + "WHERE pcode= '" + cashier.dgvCash.Rows[i].Cells[2].Value.ToString() + "'", cn);
                            cm.ExecuteNonQuery();
                            cn.Close();

                            cn.Open();
                            cm = new SqlCommand("UPDATE tbCart SET status = 'Loan' WHERE id= '" + cashier.dgvCash.Rows[i].Cells[1].Value.ToString() + "'", cn);
                            cm.ExecuteNonQuery();
                            cn.Close();
                        }
                        this.Dispose();
                        debts.Dispose();
                        settle.BringToFront();
                    }

                }


                
            }
            catch (Exception ex)
            {

                if (ex is SqlException)
                {
                    MessageBox.Show(txtphone.Text + " Is Allready Their", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtphone.Focus();
                    cn.Close();
                }
                else
                {
                    MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cn.Close();
                }


            }

        }

        private void Clear()
        {
            txtamount.Clear();
            txtphone.Clear();
            txttype.Clear();
            cmbname.SelectedText = "";
        }

        private void validation()
        {
            string moneyPattern = @"^[0-9.]+$";

            if (cmbname.Text == String.Empty)
            {
                cmbname.Focus();
                MessageBox.Show("Please  Choose Customer Name", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            else if (txtamount.Text == String.Empty)
            {
                txtamount.Focus();
                MessageBox.Show("Please Enter Amount", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }


            else if (Regex.IsMatch(txtamount.Text, moneyPattern) == false)
            {
                txtamount.Focus();
                MessageBox.Show("Please Enter Numberic Values", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                double total = double.Parse(pamout.Text ) + double.Parse(txtamount.Text);
                if (cmbname.Text == String.Empty)
                {
                    cmbname.Focus();
                    MessageBox.Show("Please  Choose Customer Name", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (MessageBox.Show("Are you sure want to update this Debt person?", "Update Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cm = new SqlCommand("UPDATE Depts SET CustomerName=@CustomerName,Type=@Type,Phone=@Phone, AmountDept=@AmountDept WHERE Phone LIKE @Phone", cn);
                        cm.Parameters.AddWithValue("@CustomerName", cmbname.Text);
                        cm.Parameters.AddWithValue("@Type", txttype.Text);
                        cm.Parameters.AddWithValue("@Phone", txtphone.Text);
                        cm.Parameters.AddWithValue("@AmountDept", total );

                        cn.Open();
                        cm.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show("Amount has been successfully updated.", stitle);
                        Clear();
                        this.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cn.Close();
            }
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }


        // get customer name
        private void Getcustomerinfo()
        {
            try
            {
                cn.Open();
                cm = new SqlCommand("SELECT CustomerName, CustomerType, Phone FROM tbCustomers where CustomerName = @CustomerName", cn);
                cm.Parameters.AddWithValue("@CustomerName", cmbname.SelectedValue.ToString());
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cm);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    txttype.Text = dr["CustomerType"].ToString();
                    txtphone.Text = dr["Phone"].ToString();
                }
                cn.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


        private void fillcustomer()
        {
            cn.Open();
            cm = new SqlCommand("select CustomerName from tbCustomers", cn);
            SqlDataReader dr = cm.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("DriverUsername", typeof(string));
            dt.Load(dr);
            cmbname.ValueMember = "CustomerName";
            cmbname.DataSource = dt;
            cn.Close();
        }

        private void cmbname_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Getcustomerinfo();
        }
        CustumerModule module = new CustumerModule(new Customers());
        private void btnnewcustomer_Click(object sender, EventArgs e)
        {
            this.Dispose();
            module.ShowDialog();

        }
    }
}
