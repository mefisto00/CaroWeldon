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
    public partial class MenadzerDB : PolaczenieDB
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

        public MenadzerDB()
        {
        }
        public MenadzerDB(DataGrid dgKlient)
        {

            wypelnijTabeleKlient(dgKlient);


        }



        public MenadzerDB(int idklient)
        {
            this.idKlient = idklient;


        }




        //tworze prywatna metode wypelniajaca tabele klient , wywoluje ja w konstruktorze
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
                conn.Close();
            }
            catch (MySqlException se)
            {
                System.Windows.MessageBox.Show("Wystąpił błąd połączenia: " + se.ToString());
            }




        }
       
        //pobieram liste kontenerow 
        public List<Kontener> pobierzListeKontenerow(List<Kontener> listaKontener, int idUmowy, int idKlient)
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
                    conn.Close();


                }
                catch (MySqlException se)
                {
                    System.Windows.MessageBox.Show("Wystąpił błąd połączenia: " + se.ToString());
                }
            }


            return listaKontener;

        }


        public void dodajDoZestawieniaDB(List<Kontener>listaKontener,int tempId,string tempNumerCaro,string tempNumerWeldon,string tempAmortyzacjaKontenera, string tempCenaNetto, string tempCzyKlimatyzowany, string tempCzyWynajety, string tempPodstawoweWyposazenieKontenera, string tempDodatkoweWyposazenieKontenera, string tempLokalizacja , string tempCenaMinimalna, string tempDataZakupuKontenera, string tempDataKoncaAmortyzacji, string tempNotatka, string tempTypKontenera, string idWybrKont)
        {
            
            try
            {
                MySqlConnection conn = polaczenieZBazaDanych();
                string stm2 = "SELECT VERSION()";
                MySqlCommand cmdlog = new MySqlCommand(stm2, conn);
                cmdlog.Connection = conn;
                cmdlog.CommandText = "select * from kontener where id=@id;";
                cmdlog.Prepare();

                cmdlog.Parameters.AddWithValue("@id", Convert.ToInt32(idWybrKont));

                MySqlDataReader dataReader = cmdlog.ExecuteReader();
                if (dataReader.Read())
                {
                    tempId = Convert.ToInt32(dataReader["id"].ToString());
                    tempNumerCaro = dataReader["nrCaro"].ToString();
                    tempNumerWeldon = dataReader["nrWeldon"].ToString();
                    tempAmortyzacjaKontenera = dataReader["amortyzacja"].ToString();
                    tempCenaNetto = dataReader["cenaNetto"].ToString();
                    tempTypKontenera = dataReader["typKontenera"].ToString();
                    tempCzyKlimatyzowany = dataReader["czyKlimatyzowany"].ToString();
                    tempCzyWynajety = dataReader["czyWynajety"].ToString();
                    tempPodstawoweWyposazenieKontenera = dataReader["podstWyposazenie"].ToString();
                    tempDodatkoweWyposazenieKontenera = dataReader["dodatWyposazenie"].ToString();
                    tempLokalizacja = dataReader["lokalizacja"].ToString();
                    tempCenaMinimalna = dataReader["cenaMinimalna"].ToString();
                    tempDataZakupuKontenera = dataReader["dataZakupu"].ToString();
                    tempDataKoncaAmortyzacji = dataReader["dataKoncaAmo"].ToString();
                    tempNotatka = dataReader["notatka"].ToString();


                    listaKontener.Add(new Kontener(tempId, tempNumerCaro, tempNumerWeldon, tempAmortyzacjaKontenera, tempCenaNetto, tempTypKontenera, tempCzyKlimatyzowany, tempCzyWynajety, tempPodstawoweWyposazenieKontenera, tempDodatkoweWyposazenieKontenera, tempLokalizacja, tempCenaMinimalna, tempDataZakupuKontenera, tempDataKoncaAmortyzacji, tempNotatka));
                }

                var oknoUmowa = new oknoNowaUmowa();
                oknoUmowa.odswiezPokaz();
                conn.Close();
            }
            catch (MySqlException se)
            {
                System.Windows.MessageBox.Show("Wystąpił błąd połączenia: " + se.ToString());
            }


        


        }


        //pobieram klienta z db
        public void SzukajNowaUmowaKlienta(DataGrid dgKlient, string klientSzukaj )
        {

            try
            {

                MySqlConnection conn = polaczenieZBazaDanych();
                string stm = "SELECT VERSION()";
                MySqlCommand cmdlog = new MySqlCommand(stm, conn);
                cmdlog.Connection = conn;
                cmdlog.CommandText = " select * from klient where concat(nazwa,' ',adres) like @frazaszukana";
                cmdlog.Prepare();
                
                string temp1 = "%" + klientSzukaj + "%";
                cmdlog.Parameters.AddWithValue("@frazaszukana", temp1);
                Console.WriteLine(cmdlog.CommandText.ToString());
                cmdlog.ExecuteNonQuery();
                MySqlDataAdapter da = new MySqlDataAdapter(cmdlog);
                MySqlCommandBuilder ccc = new MySqlCommandBuilder(da);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgKlient.DataContext = dt;
                conn.Close();
            }
            catch (MySqlException se)
            {
                System.Windows.MessageBox.Show("Wystąpił błąd połączenia: " + se.ToString());
            }
        }

        //pobieram kontener z db 
        public void SzukajNowaUmowaKontener(DataGrid dgKontener , string kontenerSzukaj)
        {

            try
            {

                MySqlConnection conn = polaczenieZBazaDanych();
                string stm = "SELECT VERSION()";
                MySqlCommand cmdlog = new MySqlCommand(stm, conn);
                cmdlog.Connection = conn;
                cmdlog.CommandText = "select * from kontener where concat(nrCaro,' ',nrWeldon) like @frazaszukana";
                cmdlog.Prepare();
                //cmdlog.Parameters.AddWithValue("@frazaszukana", ex_poleSzukajKontener.Text);
                string temp1 = "%" + kontenerSzukaj + "%";
                cmdlog.Parameters.AddWithValue("@frazaszukana", temp1);
                Console.WriteLine(cmdlog.CommandText.ToString());
                cmdlog.ExecuteNonQuery();
                MySqlDataAdapter da = new MySqlDataAdapter(cmdlog);
                MySqlCommandBuilder ccc = new MySqlCommandBuilder(da);
                //DataTable dt = new DataTable();
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgKontener.DataContext = dt;
                conn.Close();
            }
            catch (MySqlException se)
            {
                System.Windows.MessageBox.Show("Wystąpił błąd połączenia: " + se.ToString());
            }


        }

        //pobieram klienta z db
        public void SzukajKlient(DataGrid dgKlient, string klientSzukaj)
        {
            try
            {

                MySqlConnection conn = PolaczenieDB.polaczenieZBazaDanych();
                string stm = "SELECT VERSION()";
                MySqlCommand cmdlog = new MySqlCommand(stm, conn);
                cmdlog.Connection = conn;
                cmdlog.CommandText = " select * from klient where concat(nazwa,' ',adres) like @frazaszukana";
                cmdlog.Prepare();
                //cmdlog.Parameters.AddWithValue("@frazaszukana", ex_poleSzukajKontener.Text);
                string temp1 = "%" + klientSzukaj + "%";
                cmdlog.Parameters.AddWithValue("@frazaszukana", temp1);
                Console.WriteLine(cmdlog.CommandText.ToString());
                cmdlog.ExecuteNonQuery();
                MySqlDataAdapter da = new MySqlDataAdapter(cmdlog);
                MySqlCommandBuilder ccc = new MySqlCommandBuilder(da);
                //DataTable dt = new DataTable();
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgKlient.DataContext = dt;
                conn.Close();
            }
            catch (MySqlException se)
            {
                System.Windows.MessageBox.Show("Wystąpił błąd połączenia: " + se.ToString());
            }

        }

        //pobieram kontener z db 
        public void SzukajKontener(DataGrid dgKontener, string kontenerSzukaj)
        {
              try
                {

                    MySqlConnection conn = polaczenieZBazaDanych();
                    string stm = "SELECT VERSION()";
                    MySqlCommand cmdlog = new MySqlCommand(stm, conn);
                    cmdlog.Connection = conn;
                    cmdlog.CommandText = "select * from kontener where concat(nrCaro,' ',nrWeldon) like @frazaszukana";
                    cmdlog.Prepare();
                    //cmdlog.Parameters.AddWithValue("@frazaszukana", ex_poleSzukajKontener.Text);
                    string temp1 = "%" + kontenerSzukaj + "%";
                    cmdlog.Parameters.AddWithValue("@frazaszukana", temp1);
                    Console.WriteLine(cmdlog.CommandText.ToString());
                    cmdlog.ExecuteNonQuery();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmdlog);
                    MySqlCommandBuilder ccc = new MySqlCommandBuilder(da);
                    //DataTable dt = new DataTable();
                    DataTable dt = new DataTable();

                    da.Fill(dt);
                    dgKontener.DataContext = dt;
                    conn.Close();
            }
                catch (MySqlException se)
                {
                    System.Windows.MessageBox.Show("Wystąpił błąd połączenia: " + se.ToString());
                }
            
        }
        }



    }









    




