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
    public partial class analyse_Part : UserControl
    {
        public analyse_Part()
        {
            InitializeComponent();
        }
        void fillchart()
        {
            SqlConnection connect = new SqlConnection("Data Source=MSI\\SQLEXPRESS;Initial Catalog=Auto_Flash_Database;Integrated Security=True;Trust Server Certificate=True");

            DataTable dt = new DataTable();
            connect.Open();
            SqlCommand cmd = new SqlCommand("Select customers,date from analize_new", connect);

            SqlDataAdapter data = new SqlDataAdapter(cmd);

            data.Fill(dt);
            cartesianChart1.DataSource = dt;
            connect.Close();

            cartesianChart1.Series["Customer_Count"].XValueMember = "date";
            cartesianChart1.Series["Customer_Count"].YValueMembers = "customers";
            cartesianChart1.Titles.Add("Daily Customers");

            cartesianChart1.Series[0].IsValueShownAsLabel = true;


            cartesianChart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            //cartesianChart1.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            cartesianChart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            //cartesianChart1.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            fillchart();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection connect = new SqlConnection("Data Source=MSI\\SQLEXPRESS;Initial Catalog=Auto_Flash_DB;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("Select date,customers from test1", connect);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            data.Fill(dt);
            dataGridView1.DataSource = dt;


            dataGridView1.Columns[0].HeaderText = "Date";
            dataGridView1.Columns[1].HeaderText = "customers";

            dataGridView1.Columns[0].DefaultCellStyle.Format = "dd/MM/yyyy";
        }
    }
}
