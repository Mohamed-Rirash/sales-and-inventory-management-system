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
using System.Windows.Forms.DataVisualization.Charting;

namespace sales_and_inventory_management_system
{
    public partial class Dashboard : Form
    {
        SqlConnection cn = new SqlConnection();
        DBConnect dbcon = new DBConnect();
        public Dashboard()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            string sdate = DateTime.Now.ToShortDateString();
            lblDalySale.Text = dbcon.ExtractData("SELECT ISNULL(SUM(total),0) AS total FROM tbCart WHERE status LIKE 'Sold' AND sdate BETWEEN '" + sdate + "' AND '" + sdate + "'").ToString("#,##0.00");
            lblTotalProduct.Text = dbcon.ExtractData("SELECT COUNT(*) FROM tbProduct").ToString("#,##0");
            lblStockOnHand.Text = dbcon.ExtractData("SELECT ISNULL(SUM(qty), 0) AS qty FROM tbProduct").ToString("#,##0");
            lblCriticalItems.Text = dbcon.ExtractData("SELECT COUNT(*) FROM vwCriticalItems").ToString("#,##0");
        }




        private void iconButton1_Click(object sender, EventArgs e)
        {
            mainform main = new mainform();
            main.Noti();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            filchart();

        }

        private void filchart()
        {
            DataSet ds = new DataSet();
            cn.Open();
            SqlDataAdapter dt = new SqlDataAdapter("Select sdate,qty,disc,total from tbCart ", cn);
            dt.Fill(ds);
            chart1.DataSource = ds;
            chart1.Series["QTY"].XValueMember = "sdate";
            chart1.Series["QTY"].YValueMembers = "qty";

            chart1.Series["InCome"].XValueMember = "sdate";
            chart1.Series["InCome"].YValueMembers = "total";
           
            chart1.Series["Discount"].XValueMember = "sdate";
            chart1.Series["Discount"].YValueMembers = "disc";
            chart1.Titles.Add("Sales Chart");

        }

        private void btnlinechart_Click(object sender, EventArgs e)
        {
            chart1.Series["QTY"].ChartType = SeriesChartType.StepLine;
            chart1.Series["InCome"].ChartType = SeriesChartType.StepLine;
            chart1.Series["Discount"].ChartType = SeriesChartType.StepLine;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            chart1.Series["QTY"].ChartType = SeriesChartType.Column;
            chart1.Series["InCome"].ChartType = SeriesChartType.Column;
            chart1.Series["Discount"].ChartType = SeriesChartType.Column;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            chart1.Series["QTY"].ChartType = SeriesChartType.StackedArea;
            chart1.Series["InCome"].ChartType = SeriesChartType.StackedArea;
            chart1.Series["Discount"].ChartType = SeriesChartType.StackedArea;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            chart1.Series["QTY"].ChartType = SeriesChartType.Bar;
            chart1.Series["InCome"].ChartType = SeriesChartType.Bar;
            chart1.Series["Discount"].ChartType = SeriesChartType.Bar;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series["QTY"].ChartType = SeriesChartType.Candlestick;
            chart1.Series["InCome"].ChartType = SeriesChartType.Candlestick;
            chart1.Series["Discount"].ChartType = SeriesChartType.Candlestick;
        }
    }
}
