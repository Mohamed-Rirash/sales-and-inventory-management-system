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
    public partial class personal_cart : Form
    {
        SqlConnection cn = new SqlConnection();
        private UserPreferenceChangedEventHandler UserPreferenceChanged;
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        Cashier cashier = new Cashier();
        public personal_cart()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            UserPreferenceChanged = new UserPreferenceChangedEventHandler(SystemEvents_UserPreferenceChanged);
            SystemEvents.UserPreferenceChanged += UserPreferenceChanged;
            this.Disposed += new EventHandler(Form_Disposed);
            LoadTheme();
            Loadcart();
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

            panel1.BackColor = lightColor;
            dgvlcart.ColumnHeadersDefaultCellStyle.BackColor = darkColor;


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

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void Loadcart()
        {
            Depts db = new Depts();
            int i = 0;
            dgvlcart.Rows.Clear();
            cn.Open();
            int rowindex = db.dgvDebts.CurrentCell.RowIndex;
            int columnindex = db.dgvDebts.CurrentCell.ColumnIndex;
           
              

                
                    cm = new SqlCommand("SELECT c.transno,c.pcode,p.pdesc, c.price,c.qty,c.disc,c.total,c.sdate,c.cashier FROM tbCart AS c INNER JOIN tbProduct AS p On c.pcode=p.pcode WHERE transno ='" + db.dgvDebts.Rows[i].Cells[4].Value.ToString() + "'", cn);
              
                      dr = cm.ExecuteReader();
                    
                

                while (dr.Read())
                {
                    i++;
                    dgvlcart.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString());
                }
                dr.Close();
                cn.Close();
            
        }
       
    }
}
