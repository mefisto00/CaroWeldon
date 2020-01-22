using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using MySql.Data.MySqlClient;

namespace CaroSYSTEM2809
{
 public partial class MenadzerKlientDB : PolaczenieDB

    { 
        private DataGrid grid_klient;

       


        public MenadzerKlientDB( DataGrid grid_klient )
        {
            this.grid_klient = grid_klient;
            wypelnijTabeleKlient(this.grid_klient);


        }

        public void wypelnijTabeleKlient(DataGrid grid_klient)
        {
            try
            {
                
                MySqlConnection conn = PolaczenieDB.polaczenieZBazaDanych();
                string stm = "SELECT VERSION()";
                MySqlCommand cmdlog = new MySqlCommand(stm, conn);
                cmdlog.Connection = conn;
                cmdlog.CommandText = "select * from klient;";
                cmdlog.Prepare();

                cmdlog.ExecuteNonQuery();
                MySqlDataAdapter da = new MySqlDataAdapter(cmdlog);
                MySqlCommandBuilder ccc = new MySqlCommandBuilder(da);
                DataTable dt = new DataTable();

                da.Fill(dt);
                grid_klient.DataContext = dt;
                conn.Close();

            }
            catch (MySqlException se)
            {
                System.Windows.MessageBox.Show("Wystąpił błąd połączenia: " + se.ToString());
            }


                

        }




    }



}
