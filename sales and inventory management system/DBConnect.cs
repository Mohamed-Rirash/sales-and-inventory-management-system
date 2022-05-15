using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sales_and_inventory_management_system
{
    class DBConnect
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        private string con;
        public string myConnection()
        {
            con = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=sales and inventory db;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            return con;

        }

            //data addabter
            public DataTable getTable(string qury)
            {
                cn.ConnectionString = myConnection();
                cm = new SqlCommand(qury, cn);
                SqlDataAdapter adapter = new SqlDataAdapter(cm);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        
    }
}
