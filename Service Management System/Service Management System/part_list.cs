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
    public partial class part_list : UserControl
    {

        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnection dbcon = new DBConnection();
        SqlDataReader dr;
        public part_list()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
            LoadRecord();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            part_Add1 partAdd = new part_Add1();
           
            partAdd.Show();
            partAdd.BringToFront();
        }


        public void LoadRecord()
        {

            int i = 0;
            dataGridView1.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("select * from part_tbl order by part_ID,part_name,brand,description,price,qty", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i += 1;
                dataGridView1.Rows.Add(i, dr["part_ID"].ToString(), dr["part_name"].ToString(), dr["brand"].ToString(), dr["description"].ToString(), dr["price"].ToString(), dr["qty"].ToString());
            }
            dr.Close();
            cn.Close();

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {



            

            }
            else
            {
                if (MessageBox.Show("Are you sure you want to delete this Part? ", "Delete Part", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("delete from part_tbl where part_ID like '" + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", cn);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    LoadRecord();
                }
            }
        }
    }
}
