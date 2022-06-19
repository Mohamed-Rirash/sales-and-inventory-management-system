using Microsoft.Win32;
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

        public UserPreferenceChangedEventHandler UserPreferenceChanged { get; }

        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        
        public Back_up()
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

            panel2.BackColor = lightColor;
            panel1.BackColor = lightColor;

            //Buttons
            foreach (Button button in this.Controls.OfType<Button>())
            {
                button.BackColor = themeColor;
            }
            foreach (Button button in this.Controls.OfType<Button>())
            {
                button.FlatAppearance.MouseOverBackColor = themeColor;
                button.FlatAppearance.MouseDownBackColor = lightColor;
            }
        }



        #endregion


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
