using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Service_Management_System
{
    public partial class Oil_Update1 : Form
    {

        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnection dbcon = new DBConnection();
        SqlDataReader dr;
        oil_list oil;
        public Oil_Update1(oil_list oils)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
            oil = oils;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to update this Oil", "Save Oil", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    cn.Open();
                    cm = new SqlCommand("UPDATE oilchange_tbl SET Oil_ID=@Oil_ID,Oil_name=@Oil_name,Description=@Description,Price=@Price,Qty=@Qty where Oil_ID like @Oil_ID", cn);
                    cm.Parameters.AddWithValue("@Oil_ID", txtOil_ID.Text);
                    cm.Parameters.AddWithValue("@Oil_name", txtOil_Name.Text);
                    cm.Parameters.AddWithValue("@Description", txtDescription.Text);
                    cm.Parameters.AddWithValue("@Price", txtPrice.Text);
                    cm.Parameters.AddWithValue("@Qty", txtStock.Text);


                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Oil has been successfully updated.");
                    oil.LoadRecord();

                    this.Dispose();


                }
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
