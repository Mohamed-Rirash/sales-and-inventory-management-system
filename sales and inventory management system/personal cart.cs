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
    public partial class personal_cart : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        Cashier cashier = new Cashier();
        public personal_cart()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            cashier.LoadCart();        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void Loadcart()
        {
            int i = 0;
            dgvcart.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM tbCart  WHERE transno LIKE '%" + dgvcart.SelectedRows + "%'", cn);
            cn.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvcart.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), dr[9].ToString(), dr[10].ToString());
            }
            dr.Close();
            cn.Close();
        }

    }
}
