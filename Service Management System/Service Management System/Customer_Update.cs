using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace Service_Management_System
{
    public partial class Customer_Update : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnection dbcon = new DBConnection();
        SqlDataReader dr;
        customList Cus;
        public Customer_Update(customList cuss)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
            Cus = cuss;
        }

        private void Customer_Update_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to update this Customer", "Save Customer", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
             
                    cn.Open();
                    cm = new SqlCommand("UPDATE customer_tbl SET Name=@Name,Address=@Address,Mobile_no=@Mobile_no,Email=@Email where NIC like @NIC", cn);
                    cm.Parameters.AddWithValue("@NIC", txtNIC.Text);
                    cm.Parameters.AddWithValue("@Name", txtName.Text);
                    cm.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cm.Parameters.AddWithValue("@Mobile_no", txtMobile_no.Text);
                    cm.Parameters.AddWithValue("@Email", txtEmail.Text);

                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Customer has been successfully updated.");
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
