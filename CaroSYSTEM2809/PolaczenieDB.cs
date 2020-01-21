using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CaroSYSTEM2809
{
   public class PolaczenieDB
    {

        public static MySqlConnection polaczenieZBazaDanych()
        {
            string cs = @"server=localhost;userid=root;password=;database=carosystem";
            var conn = new MySqlConnection(cs);
            conn.Open();
            return conn;
        }



    }
}
