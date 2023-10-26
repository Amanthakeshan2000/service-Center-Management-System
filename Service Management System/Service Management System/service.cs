﻿using System;
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
    public partial class service : UserControl
    {


        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        DBConnection dbcon = new DBConnection();
        public service()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
            
            LoadRecord1();
            LoadRecord(); 
            LoadRecord2();

        }

        private void service_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }





        public void LoadRecord()
        {
            int i = 0;
            dataGridView1.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("select * from service_tbl order by service_name,qty,price", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i += 1;
                dataGridView1.Rows.Add(i, dr["service_name"].ToString(), dr["qty"].ToString(), dr["price"].ToString());
            }
            dr.Close();
            cn.Close();
        }


        public void LoadRecord1()
        {
            dataGridView1.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("select Oil_name from oilchange_tbl", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {             
                comboBox1.Items.Add(dr["Oil_name"].ToString());
            }
            dr.Close();
            cn.Close();
        }


        public void LoadRecord2()
        {
            dataGridView1.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("select part_name from part_tbl", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                comboBox4.Items.Add(dr["part_name"].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

 

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-1DA8EH9\\SQLEXPRESS;Initial Catalog=Auto_Flash_Database;Integrated Security=True"))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("addingService", connection))
                    {
                        // Set the CommandType to StoredProcedure
                        command.CommandType = CommandType.StoredProcedure;
                        try
                        {
                            // Add parameters and execute the stored procedure
                            command.ExecuteNonQuery();
                        }
                        catch { }
                        command.Parameters.AddWithValue("@service_name", SqlDbType.VarChar).Value = service_name.Text;
                        //command.Parameters.AddWithValue("@qty", SqlDbType.Int).Value = textBox8.Text;
                        command.Parameters.AddWithValue("@price", SqlDbType.Float).Value = textBox9.Text;



                        command.ExecuteNonQuery();
                    }


                }
            }
            catch { }
            finally 
            {
                LoadRecord();
                textBox9.Clear();
                service_name.ResetText();
            }

     


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this Oil? ", "Delete Oil", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cn.Open();
                cm = new SqlCommand("delete from service_tbl where service_name like '" + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", cn);
                cm.ExecuteNonQuery();
                cn.Close();
                LoadRecord();
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-1DA8EH9\\SQLEXPRESS;Initial Catalog=Auto_Flash_Database;Integrated Security=True"))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("addingRepair", connection))
                    {
                        // Set the CommandType to StoredProcedure
                        command.CommandType = CommandType.StoredProcedure;
                        try
                        {
                            // Add parameters and execute the stored procedure
                            command.ExecuteNonQuery();
                        }
                        catch { }
                        command.Parameters.AddWithValue("@service_name", SqlDbType.VarChar).Value = textBox4.Text;
                        //command.Parameters.AddWithValue("@qty", SqlDbType.Int).Value = textBox8.Text;
                        command.Parameters.AddWithValue("@price", SqlDbType.Float).Value = textBox2.Text;



                        command.ExecuteNonQuery();
                    }


                }
            }
            catch { }
            finally
            {
                LoadRecord();
                textBox4.Clear();
                textBox2.ResetText();
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-1DA8EH9\\SQLEXPRESS;Initial Catalog=Auto_Flash_Database;Integrated Security=True"))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("addingWork", connection))
                    {
                        // Set the CommandType to StoredProcedure
                        command.CommandType = CommandType.StoredProcedure;
                        try
                        {
                            // Add parameters and execute the stored procedure
                            command.ExecuteNonQuery();
                        }
                        catch { }
                        command.Parameters.AddWithValue("@service_name", SqlDbType.VarChar).Value = textBox7.Text;
                        //command.Parameters.AddWithValue("@qty", SqlDbType.Int).Value = textBox8.Text;
                        command.Parameters.AddWithValue("@price", SqlDbType.Float).Value = textBox3.Text;



                        command.ExecuteNonQuery();
                    }


                }
            }
            catch { }
            finally
            {
                LoadRecord();
                textBox7.Clear();
                textBox3.ResetText();
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-1DA8EH9\\SQLEXPRESS;Initial Catalog=Auto_Flash_Database;Integrated Security=True"))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("addingOils", connection))
                    {
                        // Set the CommandType to StoredProcedure
                        command.CommandType = CommandType.StoredProcedure;
                        try
                        {
                            // Add parameters and execute the stored procedure
                            command.ExecuteNonQuery();
                        }
                        catch { }

                       
                

                        command.Parameters.AddWithValue("@service_name", SqlDbType.VarChar).Value = comboBox1.Text;
                       // command.Parameters.AddWithValue("@price", SqlDbType.Int).Value = textBox8.Text;
                        command.Parameters.AddWithValue("@qty", SqlDbType.Float).Value = textBox8.Text;



                        command.ExecuteNonQuery();
                    }


                }
            }
            catch { }
            finally
            {
                LoadRecord();
                textBox8.Clear();
                comboBox1.ResetText();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
