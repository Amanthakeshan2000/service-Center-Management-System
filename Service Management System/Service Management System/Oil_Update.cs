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

namespace Service_Management_System
{
    public partial class Oil_Update : UserControl
    {

        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnection dbcon = new DBConnection();
        SqlDataReader dr;
        oil_list oil;
        public Oil_Update(oil_list oils)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
            oil = oils;
        }

        private void Oil_Update_Load(object sender, EventArgs e)
        {

        }
    }
}
