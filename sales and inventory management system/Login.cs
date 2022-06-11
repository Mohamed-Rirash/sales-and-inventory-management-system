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
    public partial class Login : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;

        public string _pass = "";
       
        public bool _isactivate;
        public Login()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit Application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
       public string _username = "", _name = "", _role = "";
        int attempt = 1;
        private void attem()
        {
            MessageBox.Show("Invalid username and password!", "ACCESS DENIED", MessageBoxButtons.OK, MessageBoxIcon.Information);
            attempt++;
            if (attempt < 4)
            {
                return;
            }

        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            var password = txtPass.Text;

            try
            {
                
                if (txtName.Text == "UserName" || txtPass.Text == "Password")
                {
                    MessageBox.Show("Please Fill UserName and Password", "Empty space", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtName.Focus();
                }
                else
                {
                    //declear hash encryption methode
                    SHA256 sha = SHA256.Create();
                    bool found;
                    cn.Open();
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

                    cm = new SqlCommand("Select * From tbUser Where username = @username and password = @password", cn);
                    cm.Parameters.AddWithValue("@username", txtName.Text);
                    cm.Parameters.AddWithValue("@password", hashedpass);
                    dr = cm.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        found = true;
                        _username = dr["username"].ToString();
                        _name = dr["name"].ToString();
                        _role = dr["role"].ToString();
                        _pass = dr["password"].ToString();
                        _isactivate = bool.Parse(dr["isactivate"].ToString());

                    }
                    else
                    {
                        found = false;
                    }
                    dr.Close();
                    cn.Close();

                    if (found)
                    {
                        if (!_isactivate)
                        {
                            MessageBox.Show("Account is deactivate. Unable to login", "Inactive Account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (_role == "Cashier")
                        {
                            MessageBox.Show("Welcome " + _name + " |", "ACCESS GRANTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtName.Clear();
                            txtPass.Clear();
                            this.Hide();
                            Cashier cashier = new Cashier();
                            cashier.lblUsername.Text = _username;
                            cashier.lblname.Text = _name + " | " + _role;
                            cashier.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Welcome " + _name + " |", "ACCESS GRANTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtName.Clear();
                            txtPass.Clear();
                            this.Hide();
                            mainform main = new mainform();
                            main.lblUsername.Text = _username;
                            main.lblName.Text = _name;
                            main._pass = _pass;
                            main.ShowDialog();
                        }
                    }
                    else
                    {
                        attem();


                    }
                    
                    if (attempt == 4)
                    {
                        MessageBox.Show("You reached  the maximum Number of attempts! \n please request admin to reset your password");
                        txtName.Enabled = false;
                        txtPass.Enabled = false;
                        btnLogin.Enabled = false;
                        llblhelp.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        


        }
        

        private void btnexit_Click(object sender, EventArgs e)
        {Task.Run(() =>
            exit());
        }

        private static void exit()
        {
            if (MessageBox.Show("Exit Application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void txtName_Enter(object sender, EventArgs e)
        {
            if (txtName.Text == "UserName")
            {
                txtName.Text = "";
                txtName.ForeColor = Color.Black;
            }
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                txtName.Text = "UserName";
                txtName.ForeColor = Color.DimGray;
            }
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text == "Password")
            {
                txtPass.Text = "";
                txtPass.ForeColor = Color.Black;
            }
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnLogin.PerformClick();
            }
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtName.Multiline = false;
                txtPass.Focus();
            }
        }

        private void btnshow_Click(object sender, EventArgs e)
        {
            
            if (txtPass.PasswordChar == '●')
            {
                btnhide.BringToFront();
                txtPass.PasswordChar = '\0';
            }
        }

        private void btnhide_Click(object sender, EventArgs e)
        {
            if (txtPass.PasswordChar == '\0')
            {
                btnshow.BringToFront();
                txtPass.PasswordChar = '●';
            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text == "")
            {
                txtPass.Text = "Password";
                txtPass.ForeColor = Color.DimGray;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        
    }
}
