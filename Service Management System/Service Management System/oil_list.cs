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
    public partial class oil_list : UserControl
    {

        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnection dbcon = new DBConnection();
        SqlDataReader dr;


        public oil_list()
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
            cm = new SqlCommand("select * from oilchange_tbl order by Oil_ID,Oil_name,Qty,Price,Description", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i += 1;
                dataGridView1.Rows.Add(i, dr["Oil_ID"].ToString(), dr["Oil_name"].ToString(), dr["Description"].ToString(), dr["Price"].ToString(), dr["Qty"].ToString());
            }
            dr.Close();
            cn.Close();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {



                Oil_Update1 oo = new Oil_Update1(this);
                //cu.txtNIC.Text = dataGridView11[e.ColumnIndex,2].Value.ToString();
                oo.txtOil_ID.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                oo.txtOil_Name.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                oo.txtDescription.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                oo.txtPrice.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                oo.txtStock.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();

                oo.Show();

            }
            else
            {
                if (MessageBox.Show("Are you sure you want to delete this Customer? ", "Delete Customer", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("delete from oilchange_tbl where Oil_ID like '" + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", cn);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    LoadRecord();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Oii_Add1 oii_Add1 = new Oii_Add1();
            //panel3.Controls.Add(o2);
            oii_Add1.Show();
            oii_Add1.BringToFront();

        

        }
    }
}
