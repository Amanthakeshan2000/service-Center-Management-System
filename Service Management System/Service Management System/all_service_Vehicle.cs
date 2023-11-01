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

    public partial class all_service_Vehicle : UserControl
    {

        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnection dbcon = new DBConnection();
        SqlDataReader dr;

        public all_service_Vehicle()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
            LoadRecord1();
        }

        public void LoadRecord1()
        {

            int i = 0;
            dataGridView1.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("select p.vehicle_no,p.service_id,p.Owner_name,p.date,p.service_type,p.qty,p.price from service_Full_tbl as p where p.vehicle_no like '" + metroTextBox1.Text + "%'", cn);

            //cm = new SqlCommand("select vehicle_no,service_id,Owner_name,date,service_type,qty,price from service_Full_tbl where vehicle_no like '" + metroTextBox1.Text + "%'", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dataGridView1.Rows.Add(i, dr["vehicle_no"].ToString(), dr["service_id"].ToString(), dr["Owner_name"].ToString(), dr["date"].ToString(), dr["service_type"].ToString(), dr["qty"].ToString(), dr["price"].ToString());
            }
            dr.Close();
            cn.Close();
        }

        //public void LoadRecord()
       // {

          //  int i = 0;
         //   dataGridView1.Rows.Clear();
         //   cn.Open();
          //  cm = new SqlCommand("select * from service_Full_tbl order by vehicle_no,service_id,Owner_name,date,service_type,qty,price", cn);
          //  dr = cm.ExecuteReader();
         //   while (dr.Read())
          //  {
           //     i += 1;
          //      dataGridView1.Rows.Add(i, dr["vehicle_no"].ToString(), dr["service_id"].ToString(), dr["Owner_name"].ToString(), dr["date"].ToString(), dr["service_type"].ToString(), dr["qty"].ToString(), dr["price"].ToString());
           // }
           // dr.Close();
           // cn.Close();

     //   }

        private void all_service_Vehicle_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this Bill? ", "Delete Bill", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cn.Open();
                cm = new SqlCommand("delete from service_Full_tbl where service_id like '" + dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString() + "'", cn);
                cm.ExecuteNonQuery();
                cn.Close();
                LoadRecord1();
            }
        }

        private void metroTextBox1_TabIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void metroTextBox1_TextChanged(object sender, EventArgs e)
        {
            LoadRecord1();
        }
    }
}
