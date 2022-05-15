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
                if (txtPcode.Text == "")
                {
                    MessageBox.Show("Please Enter Product Code ", "empty field", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPcode.Focus();
                }
                else if (txtBarcode.Text == "")
                {
                    MessageBox.Show("Please Enter Product Barcode ", "empty field", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBarcode.Focus();

                }
                else if (txtPrice.Text == "")
                {
                    MessageBox.Show("Please Enter Product Price", "empty field", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPrice.Focus();

                }
                else if (txtPdesc.Text == "")
                {
                    MessageBox.Show("Please Enter Product discription", "empty field", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPdesc.Focus();

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

                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPcode.Text == "" )
                {
                    MessageBox.Show("Please Enter Product Code ", "empty field", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPcode.Focus();
                }
                else if(txtBarcode.Text == "")
                {
                    MessageBox.Show("Please Enter Product Barcode ", "empty field", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBarcode.Focus();

                }
                else if(txtPrice.Text == "")
                {
                    MessageBox.Show("Please Enter Product Price", "empty field", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPrice.Focus();

                }
                else if (txtPdesc.Text == "")
                {
                    MessageBox.Show("Please Enter Product discription", "empty field", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPdesc.Focus();

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
                MessageBox.Show(ex.Message);
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
