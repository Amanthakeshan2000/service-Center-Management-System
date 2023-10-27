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
    public partial class part_Update : Form
    {

        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnection dbcon = new DBConnection();
        SqlDataReader dr;
        part_list Cus;

        public part_Update(part_list cuss)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
            Cus = cuss;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to update this Part", "Save Part", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    cn.Open();
                    cm = new SqlCommand("UPDATE part_tbl SET part_ID=@part_ID,part_name=@part_name,brand=@brand,description=@description,price=@price,qty=@qty where part_ID like @part_ID", cn);
                    cm.Parameters.AddWithValue("@part_ID", txtNIC.Text);
                    cm.Parameters.AddWithValue("@part_name", txtName.Text);
                    cm.Parameters.AddWithValue("@brand", textBox1.Text);
                    cm.Parameters.AddWithValue("@description", txtAddress.Text);
                    cm.Parameters.AddWithValue("@price", txtMobile_no.Text);
                    cm.Parameters.AddWithValue("@qty", txtEmail.Text);

                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Part has been successfully updated.");
                    Cus.LoadRecord();

                    this.Dispose();


                }
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message);
            }
        }
    }
}
