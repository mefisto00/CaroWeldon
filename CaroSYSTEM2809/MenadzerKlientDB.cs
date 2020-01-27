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

        //  tomasz.wydro @weldon.pl



      //  private DataGrid dgKlient;
        private int idKlient;

        /*   public System.Windows.Controls.DataGrid DgKlient
           {
               get { return dgKlient; }
               set { dgKlient = value; }

           }

       */
        public MenadzerKlientDB(DataGrid dgKlient)
        {

            wypelnijTabeleKlient(dgKlient);


        }



        public MenadzerKlientDB(int idklient)
        {
            this.idKlient = idklient;


        }





        private void wypelnijTabeleKlient(DataGrid dgKlient)
        {
            try
            {
                //   PolaczenieDB polaczenieDB = new PolaczenieDB();
                MySqlConnection conn = polaczenieZBazaDanych();
                string stm = "SELECT VERSION()";
                MySqlCommand cmdlog = new MySqlCommand(stm, conn);
                cmdlog.Connection = conn;
                cmdlog.CommandText = "select * from klient;";
                cmdlog.Prepare();

                cmdlog.ExecuteNonQuery();
                MySqlDataAdapter da = new MySqlDataAdapter(cmdlog);
                MySqlCommandBuilder ccc = new MySqlCommandBuilder(da);
                DataTable dt = new DataTable();
                //   DataGrid grid_klient = new DataGrid();

                da.Fill(dt);
                // grid_klient = new DataGrid();




                //    grid_klient.DataContext = dt;

                // conn.Close();

            }
            catch (MySqlException se)
            {
                System.Windows.MessageBox.Show("Wystąpił błąd połączenia: " + se.ToString());
            }




        }
        public void pobierzListeKontenerow(List<Kontener> listaKontener, int idUmowy)
        {
            
            foreach (var item in listaKontener)
            {

                try
                {

                    MySqlConnection conn = polaczenieZBazaDanych();
                    string stm = "SELECT VERSION()";
                    MySqlCommand cmdKontener = new MySqlCommand(stm, conn);
                    cmdKontener.CommandText = "UPDATE kontener SET idumowy=@idumowy, idklienta=@idklienta, czyWynajety=1 WHERE id=@idkont";
                    cmdKontener.Prepare();
                    cmdKontener.Parameters.AddWithValue("@idumowy", idUmowy);
                    cmdKontener.Parameters.AddWithValue("@idklienta", idKlient);
                    cmdKontener.Parameters.AddWithValue("@idkont", item.Ko_Id);
                    cmdKontener.ExecuteNonQuery();

                    //Console.WriteLine("CHUJ CHUJ" + item.ko_id);

                }
                catch (MySqlException se)
                {
                    System.Windows.MessageBox.Show("Wystąpił błąd połączenia: " + se.ToString());
                }
            }

       


        }

    }
}

    




