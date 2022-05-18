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
    public partial class CategoryModule : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        Category category;
        public CategoryModule(Category ct)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            category = ct;
        }

        #region category buttons

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string categorypattern = @"^[a-zA-Z]+$";
                if (txtCategory.Text == String.Empty)
                {
                    txtCategory.Focus();
                    MessageBox.Show(" Fill the category");
                }
                else if (Regex.IsMatch(txtCategory.Text, categorypattern) == false)
                {

                    txtCategory.Focus();
                    MessageBox.Show("Please Enter charectors only");
                    return;
                }
                else
                {
                    if (MessageBox.Show("Are you sure you want to update this category?", "Update Record!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cn.Open();
                        cm = new SqlCommand("UPDATE tbCategory SET category = @category WHERE id LIKE'" + lblId.Text + "'", cn);
                        cm.Parameters.AddWithValue("@category", txtCategory.Text);
                        cm.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show("Category has been successfully updated.", "Sales MS");
                        Clear();
                        this.Dispose();// To close this form after update data
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex is SqlException)
                {
                    MessageBox.Show(txtCategory.Text + " Is Allready Their", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCategory.Focus();
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
               
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string categorypattern = @"^[a-zA-Z]+$";
                if (txtCategory.Text == String.Empty)
                {
                    txtCategory.Focus();
                    MessageBox.Show(" Fill the category");
                }
                else if (Regex.IsMatch(txtCategory.Text, categorypattern) == false)
                {

                    txtCategory.Focus();
                    MessageBox.Show("Please Enter charectors only");
                    return;
                }
                

                else
                {
                    

                    if (MessageBox.Show("Are you sure you want to save this Category?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cn.Open();
                        cm = new SqlCommand("INSERT INTO tbCategory(category)VALUES(@category)", cn);
                        cm.Parameters.AddWithValue("@category", txtCategory.Text);
                        cm.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show("Record has been successful saved.", "Sales MS");
                        Clear();
                    }
                    category.LoadCategory();

            }
        }
            catch (Exception ex)
            {                               
                if (ex is SqlException)
                {
                    MessageBox.Show(txtCategory.Text + " Is Allready Their" ,"Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    txtCategory.Focus();
                    cn.Close();
                }
                else
                {
                    MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cn.Close();
                }
            }
}
        #endregion category buttons

        // clear textbox
        public void Clear()
        {
            txtCategory.Clear();
            txtCategory.Focus();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }

        private void CategoryModule_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }
    }
}
