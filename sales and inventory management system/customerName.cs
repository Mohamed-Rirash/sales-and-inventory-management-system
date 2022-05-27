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
        

        public customerName(Cashier cash)
        {
            InitializeComponent();
            
            cashier = cash;
        }



        private void txtname_KeyPress(object sender, KeyPressEventArgs e)
        {
            
       
            
        }

        

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
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
