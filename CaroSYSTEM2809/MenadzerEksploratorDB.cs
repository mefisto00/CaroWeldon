using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MySql.Data.MySqlClient;

namespace CaroSYSTEM2809
{
    public class MenadzerEksploratorDB : PolaczenieDB

    {

        public MenadzerEksploratorDB()
        {


        }


        public void WypelnijTabeleKlient(DataGrid grid_klient)
        {
            try
            {

                MySqlConnection conn = polaczenieZBazaDanych();
                string stm = "SELECT VERSION()";
                MySqlCommand cmdlog = new MySqlCommand(stm, conn);
                cmdlog.Connection = conn;
                cmdlog.CommandText = "select * from klient;";
                cmdlog.Prepare();

                cmdlog.ExecuteNonQuery();
                MySqlDataAdapter da = new MySqlDataAdapter(cmdlog);
                MySqlCommandBuilder ccc = new MySqlCommandBuilder(da);
                //DataTable dt = new DataTable();
                DataTable dt = new DataTable();

                da.Fill(dt);
                grid_klient.DataContext = dt;

            }
            catch (MySqlException se)
            {
                System.Windows.MessageBox.Show("Wystąpił błąd połączenia: " + se.ToString());
            }

        }
            public void WypelnijTabeleUmowy(DataGrid grid_umowy)
            {

                try
                {

                    MySqlConnection conn = polaczenieZBazaDanych();
                    string stm = "SELECT VERSION()";
                    MySqlCommand cmdlog = new MySqlCommand(stm, conn);
                    cmdlog.Connection = conn;
                    // cmdlog.CommandText = "select * from umowy, kontenery, klienci, faktury where kontenery.fk_um_id=umowy.um_id and umowy.um_id=klienci.klient_id and umowy.fk_fa_id=faktury.fa_id";
                    //cmdlog.CommandText = "select um_id, um_nrUmowy, um_dataRozpoczeciaUmowy, um_dataZakonczeniaUmowy, um_czyToAneks, um_aneksDoUmowy, klient_nazwa from umowy, klienci where umowy.fk_klient_id=klienci.klient_id;";
                    cmdlog.CommandText = "select * from umowa, klient where umowa.idklienta=klient.id";

                    cmdlog.Prepare();

                    cmdlog.ExecuteNonQuery();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmdlog);
                    MySqlCommandBuilder ccc = new MySqlCommandBuilder(da);
                    //DataTable dt = new DataTable();
                    DataTable dt = new DataTable();

                    da.Fill(dt);
                    grid_umowy.DataContext = dt;

                }
                catch (MySqlException se)
                {
                    System.Windows.MessageBox.Show("Wystąpił błąd połączenia: " + se.ToString());
                }



            }


        public void WypelnijTabeleKontener(DataGrid grid_kont)
        {

            try
            {
                MySqlConnection conn = polaczenieZBazaDanych();
                string stm = "SELECT VERSION()";
                MySqlCommand cmdlog = new MySqlCommand(stm, conn);
                cmdlog.Connection = conn;
                cmdlog.CommandText = "select * from kontener;";
                cmdlog.Prepare();

                cmdlog.ExecuteNonQuery();
                MySqlDataAdapter da = new MySqlDataAdapter(cmdlog);
                MySqlCommandBuilder ccc = new MySqlCommandBuilder(da);
                //DataTable dt = new DataTable();
                DataTable dt = new DataTable();

                da.Fill(dt);
                grid_kont.DataContext = dt;

            }
            catch (MySqlException se)
            {
                System.Windows.MessageBox.Show("Wystąpił błąd połączenia: " + se.ToString());
            }


        }

        public void SzukajUmowy(DataGrid grid_umowy, string szukajKlienta)
        {
           
            try
            {

                MySqlConnection conn = polaczenieZBazaDanych();

                string stm = "SELECT VERSION()";
                MySqlCommand cmdlog = new MySqlCommand(stm, conn);
                cmdlog.Connection = conn;
                cmdlog.CommandText = " select * from klient where concat(numer,' ',notatka) like @frazaszukana";
                cmdlog.Prepare();
                //cmdlog.Parameters.AddWithValue("@frazaszukana", ex_poleSzukajKontener.Text);
                string temp1 = "%" + szukajKlienta + "%";
                cmdlog.Parameters.AddWithValue("@frazaszukana", temp1);
                Console.WriteLine(cmdlog.CommandText.ToString());
                cmdlog.ExecuteNonQuery();
                MySqlDataAdapter da = new MySqlDataAdapter(cmdlog);
                MySqlCommandBuilder ccc = new MySqlCommandBuilder(da);
                //DataTable dt = new DataTable();
                DataTable dt = new DataTable();

                da.Fill(dt);
                grid_umowy.DataContext = dt;
            }
            catch (MySqlException se)
            {
                System.Windows.MessageBox.Show("Wystąpił błąd połączenia: " + se.ToString());
            }

        }
        public void SzukajKontener(DataGrid grid_kont, string szukajKontener)
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
                string temp1 = "%" + szukajKontener  + "%";
                cmdlog.Parameters.AddWithValue("@frazaszukana", temp1);
                Console.WriteLine(cmdlog.CommandText.ToString());
                cmdlog.ExecuteNonQuery();
                MySqlDataAdapter da = new MySqlDataAdapter(cmdlog);
                MySqlCommandBuilder ccc = new MySqlCommandBuilder(da);
                //DataTable dt = new DataTable();
                DataTable dt = new DataTable();

                da.Fill(dt);
                grid_kont.DataContext = dt;
            }
            catch (MySqlException se)
            {
                System.Windows.MessageBox.Show("Wystąpił błąd połączenia: " + se.ToString());
            }

        }

        public void SzukajKlienta(DataGrid grid_klient, string szukajKlient)
        {

            try
            {
                MySqlConnection conn = polaczenieZBazaDanych();
                string stm = "SELECT VERSION()";
                MySqlCommand cmdlog = new MySqlCommand(stm, conn);
                cmdlog.Connection = conn;
                cmdlog.CommandText = " select * from klient where concat(nazwa,' ',adres) like @frazaszukana";
                cmdlog.Prepare();
                //cmdlog.Parameters.AddWithValue("@frazaszukana", ex_poleSzukajKontener.Text);
                string temp1 = "%" + szukajKlient + "%";
                cmdlog.Parameters.AddWithValue("@frazaszukana", temp1);
                Console.WriteLine(cmdlog.CommandText.ToString());
                cmdlog.ExecuteNonQuery();
                MySqlDataAdapter da = new MySqlDataAdapter(cmdlog);
                MySqlCommandBuilder ccc = new MySqlCommandBuilder(da);
                //DataTable dt = new DataTable();
                DataTable dt = new DataTable();

                da.Fill(dt);
                grid_klient.DataContext = dt;
            }
            catch (MySqlException se)
            {
                System.Windows.MessageBox.Show("Wystąpił błąd połączenia: " + se.ToString());
            }





        }

    }
}