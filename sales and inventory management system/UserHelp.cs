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
    public partial class UserHelp : Form
    {
        SqlConnection cn = new SqlConnection();
        private UserPreferenceChangedEventHandler UserPreferenceChanged;
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        string stitle = "SIMS";
       
        public UserHelp()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            UserPreferenceChanged = new UserPreferenceChangedEventHandler(SystemEvents_UserPreferenceChanged);
            SystemEvents.UserPreferenceChanged += UserPreferenceChanged;
            this.Disposed += new EventHandler(Form_Disposed);
            LoadTheme();

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
        public void  getusetname()
        {

        }
       
            private void picClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clear();
        }
        
        public void clear()
        {
            txtUsername.Clear();
            txtCom.Clear();
            txtName.Clear();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string oldusername = dbcon.getusername(txtUsername.Text);
            try
            {
                string addresspattern = @"^[a-z A-Z0-9]+$";
                string namepatern = @"^[a-z A-Z]+$";

                if (Regex.IsMatch(txtCom.Text, addresspattern) == false)
                {
                    txtCom.Focus();
                    MessageBox.Show("Please Enter Alphabrtic Values", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (txtName.Text == String.Empty)
                {
                    MessageBox.Show("Please Enter Your fulname", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else if (Regex.IsMatch(txtName.Text, namepatern) == false)
                {
                    txtCom.Focus();
                    MessageBox.Show("Please Enter Alphabrtic Values", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (oldusername != txtUsername.Text)
                {
                    MessageBox.Show("this user account does not exist, please try again!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                else
                {

                    cm = new SqlCommand("INSERT INTO Userhelp(UserName, Full_Name, Combelain)VALUES (@UserName,@Full_Name, @Combelain)", cn);
                    cm.Parameters.AddWithValue("@UserName", txtUsername.Text);
                    cm.Parameters.AddWithValue("@Full_Name", txtName.Text);
                    cm.Parameters.AddWithValue("@Combelain", txtCom.Text);
                    cn.Open();
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Thanks for Your feedback and Wait Administrators answer!.", stitle, MessageBoxButtons.OK,MessageBoxIcon.Information);
                        
                        clear();

                }
            }
            catch (Exception ex)
            {
               
                    MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cn.Close();
                
            }
        }

       
    }
}
