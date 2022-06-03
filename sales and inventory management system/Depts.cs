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
    public partial class Depts : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        public Depts()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            LoadDepts();
        }

        public void LoadDepts()
        {
            int i = 0;
            dgvDebts.Rows.Clear();
            cm = new SqlCommand("SELECT CustomerName, Type, Phone, transNo, Date,  AmountDept FROM Depts  WHERE CONCAT(CustomerName, Type, transNo,Phone,AmountDept,Date) LIKE '%" + txtSearch.Text + "%'", cn);
            cn.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvDebts.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadDepts();
        }

        private void btnaddn_Click(object sender, EventArgs e)
        {
            Debtsmodule debt = new Debtsmodule(this);
            debt.ShowDialog();
        }

        private void picClose_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }

       

        private void dgvDebts_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string colName = dgvDebts.Columns[e.ColumnIndex].Name;
                if (colName == "Edit")
                {
                    Debtsmodule debts = new Debtsmodule(this);
                    debts.cmbname.Text = dgvDebts.Rows[e.RowIndex].Cells[1].Value.ToString();
                    debts.txttype.Text = dgvDebts.Rows[e.RowIndex].Cells[2].Value.ToString();
                    debts.txtphone.Text = dgvDebts.Rows[e.RowIndex].Cells[3].Value.ToString();
                    debts.txtamount.Text = dgvDebts.Rows[e.RowIndex].Cells[6].Value.ToString();

                    debts.txtamount.Enabled = false;
                    debts.btnSave.Enabled = false;
                    debts.btnUpdate.Enabled = true;
                    debts.ShowDialog();
                }
                else if (colName == "Cart")
                {
                    personal_cart cart = new personal_cart();
                    cart.ShowDialog();
                }
                LoadDepts();
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message);
            }
        }
    }
}
