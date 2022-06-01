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
    public partial class CustumerModule : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        string stitle = "Point Of Sales";
        Customers Customers;
        public CustumerModule(Customers custo)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            Customers = custo;
          
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string phonePattern = @"^[0-9]+$";
                string namePattern = @"^[a-z A-Z]+$";
                string addresspattern = @"^[a-z A-Z0-9]+$";
                if (txtcustomerName.Text == String.Empty)
                {
                    txtcustomerName.Focus();
                    MessageBox.Show("Please  Enter Customer Name", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Regex.IsMatch(txtcustomerName.Text, namePattern) == false)
                {
                    txtcustomerName.Focus();
                    MessageBox.Show("Please Enter Alphabrtic Values", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (cmbcustomertype.Text == string.Empty)
                {
                    cmbcustomertype.Focus();
                    MessageBox.Show("Please choose a customer type","information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else if (Regex.IsMatch(txtaddress.Text, addresspattern) == false)
                {
                    txtaddress.Focus();
                    MessageBox.Show("Please Enter Alpha numberic Values", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (txtPhone.Text == String.Empty)
                {
                    txtPhone.Focus();
                    MessageBox.Show("Please Enter Phone Number", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else if (txtPhone.Text.Length > 10 )
                {
                    txtPhone.Focus();
                    MessageBox.Show("Please Enter Correct format of Phone Number", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else if (txtPhone.Text.Length < 10)
                {
                    txtPhone.Focus();
                    MessageBox.Show("Please Phone Number must not less then 10 digits", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else if (Regex.IsMatch(txtPhone.Text, phonePattern) == false)
                {
                    txtPhone.Focus();
                    MessageBox.Show("Please Enter Numberic Values", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
               
                
                else
                {

                    if (MessageBox.Show("Are you sure want to save this Customer?", "Save Customer", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cm = new SqlCommand("INSERT INTO tbCustomers(CustomerName, CustomerType, Address, Phone)VALUES (@CustomerName,@CustomerType, @Address, @Phone)", cn);
                        cm.Parameters.AddWithValue("@CustomerName", txtcustomerName.Text);
                        cm.Parameters.AddWithValue("@CustomerType", cmbcustomertype.SelectedItem);
                        cm.Parameters.AddWithValue("@Address", txtaddress.Text);
                        cm.Parameters.AddWithValue("@Phone", txtPhone.Text);
                        cn.Open();
                        cm.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show("Cutomer successfully saved.", stitle);
                        Clear();
                        Customers.Loadcustomers();
                    }


                }
            }
            catch (Exception ex)
            {
                if (ex is SqlException)
                {
                    MessageBox.Show(txtPhone.Text + " Is Allready Their", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPhone.Focus();
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
            txtPhone.Clear();
            txtcustomerName.Clear();
            txtaddress.Clear();
            cmbcustomertype.SelectedIndex = 0;
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string phonePattern = @"^[0-9]+$";
                string namePattern = @"^[a-z A-Z]+$";
                string addresspattern = @"^[a-z A-Z0-9]+$";
                if (txtcustomerName.Text == String.Empty)
                {
                    txtcustomerName.Focus();
                    MessageBox.Show("Please  Enter Customer Name", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Regex.IsMatch(txtcustomerName.Text, namePattern) == false)
                {
                    txtcustomerName.Focus();
                    MessageBox.Show("Please Enter Alphabrtic Values", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (cmbcustomertype.Text == string.Empty)
                {
                    cmbcustomertype.Focus();
                    MessageBox.Show("Please choose a customer type", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else if (txtaddress.Text == string.Empty)
                {
                    cmbcustomertype.Focus();
                    MessageBox.Show("Please Enter a customer Address", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else if (Regex.IsMatch(txtaddress.Text, addresspattern) == false)
                {
                    txtaddress.Focus();
                    MessageBox.Show("Please Enter Alpha numberic Values", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (txtPhone.Text == String.Empty)
                {
                    txtPhone.Focus();
                    MessageBox.Show("Please Enter Phone Number", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else if (txtPhone.Text.Length > 10)
                {
                    txtPhone.Focus();
                    MessageBox.Show("Please Enter Correct format of Phone Number", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else if (txtPhone.Text.Length < 10)
                {
                    txtPhone.Focus();
                    MessageBox.Show("Please Phone Number must not less then 10 digits", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else if (Regex.IsMatch(txtPhone.Text, phonePattern) == false)
                {
                    txtPhone.Focus();
                    MessageBox.Show("Please Enter Numberic Values", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                else
                {
                    if (MessageBox.Show("Are you sure want to update this Customer Info?", "Update Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cm = new SqlCommand("UPDATE tbCustomers SET CustomerName=@CustomerName,CustomerType=@CustomerType,Address=@Address,Phone=@Phone WHERE Phone LIKE @Phone", cn);
                        cm.Parameters.AddWithValue("@CustomerName", txtcustomerName.Text);
                        cm.Parameters.AddWithValue("@CustomerType", cmbcustomertype.SelectedValue);
                        cm.Parameters.AddWithValue("@Address", txtaddress.Text);
                        cm.Parameters.AddWithValue("@Phone", txtPhone.Text);
                        cn.Open();
                        cm.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show("Product has been successfully updated.", stitle);
                        Clear();
                        this.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {

                if (ex is SqlException)
                {
                    MessageBox.Show(txtPhone.Text + " Is Allready Their", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPhone.Focus();
                    cn.Close();
                }
                else
                {
                    MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cn.Close();
                }
            }
        }
    }
}
