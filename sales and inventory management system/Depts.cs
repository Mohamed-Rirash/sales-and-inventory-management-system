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
    public partial class Depts : Form
    {
        SqlConnection cn = new SqlConnection();
        private UserPreferenceChangedEventHandler UserPreferenceChanged;
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        public Depts()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            UserPreferenceChanged = new UserPreferenceChangedEventHandler(SystemEvents_UserPreferenceChanged);
            SystemEvents.UserPreferenceChanged += UserPreferenceChanged;
            this.Disposed += new EventHandler(Form_Disposed);
            LoadTheme();
            LoadDepts();
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
            panel1.BackColor = lightColor;
            dgvDebts.ColumnHeadersDefaultCellStyle.BackColor = darkColor;


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
        public void LoadDepts()
        {
            int i = 0;
            dgvDebts.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("SELECT CustomerName, Type, Phone, transNo, Date,  AmountDept FROM Depts  WHERE CONCAT(CustomerName, Type, transNo,Phone,AmountDept,Date) LIKE '%" + txtSearch.Text + "%'", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvDebts.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadDepts();
        }

        private void btnaddn_Click(object sender, EventArgs e)
        {
            Debtsmodule debt = new Debtsmodule(this);
            debt.ShowDialog();
        }

        private void picClose_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }

       

        private void dgvDebts_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string colName = dgvDebts.Columns[e.ColumnIndex].Name;
                if (colName == "Edit")
                {
                    Debtsmodule debts = new Debtsmodule(this);
                    debts.cmbname.Text = dgvDebts.Rows[e.RowIndex].Cells[1].Value.ToString();
                    debts.txttype.Text = dgvDebts.Rows[e.RowIndex].Cells[2].Value.ToString();
                    debts.txtphone.Text = dgvDebts.Rows[e.RowIndex].Cells[3].Value.ToString();
                    debts.pamout.Text = dgvDebts.Rows[e.RowIndex].Cells[6].Value.ToString();

                   
                    debts.btnSave.Enabled = false;
                    debts.btnUpdate.Enabled = true;
                    debts.ShowDialog();
                }
                else if (colName == "Cart")
                {
                    personal_cart cart = new personal_cart();
                    cart.ShowDialog();
                }
               
                LoadDepts();
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvDebts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)

            {
                if (MessageBox.Show("Are you sure want to save this product?", "Save Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("INSERT INTO paidpeople(CustomerName, Type, transNo, Date, Phone, AmountDept)VALUES (@CustomerName,@Type,@transNo,@Date,@Phone,@AmountDept)", cn);
                    cm.Parameters.AddWithValue("@CustomerName", dgvDebts.Rows[e.RowIndex].Cells[1].Value.ToString());
                    cm.Parameters.AddWithValue("@Type", dgvDebts.Rows[e.RowIndex].Cells[2].Value.ToString());
                    cm.Parameters.AddWithValue("@transNo", dgvDebts.Rows[e.RowIndex].Cells[4].Value.ToString());
                    cm.Parameters.AddWithValue("@Date", DateTime.Parse( dgvDebts.Rows[e.RowIndex].Cells[5].Value.ToString()));
                    cm.Parameters.AddWithValue("@Phone", dgvDebts.Rows[e.RowIndex].Cells[3].Value.ToString());
                    cm.Parameters.AddWithValue("@AmountDept",double.Parse( dgvDebts.Rows[e.RowIndex].Cells[6].Value.ToString()));
                    cn.Open();
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Dubt Paid successfully saved.", "SIMs");
                   //delet from debts
                    cn.Open();
                    cm = new SqlCommand("DELETE FROM Depts WHERE Phone LIKE '" + dgvDebts[3, e.RowIndex].Value.ToString() + "'", cn);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    LoadDepts();
                  //  MessageBox.Show("Brand has been successfully deleted.", "Sales Ms", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
            }
            else if (e.ColumnIndex == 9)
            {
                personal_cart personal = new personal_cart();
                personal.Loadcart();
            }
        }

        private void btnviewpaid_Click(object sender, EventArgs e)
        {
            viewpaiddebts viewpaid = new viewpaiddebts();
            viewpaid.ShowDialog();
        }
    }
}
