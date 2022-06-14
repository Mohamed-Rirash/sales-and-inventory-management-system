using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sales_and_inventory_management_system
{
    public partial class customerName : Form
    {
        
        Cashier cashier;

        public UserPreferenceChangedEventHandler UserPreferenceChanged { get; private set; }

        public customerName(Cashier cash)
        {
            InitializeComponent();
            UserPreferenceChanged = new UserPreferenceChangedEventHandler(SystemEvents_UserPreferenceChanged);
            SystemEvents.UserPreferenceChanged += UserPreferenceChanged;
            this.Disposed += new EventHandler(Form_Disposed);
            LoadTheme();

            cashier = cash;
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




        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            string NamePattern = @"^[a-z A-Z]+$";

            if (txtname.Text == String.Empty)
            {
                txtname.Focus();
                MessageBox.Show("Please Enter Customer Name!");

            }
            else if (Regex.IsMatch(txtname.Text, NamePattern) == false)
            {

                txtname.Focus();
                MessageBox.Show("Please Enter charectors only");
                return;
            }
            else
            {
                if (cashier.lblcustomername.Text == String.Empty)
                {
                    TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                    cashier.lblcustomername.Text = textInfo.ToTitleCase(txtname.Text);
                    this.Dispose();
                }
            }
        }
    }
}
