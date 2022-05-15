using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sales_and_inventory_management_system
{
    public partial class Cashier : Form
    {
            

        public Cashier()
        {
            InitializeComponent();
            
            
        }
        public void slide(Button button)
        {

            panelSlide.Location = new Point(0, button.Location.Y);
            panelSlide.BackColor = Color.White;
            panelSlide.Height = button.Height;
        }

        private void btnNTran_Click(object sender, EventArgs e)
        {
            slide(btnNTran);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            slide(btnSearch);

        }

        private void btnDiscount_Click(object sender, EventArgs e)
        {
            slide(btnDiscount);

        }

        private void btnSettle_Click(object sender, EventArgs e)
        {
            slide(btnSettle);

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            slide(btnClear);

        }

        private void btnDSales_Click(object sender, EventArgs e)
        {
            slide(btnDSales);

        }

        private void btncustomers_Click(object sender, EventArgs e)
        {
            slide(btncustomers);


        }

        private void btnDepts_Click(object sender, EventArgs e)
        {
            slide(btnDepts);

        }

        private void btnPass_Click(object sender, EventArgs e)
        {
            slide(btnPass);

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            slide(btnLogout);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTimer.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }
    }
}
