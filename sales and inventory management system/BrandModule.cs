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
    public partial class BrandModule : Form
    {
        SqlConnection cn = new SqlConnection();

        public UserPreferenceChangedEventHandler UserPreferenceChanged { get; }

        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        Brand brand;

        public BrandModule(Brand br)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            UserPreferenceChanged = new UserPreferenceChangedEventHandler(SystemEvents_UserPreferenceChanged);
            SystemEvents.UserPreferenceChanged += UserPreferenceChanged;
            this.Disposed += new EventHandler(Form_Disposed);
            LoadTheme();
            brand = br;
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

            panel1.BackColor = themeColor;


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
        #region brand buttons
        private void picClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
         
            try
            {
                string NamePattern = @"^[a-zA-Z 0-9]+$";
               
                if (txtBrand.Text == String.Empty)
                {
                    txtBrand.Focus();
                    MessageBox.Show(" Fill the category");
                }
                else if (Regex.IsMatch(txtBrand.Text, NamePattern) == false)
                {

                    txtBrand.Focus();
                    MessageBox.Show("Please Enter charectors only");
                    return;
                }
                else
                {
                    if (MessageBox.Show("Are you sure you want to save this brand?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cn.Open();
                        cm = new SqlCommand("INSERT INTO tbBrand(brand)VALUES(@brand)", cn);
                        cm.Parameters.AddWithValue("@brand", txtBrand.Text);
                        cm.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show("Record has been successful saved.", "Sale MS");
                        Clear();
                        brand.LoadBrand();
                    }
                }

            }
            catch (Exception ex)
            {
                if (ex is SqlException)
                {
                    MessageBox.Show(txtBrand.Text + " Is Allready Their", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBrand.Focus();
                    cn.Close();
                }
                else
                {
                    MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cn.Close();
                }

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
           Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Update brand name
            try
            {
                string NamePattern = @"^[a-zA-Z 0-9]+$";
                if (txtBrand.Text == String.Empty)
                {
                    txtBrand.Focus();
                    MessageBox.Show(" Fill the category");
                }
                else if (Regex.IsMatch(txtBrand.Text, NamePattern) == false)
                {

                    txtBrand.Focus();
                    MessageBox.Show("Please Enter charectors only");
                    return;
                }
                if (MessageBox.Show("Are you sure you want to update this brand?", "Update Record!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("UPDATE tbBrand SET brand = @brand WHERE id LIKE'" + lblId.Text + "'", cn);
                    cm.Parameters.AddWithValue("@brand", txtBrand.Text);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Brand has been successfully updated.", "Sale MS");
                    Clear();
                    this.Dispose();// To close this form after update data
                }
            }
            catch (Exception ex)
            {

                if (ex is SqlException)
                {
                    MessageBox.Show(txtBrand.Text + " Is Allready Their", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBrand.Focus();
                    cn.Close();
                }
                else
                {
                    MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cn.Close();
                }
            }
        }
# endregion brand buttons


        public void Clear()
        {
            txtBrand.Clear();
        }
    }
}
