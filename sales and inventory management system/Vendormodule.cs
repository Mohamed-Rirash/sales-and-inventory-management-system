using Microsoft.Win32;
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
    public partial class Vendormodule : Form
    {
        SqlConnection cn = new SqlConnection();
        private UserPreferenceChangedEventHandler UserPreferenceChanged;
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        Vendor vendor;
        public Vendormodule(Vendor vr)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            UserPreferenceChanged = new UserPreferenceChangedEventHandler(SystemEvents_UserPreferenceChanged);
            SystemEvents.UserPreferenceChanged += UserPreferenceChanged;
            this.Disposed += new EventHandler(Form_Disposed);
            LoadTheme();
            vendor = vr;
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
                button.BackColor = darkColor;
            }
        }



        #endregion

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
                string phonePattern = @"^[0-9]+$";
                string namePattern = @"^[a-z A-Z]+$";
                string addresspattern = @"^[a-z A-Z0-9]+$";
                string emailpattern = @"^[a-z A-Z0-9@.]+$";
                if (txtSupplier.Text == String.Empty)
                {
                    MessageBox.Show("Please Enter Supplier Name ", "empty field", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSupplier.Focus();
                }
                else if (Regex.IsMatch(txtSupplier.Text, namePattern) == false)
                {
                    txtSupplier.Focus();
                    MessageBox.Show("Please Enter Alphabetic Values", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (txtAddress.Text == String.Empty)
                {
                    MessageBox.Show("Please Enter Address ", "empty field", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAddress.Focus();

                }
                else if (Regex.IsMatch(txtAddress.Text, addresspattern) == false)
                {
                    txtAddress.Focus();
                    MessageBox.Show("Please Enter Alpha numberic Values", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (txtConPerson.Text == String.Empty)
                {
                    MessageBox.Show("Please Enter  contact person", "empty field", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtConPerson.Focus();

                }
                else if (Regex.IsMatch(txtConPerson.Text, namePattern) == false)
                {
                    MessageBox.Show("Please Enter Alphabetic Values", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtConPerson.Focus();

                }
                else if (txtPhone.Text == String.Empty)
                {
                    MessageBox.Show("Please Enter  Phone Number", "empty field", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPhone.Focus();

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

                else if (txtFaxNo.Text == String.Empty)
                {
                    MessageBox.Show("Please Enter Fax NO", "empty field", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtFaxNo.Focus();

                }
                else if (txtFaxNo.Text.Length > 10)
                {
                    txtFaxNo.Focus();
                    MessageBox.Show("invalid Fax Number", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else if (Regex.IsMatch(txtFaxNo.Text, phonePattern) == false)
                {
                    txtFaxNo.Focus();
                    MessageBox.Show("Please Enter Numberic Values", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                else if (txtEmail.Text == String.Empty)
                {
                    MessageBox.Show("Please Enter Email", "empty field", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEmail.Focus();

                }
                else if (Regex.IsMatch(txtEmail.Text,emailpattern) == false)
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
