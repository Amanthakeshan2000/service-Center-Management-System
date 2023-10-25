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
    public partial class customList : UserControl
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnection dbcon = new DBConnection();
        SqlDataReader dr;

        public customList()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
            LoadRecord();
        }

        private void customList_Load(object sender, EventArgs e)
        {

        }


        public void LoadRecord()
        {

            int i = 0;
            dataGridView1.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("select * from customer_tbl order by NIC,Name,Address,Mobile_no,Email,Date", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i += 1;
                dataGridView1.Rows.Add(i, dr["NIC"].ToString(), dr["Name"].ToString(), dr["Address"].ToString(), dr["Mobile_no"].ToString(), dr["Email"].ToString(), dr["Date"].ToString());
            }
            dr.Close();
            cn.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            if(colName == "Edit")
            {
                Customer_Update cuss = new Customer_Update(this);
                //cu.txtNIC.Text = dataGridView11[e.ColumnIndex,2].Value.ToString();
                cuss.txtNIC.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                cuss.txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                cuss.txtAddress.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                cuss.txtMobile_no.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                cuss.txtEmail.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();

                cuss.Show();

            }
            else
            {
                if (MessageBox.Show("Are you sure you want to delete this Customer? ", "Delete Customer", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("delete from customer_tbl where NIC like '" + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", cn);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    LoadRecord();
                }
            }

        }
    }
}
