using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Management_System
{
    class DBConnection
    {
        public string MyConnection()
        {
            string con = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=1;Integrated Security=True;";
            return con; 
        }
    }
}
