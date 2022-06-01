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
    public partial class Customers : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        public Customers()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            Loadcustomers();
        }

        public void Loadcustomers()
        {
            int i = 0;
            dgvcustomers.Rows.Clear();
            cm = new SqlCommand("SELECT CustomerName, CustomerType, Address, Phone FROM tbCustomers  WHERE CONCAT(CustomerName, CustomerType, Address, Phone ) LIKE '%" + txtSearch.Text + "%'", cn);
            cn.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvcustomers.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void dgvcustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string colName = dgvcustomers.Columns[e.ColumnIndex].Name;
                if (colName == "Edit")
                {
                    CustumerModule customer = new CustumerModule(this);
                    customer.txtcustomerName.Text = dgvcustomers.Rows[e.RowIndex].Cells[1].Value.ToString();
                    customer.cmbcustomertype.Text = dgvcustomers.Rows[e.RowIndex].Cells[2].Value.ToString();
                    customer.txtaddress.Text = dgvcustomers.Rows[e.RowIndex].Cells[3].Value.ToString();
                    customer.txtPhone.Text = dgvcustomers.Rows[e.RowIndex].Cells[4].Value.ToString();

                   
                    customer.btnSave.Enabled = false;
                   customer.btnUpdate.Enabled = true;
                   customer.ShowDialog();
                }  
                else if (colName == "Delete")
                {
                    if (MessageBox.Show("Are you sure you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cn.Open();
                        cm = new SqlCommand("DELETE FROM tbCustomers WHERE phone LIKE '" + dgvcustomers[4, e.RowIndex].Value.ToString() + "'", cn);
                        cm.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show("Product has been successfully deleted.", "SIM", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                Loadcustomers();
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void btnaddn_Click(object sender, EventArgs e)
        {
            CustumerModule customerm = new CustumerModule(this);
            customerm.ShowDialog();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Loadcustomers();
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
