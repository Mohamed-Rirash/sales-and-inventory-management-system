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
    public partial class ProductModule : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        string stitle = "Point Of Sales";
        Product product;
        public ProductModule(Product pd)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            product = pd;
            LoadBrand();
            LoadCategory();
        }
        #region product madule buttons
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
                string PricePattern = @"^[0-9.]+$";
                string DescPattern = @"^[a-z A-Z0-9]+$";
                string CodePattern = @"^[a-zA-Z0-9]+$";
                if (txtPcode.Text == String.Empty)
                {
                    txtPcode.Focus();
                    MessageBox.Show("Please  Enter Product Code", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Regex.IsMatch(txtPcode.Text, CodePattern) == false)
                {
                    txtPcode.Focus();
                    MessageBox.Show("Please Enter Alpha numberic Values", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (Regex.IsMatch(txtBarcode.Text, CodePattern) == false)
                {
                    txtBarcode.Focus();
                    MessageBox.Show("Please Enter Alpha numberic Values", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (Regex.IsMatch(txtPdesc.Text, DescPattern) == false)
                {
                    txtPdesc.Focus();
                    MessageBox.Show("Please Enter Alpha numberic Values", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (txtPrice.Text == string.Empty)
                {
                    txtPrice.Focus();
                    MessageBox.Show("Please Enter Product Price", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (Regex.IsMatch(txtPrice.Text, PricePattern) == false)
                {
                    txtPrice.Focus();
                    MessageBox.Show("Please Enter numberic or decimal Values ", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    if (MessageBox.Show("Are you sure want to update this product?", "Update Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cm = new SqlCommand("UPDATE tbProduct SET barcode=@barcode,pdesc=@pdesc,bid=@bid,cid=@cid,price=@price, reorder=@reorder WHERE pcode LIKE @pcode", cn);
                        cm.Parameters.AddWithValue("@pcode", txtPcode.Text);
                        cm.Parameters.AddWithValue("@barcode", txtBarcode.Text);
                        cm.Parameters.AddWithValue("@pdesc", txtPdesc.Text);
                        cm.Parameters.AddWithValue("@bid", cboBrand.SelectedValue);
                        cm.Parameters.AddWithValue("@cid", cboCategory.SelectedValue);
                        cm.Parameters.AddWithValue("@price", double.Parse(txtPrice.Text));
                        cm.Parameters.AddWithValue("@reorder", UDReOrder.Value);
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
                    MessageBox.Show(txtPcode.Text + " Is Allready Their", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPcode.Focus();
                    cn.Close();
                }
                else
                {
                    MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cn.Close();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string PricePattern = @"^[0-9.]+$";
                string DescPattern = @"^[a-z A-Z0-9]+$";
                string CodePattern = @"^[a-zA-Z0-9]+$";
                if (txtPcode.Text == String.Empty)
                {
                    txtPcode.Focus();
                    MessageBox.Show("Please  Enter Product Code", "information", MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else if (Regex.IsMatch(txtPcode.Text, CodePattern) == false)
                {
                    txtPcode.Focus();
                    MessageBox.Show("Please Enter Alpha numberic Values", "information", MessageBoxButtons.OK,MessageBoxIcon.Information);
                    return;
                }
                /*else if (Regex.IsMatch(txtBarcode.Text, CodePattern) == false)
                {
                    txtBarcode.Focus();
                    MessageBox.Show("Please Enter Alpha numberic Values", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }*/
                else if (Regex.IsMatch(txtPdesc.Text, DescPattern) == false)
                {
                    txtPdesc.Focus();
                    MessageBox.Show("Please Enter Alpha numberic Values", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (txtPrice.Text == string.Empty)
                {
                    txtPrice.Focus();
                    MessageBox.Show("Please Enter Product Price", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (Regex.IsMatch(txtPrice.Text, PricePattern) == false)
                {
                    txtPrice.Focus();
                    MessageBox.Show("Please Enter numberic or decimal Values ", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {

                    if (MessageBox.Show("Are you sure want to save this product?", "Save Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cm = new SqlCommand("INSERT INTO tbProduct(pcode, barcode, pdesc, bid, cid, price, reorder)VALUES (@pcode,@barcode,@pdesc,@bid,@cid,@price, @reorder)", cn);
                        cm.Parameters.AddWithValue("@pcode", txtPcode.Text);
                        cm.Parameters.AddWithValue("@barcode", txtBarcode.Text);
                        cm.Parameters.AddWithValue("@pdesc", txtPdesc.Text);
                        cm.Parameters.AddWithValue("@bid", cboBrand.SelectedValue);
                        cm.Parameters.AddWithValue("@cid", cboCategory.SelectedValue);
                        cm.Parameters.AddWithValue("@price", double.Parse(txtPrice.Text));
                        cm.Parameters.AddWithValue("@reorder", UDReOrder.Value);
                        cn.Open();
                        cm.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show("Product has been successfully saved.", stitle);
                        Clear();
                        product.LoadProduct();
                    }


                }
            }
            catch (Exception ex)
            {
                if (ex is SqlException)
                {
                    MessageBox.Show(txtPcode.Text + " Is Allready Their", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPcode.Focus();
                    cn.Close();
                }
                else
                {
                    MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cn.Close();
                }
            }
        }

#endregion buttons

        public void Clear()
        {
            txtPcode.Clear();
            txtBarcode.Clear();
            txtPdesc.Clear();
            txtPrice.Clear();
            cboBrand.SelectedIndex = 0;
            cboCategory.SelectedIndex = 0;
            UDReOrder.Value = 1;

            txtPcode.Enabled = true;
            txtPcode.Focus();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }

        // loud data in brand and category

        public void LoadCategory()
        {
            cboCategory.Items.Clear();
            cboCategory.DataSource = dbcon.getTable("SELECT * FROM tbCategory");
            cboCategory.DisplayMember = "category";
            cboCategory.ValueMember = "id";
        }

        public void LoadBrand()
        {
            cboBrand.Items.Clear();
            cboBrand.DataSource = dbcon.getTable("SELECT * FROM tbBrand");
            cboBrand.DisplayMember = "brand";
            cboBrand.ValueMember = "id";
        }

        private void ProductModule_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }
        // txtprice validation
        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;
        }
    }
}
