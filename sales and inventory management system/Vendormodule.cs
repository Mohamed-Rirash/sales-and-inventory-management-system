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
    public partial class Vendormodule : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        Vendor vendor;
        public Vendormodule(Vendor vr)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            vendor = vr;
        }
        #region buttons
        private void picClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSupplier.Text == "")
                {
                    MessageBox.Show("Please Enter Supplier Name ", "empty field", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSupplier.Focus();
                }
                else if (txtAddress.Text == "")
                {
                    MessageBox.Show("Please Enter Address ", "empty field", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAddress.Focus();

                }
                else if (txtPhone.Text == "")
                {
                    MessageBox.Show("Please Enter  Phone NO", "empty field", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPhone.Focus();

                }
                else if (txtConPerson.Text == "")
                {
                    MessageBox.Show("Please Enter  contact person", "empty field", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtConPerson.Focus();

                }
                else if (txtFaxNo.Text == "")
                {
                    MessageBox.Show("Please Enter Fax NO", "empty field", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtFaxNo.Focus();

                }
                else if (txtEmail.Text == "")
                {
                    MessageBox.Show("Please Enter Email", "empty field", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEmail.Focus();

                }
                else
                {
                    if (MessageBox.Show("Update this record? click yes to confirm.", "CONFIRM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cn.Open();
                        cm = new SqlCommand("Update tbSupplier set supplier=@supplier, address=@address, contactperson=@contactperson, phone=@phone, email=@email, fax=@fax where id=@id ", cn);
                        cm.Parameters.AddWithValue("@id", lblId.Text);
                        cm.Parameters.AddWithValue("@supplier", txtSupplier.Text);
                        cm.Parameters.AddWithValue("@address", txtAddress.Text);
                        cm.Parameters.AddWithValue("@contactperson", txtConPerson.Text);
                        cm.Parameters.AddWithValue("@phone", txtPhone.Text);
                        cm.Parameters.AddWithValue("@email", txtEmail.Text);
                        cm.Parameters.AddWithValue("@fax", txtFaxNo.Text);
                        cm.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show("Record has been successfully updated!", "Update Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSupplier.Text == "")
                {
                    MessageBox.Show("Please Enter Supplier Name ", "empty field", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSupplier.Focus();
                }
                else if (txtAddress.Text == "")
                {
                    MessageBox.Show("Please Enter Address ", "empty field", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAddress.Focus();

                }
                else if (txtPhone.Text == "")
                {
                    MessageBox.Show("Please Enter  Phone NO", "empty field", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPhone.Focus();

                }
                else if (txtConPerson.Text == "")
                {
                    MessageBox.Show("Please Enter  contact person", "empty field", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtConPerson.Focus();

                }
                else if (txtFaxNo.Text == "")
                {
                    MessageBox.Show("Please Enter Fax NO", "empty field", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtFaxNo.Focus();

                }
                else if (txtEmail.Text == "")
                {
                    MessageBox.Show("Please Enter Email", "empty field", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEmail.Focus();

                }
                else
                {
                    if (MessageBox.Show("Save this record? click yes to confirm.", "CONFIRM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cn.Open();
                        cm = new SqlCommand("Insert into tbSupplier (supplier, address, contactperson, phone, email, fax) values (@supplier, @address, @contactperson, @phone, @email, @fax) ", cn);
                        cm.Parameters.AddWithValue("@supplier", txtSupplier.Text);
                        cm.Parameters.AddWithValue("@address", txtAddress.Text);
                        cm.Parameters.AddWithValue("@contactperson", txtConPerson.Text);
                        cm.Parameters.AddWithValue("@phone", txtPhone.Text);
                        cm.Parameters.AddWithValue("@email", txtEmail.Text);
                        cm.Parameters.AddWithValue("@fax", txtFaxNo.Text);
                        cm.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show("Record has been successfully saved!", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();
                        vendor.LoadVendor();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        #endregion buttons
        // clearing function
        public void Clear()
        {
            txtAddress.Clear();
            txtConPerson.Clear();
            txtEmail.Clear();
            txtFaxNo.Clear();
            txtPhone.Clear();
            txtSupplier.Clear();

            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            txtSupplier.Focus();
        }

        private void Vendormodule_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }
    }
}
