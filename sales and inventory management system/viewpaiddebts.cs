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
    public partial class viewpaiddebts : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        public viewpaiddebts()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            LoadpDepts();
        }

        public void LoadpDepts()
        {
            int i = 0;
            dgvDebts.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("SELECT CustomerName, Type, Phone, transNo, Date,  AmountDept FROM paidpeople  WHERE CONCAT(CustomerName, Type, transNo,Phone,AmountDept,Date) LIKE '%" + txtSearch.Text + "%'", cn);
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
    }
}
