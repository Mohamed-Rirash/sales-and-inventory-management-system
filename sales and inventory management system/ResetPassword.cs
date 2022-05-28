using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sales_and_inventory_management_system
{
    public partial class ResetPassword : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        UserAccount user;
        public ResetPassword(UserAccount account)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            user = account;
        }

        private void iconPictureBox2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var password = txtNpass.Text;
            var repassword = txtResPass.Text;
            //declear hash encryption methode
            SHA256 sha = SHA256.Create();

            // compute hash
            byte[] data = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            // create string builder
            StringBuilder sbuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sbuilder.Append(data[i].ToString("x2"));
            }

            // hash password assignment

            var hashedpass = sbuilder.ToString();
            if (password != repassword)
            {
                MessageBox.Show("The password you typed do not match. Type the password for this account in both text boxes.", "Add User Wizard", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {

                if (MessageBox.Show("Reset password?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    dbcon.ExecuteQuery("UPDATE tbUser SET password = '" + hashedpass + "'WHERE username = '" + user.username + "'");
                    MessageBox.Show("Password has been successfully reset", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                }
            }
        }

        private void ResetPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }
    }
}
