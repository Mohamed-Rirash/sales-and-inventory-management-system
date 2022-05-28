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
    public partial class UserAccount : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        mainform main;
        public string username;
        string name;
        string role;
       string accstatus;
        public UserAccount(mainform mn)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            main = mn;
            LoadUser();
        }
        public void LoadUser()
        {
            int i = 0;
            dgvUser.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM tbUser", cn);
            cn.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvUser.Rows.Add(i, dr[0].ToString(), dr[3].ToString(), dr[4].ToString(), dr[2].ToString());
            }
            dr.Close();
            cn.Close();
        }

        public void Clear()
        {
            txtName.Clear();
            txtPass.Clear();
            txtRePass.Clear();
            txtUsername.Clear();
            cbRole.Text = "";
            txtUsername.Focus();
        }
        #region add acount
        private void btnAccSave_Click(object sender, EventArgs e)
        {
            var password = txtPass.Text;
            var repassword = txtRePass.Text;

            try
            {
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
                    MessageBox.Show("Password did not March!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                cn.Open();
                cm = new SqlCommand("Insert into tbUser(username, password, role, name) Values (@username, @password, @role, @name)", cn);
                cm.Parameters.AddWithValue("@username", txtUsername.Text);
                cm.Parameters.AddWithValue("@password", hashedpass);
                cm.Parameters.AddWithValue("@role", cbRole.Text);
                cm.Parameters.AddWithValue("@name", txtName.Text);
                cm.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("New account has been successfully saved!", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
                LoadUser();
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, "Warning");
            }
        }





        private void btnAccCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        #endregion add acount

        private void btnPassSave_Click(object sender, EventArgs e)
        {
            var carentpassword = txtCurPass.Text;
            var mainpass = main._pass;
            var curentpass = txtCurPass.Text;
            var password = txtNPass.Text;
            var repassword = txtRePass2.Text;
           
            try
            {
                //declear hash encryption methode
                SHA256 shaa = SHA256.Create();

                // compute hash
                byte[] dataa = shaa.ComputeHash(Encoding.UTF8.GetBytes(curentpass));
                // create string builder
                StringBuilder cbuilder = new StringBuilder();

                for (int i = 0; i < dataa.Length; i++)
                {
                    cbuilder.Append(dataa[i].ToString("x2"));
                }

                // hash password assignment

                var chashedpass = cbuilder.ToString();
                if (mainpass != chashedpass)
                {
                    MessageBox.Show("Current password did not martch!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                             



                if (txtNPass.Text != txtRePass2.Text)
                {
                    MessageBox.Show("Confirm new password did not martch!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
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

                dbcon.ExecuteQuery("UPDATE tbUser SET password= '" + hashedpass + "' WHERE username='" + lblUsername.Text + "'");
                MessageBox.Show("Password has been succefully changed!", "Changed Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearCP();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnPassCancel_Click(object sender, EventArgs e)
        {
            ClearCP();
        }

        public void ClearCP()
        {
            txtCurPass.Clear();
            txtNPass.Clear();
            txtRePass2.Clear();
        }

        private void UserAccount_Load(object sender, EventArgs e)
        {
            lblUsername.Text = main.lblUsername.Text;
        }

        private void dgvUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgvUser.CurrentRow.Index;
            username = dgvUser[1, i].Value.ToString();
            name = dgvUser[2, i].Value.ToString();
            role = dgvUser[4, i].Value.ToString();
            accstatus = dgvUser[3, i].Value.ToString();
            if (lblUsername.Text == username)
            {
                btnRemove.Enabled = false;
                btnResetPass.Enabled = false;
                lblAccNote.Text = "To change your password, go to change password tag.";

            }
            else
            {
                btnRemove.Enabled = true;
                btnResetPass.Enabled = true;
                lblAccNote.Text = "To change the password for " + username + ", click Reset Password.";
            }
            gbUser.Text = "Password For " + username;

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("You chose to remove this account from this Point Of Sales System's user list. \n\n Are you sure you want to remove '" + username + "' \\ '" + role + "'", "User Account", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes))
            {
                dbcon.ExecuteQuery("DELETE FROM tbUser WHERE username = '" + username + "'");
                MessageBox.Show("Account has been successfully deleted");
                LoadUser();
            }
        }

        private void btnProperties_Click(object sender, EventArgs e)
        {
            UserProperties properties = new UserProperties(this);
            properties.Text = name + "\\" + username + " Properties";
            properties.txtName.Text = name;
            properties.cbRole.Text = role;
            properties.cbActivate.Text = accstatus;
            properties.username = username;
            properties.ShowDialog();
        }

        private void btnResetPass_Click(object sender, EventArgs e)
        {
            ResetPassword reset = new ResetPassword(this);
            reset.ShowDialog();
        }
    }
}
