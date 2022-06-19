using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zen.Barcode;
namespace sales_and_inventory_management_system
{
    public partial class barcode : Form
    {
        SqlConnection cn = new SqlConnection();
       // private UserPreferenceChangedEventHandler UserPreferenceChanged;
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        string fname;
        private UserPreferenceChangedEventHandler UserPreferenceChanged;

        public barcode()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            LoadProduct();
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


            panel1.BackColor = lightColor;
            dgvbarcode.ColumnHeadersDefaultCellStyle.BackColor = darkColor;


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

        public void LoadProduct()
        {
            int i = 0;
            dgvbarcode.Rows.Clear();
            cm = new SqlCommand("SELECT p.pcode, p.barcode, p.pdesc, b.brand, c.category, p.price, p.reorder FROM tbProduct AS p INNER JOIN tbBrand AS b ON b.id = p.bid INNER JOIN tbCategory AS c on c.id = p.cid WHERE CONCAT(p.pdesc, b.brand, c.category) LIKE '%" + txtSearch.Text + "%'", cn);
            cn.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvbarcode.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadProduct();
        }

        private void dgvbarcode_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string columname = dgvbarcode.Columns[e.ColumnIndex].Name;
            if (columname == "Select")
            {
                Code128BarcodeDraw barcode = BarcodeDrawFactory.Code128WithChecksum;
                picbarcode.Image = barcode.Draw(dgvbarcode.Rows[e.RowIndex].Cells[2].Value.ToString(), 60,2 );
                fname = dgvbarcode.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.SaveFileDialog savefile = new System.Windows.Forms.SaveFileDialog();
                savefile.Title = "Save Barcode image as";
                savefile.FileName = fname;
                savefile.Filter = "Image File (*.jpg, *.png)| *.jpg, *.png";
                ImageFormat image = ImageFormat.Png;
                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    string ftype = System.IO.Path.GetExtension(savefile.FileName);
                    switch (ftype)
                    {
                        case ".jpg":
                            image = ImageFormat.Jpeg;
                            break;
                        case ".png":
                            image = ImageFormat.Png;
                            break;


                    }
                    picbarcode.Image.Save(savefile.FileName, image);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
