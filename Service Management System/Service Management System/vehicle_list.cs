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
    public partial class vehicle_list : UserControl
    {

        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnection dbcon = new DBConnection();
        SqlDataReader dr;
        public vehicle_list()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
            LoadRecord();
        }


        public void LoadRecord()
        {

            int i = 0;
            dataGridView1.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("select * from vehicle_tbl order by OwnerNIC,Name,VehicleNo,VModel,FuelType,Date", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i += 1;
                dataGridView1.Rows.Add(i, dr["VehicleNo"].ToString(), dr["OwnerNIC"].ToString(), dr["Name"].ToString(), dr["VModel"].ToString(), dr["FuelType"].ToString(), dr["Date"].ToString());
            }
            dr.Close();
            cn.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            if(colName == "Edit")
            {
                vehicle_Update vess = new vehicle_Update(this);
                //cu.txtNIC.Text = dataGridView11[e.ColumnIndex,2].Value.ToString();
                vess.txtVehicleNo1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                vess.txtName1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                vess.txtNIC1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                vess.txtVehicleModel1.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                vess.txtFuelType1.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                vess.txtFuelType1.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();

                vess.Show();

            }
            else
            {
                if (MessageBox.Show("Are you sure you want to delete this Customer? ", "Delete Customer", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("delete from vehicle_tbl where VehicleNo like '" + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", cn);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    LoadRecord();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
