using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Service_Management_System
{
    public partial class vehicle : UserControl
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        DBConnection dbcon = new DBConnection();

        public vehicle()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
            LoadRecord();
           // cn.Open();

        }

        String N;

      
        public string stdName {  get; set; }    

        private void Clear()
        {
            btnadd.Enabled = true;
            //btnupdate.Enabled = false;
            //txtNIC.Clear();
            txtNIC1.Clear();
            txtName1.Clear();
         
            txtVehicleNo1.Clear();
            dataGridView2.Rows.Clear();

            txtNIC1.Focus();
            txtName1.Focus();
            txtVehicleModel1.Focus();
            txtFuelType1.Focus();
            txtVehicleNo1.Focus();
            txtVehicleModel1.ResetText();
            txtFuelType1.ResetText();


        }

        public void LoadRecord()
        {
          
            customers c3=new customers();
            String s= c3.uName();
            txtNIC1.Text = s;


            int i = 0;
            dataGridView1.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("select * from vehicle_tbl order by VehicleNo,Name,OwnerNIC,Date", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i += 1;
                dataGridView1.Rows.Add(i, dr["VehicleNo"].ToString(), dr["Name"].ToString(), dr["OwnerNIC"].ToString(),dr["Date"].ToString());
            }
            dr.Close();
            cn.Close();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {


            try
            {
                if (MessageBox.Show("Are You Sure You Want to Save this Customer?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("INSERT INTo vehicle_tbl(OwnerNIC,Name,VehicleNo,VModel,FuelType,Date)VALUEs(@OwnerNIC,@Name,@VehicleNo,@VModel,@FuelType,@Date)", cn);

                    cm.Parameters.AddWithValue("@OwnerNIC", txtNIC1.Text);
                    cm.Parameters.AddWithValue("@Name", txtName1.Text);
                    cm.Parameters.AddWithValue("@VehicleNo", txtVehicleNo1.Text);
                    cm.Parameters.AddWithValue("@VModel", txtVehicleModel1.Text);
                    cm.Parameters.AddWithValue("@FuelType", txtFuelType1.Text);
                    cm.Parameters.AddWithValue("@Date", txtDate1.Text);

                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Record has been successfully saved.");
                    Clear();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
               LoadRecord();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                string selectCustomerQuery = "SELECT * FROM customer_tbl WHERE NIC LIKE @NIC";
                cm = new SqlCommand(selectCustomerQuery, cn);
                cm.Parameters.AddWithValue("@NIC", "%" + txtNIC1.Text + "%");

                dr = cm.ExecuteReader();

                if (dr.Read())
                {
                    txtName1.Text = dr["Name"].ToString();
                }
                else
                {
                    MessageBox.Show("No Customer Found.");
                }

                dr.Close();

                // Now fetch related vehicle data
                string selectVehiclesQuery = "SELECT VehicleNo FROM vehicle_tbl WHERE OwnerNIC = @OwnerNIC";
                cm = new SqlCommand(selectVehiclesQuery, cn);
                cm.Parameters.AddWithValue("@OwnerNIC", txtNIC1.Text);

                dr = cm.ExecuteReader();

                int i = 0;
                dataGridView2.Rows.Clear();

                while (dr.Read())
                {
                    i += 1;
                    dataGridView2.Rows.Add(dr["VehicleNo"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Close the connection in the finally block to ensure it gets closed even if an exception occurs.
                cn.Close();
            }
        }



        private void vehicle_Load(object sender, EventArgs e)
        {
           // customers c5=new customers();
           // String cc = c5.uName();
           // txtNIC1.Text = cc;  
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            service se=new service();
            Controls.Add(se);
            se.BringToFront();
            se.Show();
        }
    }
}
