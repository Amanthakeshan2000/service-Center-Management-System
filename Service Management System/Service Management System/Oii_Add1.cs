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
using System.Xml.Linq;

namespace Service_Management_System
{
    public partial class Oii_Add1 : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        DBConnection dbcon = new DBConnection();


        public Oii_Add1()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
            oil_list a1 = new oil_list();
            a1.LoadRecord();

        }

        private void Clear()
        {
           // btnSave.Enabled = true;
            //btnUpdate.Enabled = false;
            //txtNIC.Clear();
            txtOil_ID.Clear();
            txtOil_Name.Clear();
            txtDescription.Clear();
            txtPrice.Clear();
            txtStock.Clear();

            txtOil_ID.Focus();
            txtOil_Name.Focus();
            txtDescription.Focus();
            txtPrice.Focus();
            txtStock.Focus();


        }

   

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are You Sure You Want to Add this Oil?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("INSERT INTo oilchange_tbl(Oil_name,Qty,Price,Oil_ID,Description)VALUEs(@Oil_name,@Qty,@Price,@Oil_ID,@Description)", cn);

                    cm.Parameters.AddWithValue("@Oil_ID", txtOil_ID.Text);
                    cm.Parameters.AddWithValue("@Oil_name", txtOil_Name.Text);
                    cm.Parameters.AddWithValue("@Description", txtDescription.Text);
                    cm.Parameters.AddWithValue("@Price", txtPrice.Text);
                    cm.Parameters.AddWithValue("@Qty", txtStock.Text);                 

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
          
                this.Close();

                oil_list o1 = new oil_list();
                Controls.Add(o1);
                o1.Show();
                o1.BringToFront();

            }
           
        }

        private void Oii_Add1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
