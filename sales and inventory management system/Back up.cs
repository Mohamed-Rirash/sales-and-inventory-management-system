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
    public partial class Back_up : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        
        public Back_up()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
        }

        private void btnbrows_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtpath.Text = dlg.SelectedPath;
                btnbackup.Enabled = true;
            }
        }

        private void btnbackup_Click(object sender, EventArgs e)
        {
            string database = cn.Database.ToString();
            if (txtpath.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Backup File Location");
            }

            else
            {

                string cmd = "BACKUP DATABASE[" + database + "] TO DISK= '" + txtpath.Text + "\\" + "database" + "-" + DateTime.Now.ToString("yyy--MMM--dd--hh--mm--ss") + ".bak'";
                cn.Open();
                SqlCommand command = new SqlCommand(cmd, cn);
                command.ExecuteNonQuery();
                MessageBox.Show("Database Backup Done Successfuly");
                cn.Close();
                btnbackup.Enabled = false;
            }
        }
    }
}
