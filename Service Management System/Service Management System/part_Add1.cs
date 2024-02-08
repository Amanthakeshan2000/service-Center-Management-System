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
    public partial class part_Add1 : Form
    {

        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        DBConnection dbcon = new DBConnection();
        public part_Add1()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are You Sure You Want to Add this Part?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("INSERT INTo part_tbl(part_ID,part_name,brand,description,price,qty)VALUEs(@part_ID,@part_name,@brand,@description,@price,@qty)", cn);

                    cm.Parameters.AddWithValue("@part_ID", txtOil_ID.Text);
                    cm.Parameters.AddWithValue("@part_name", txtOil_Name.Text);
                    cm.Parameters.AddWithValue("@brand", textBox1.Text);
                    cm.Parameters.AddWithValue("@description", txtDescription.Text);
                    cm.Parameters.AddWithValue("@price", txtPrice.Text);
                    cm.Parameters.AddWithValue("@qty", txtStock.Text);

                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Record has been successfully saved.");
                    //Clear();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

                this.Close();

                oil_list o1 = new oil_list();
                Controls.Add(o1);
                o1.Show();
                o1.BringToFront();

            }
        }

        private void part_Add1_Load(object sender, EventArgs e)
        {

        }
    }
}
