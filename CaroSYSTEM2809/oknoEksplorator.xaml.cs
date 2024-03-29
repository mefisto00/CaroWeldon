﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using Microsoft.Win32;
using System.Data;
using System.IO;
using System.Collections;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Diagnostics;

namespace CaroSYSTEM2809
{
    /// <summary>
    /// Logika interakcji dla klasy oknoEksplorator.xaml
    /// </summary>
    public partial class oknoEksplorator : Window


    {

        private string szukajKlienta;
        private string szukajKontener;

        

        public string SzukajKlienta
        {
            get { return szukajKlienta; }
            private set { szukajKlienta = ex_poleSzukajKlient.Text; }  

        }
        public string SzukajKontener
        {
            get { return szukajKontener; }
            private set { szukajKontener = ex_poleSzukajKontener.Text; }

        }


        MenadzerEksploratorDB menadzerEksploratorDB = new MenadzerEksploratorDB();

        public oknoEksplorator()
        {

            InitializeComponent();
            E_stronaglowna.Visibility = Visibility.Visible;
            E_klienci.Visibility = Visibility.Collapsed;
            E_kontenery.Visibility = Visibility.Collapsed;
            E_umowy.Visibility = Visibility.Collapsed;
            dodajWpisKlient.Visibility = Visibility.Collapsed;
            dodajWpisKontener.Visibility = Visibility.Collapsed;
            refresz_kontener.Visibility = Visibility.Collapsed;
            refresz_klient.Visibility = Visibility.Collapsed;
            edytujWpisKlient.Visibility = Visibility.Collapsed;
            edytujWpisKontener.Visibility = Visibility.Collapsed;
            edytujWpisUmowa.Visibility = Visibility.Collapsed;
            
        }
 



      

            private void PokażStronaGlowna_Click(object sender, RoutedEventArgs e)
            {
                E_stronaglowna.Visibility = Visibility.Visible;
                E_klienci.Visibility = Visibility.Collapsed;
                E_kontenery.Visibility = Visibility.Collapsed;
                E_umowy.Visibility = Visibility.Collapsed;
                dodajWpisKlient.Visibility = Visibility.Collapsed;
                dodajWpisKontener.Visibility = Visibility.Collapsed;
                refresz_klient.Visibility = Visibility.Collapsed;
                refresz_kontener.Visibility = Visibility.Collapsed;
                edytujWpisKontener.Visibility = Visibility.Collapsed;
                edytujWpisKlient.Visibility = Visibility.Collapsed;
                edytujWpisUmowa.Visibility = Visibility.Collapsed;
            }

            private void pokazKlientBaza_Click(object sender, RoutedEventArgs e)
            {
                E_stronaglowna.Visibility = Visibility.Collapsed;
                E_klienci.Visibility = Visibility.Visible;
                E_kontenery.Visibility = Visibility.Collapsed;
                E_umowy.Visibility = Visibility.Collapsed;
                dodajWpisKlient.Visibility = Visibility.Visible;
                dodajWpisKontener.Visibility = Visibility.Collapsed;
                refresz_klient.Visibility = Visibility.Visible;
                refresz_kontener.Visibility = Visibility.Collapsed;
                edytujWpisKontener.Visibility = Visibility.Collapsed;
                edytujWpisKlient.Visibility = Visibility.Visible;
                edytujWpisUmowa.Visibility = Visibility.Collapsed;
            //aFillGrid("klienci", grid_klient);
                menadzerEksploratorDB.WypelnijTabeleKlient(grid_klient);

            }

            private void pokazKontenerBaza_Click(object sender, RoutedEventArgs e)
            {
                E_stronaglowna.Visibility = Visibility.Collapsed;
                E_klienci.Visibility = Visibility.Collapsed;
                E_kontenery.Visibility = Visibility.Visible;
                E_umowy.Visibility = Visibility.Collapsed;
                dodajWpisKlient.Visibility = Visibility.Collapsed;
                dodajWpisKontener.Visibility = Visibility.Visible;
                refresz_klient.Visibility = Visibility.Collapsed;
                refresz_kontener.Visibility = Visibility.Visible;
                edytujWpisKlient.Visibility = Visibility.Collapsed;
                edytujWpisKontener.Visibility = Visibility.Visible;
                edytujWpisUmowa.Visibility = Visibility.Collapsed;
                // aFillGrid("kontenery", grid_kont);
                menadzerEksploratorDB.WypelnijTabeleKontener(grid_kont);
            }

            private void Button_Click(object sender, RoutedEventArgs e)
            {

            }

            private void Button_Click_1(object sender, RoutedEventArgs e)
            {

            }

        //public void aFillGrid(string tabelaBD, DataGrid nazwaDataGrida)
        //{
        //    ///
        //    string sql = "SELECT * FROM " + tabelaBD;


        //    DataTable dt = new DataTable();
        //    MySqlDataAdapter da = new MySqlDataAdapter(cmdSel);
        //    da.Fill(dt);
        //    nazwaDataGrida.DataContext = dt;

        //    MySqlConnection conn = null;
        //    conn = new MySqlConnection(konfiguracja);
        //    conn.Open();
        //    string stm = "SELECT VERSION()";
        //    MySqlCommand cmdlog = new MySqlCommand(stm, conn);
        //    cmdlog.Connection = conn;
        //    cmdlog.CommandText = "select * from kontenery where kont_id=@id;";
        //    cmdlog.Prepare();

        //}

        /*
                    public void wypelnijTabeleKlient()
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


            */
        //public void wypelnijTabeleUmowy()
        //{

        //    try
        //    {

        //        MySqlConnection conn = PolaczenieDB.polaczenieZBazaDanych();
        //        string stm = "SELECT VERSION()";
        //        MySqlCommand cmdlog = new MySqlCommand(stm, conn);
        //        cmdlog.Connection = conn;
        //        // cmdlog.CommandText = "select * from umowy, kontenery, klienci, faktury where kontenery.fk_um_id=umowy.um_id and umowy.um_id=klienci.klient_id and umowy.fk_fa_id=faktury.fa_id";
        //        //cmdlog.CommandText = "select um_id, um_nrUmowy, um_dataRozpoczeciaUmowy, um_dataZakonczeniaUmowy, um_czyToAneks, um_aneksDoUmowy, klient_nazwa from umowy, klienci where umowy.fk_klient_id=klienci.klient_id;";
        //        cmdlog.CommandText = "select * from umowa, klient where umowa.idklienta=klient.id";

        //        cmdlog.Prepare();

        //        cmdlog.ExecuteNonQuery();
        //        MySqlDataAdapter da = new MySqlDataAdapter(cmdlog);
        //        MySqlCommandBuilder ccc = new MySqlCommandBuilder(da);
        //        //DataTable dt = new DataTable();
        //        DataTable dt = new DataTable();

        //        da.Fill(dt);
        //        grid_umowy.DataContext = dt;

        //    }
        //    catch (MySqlException se)
        //    {
        //        System.Windows.MessageBox.Show("Wystąpił błąd połączenia: " + se.ToString());
        //    }



        //}

        
            //public void wypelnijTabeleKontener()
            //{

            //    try
            //      {  
            //        MySqlConnection conn = PolaczenieDB.polaczenieZBazaDanych();
            //        string stm = "SELECT VERSION()";
            //        MySqlCommand cmdlog = new MySqlCommand(stm, conn);
            //        cmdlog.Connection = conn;
            //        cmdlog.CommandText = "select * from kontener;";
            //        cmdlog.Prepare();

            //        cmdlog.ExecuteNonQuery();
            //        MySqlDataAdapter da = new MySqlDataAdapter(cmdlog);
            //        MySqlCommandBuilder ccc = new MySqlCommandBuilder(da);
            //        //DataTable dt = new DataTable();
            //        DataTable dt = new DataTable();

            //        da.Fill(dt);
            //        grid_kont.DataContext = dt;

            //    }
            //    catch (MySqlException se)
            //    {
            //        System.Windows.MessageBox.Show("Wystąpił błąd połączenia: " + se.ToString());
            //    }


            //}




            private void EdytujWpisKlient_Click(object sender, RoutedEventArgs e)
            {
                DataRowView row = grid_klient.SelectedItem as DataRowView;
                eOknoKlient klient = new eOknoKlient(row.Row.ItemArray[0].ToString(), row.Row.ItemArray[1].ToString(), row.Row.ItemArray[2].ToString(), row.Row.ItemArray[3].ToString(), row.Row.ItemArray[4].ToString(), row.Row.ItemArray[5].ToString(), row.Row.ItemArray[6].ToString(), row.Row.ItemArray[7].ToString(), row.Row.ItemArray[8].ToString(), row.Row.ItemArray[9].ToString());
                klient.dodajDoBazyKlient.Visibility = Visibility.Collapsed;
                klient.Show();


        }

            private void DodajWpisKontener_Click(object sender, RoutedEventArgs e)
            {
                eOknoKontener kont = new eOknoKontener();
                kont.edytujWpisKontener.Visibility = Visibility.Collapsed;
                kont.UsunKontener.Visibility = Visibility.Collapsed;
                kont.Show();
            }

            private void EdytujWpisUmowa_Click(object sender, RoutedEventArgs e)
            {
                DataRowView row = grid_umowy.SelectedItem as DataRowView;
            eOknoUmowa umo = new eOknoUmowa(row.Row.ItemArray[0].ToString(), row.Row.ItemArray[1].ToString(), row.Row.ItemArray[2].ToString(), row.Row.ItemArray[3].ToString(), row.Row.ItemArray[4].ToString(), row.Row.ItemArray[5].ToString(), row.Row.ItemArray[7].ToString(), row.Row.ItemArray[8].ToString(), row.Row.ItemArray[9].ToString(), row.Row.ItemArray[10].ToString(), row.Row.ItemArray[11].ToString(), row.Row.ItemArray[12].ToString(), row.Row.ItemArray[13].ToString(), row.Row.ItemArray[14].ToString(), row.Row.ItemArray[15].ToString(), row.Row.ItemArray[16].ToString(), row.Row.ItemArray[17].ToString(), row.Row.ItemArray[18].ToString(), row.Row.ItemArray[19].ToString(), row.Row.ItemArray[20].ToString(), row.Row.ItemArray[21].ToString(), row.Row.ItemArray[22].ToString(), row.Row.ItemArray[23].ToString(), row.Row.ItemArray[24].ToString(), row.Row.ItemArray[25].ToString(), row.Row.ItemArray[27].ToString(), row.Row.ItemArray[29].ToString(), row.Row.ItemArray[30].ToString(), row.Row.ItemArray[31].ToString(), row.Row.ItemArray[32].ToString());
            //Console.WriteLine("0 -" + row.Row.ItemArray[0].ToString());
            //Console.WriteLine("0 -" + row.Row.ItemArray[0].ToString());
            //Console.WriteLine("1 -" + row.Row.ItemArray[1].ToString());
            //Console.WriteLine("2 -" + row.Row.ItemArray[2].ToString());
            //Console.WriteLine("3 -" + row.Row.ItemArray[3].ToString());
            //Console.WriteLine("4 -" + row.Row.ItemArray[4].ToString());
            //Console.WriteLine("5 -" + row.Row.ItemArray[5].ToString());
            //Console.WriteLine("6 -" + row.Row.ItemArray[6].ToString());
            //Console.WriteLine("7 -" + row.Row.ItemArray[7].ToString());
            //Console.WriteLine("8 -" + row.Row.ItemArray[8].ToString());
            //Console.WriteLine("9 -" + row.Row.ItemArray[9].ToString());
            //Console.WriteLine("10 -" + row.Row.ItemArray[10].ToString());
            //Console.WriteLine("11 -" + row.Row.ItemArray[11].ToString());
            //Console.WriteLine("12 -" + row.Row.ItemArray[12].ToString());
            //Console.WriteLine("13 -" + row.Row.ItemArray[13].ToString());
            //Console.WriteLine("14 -" + row.Row.ItemArray[14].ToString());
            //Console.WriteLine("15 -" + row.Row.ItemArray[15].ToString());
            //Console.WriteLine("16 -" + row.Row.ItemArray[16].ToString());
            //Console.WriteLine("17 -" + row.Row.ItemArray[17].ToString());
            //Console.WriteLine("18 -" + row.Row.ItemArray[18].ToString());
            //Console.WriteLine("19 -" + row.Row.ItemArray[19].ToString());
            //Console.WriteLine("20 -" + row.Row.ItemArray[20].ToString());
            //Console.WriteLine("21 -" + row.Row.ItemArray[21].ToString());
            //Console.WriteLine("22 -" + row.Row.ItemArray[22].ToString());
            //Console.WriteLine("23 -" + row.Row.ItemArray[23].ToString());
            //Console.WriteLine("24 -" + row.Row.ItemArray[24].ToString());
            Console.WriteLine("25 -" + row.Row.ItemArray[25].ToString());
            Console.WriteLine("26 -" + row.Row.ItemArray[26].ToString());
            Console.WriteLine("27 -" + row.Row.ItemArray[27].ToString());
           Console.WriteLine("28 -" + row.Row.ItemArray[28].ToString());
            Console.WriteLine("29 -" + row.Row.ItemArray[29].ToString());
            Console.WriteLine("30 -" + row.Row.ItemArray[30].ToString());
            Console.WriteLine("31 -" + row.Row.ItemArray[31].ToString());

            //umo.usunUmowa.Visibility = Visibility.Collapsed;
            umo.Show();

           
        }

            private void DodajWpisKlient_Click(object sender, RoutedEventArgs e)
            {
            eOknoKlient klient = new eOknoKlient();
                klient.edytujKlientBaza.Visibility = Visibility.Collapsed;
                klient.usuńKlient.Visibility = Visibility.Collapsed;
                klient.Show();

            }

            private void EdytujWpisKontener_Click(object sender, RoutedEventArgs e)
            {
                DataRowView row = grid_kont.SelectedItem as DataRowView;
            eOknoKontener kont = new eOknoKontener(row.Row.ItemArray[0].ToString(), row.Row.ItemArray[1].ToString(), row.Row.ItemArray[2].ToString(), row.Row.ItemArray[3].ToString(), row.Row.ItemArray[4].ToString(), row.Row.ItemArray[5].ToString(), row.Row.ItemArray[6].ToString(), row.Row.ItemArray[7].ToString(), row.Row.ItemArray[8].ToString(), row.Row.ItemArray[9].ToString(), row.Row.ItemArray[10].ToString(), row.Row.ItemArray[11].ToString(), row.Row.ItemArray[12].ToString(), row.Row.ItemArray[13].ToString(), row.Row.ItemArray[16].ToString());
            kont.dodajDoBazyKontener.Visibility = Visibility.Collapsed;
                kont.Show();

          

            }



            private void Refresz_kontener_Click(object sender, RoutedEventArgs e)
            {
               menadzerEksploratorDB.WypelnijTabeleKontener(grid_kont);

            }

            private void Refresz_klient_Click(object sender, RoutedEventArgs e)
            {

            menadzerEksploratorDB.WypelnijTabeleKlient(grid_klient);

            }

        private void PokazUmowyBaza_Click(object sender, RoutedEventArgs e)
            {
                E_stronaglowna.Visibility = Visibility.Collapsed;
                E_klienci.Visibility = Visibility.Collapsed;
                E_kontenery.Visibility = Visibility.Collapsed;
                E_umowy.Visibility = Visibility.Visible;
                dodajWpisKlient.Visibility = Visibility.Collapsed;
                dodajWpisKontener.Visibility = Visibility.Collapsed;
                refresz_klient.Visibility = Visibility.Collapsed;
                refresz_kontener.Visibility = Visibility.Collapsed;
                edytujWpisKlient.Visibility = Visibility.Collapsed;
                edytujWpisKontener.Visibility = Visibility.Collapsed;
                edytujWpisUmowa.Visibility = Visibility.Visible;
                // aFillGrid("kontenery", grid_kont);
                menadzerEksploratorDB.WypelnijTabeleUmowy(grid_umowy);
            }

        private void Ex_szukajUmowaBTN_Click(object sender, RoutedEventArgs e)
        {
            menadzerEksploratorDB.SzukajUmowy(grid_umowy, szukajKlienta);
            
            /*  string sciezka = "baza.config";
            string konfiguracja = File.ReadAllText(sciezka);
            try
            {

                MySqlConnection conn = null;
                conn = new MySqlConnection(konfiguracja);
                conn.Open();

                string stm = "SELECT VERSION()";
                MySqlCommand cmdlog = new MySqlCommand(stm, conn);
                cmdlog.Connection = conn;
                cmdlog.CommandText = " select * from klient where concat(numer,' ',notatka) like @frazaszukana";
                cmdlog.Prepare();
                //cmdlog.Parameters.AddWithValue("@frazaszukana", ex_poleSzukajKontener.Text);
                string temp1 = "%" + ex_poleSzukajKlient.Text + "%";
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
            } */
        }

        private void Ex_szukajKontenerBTN_Click(object sender, RoutedEventArgs e)
        {

            menadzerEksploratorDB.SzukajKontener(grid_kont, szukajKlienta);
            //string sciezka = "baza.config";
            //string konfiguracja = File.ReadAllText(sciezka);
            //try
            //{

            //    MySqlConnection conn = null;
            //    conn = new MySqlConnection(konfiguracja);
            //    conn.Open();

            //    string stm = "SELECT VERSION()";
            //    MySqlCommand cmdlog = new MySqlCommand(stm, conn);
            //    cmdlog.Connection = conn;
            //    cmdlog.CommandText = "select * from kontener where concat(nrCaro,' ',nrWeldon) like @frazaszukana";
            //    cmdlog.Prepare();
            //    //cmdlog.Parameters.AddWithValue("@frazaszukana", ex_poleSzukajKontener.Text);
            //    string temp1 = "%" + ex_poleSzukajKontener.Text + "%";
            //    cmdlog.Parameters.AddWithValue("@frazaszukana", temp1); 
            //    Console.WriteLine(cmdlog.CommandText.ToString());
            //    cmdlog.ExecuteNonQuery();
            //    MySqlDataAdapter da = new MySqlDataAdapter(cmdlog);
            //    MySqlCommandBuilder ccc = new MySqlCommandBuilder(da);
            //    //DataTable dt = new DataTable();
            //    DataTable dt = new DataTable();

            //    da.Fill(dt);
            //    grid_kont.DataContext = dt;
            //}
            //catch (MySqlException se)
            //{
            //    System.Windows.MessageBox.Show("Wystąpił błąd połączenia: " + se.ToString());
            //}
        }


            private void Ex_szukajKlientBTN_Click(object sender, RoutedEventArgs e)
        {
            menadzerEksploratorDB.SzukajKlienta(grid_klient, szukajKlienta);
            //string sciezka = "baza.config";
            //string konfiguracja = File.ReadAllText(sciezka);
            //try
            //{

            //    MySqlConnection conn = null;
            //    conn = new MySqlConnection(konfiguracja);
            //    conn.Open();

            //    string stm = "SELECT VERSION()";
            //    MySqlCommand cmdlog = new MySqlCommand(stm, conn);
            //    cmdlog.Connection = conn;
            //    cmdlog.CommandText = " select * from klient where concat(nazwa,' ',adres) like @frazaszukana";
            //    cmdlog.Prepare();
            //    //cmdlog.Parameters.AddWithValue("@frazaszukana", ex_poleSzukajKontener.Text);
            //    string temp1 = "%" + ex_poleSzukajKlient.Text + "%";
            //    cmdlog.Parameters.AddWithValue("@frazaszukana", temp1);
            //    Console.WriteLine(cmdlog.CommandText.ToString());
            //    cmdlog.ExecuteNonQuery();
            //    MySqlDataAdapter da = new MySqlDataAdapter(cmdlog);
            //    MySqlCommandBuilder ccc = new MySqlCommandBuilder(da);
            //    //DataTable dt = new DataTable();
            //    DataTable dt = new DataTable();

            //    da.Fill(dt);
            //    grid_klient.DataContext = dt;
            //}
            //catch (MySqlException se)
            //{
            //    System.Windows.MessageBox.Show("Wystąpił błąd połączenia: " + se.ToString());
            //}

        }

        private void Ex_resetujSzukajKlientBTN_Click(object sender, RoutedEventArgs e)
        {
            ex_poleSzukajKlient.Text = "";
            menadzerEksploratorDB.WypelnijTabeleKlient(grid_klient);

        }

        private void Ex_resetujSzukajKontenerBTN_Click(object sender, RoutedEventArgs e)
        {
            ex_poleSzukajKontener.Text = "";
            menadzerEksploratorDB.WypelnijTabeleKontener(grid_kont);
        }

        private void Ex_resetujSzukajUmowaBTN_Click(object sender, RoutedEventArgs e)
        {
            ex_poleSzukajUmowa.Text = "";
            menadzerEksploratorDB.WypelnijTabeleUmowy(grid_umowy);
        }

        private void Ex_poleSzukajKlient_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string sciezka = "baza.config";
                string konfiguracja = File.ReadAllText(sciezka);
                try
                {

                    MySqlConnection conn = null;
                    conn = new MySqlConnection(konfiguracja);
                    conn.Open();

                    string stm = "SELECT VERSION()";
                    MySqlCommand cmdlog = new MySqlCommand(stm, conn);
                    cmdlog.Connection = conn;
                    cmdlog.CommandText = " select * from klient where concat(nazwa,' ',adres) like @frazaszukana";
                    cmdlog.Prepare();
                    //cmdlog.Parameters.AddWithValue("@frazaszukana", ex_poleSzukajKontener.Text);
                    string temp1 = "%" + ex_poleSzukajKlient.Text + "%";
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

        private void Ex_poleSzukajKontener_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string sciezka = "baza.config";
                string konfiguracja = File.ReadAllText(sciezka);
                try
                {

                    MySqlConnection conn = null;
                    conn = new MySqlConnection(konfiguracja);
                    conn.Open();

                    string stm = "SELECT VERSION()";
                    MySqlCommand cmdlog = new MySqlCommand(stm, conn);
                    cmdlog.Connection = conn;
                    cmdlog.CommandText = "select * from kontener where concat(nrCaro,' ',nrWeldon) like @frazaszukana";
                    cmdlog.Prepare();
                    //cmdlog.Parameters.AddWithValue("@frazaszukana", ex_poleSzukajKontener.Text);
                    string temp1 = "%" + ex_poleSzukajKontener.Text + "%";
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
        }

        private void Ex_poleSzukajUmowa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string sciezka = "baza.config";
                string konfiguracja = File.ReadAllText(sciezka);
                try
                {

                    MySqlConnection conn = null;
                    conn = new MySqlConnection(konfiguracja);
                    conn.Open();

                    string stm = "SELECT VERSION()";
                    MySqlCommand cmdlog = new MySqlCommand(stm, conn);
                    cmdlog.Connection = conn;
                    cmdlog.CommandText = " select * from klient where concat(numer,' ',notatka) like @frazaszukana";
                    cmdlog.Prepare();
                    //cmdlog.Parameters.AddWithValue("@frazaszukana", ex_poleSzukajKontener.Text);
                    string temp1 = "%" + ex_poleSzukajKlient.Text + "%";
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
        }

       public string knazwa;
        public string kadres;
        public string knip;
        public string unumer;
        public string udatawystawienia;
        public string udatarozpoczecia;
        public string udatazakonczenia;
        public string ucenamycie;
        public string ucenatransdocelowy;
        public string ucenatranspowrotny;
        public string kkontakt;
        public string ukaucja;



        public class klasaKontener
        {
            public int dkid { get; set; }
            public string dknumer { get; set; }
            public string dktyp { get; set; }
            public double dkcenanetto { get; set; }
            public double dkubezpieczenie { get; set; }
            public double dkrazem { get; set; }

            public klasaKontener() { }

            public klasaKontener(int xdkid, string xdknumer, string xdktyp, double xdkcenanetto, double xdkubezpieczenie, double xdkrazem)
            {
                dkid = xdkid;
                dknumer = xdknumer;
                dktyp = xdktyp;
                dkcenanetto = xdkubezpieczenie;
                dkubezpieczenie = xdkubezpieczenie;
                dkrazem = xdkrazem;
            }
        }



        private void PokazUmowaPDF_Click(object sender, RoutedEventArgs e)
        {
            DataRowView dtrow = (DataRowView)((Button)e.Source).DataContext;
            string nazwa = "U_" + dtrow[1].ToString().ToUpper() + "_2019.pdf";
           string sciezka="Umowy/" + nazwa;
            Process.Start("AcroRd32.exe",sciezka);

        }

        //private void PokazUmowaPDF_Click(object sender, RoutedEventArgs e)
        //{
        //    DataRowView dtrow = (DataRowView)((Button)e.Source).DataContext;
        //    List<klasaKontener> listaKontener = new List<klasaKontener>();

        //    int temp_id;
        //    string temp_numercaro;
        //    string temp_typkontenera;
        //    double temp_cenanetto;
        //    double temp_ubezpieczenie;
        //    double temp_razem;


        //string FONT = "c:/windows/fonts/times.ttf";
        //    string FONT2= "c:/windows/fonts/timesbd.ttf";

        //    BaseFont bf = BaseFont.CreateFont(FONT, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
        //    //  BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
        //    BaseFont bf2 = BaseFont.CreateFont(FONT2, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

        //    Document document = new Document();
        //    PdfWriter writer = PdfWriter.GetInstance(document, new FileStream("testX.pdf", FileMode.Create));
        //    document.Open();

        //    iTextSharp.text.Paragraph CNaglowek = new iTextSharp.text.Paragraph();
        
        //    CNaglowek.Alignment = Element.ALIGN_CENTER;
        //    CNaglowek.Font = new Font(bf2, 13f);
        //    CNaglowek.Add("UMOWA NAJMU KONTENERÓW nr  U/"+ dtrow[1].ToString()+"\n");
        //    //CNaglowek.Add("KONTENER T")


        //    string sciezka = "baza.config";
        //    string konfiguracja = File.ReadAllText(sciezka);
        //    try
        //    {

        //        MySqlConnection conn = null;
        //        conn = new MySqlConnection(konfiguracja);
        //        conn.Open();

        //        string stm = "SELECT VERSION()";
        //        MySqlCommand cmdlog = new MySqlCommand(stm, conn);
        //        MySqlCommand cmdlog1 = new MySqlCommand(stm, conn);
        //        MySqlCommand cmdW = new MySqlCommand(stm, conn);
        //        cmdlog.Connection = conn;
        //        cmdlog.CommandText = "select kontener.id, kontener.typKontenera, kontener.nrCaro, kontener.cenaNetto from kontener, umowa where kontener.idumowy=umowa.id and umowa.id=@idUmowy";
        //        cmdlog.Prepare();  
        //        //cmdlog.Parameters.AddWithValue("@frazaszukana", ex_poleSzukajKontener.Text);

        //        cmdlog.Parameters.AddWithValue("@idUmowy", dtrow[0]);
        //        // Console.WriteLine(cmdlog.CommandText.ToString());
        //        //  cmdlog.ExecuteNonQuery();
        //        MySqlDataReader rdr = cmdlog.ExecuteReader();
        //        while (rdr.Read())
        //        {
        //            CNaglowek.Add("\nKONTENER TYP: " + rdr.GetString(1).ToString() + " O NR " + rdr.GetString(2).ToString());

        //            temp_id = rdr.GetInt16(0);
        //            temp_numercaro = rdr.GetString(2);
        //            temp_typkontenera = rdr.GetString(1);
        //           // string sss = rdr.GetString(3);
        //            if (rdr["cenaNetto"] == DBNull.Value) { temp_cenanetto = 0; } else temp_cenanetto = rdr.GetDouble(3);
        //            //temp_cenanetto = rdr.GetDouble(3);
        //            temp_ubezpieczenie = temp_cenanetto * 0.05;
        //            temp_razem = temp_ubezpieczenie + temp_cenanetto;
        //            listaKontener.Add(new klasaKontener(temp_id, temp_numercaro, temp_typkontenera, temp_cenanetto, temp_ubezpieczenie, temp_razem));
        //            //listaKontener.Add(new klasaKontener)
        //        }
        //        rdr.Close();


                



        //            cmdlog1.Connection = conn;
        //        cmdlog1.CommandText= "SELECT klient.nazwa, klient.adres, klient.nip, umowa.numer, umowa.dataWystawienia, umowa.dataRozpoczecia, umowa.dataZakonczenia, umowa.cenaMycie, umowa.cenaTransDocelowy, umowa.cenaTransPowrotny, klient.osobaKontaktowa, umowa.cenaKaucja from umowa, klient where umowa.idklienta=klient.id and umowa.id=@idUmowy";
        //        cmdlog1.Prepare();
        //        cmdlog1.Parameters.AddWithValue("@idUmowy", dtrow[0].ToString());
        //        MySqlDataReader rdr2 = cmdlog1.ExecuteReader();
        //        while(rdr2.Read())
        //        {
        //            knazwa = rdr2.GetString(0).ToString();
        //            kadres = rdr2.GetString(1).ToString();


        //            if (rdr2["nip"] != DBNull.Value)
        //            {
        //                knip= rdr2["nip"].ToString();
        //            }
        //            else
        //            {
        //                knip = "NULL";
        //            }


        //            unumer = rdr2.GetString(3).ToString();
        //            udatawystawienia = rdr2.GetString(4).ToString();
        //            udatarozpoczecia = rdr2.GetString(5).ToString();
        //            udatazakonczenia = rdr2.GetString(6).ToString();
        //            ucenamycie = rdr2.GetString(7).ToString();
        //            ucenatransdocelowy = rdr2.GetString(8).ToString();
        //            ucenatranspowrotny = rdr2.GetString(9).ToString();
        //           // kkontakt = rdr2.GetString(10).ToString();
        //            if (rdr2["osobaKontaktowa"] != DBNull.Value)
        //            {
        //                kkontakt = rdr2["osobaKontaktowa"].ToString();
        //            }
        //            else
        //            {
        //                knip = "NULL";
        //            }
        //            ukaucja = rdr2.GetString(11).ToString();
        //            ///


        //        }
        //        rdr2.Close();
        //        //Dodanie nagłówka
        //        document.Add(CNaglowek);

        //        //Zdefiniowanie CFrazy1

        //        iTextSharp.text.Paragraph CFraza1 = new iTextSharp.text.Paragraph();
        //        CFraza1.Font = new Font(bf, 10f);
        //        CFraza1.Add("\nzawarta w Brzezówce dnia: ");
        //        CFraza1.Add(new Chunk(udatawystawienia.Remove(udatawystawienia.Length-8), new Font(bf2)));
        //        CFraza1.Add(" pomiędzy: \n");

        //        CFraza1.Add(knazwa + "\n");
        //        CFraza1.Add(kadres + "\n");
        //        CFraza1.Add("reprezentowaną przez: \n");
        //        CFraza1.Add(kkontakt + "\n");
        //        CFraza1.Add("Zwanym dalej ");
        //        CFraza1.Add(new Chunk("Najemcą", new Font(bf2)));

        //        //dodanie CFrazy1 do dokumentu
        //        document.Add(CFraza1);



        //        //zdefiniowanie CFraza2
        //        iTextSharp.text.Paragraph CFraza2 = new iTextSharp.text.Paragraph();
        //        CFraza2.Font = new Font(bf2, 10f);
        //        CFraza2.Alignment = Element.ALIGN_CENTER;
        //        CFraza2.Add("a");

        //        //dodanie CFraza2 do dokumentu
        //        document.Add(CFraza2);

        //        //zdefiniowanie CFraza3
        //        iTextSharp.text.Paragraph CFraza3 = new iTextSharp.text.Paragraph();
        //        CFraza3.Font = new Font(bf, 10f);
        //        CFraza3.Alignment = Element.ALIGN_LEFT;

        //        CFraza3.Add(new Chunk("CARO Design Sp. z o.o. \n", new Font(bf2)));
        //        CFraza3.Add("Brzezówka 90A\n");
        //        CFraza3.Add("39-102 Brzezówka\n\n");
        //        CFraza3.Add("zarejestrowaną przez Sąd Rejonowy w Rzeszowie pod numerem KRS 00000281864\n");
        //        CFraza3.Add("NIP 537-24-56-851, Regon 060235541\n");
        //        CFraza3.Add("reprezentowaną przez\n");
        //        CFraza3.Add(new Chunk("Monika Różańska - V-ce Prezes Zarządu\n",new Font(bf2)));
        //        CFraza3.Add(new Chunk("Anna Krzystyniak-Gonet - Członek Zarządu\n", new Font(bf2)));
             
        //        CFraza3.Add("zwaną dalej ");
        //        CFraza3.Add(new Chunk("Wynajmującym", new Font(bf2)));

        //        //Dodanie CFraza3 do dokumentu
        //        document.Add(CFraza3);


        //        //zdefiniowanie CFraza4
        //        int xtemp = 2;
        //        iTextSharp.text.Paragraph CFraza4 = new iTextSharp.text.Paragraph();
        //        CFraza4.Font = new Font(bf2, 11f);
        //        CFraza4.Alignment = Element.ALIGN_CENTER;
        //        CFraza4.Add("\n§1. Przedmiot Umowy");

        //        document.Add(CFraza4);
        //        //zdefiniowanie CListy1
        //        iTextSharp.text.List CLista1 = new iTextSharp.text.List(iTextSharp.text.List.ORDERED, 20f);
        //        CLista1.IndentationLeft = 20f;

        //        // zdefiniowanie podlisty CListy1
              

        //        CLista1.Add(new iTextSharp.text.ListItem("Przedmiotem niniejszej umowy są zasady wynajmu przez Wynajmującego na rzecz Najemcy kontenerów określonych w zapisach Załącznika NR1 stanowącego integralną część niniejszej Umowy", new Font(bf, 10f)));
        //        CLista1.Add(new iTextSharp.text.ListItem("Zakres umowy nie obejmuje", new Font(bf, 10f)));

        //        iTextSharp.text.List subList = new iTextSharp.text.List(iTextSharp.text.List.ORDERED);
        //        subList.PreSymbol = string.Format("{0}.", xtemp);
               
                
        //        subList.Add(new iTextSharp.text.ListItem("Przygotowania podłoża pod kontenery (tj. niwelacja terenu/wypoziomowanie, płyty betonowe/ stopy fundamentowe pod naroża kontenerów, itp)", new Font(bf,10f)));
        //        subList.Add(new iTextSharp.text.ListItem("połączenia wewnętrznych instalacji z zewnętrznymi sieciami zasilającymi, tj. prąd, woda, kanalizacja, uziemienie zewnętrzne, instalacja telefoniczna, RTV, komputerowa, klimatyzacyjna,  itp.,", new Font(bf,10f)));
        //        subList.Add(new iTextSharp.text.ListItem("pomiarów elektrycznych kontenerów po podłączeniu do zewnętrznych sieci zasilających (pomiary zerowania instalacji elektrycznej oraz przeciwporażeniowej)", new Font(bf,10f)));
        //        subList.Add(new iTextSharp.text.ListItem("pomiarów zużycia energii elektrycznej kontenera,", new Font(bf,10f)));
        //        subList.Add(new iTextSharp.text.ListItem("dokumentacji architektoniczno-budowlanej kontenera", new Font(bf,10f)));
        //        subList.Add(new iTextSharp.text.ListItem("wszelkich wymaganych zezwoleń urzędowych", new Font(bf,10f)));
        //        CLista1.Add(subList);

        //        //dodanie Clista1 do dokumentu
        //        document.Add(CLista1);

        //        //zdefiniowanie CFraza5
                
        //        iTextSharp.text.Paragraph CFraza5 = new iTextSharp.text.Paragraph();
        //        CFraza5.Font = new Font(bf2, 11f);
        //        CFraza5.Alignment = Element.ALIGN_CENTER;
        //        CFraza5.Add("\n§2. Płatności");

        //        //zdefiniowanie Clisty2
        //        iTextSharp.text.List CLista2 = new iTextSharp.text.List(iTextSharp.text.List.ORDERED, 20f);
        //        CLista2.IndentationLeft = 20f;
        //        CLista2.Add(new iTextSharp.text.ListItem("Na podstawie niniejszej umowy Najemca zobowiązuje się zapłacić Wynajmującemu opłaty określone w Załączniku Nr 1", new Font(bf, 10f)));
        //        // CLista2.Add(new iTextSharp.text.ListItem( , new Font(bf, 10f)));
        //        CLista2.Add(new iTextSharp.text.ListItem("Załącznik Nr 1 określa cenę netto wynajmu oraz zakres i wysokość dodatkowych kosztów wynajmu", new Font(bf, 10f)));
        //        CLista2.Add(new iTextSharp.text.ListItem("Ceny określone w niniejszej Umowie wyrażone są w wartościach netto. Każdorazowo doliczony zostanie do nich podatek VAT w wysokości zgodnej z obowiązującą ustawą", new Font(bf, 10f)));
        //        CLista2.Add(new iTextSharp.text.ListItem("W przypadku, gdy okres najmu nie będzie obejmował pełnego miesiąca, czynsz najmu za taki okres wyliczany będzie jako iloczyn 1/30 –tej miesięcznego czynszu najmu oraz ilości dni", new Font(bf, 10f)));
        //        CLista2.Add(new iTextSharp.text.ListItem("Szczegółowe warunki płatności określone są w Załączniku Nr1 do niniejszej Umowy" , new Font(bf, 10f)));
        //        CLista2.Add(new iTextSharp.text.ListItem("Za dzień dokonania płatności przyjmuje się dzień wpływu środków pieniężnych na konto Wynajmującego" , new Font(bf, 10f)));
        //        CLista2.Add(new iTextSharp.text.ListItem("Wszystkie wpłaty będą uregulowane przez Najemcę w formie przelewu na rzecz Wynajmującego, na rachunek bankowy w banku: BGŻ SA, konto nr:  95 2030 0045 1110 0000 0184 9640." , new Font(bf, 10f)));
        //        CLista2.Add(new iTextSharp.text.ListItem("W przypadku nie zapłacenia w terminie jakiejkolwiek należności lub jej części wynikającej z niniejszej umowy, Wynajmujący zastrzega sobie prawo do naliczenia odsetek ustawowych", new Font(bf, 10f)));
        //        CLista2.Add(new iTextSharp.text.ListItem("Wynajmujący oświadcza, że jest płatnikiem podatku VAT od towarów i usług o numerze identyfikacyjnym NIP 537-24-56-851" , new Font(bf, 10f)));
        //        CLista2.Add(new iTextSharp.text.ListItem("Najemca oświadcza, że jest płatnikiem podatku VAT od towarów i usług o numerze identyfikacyjnym NIP "+knip+ " oraz upoważnia Wynajmującego do wystawiania faktur VAT bez podpisu odbierającego. " , new Font(bf, 10f)));

        //        //dodanie CFrazy5
        //        document.Add(CFraza5);

        //        //dodanie Clisty2
        //        document.Add(CLista2);

        //        //zdefiniowanie CFraza6

        //        iTextSharp.text.Paragraph CFraza6 = new iTextSharp.text.Paragraph();
        //        CFraza6.Font = new Font(bf2, 11f);
        //        CFraza6.Alignment = Element.ALIGN_CENTER;
        //        CFraza6.Add("\n§3. Okres wynajmu");

        //        //zdefiniowanie Clisty3
        //        iTextSharp.text.List CLista3 = new iTextSharp.text.List(iTextSharp.text.List.ORDERED, 20f);
        //        CLista3.IndentationLeft = 20f;
        //        CLista3.Add(new iTextSharp.text.ListItem("Okres wynajmu kontenera określony jest w Załączniku Nr 1 do niniejszej Umowy", new Font(bf, 10f)));
        //        CLista3.Add(new iTextSharp.text.ListItem("Okres wynajmu rozpoczyna się od dnia protokolarnego odbioru kontenera przez Najemcę, a kończy z dniem protokolarnego zwrotu kontenera przez Najemcę do Wynajmującego", new Font(bf, 10f)));
        //        CLista3.Add(new iTextSharp.text.ListItem("Strony zastrzegają możliwość przedłużenia lub skrócenia okresu wynajmu na warunkach określonych w niniejszej umowie", new Font(bf, 10f)));
        //        CLista3.Add(new iTextSharp.text.ListItem("Przedłużenie okresu najmu możliwe jest na pisemny wniosek Najemcy dostarczony Wynajmującemu nie później, niż na 7 dni przed końcem okresu wynajmu przewidzianego w Załączniku Nr 1", new Font(bf, 10f)));
        //        CLista3.Add(new iTextSharp.text.ListItem("Przedłużenie okresu najmu wymaga pisemnego aneksu do niniejszej Umowy", new Font(bf, 10f)));
        //        CLista3.Add(new iTextSharp.text.ListItem("Skrócenie okresu wynajmu przez Najemcę i wcześniejszy zwrot kontenerów, wymaga pisemnego wypowiedzenia niniejszej Umowy, dostarczonego Wynajmującemu przez Najemcę listem poleconym lub pocztą elektroniczną, najpóźniej przed upływem 7 dni przed planowanym wcześniejszym zwrotem, przy czym Wynajmujący będzie w takim wypadku uprawniony do obciążenia Najemcy opłatą dodatkową stanowiącą równowartość miesięcznego czynszu za wynajem przedmiotu najmu podlegającego wcześniejszemu zwrotowi", new Font(bf, 10f)));
        //        CLista3.Add(new iTextSharp.text.ListItem("Wypowiedzenie i/lub skrócenie Umowy przez Wynajmującego może nastąpić tylko z ważnych uzasadnionych przyczyn. W szczególności Wynajmujący może wypowiedzieć Umowę ze skutkiem natychmiastowym w przypadku rażącego naruszenia postanowień Umowy przez Najemcę (np. naruszenie terminu zapłaty czynszu o co najmniej 30 dni), ", new Font(bf, 10f)));
        //        CLista3.Add(new iTextSharp.text.ListItem("W przypadku wypowiedzenia przez Wynajmującego Umowy ze skutkiem natychmiastowym, Najemca zobowiązuje się bezzwłocznie, bez dodatkowego wezwania przygotować przedmiot najmu do odbioru oraz wydać go Wynajmującemu w terminie wskazanym przez tego ostatniego", new Font(bf, 10f)));
        //        CLista3.Add(new iTextSharp.text.ListItem("W przypadku wypowiedzenia Umowy przez Wynajmującego ze skutkiem natychmiastowym, uzasadnionego rażącym naruszaniem przez Najemcę warunków Umowy, Wynajmujący uprawniony będzie do zajęcia zdeponowanej u niego przez Najemcę kaucji, o której mowa w Załączniku Nr 1", new Font(bf, 10f)));
        //        // CLista2.Add(new iTextSharp.text.ListItem( , new Font(bf, 10f)));

        //        //dodanie CFrazy6
        //        document.Add(CFraza6);

        //        //dodanie Clisty3
        //        document.Add(CLista3);

        //        //zdefiniowanie CFraza7

        //        iTextSharp.text.Paragraph CFraza7 = new iTextSharp.text.Paragraph();
        //        CFraza7.Font = new Font(bf2, 11f);
        //        CFraza7.Alignment = Element.ALIGN_CENTER;
        //        CFraza7.Add("\n§4. Wydanie przedmiotu najmu");


        //        //zdefiniowanie Clisty4
        //        iTextSharp.text.List CLista4 = new iTextSharp.text.List(iTextSharp.text.List.ORDERED, 20f);
        //        CLista4.IndentationLeft = 20f;
        //        CLista4.Add(new iTextSharp.text.ListItem("Wydanie i zwrot kontenera odbywają się w drodze protokolarnego przekazania", new Font(bf, 10f)));
        //        CLista4.Add(new iTextSharp.text.ListItem("W przypadku, kiedy transport kontenera nie zostaje zlecony Wynajmującemu, ryzyko związane z przewozem kontenera ponosi Najemca, który jest uprawniony do osobistego, lub poprzez upoważnionego przedstawiciela dokonania technicznego odbioru przedmiotu najmu przed załadunkiem w siedzibie Wynajmującego oraz jego protokolarnego zdania po okresie najmu. Jeśli Najemca rezygnuje z tego prawa, tym samym zgadza się, aby wydania i odbioru dokonał jednostronnie Wynajmujący, tym samym przyjmując jego wszelkie deklaracje i zastrzeżenia co do stanu technicznego kontenerów", new Font(bf, 10f)));
        //        CLista4.Add(new iTextSharp.text.ListItem("Najemca jest zobowiązany być obecnym w trakcie rozładunku przy dostawie i załadunku w trakcie odbioru kontenera oraz nadzorować ich właściwy przebieg", new Font(bf, 10f)));
        //        CLista4.Add(new iTextSharp.text.ListItem("Najemca zobowiązany jest zapewnić dojazd i miejsce manewrowe dla samochodów dostarczających oraz odbierających kontenery, a także źródło prądu oraz wody na czas ewentualnego montażu obiektów wielomodułowych. ", new Font(bf, 10f)));
        //        CLista4.Add(new iTextSharp.text.ListItem("O ile Strony nie uzgodnią inaczej na piśmie, Najemca zobowiązuje się do stosownego przygotowania podłoża przed dostawą przedmiotu najmu (w tym w szczególności jego odpowiedniego utwardzenia i wypoziomowania), co stanowi warunek niezbędny dla posadowienia kontenera/obiektu modułowego", new Font(bf, 10f)));

        //        //dodanie CFrazy7
        //        document.Add(CFraza7);

        //        //dodanie Clisty4
        //        document.Add(CLista4);

        //        //zdefiniowanie CFraza8

        //        iTextSharp.text.Paragraph CFraza8 = new iTextSharp.text.Paragraph();
        //        CFraza8.Font = new Font(bf2, 11f);
        //        CFraza8.Alignment = Element.ALIGN_CENTER;
        //        CFraza8.Add("\n§5. Zwrot przedmiotu najmu");

        //        //zdefiniowanie Clisty5
        //        iTextSharp.text.List CLista5 = new iTextSharp.text.List(iTextSharp.text.List.ORDERED, 20f);
        //        CLista5.IndentationLeft = 20f;
        //        CLista5.Add(new iTextSharp.text.ListItem("Wraz z upływem okresu najmu, tj. nie później, niż do pierwszego dnia po zakończeniu najmu, Najemca powinien doprowadzić kontener do pełnej gotowości do odbioru. Dotyczy to również zakończenia najmu w drodze wcześniejszego wypowiedzenia Umowy przez którąkolwiek ze stron", new Font(bf, 10f)));

        //        //zdefiniowanie subListy1
        //        iTextSharp.text.List subList1 = new iTextSharp.text.List(iTextSharp.text.List.UNORDERED);
        //        subList1.SetListSymbol("\u2012");
        //        subList1.Add(new iTextSharp.text.ListItem(" doprowadzenie kontenera do stanu pierwotnego, tj. z dnia jego odbioru przez Najemcę", new Font(bf, 10f)));
        //        subList1.Add(new iTextSharp.text.ListItem(" opróżnienie z kontenera wszelkich przedmiotów nienależących do jego właściwego wyposażenia", new Font(bf, 10f)));
        //        subList1.Add(new iTextSharp.text.ListItem(" opróżnienie bojlera oraz odpływów (opłata za nieopróżniony bojler podana jest w Załączniku Nr1)", new Font(bf, 10f)));
        //        // subList.Add(new iTextSharp.text.ListItem("", new Font(bf, 10f)));
        //        CLista5.Add(subList1);

        //        CLista5.Add(new iTextSharp.text.ListItem("Po zakończeniu okresu najmu, Najemca zobowiązany jest bezzwłocznie wydać przedmiot najmu na żądanie Wynajmującego", new Font(bf, 10f)));
        //        CLista5.Add(new iTextSharp.text.ListItem("O ile obie Strony nie ustalą inaczej na piśmie, zwrot przedmiotu najmu nastąpi w miejscu/na placu budowy, na którym kontener został wydany Najemcy. Zwrotu Najemca powinien dokonać nie później, niż następnego dnia roboczego następującego po dniu rozwiązania umowy", new Font(bf, 10f)));
        //        CLista5.Add(new iTextSharp.text.ListItem("W przypadku nie wydania kontenera w terminie o którym mowa w ust. 3, Najemca upoważnia nieodwołanie Wynajmującego do samodzielnego odbioru kontenera i wejścia w takim przypadku na teren będący w posiadaniu Najemcy, w tym do otwarcia niezbędnych zamknięć i zabezpieczeń, bez jakichkolwiek roszczeń odszkodowawczych wobec Wynajmującego", new Font(bf, 10f)));
        //        CLista5.Add(new iTextSharp.text.ListItem("O dacie odbioru przedmiotu najmu Najemca zostanie poinformowany przez Wynajmującego pisemnie z min. 3-dniowym wyprzedzeniem", new Font(bf, 10f)));
        //        CLista5.Add(new iTextSharp.text.ListItem("W przypadku braku gotowości kontenera do odbioru w ustalonym przez Wynajmującego terminie, Najemca upoważnia Wynajmującego do opróżnienia kontenera z przedmiotów wykraczających poza jego pierwotne wyposażenie. Usunięte w takich okolicznościach z kontenera przedmioty nienależące do Wynajmującego, zostaną przez niego protokolarnie zinwentaryzowane i zdeponowane na magazynie Wynajmującego, na koszt Najemcy, na co Najemca niniejszym wyraża zgodę", new Font(bf, 10f)));
        //        CLista5.Add(new iTextSharp.text.ListItem("W przypadku opóźnienia terminu zwrotu kontenera Wynajmującemu, z przyczyn leżących po stronie Najemcy, na Najemcy spoczywa obowiązek uiszczenia na rzecz Wynajmującego tytułem wynagrodzenia za bezumowne korzystanie z przedmiotu najmu należności, odpowiadającej wartości czynszu najmu  za  okres   do chwili właściwego protokolarnego przekazania kontenera Wynajmującemu", new Font(bf, 10f)));
        //        CLista5.Add(new iTextSharp.text.ListItem("W razie przekroczenia ustalonego w umowie terminu zwrotu kontenera, z przyczyn leżących po stronie Najemcy, Wynajmujący uprawniony będzie do podjęcia kroków stosownych do wyegzekwowania  zwrotu kontenera i obciążenia Najemcy wszelkimi kosztami egzekucji, na co Najemca niniejszym wyraża zgodę.", new Font(bf, 10f)));
        //        CLista5.Add(new iTextSharp.text.ListItem("Ponadto w przypadku zawinionej przez Najemcę zwłoki w zwrocie kontenera, Wynajmujący uprawniony będzie do obciążenia Najemcy karą umowną w wysokości 100zł, za każdy dzień takiej zwłoki", new Font(bf, 10f)));
        //        CLista5.Add(new iTextSharp.text.ListItem("Najemca wyraża zgodę na obciążenie go przez Wynajmującego dodatkowymi opłatami wynikłymi z:", new Font(bf, 10f)));
        //        //zdefiniowanie subListy1
        //        iTextSharp.text.List subList2 = new iTextSharp.text.List(iTextSharp.text.List.UNORDERED);
        //        subList2.SetListSymbol("\u2012");
        //        subList2.Add(new iTextSharp.text.ListItem(" braku możliwości dojazdu i/lub rozładunku/załadunku kontenerów", new Font(bf, 10f)));
        //        subList2.Add(new iTextSharp.text.ListItem(" braku stosownego przygotowania podłoża pod kontener(y),", new Font(bf, 10f)));
        //        subList2.Add(new iTextSharp.text.ListItem(" opóźnień w rozładunku i/lub załadunku kontenerów powstałych z przyczyn nie leżących po stronie Wynajmującego", new Font(bf, 10f)));
        //        CLista5.Add(subList2);
        //        CLista5.Add(new iTextSharp.text.ListItem("Wysokość kosztów, o których mowa powyżej określa Załącznik Nr 1 stanowiący integralną część niniejszej Umowy", new Font(bf, 10f)));
        //        // CLista5.Add(new iTextSharp.text.ListItem("", new Font(bf, 10f)));
               

        //        //dodanie CFrazy8
        //        document.Add(CFraza8);

        //        //dodanie Clisty5
        //        document.Add(CLista5);


        //        //zdefiniowanie CFraza9
        //        iTextSharp.text.Paragraph CFraza9 = new iTextSharp.text.Paragraph();
        //        CFraza9.Font = new Font(bf2, 11f);
        //        CFraza9.Alignment = Element.ALIGN_CENTER;
        //        CFraza9.Add("\n§6. Stan techniczny przedmiotu najmu");

        //        //zdefiniowanie Clisty6
        //        iTextSharp.text.List CLista6 = new iTextSharp.text.List(iTextSharp.text.List.ORDERED, 20f);
        //        CLista6.IndentationLeft = 20f;
        //        CLista6.Add(new iTextSharp.text.ListItem("Po zakończeniu okresu najmu kontener poddany zostanie inspekcji technicznej przeprowadzonej przez przedstawicieli obu stron, co udokumentowane zostanie stosownym podpisanym przez upoważnionych reprezentantów Stron protokołem odbioru kontenera od Najemcy. Protokół zawierać będzie opis stanu i czystości kontenera oraz w razie potrzeby opis typu i zakresu ewentualnych uszkodzeń, wykraczających poza normalne zużycie wynikające z prawidłowego użytkowania kontenera", new Font(bf, 10f)));
        //        CLista6.Add(new iTextSharp.text.ListItem("Nie przystąpienie przez Najemcę do odbioru w wyznaczonym przez Wynajmującego terminie będzie jednoznaczne ze zgodą Najemcy na jednostronne zaprotokołowanie odbioru przez Wynajmującego oraz akceptacją wszelkich deklaracji i zastrzeżeń co do stanu technicznego przedmiotu najmu w chwili odbioru", new Font(bf, 10f)));
        //        CLista6.Add(new iTextSharp.text.ListItem("Wszelkie ubytki, uszkodzenia, defekty kontenera i zainstalowanego w nim wyposażenia, wykraczające poza normalne zużycie eksploatacyjne, a zaistniałe w okresie wynajmu, będą przywracane do stanu pierwotnego na koszt Najemcy, a Wynajmujący będzie uprawniony do wystawienia dodatkowej faktury, obciążającej Najemcę w tego tytułu (np. za konieczne naprawy, wymianę części zamiennych, usuwanie zanieczyszczeń z odpływów, koszty dodatkowego czyszczenia i remontów).", new Font(bf, 10f)));
        //        CLista6.Add(new iTextSharp.text.ListItem("Obowiązek udokumentowania, iż zwracany kontener jest w stanie z dnia wydania kontenera leży po stronie Najemcy.", new Font(bf, 10f)));

        //        //dodanie CFrazy9
        //        document.Add(CFraza9);

        //        //dodanie Clisty6
        //        document.Add(CLista6);


        //        //zdefiniowanie CFraza10
        //        iTextSharp.text.Paragraph CFraza10 = new iTextSharp.text.Paragraph();
        //        CFraza10.Font = new Font(bf2, 11f);
        //        CFraza10.Alignment = Element.ALIGN_CENTER;
        //        CFraza10.Add("\n§7. Warunki eksploatacji i użytkowania");

        //        //zdefiniowanie Clisty7
        //        iTextSharp.text.List CLista7 = new iTextSharp.text.List(iTextSharp.text.List.ORDERED, 20f);
        //        CLista7.IndentationLeft = 20;
        //        CLista7.Add(new iTextSharp.text.ListItem("Kontener może być używany tylko i wyłącznie na terytorium Rzeczypospolitej Polskiej, zgodnie ze swoim przeznaczeniem oraz wszelkimi zaleceniami Wynajmującego, jak również wytycznymi zawartymi w Instrukcji Eksploatacji i Obsługi Kontenera stanowiącej Załącznik nr 2 do niniejszej Umowy", new Font(bf, 10f)));
        //        CLista7.Add(new iTextSharp.text.ListItem("Wszelkie próby i przypadki połączenia kontenera z obiektami, instalacjami, przedmiotami lub kontenerami osób trzecich, wymagają uprzedniego pisemnego poinformowania Wynajmującego przez Najemcę o takim zamiarze oraz uprzedniego uzyskania od niego pisemnej zgody na realizację takich działań, która powinna być wyrażona w tej formie pod rygorem nieważności. Wynajmujący zastrzega sobie jednak prawo do odmowy udzielenia takiej zgody", new Font(bf, 10f)));
        //        CLista7.Add(new iTextSharp.text.ListItem("Bez względu na okoliczności, Najemca w każdym w/w przypadku ponosi pełną odpowiedzialność za prawidłowy montaż i demontaż oraz bierze na siebie wszelkie ryzyko oraz koszty z tym związane, w tym w szczególności wszelkie koszty ewentualnych usterek i napraw wynikłych wskutek takiego działania", new Font(bf, 10f)));
        //        CLista7.Add(new iTextSharp.text.ListItem("Bez pisemnej zgody wydanej przez Wynajmującego, przedmiot najmu nie może być zarządzany przez osoby trzecie i niezatrudnione przez Najemcę. Zgoda, o której mowa w zdaniu poprzednim powinna być wyrażona w formie pisemnej pod rygorem nieważnośc", new Font(bf, 10f)));
        //        CLista7.Add(new iTextSharp.text.ListItem("Podczas całego okresu najmu, Najemca jest zobowiązany do dbałości o stan techniczny kontenera, przeprowadzania regularnych kontroli stanu kontenera oraz usuwania wszelkich czynników mogących mieć wpływ na jego pogorszenie.", new Font(bf, 10f)));
        //        CLista7.Add(new iTextSharp.text.ListItem("W okresie najmu, Najemca może dokonywać napraw przedmiotu najmu we własnym zakresie wyłącznie po wcześniejszym pisemnym zgłoszeniu usterki Wynajmującemu oraz na podstawie pisemnych instrukcji przesyłanych każdorazowo przez Wynajmującego", new Font(bf, 10f)));
        //        CLista7.Add(new iTextSharp.text.ListItem("W przypadku wystąpienia w okresie najmu uszkodzenia przedmiotu najmu, Najemca zawiadomi Wynajmującego o uszkodzeniu pisemnie (faxem lub e-mailem). ", new Font(bf, 10f)));
        //        CLista7.Add(new iTextSharp.text.ListItem("Koszty przeglądów i drobnych napraw związanych z bieżącym użytkowaniem każdego kontenera w trakcie najmu, w tym w szczególności wymiany świetlówek, wkładów zamków, bezpieczników itp. ponoszone są przez Najemcę.", new Font(bf, 10f)));
        //        CLista7.Add(new iTextSharp.text.ListItem("Najemca zobowiązuje się do używania w okresie najmu wyłącznie materiałów eksploatacyjnych tej samej klasy i standardu jak te, które zamontowane były przez Wynajmującego", new Font(bf, 10f)));

        //        //dodanie CFrazy10
        //        document.Add(CFraza10);

        //        //dodanie Clisty7
        //        document.Add(CLista7);


        //        //zdefiniowanie CFraza11
        //        iTextSharp.text.Paragraph CFraza11 = new iTextSharp.text.Paragraph();
        //        CFraza11.Font = new Font(bf2, 11f);
        //        CFraza11.Alignment = Element.ALIGN_CENTER;
        //        CFraza11.Add("\n§8. Odpowiedzialność materialna i prawna");

        //        //zdefiniowanie Clisty8
        //        iTextSharp.text.List CLista8 = new iTextSharp.text.List(iTextSharp.text.List.ORDERED, 20f);
        //        CLista8.IndentationLeft = 20;
        //        CLista8.Add(new iTextSharp.text.ListItem("Z chwilą protokolarnego odbioru kontenera do momentu jego protokolarnego zwrotu, na Najemcy spoczywa wszelka odpowiedzialność materialna i prawna, wszelkie ryzyko związane z zabezpieczeniem i dozorem kontenera, jak również jego utrzymaniem w dobrym stanie technicznym", new Font(bf, 10f)));
        //        CLista8.Add(new iTextSharp.text.ListItem("W przypadku, kiedy transport kontenera nie zostaje zlecony Wynajmującemu, Najemca przejmuje wszelkie ryzyko oraz pełną odpowiedzialność materialną i prawną za przedmiot najmu od momentu jego pobrania w siedzibie Wynajmującego, aż do chwili jego protokolarnego zwrotu", new Font(bf, 10f)));
        //        CLista8.Add(new iTextSharp.text.ListItem("Najemca bierze na siebie pełną odpowiedzialność materialną za właściwą eksploatację przedmiotu najmu oraz jego właściwe zabezpieczenie przed zniszczeniem i kradzieżą", new Font(bf, 10f)));
        //        CLista8.Add(new iTextSharp.text.ListItem("Za jakikolwiek uszczerbek/usterkę kontenerów będących przedmiotem wynajmu Najemca odpowiada wobec Wynajmującego. Dotyczy to również przypadków, kiedy taki uszczerbek/usterka jest następstwem działania osób trzecich.", new Font(bf, 10f)));
        //        CLista8.Add(new iTextSharp.text.ListItem("W wypadku uszkodzeń powstałych w okresie najmu, Najemca zostanie obciążony i pokryje wszelkie koszty napraw, w tym koszty części zamiennych, robocizny oraz koszty dodatkowe powstałe na skutek dalszego użytkowania kontenera z uszkodzeniem, określone w cenniku, który stanowi Załącznik nr 3 do niniejszej Umowy", new Font(bf, 10f)));
        //        CLista8.Add(new iTextSharp.text.ListItem("W razie trwałego i nieodwracalnego uszkodzenia, zniszczenia lub utraty przedmiotu najmu, Najemca zobowiązany jest do zapłaty Wynajmującemu odszkodowania odpowiadającego wartości odtworzeniowej przedmiotu najmu, przy czym Najemca ma obowiązek uiszczenia w takim przypadku czynszu w wysokości umownej za okres od dnia zajścia zdarzenia do dnia zapłaty wspomnianego odszkodowania. ", new Font(bf, 10f)));
        //        CLista8.Add(new iTextSharp.text.ListItem("Najemca ponosi odpowiedzialność za szkody wynikłe z naruszania zasad BHP w trakcie używania przedmiotu najmu, w tym w szczególności w przypadku, gdy przedmiot najmu jest obsługiwany przez osoby nie posiadające odpowiednich, wymaganych przez prawo uprawnień. Nieznajomość tych zasad obciąża Najemcę.", new Font(bf, 10f)));
        //        CLista8.Add(new iTextSharp.text.ListItem("W przypadku przesunięcia terminu zwrotu kontenera Wynajmującemu, na Najemcy spoczywa obowiązek dozoru oraz dbałości o utrzymanie kontenera w dobrym stanie technicznym, aż do chwili protokolarnego przekazania kontenera Wynajmującemu.", new Font(bf, 10f)));
        //        CLista8.Add(new iTextSharp.text.ListItem("W dniu podpisania niniejszej umowy, Najemca wpłaci Wynajmującemu kaucję określoną w Załączniku Nr 1 do niniejszej umowy, tytułem zabezpieczenia kosztów ewentualnych napraw i szkód powstałych w czasie trwania najmu. O ile nie zaistnieją uzasadnione przesłanki do potrącenia kaucji na poczet nieuregulowanych rozliczeń Najemcy wobec Wynajmującego (w tym w szczególności za najem, transport, mycie lub naprawę usterek kontenera po okresie najmu, kar umownych, itp.), kaucja zostanie zwrócona Najemcy w terminie do 10 dni roboczych od daty zwrotu kontenera, po sprawdzeniu jego stanu technicznego lub w innym terminie ustalonym przez strony.", new Font(bf, 10f)));
        //        CLista8.Add(new iTextSharp.text.ListItem("Kontener nie może być użytkowany poza terytorium państwa polskiego.", new Font(bf, 10f)));

        //        //dodanie CFrazy1
        //        document.Add(CFraza11);

        //        //dodanie Clisty8
        //        document.Add(CLista8);

        //        //zdefiniowanie CFraza12
        //        iTextSharp.text.Paragraph CFraza12 = new iTextSharp.text.Paragraph();
        //        CFraza12.Font = new Font(bf2, 11f);
        //        CFraza12.Alignment = Element.ALIGN_CENTER;
        //        CFraza12.Add("\n§9. Pozostałe");

        //        //zdefiniowanie Clisty9
        //        iTextSharp.text.List CLista9 = new iTextSharp.text.List(iTextSharp.text.List.ORDERED, 20f);
        //        CLista9.IndentationLeft = 20;
        //        CLista9.Add(new iTextSharp.text.ListItem("Wszelkie zmiany w treści umowy wymagają, pod rygorem nieważności, pisemnego aneksu, skutecznego po podpisaniu go przez obie strony", new Font(bf, 10f)));
        //        CLista9.Add(new iTextSharp.text.ListItem("Strony zgodnie oświadczają, że osoby reprezentujące Najemcę i Wynajmującego przy zawieraniu niniejszej Umowy są prawnie umocowane do reprezentowania Stron zgodnie z wymogami zasad reprezentacji prawa polskiego. W związku z powyższym nie będą powoływać się na brak umocowania osoby reprezentującej w przypadku jakichkolwiek sporów, mogących wyniknąć z niniejszej Umowy", new Font(bf, 10f)));
        //        CLista9.Add(new iTextSharp.text.ListItem("Przedmiot najmu pozostaje własnością Wynajmującego przez cały okres najmu", new Font(bf, 10f)));
        //        CLista9.Add(new iTextSharp.text.ListItem("Strony mają obowiązek wzajemnego informowania się o wszelkich zmianach statusu prawnego swojej firmy, a także o wszczęciu postępowania upadłościowego, układowego i likwidacyjnego", new Font(bf, 10f)));
        //        CLista9.Add(new iTextSharp.text.ListItem("Podczas trwania umowy najmu Wynajmujący zastrzega sobie prawo do przeniesienia praw i obowiązków wynikających z niniejszej Umowy na stronę trzecią, o czym niezwłocznie poinformuje Najemcę ", new Font(bf, 10f)));
        //        CLista9.Add(new iTextSharp.text.ListItem("Wynajmujący oświadcza, że przedmiotowe kontenery są objęte polisą ubezpieczeniową NR 320000052559 w zakresie Ubezpieczenia mienia od ognia, kradzieży i innych zdarzeń losowych", new Font(bf, 10f)));
        //        CLista9.Add(new iTextSharp.text.ListItem("Jeżeli którekolwiek postanowienie niniejszej umowy okaże się w części lub w całości nieważne, okoliczność ta nie będzie miała wpływu na ważność pozostałych postanowień.", new Font(bf, 10f)));
        //        CLista9.Add(new iTextSharp.text.ListItem("Prawem obowiązującym dla niniejszej umowy jest prawo polskie. ", new Font(bf, 10f)));
        //        CLista9.Add(new iTextSharp.text.ListItem("Sądem właściwym dla rozstrzygnięcia sporu będzie sąd właściwy dla siedziby Wynajmującego", new Font(bf, 10f)));
        //        CLista9.Add(new iTextSharp.text.ListItem("Umowę niniejszą sporządzono w 2 jednobrzmiących egzemplarzach - każdy na prawach oryginału, przeznaczonych po 1 dla każdej ze stron. ", new Font(bf, 10f)));
        //        CLista9.Add(new iTextSharp.text.ListItem("Umowa wchodzi w życie z dniem podpisania. ", new Font(bf, 10f)));

        //        //dodanie CFrazy12
        //        document.Add(CFraza12);

        //        //dodanie Clisty9
        //        document.Add(CLista9);
        //        // CLista5.Add(new iTextSharp.text.ListItem("", new Font(bf, 10f)));

        //        //zdefiniowanie CFraza13
        //        iTextSharp.text.Paragraph CFraza13 = new iTextSharp.text.Paragraph();
        //        CFraza13.Font = new Font(bf2, 11f);
        //        CFraza13.Alignment = Element.ALIGN_LEFT;
        //        CFraza13.Add("\n\nZałączniki:");

        //        //zdefiniowanie CFraza14
        //        iTextSharp.text.Paragraph CFraza14 = new iTextSharp.text.Paragraph();
        //        CFraza14.Font = new Font(bf2, 11f);
        //        CFraza14.Alignment = Element.ALIGN_LEFT;
        //        CFraza14.IndentationLeft = 30;              
        //        CFraza14.Add(new Chunk("Załącznik nr 1 -", new Font(bf2)));
        //        CFraza14.Add(new Chunk(" Opis kontenerów i szczegółowe warunki finansowe wynajmu.\n", new Font(bf)));

        //        CFraza14.Add(new Chunk("Załącznik nr 2 -", new Font(bf2)));
        //        CFraza14.Add(new Chunk(" Instrukcja Montażu, Eksploatacji i Obsługi kontenerów biurowych, socjalnych, sanitarnych, socjalno-sanitarnych\n", new Font(bf)));

        //        CFraza14.Add(new Chunk("Załącznik nr 3 -", new Font(bf2)));
        //        CFraza14.Add(new Chunk(" Cennik napraw\n\n\n\n\n\n\n", new Font(bf)));

        //        document.Add(CFraza13);
        //        document.Add(CFraza14);

        //        //zdefiniowanie CFraza15
        //        iTextSharp.text.Paragraph CFraza15 = new iTextSharp.text.Paragraph();
        //        CFraza15.Font = new Font(bf2, 10f);
        //        CFraza15.Alignment = Element.ALIGN_LEFT;               
        //        CFraza15.Add(new Chunk("Wynajmujący                                                                                                                   Najemca", new Font(bf2)));

        //        document.Add(CFraza15);
        //        document.NewPage();

        //        ///Nowa strona
        //        ///


        //        //zdefiniowanie DFraza1

        //        iTextSharp.text.Paragraph DFraza1 = new iTextSharp.text.Paragraph();
        //        DFraza1.Font = new Font(bf2, 11f, 1);
        //        DFraza1.Alignment = Element.ALIGN_LEFT;
        //        DFraza1.Add(new Chunk("Załącznik Nr 1 \n",new Font(bf2)));
        //        DFraza1.Add(new Chunk("do Umowy Najmu Kontenerów nr: "+unumer+" z dnia: "+udatawystawienia.Remove(udatawystawienia.Length-8)+"  \n\n\n", new Font(bf2)));
        //        document.Add(DFraza1);


        //        PdfPTable dtab1 = new PdfPTable(7);
        //        PdfPRow row1 = null;
        //        float[] wi1 = new float[] { 1f, 2f, 1f, 1f, 1f, 1f, 1f };
        //        dtab1.SetWidths(wi1);
        //        dtab1.WidthPercentage = 100;

        //        dtab1.AddCell((new Phrase("LP", new Font(bf, 11))));
        //        dtab1.AddCell((new Phrase("RODZAJ KONTENERA", new Font(bf, 11))));
        //        dtab1.AddCell((new Phrase("TYP", new Font(bf, 11))));
        //        dtab1.AddCell((new Phrase("ILOŚĆ", new Font(bf, 11))));
        //        dtab1.AddCell((new Phrase("CENA 1m-c [PLN] netto", new Font(bf, 11))));
        //        dtab1.AddCell((new Phrase("UBEZPIECZENIE 5% ceny netto kontenera [PLN]", new Font(bf, 11))));
        //        dtab1.AddCell((new Phrase("ŁĄCZNIE 1m-c [PLN] netto", new Font(bf, 11))));
        //        int xint = 1;

        //        foreach (var item in listaKontener)
        //        {
        //            dtab1.AddCell((new Phrase(xint.ToString(), new Font(bf, 11))));
        //            dtab1.AddCell((new Phrase(item.dknumer.ToString(), new Font(bf, 11))));
        //            dtab1.AddCell((new Phrase(item.dktyp.ToString(), new Font(bf, 11))));
        //            dtab1.AddCell((new Phrase("1", new Font(bf, 11))));
        //            dtab1.AddCell((new Phrase(item.dkcenanetto.ToString(), new Font(bf, 11))));
        //            dtab1.AddCell((new Phrase(item.dkubezpieczenie.ToString(), new Font(bf, 11))));
        //            dtab1.AddCell((new Phrase(item.dkrazem.ToString(), new Font(bf, 11))));
        //            xint++;
        //        }
        //        byte aa = 100;
        //        byte ab = 100;
        //        byte ac = 100;
        //        PdfPCell dtab1cell1 = new PdfPCell(new Phrase("Suma 1 m-c", new Font(bf,11)));
        //        dtab1cell1.BackgroundColor = new BaseColor(190, 190, 190);

        //        PdfPCell dtab1cell0 = new PdfPCell(new Phrase("", new Font(bf, 11)));
        //        dtab1cell1.BackgroundColor = new BaseColor(190, 190, 190);
        //        dtab1cell0.Border = 0;

        //        //dtab1.AddCell((new Phrase("", new Font(bf, 11))));
        //        //dtab1.AddCell((new Phrase("", new Font(bf, 11))));
        //        //dtab1.AddCell((new Phrase("", new Font(bf, 11))));
        //        //dtab1.AddCell((new Phrase("", new Font(bf, 11))));
        //        //dtab1.AddCell((new Phrase("", new Font(bf, 11))));
        //        dtab1.AddCell(dtab1cell0);
        //        dtab1.AddCell(dtab1cell0);
        //        dtab1.AddCell(dtab1cell0);
        //        dtab1.AddCell(dtab1cell0);
        //        dtab1.AddCell(dtab1cell0);

        //        dtab1.AddCell(dtab1cell1);

        //        double dtab1Suma = listaKontener.Sum(x => x.dkrazem);
        //        dtab1.AddCell((new Phrase(dtab1Suma.ToString(), new Font(bf, 11))));

        //        document.Add(dtab1);

        //        //przerwa lubener
        //        iTextSharp.text.Paragraph CEnte1r = new iTextSharp.text.Paragraph();
        //        CEnte1r.Font = new Font(bf2, 10f);
        //        CEnte1r.Alignment = Element.ALIGN_LEFT;
        //        CEnte1r.Add(" \n \n \n \n");

        //        //druga tabela

        //        PdfPTable dtab2 = new PdfPTable(6);
        //        PdfPRow row2 = null;
        //        float[] wi2 = new float[] { 0.5f, 1f, 1f, 1f, 1f, 1f };
        //        dtab2.SetWidths(wi2);
        //        dtab2.WidthPercentage = 100;
        //        dtab2.PaddingTop = 10;

        //        dtab2.AddCell((new Phrase("LP", new Font(bf, 11))));
        //        dtab2.AddCell((new Phrase("DODATKOWE KOSZTY JEDNORAZOWE", new Font(bf, 11))));
        //        dtab2.AddCell((new Phrase("OPIS", new Font(bf, 11))));
        //        dtab2.AddCell((new Phrase("STAWKA [PLN] netto", new Font(bf, 11))));
        //        dtab2.AddCell((new Phrase("ILOŚĆ", new Font(bf, 11))));
        //        dtab2.AddCell((new Phrase("ŁĄCZNIE [PLN] netto", new Font(bf, 11))));

        //        dtab2.AddCell((new Phrase("1", new Font(bf, 11))));
        //        dtab2.AddCell((new Phrase("Transport docelowy z rozładunkiem (2 kontenery)", new Font(bf, 11))));
        //        dtab2.AddCell((new Phrase("", new Font(bf, 11))));
        //        dtab2.AddCell((new Phrase("", new Font(bf, 11))));
        //        dtab2.AddCell((new Phrase("", new Font(bf, 11))));
        //        dtab2.AddCell((new Phrase("", new Font(bf, 11))));

        //        dtab2.AddCell((new Phrase("2", new Font(bf, 11))));
        //        dtab2.AddCell((new Phrase("Transport powrotny z rozładunkiem (2 kontenery)", new Font(bf, 11))));
        //        dtab2.AddCell((new Phrase("", new Font(bf, 11))));
        //        dtab2.AddCell((new Phrase("", new Font(bf, 11))));
        //        dtab2.AddCell((new Phrase("", new Font(bf, 11))));
        //        dtab2.AddCell((new Phrase("", new Font(bf, 11))));

        //        dtab2.AddCell((new Phrase("3", new Font(bf, 11))));
        //        dtab2.AddCell((new Phrase("Usługa mycia kontenera po wynajmie", new Font(bf, 11))));
        //        dtab2.AddCell((new Phrase("", new Font(bf, 11))));
        //        dtab2.AddCell((new Phrase("", new Font(bf, 11))));
        //        dtab2.AddCell((new Phrase("", new Font(bf, 11))));
        //        dtab2.AddCell((new Phrase("", new Font(bf, 11))));

        //        document.Add(CEnte1r);
        //        document.Add(dtab2);

        //        //Zdefiniowanie DFraza2
        //        iTextSharp.text.Paragraph DFraza2 = new iTextSharp.text.Paragraph();
        //        DFraza2.Font = new Font(bf, 10f, 1);
        //        DFraza2.Alignment = Element.ALIGN_LEFT;

        //        DFraza2.Add("Warunki dostawy:");
        //        DFraza2.Add(new Chunk("Loco:... \n", new Font(bf2)));

        //        DFraza2.Add("Warunki zwrotu:");
        //        DFraza2.Add(new Chunk("Loco:... \n", new Font(bf2)));

        //        DFraza2.Add("Okres wynajmu: od "+udatarozpoczecia.Remove(udatarozpoczecia.Length-8)+" do "+udatazakonczenia.Remove(udatazakonczenia.Length - 8) + " z możliwością przedłużenia i wszcześniejszego wypowiedzenia. \n");

        //        document.Add(DFraza2);

        //        Chunk underline = new Chunk("Szczegółowe warunki płatności:" +
        //            "\n- opłata najmu płatna jest przelewem z góry miesiąca" +
        //            "\n- termin płatności wynosi 14 dni (od dnia wystawienia faktury VAT przez Wynajmującego)" +
        //            "\n- kaucja płatna na podstawie faktury pro-forma, przed postawieniem kontenerów w wysokości: "+ukaucja+"\n\n", new Font(bf2,10f));
              
        //        underline.SetUnderline(0.1f, -2f); //0.1 thick, -2 y-location
        //        document.Add(underline);

        //        //zdefiniowanie Dfraza3
        //        iTextSharp.text.Paragraph DFraza3 = new iTextSharp.text.Paragraph();
        //        DFraza3.Font = new Font(bf, 10f, 1);
        //        DFraza3.Alignment = Element.ALIGN_LEFT;
        //        DFraza3.Add("\nUwagi:");

        //        document.Add(DFraza3);
        //        iTextSharp.text.List DLista1 = new iTextSharp.text.List(iTextSharp.text.List.UNORDERED, 20f);
        //        DLista1.IndentationLeft = 20;


        //        // CLista9.Add(new iTextSharp.text.ListItem(new Chunk("Loco:... \n"), new Font(bf, 10f)));
        //        Chunk ch0 = new Chunk(" ", new Font(bf, 10f));
        //        Chunk ch1 = new Chunk("opłata dodatkowa za poziomowanie kontenera", new Font(bf2, 10f));
        //        Chunk ch2 = new Chunk("naliczana w razie braku stosownego przygotowania podłoża pod kontener(y) wynosi - 150zł netto/1kontener", new Font(bf, 10f));
        //        iTextSharp.text.Paragraph ch1ch2 = new iTextSharp.text.Paragraph();
        //        ch1ch2.Add(ch0);
        //        ch1ch2.Add(ch1);
        //        ch1ch2.Add(" ");
        //        ch1ch2.Add(ch2);
        //        DLista1.Add(new iTextSharp.text.ListItem(ch1ch2));


        //        Chunk ch3 = new Chunk("opłata dodatkowa za przestój środka transportu ", new Font(bf2, 10f));
        //        Chunk ch4 = new Chunk("wynikły z przyczyn leżących po stronie Najemcy (np. brak możliwości wjazdu na budowę po przyjeździe HDSa na miejsce) wynosi - 150zł netto/godzina. ", new Font(bf, 10f));
        //        iTextSharp.text.Paragraph ch3ch4 = new iTextSharp.text.Paragraph();
        //        ch3ch4.Add(ch0);
        //        ch3ch4.Add(ch3);
        //        ch3ch4.Add(" ");
        //        ch3ch4.Add(ch4);
        //        DLista1.Add(new iTextSharp.text.ListItem(ch3ch4));

        //        Chunk ch5 = new Chunk("opłata za brak spuszczonej wody z bojlera i/lub odpływów ", new Font(bf2, 10f));
        //        Chunk ch6 = new Chunk("w chwili odbioru kontenera, wynosi 200zł netto.", new Font(bf, 10f));
        //        iTextSharp.text.Paragraph ch5ch6 = new iTextSharp.text.Paragraph();
        //        ch5ch6.Add(ch0);
        //        ch5ch6.Add(ch5);
        //        ch5ch6.Add(" ");
        //        ch5ch6.Add(ch6);
        //        DLista1.Add(new iTextSharp.text.ListItem(ch5ch6));
        //        DLista1.Add(new iTextSharp.text.ListItem(" Jeśli okres wynajmu kontenera przekracza 6 m-cy Wynajmujący w przypadku wzrostu kosztów spowodowanych ogólnymi warunkami gospodarczymi zastrzega sobie prawo zmiany cen najmu kontenera oraz kosztów jego zwrotu. Podwyższone opłaty obowiązywać będą od pierwszego dnia miesiąca następującego po miesiącu, z którym Najemca został poinformowany o zmianie warunków.", new Font(bf, 10f)));
        //        document.Add(DLista1);

        //        document.NewPage();

        //        //zdefiniowanie DFrazy4
        //        iTextSharp.text.Paragraph DFraza4 = new iTextSharp.text.Paragraph();
        //        DFraza4.Font = new Font(bf2, 11f);
        //        DFraza4.Alignment = Element.ALIGN_LEFT;
        //        DFraza4.Add(new Chunk("Załącznik Nr 2 do Umowy Najmu Kontenerów nr: " + unumer + " z dnia: " + udatawystawienia.Remove(udatawystawienia.Length - 8) + "  \n\n\n", new Font(bf2)));
        //        document.Add(DFraza4);

        //        Chunk DFraza5 = new Chunk("INSTRUKCJA MONTAŻU, EKSPLOATACJI KONTENERA, KONTENERÓW BIUROWYCH, SOCJALNYCH, SANITARNYCH , SOCJALNO-SANITARNEGO\n", new Font(bf, 10f));
        //        DFraza5.SetUnderline(0.1f, -2f);
        //        document.Add(DFraza5);

        //        Chunk DFraza6 = new Chunk("\nZasady bezpieczeństwa:\n",new Font(bf2,10f));
        //        DFraza5.SetUnderline(0.1f, -2f);
        //        document.Add(DFraza6);

        //        iTextSharp.text.List DLista2 = new iTextSharp.text.List(iTextSharp.text.List.UNORDERED, 20f);
        //        DLista2.IndentationLeft = 20;
        //        DLista2.SetListSymbol("\u2022");
        //        DLista2.Add(new iTextSharp.text.ListItem("Przed rozpoczęciem użytkowania kontenera, należy zapoznać się z zasadami bezpieczeństwa, zaleceniami producenta, instrukcją eksploatacji i obsługi.", new Font(bf,10f)));
        //        DLista2.Add(new iTextSharp.text.ListItem("Zachować szczególną ostrożność przy pracach związanych z transportem, montażem oraz serwisowaniem kontenera. W trakcie w/w czynności należy przestrzegać ogólnych zasad BHP.", new Font(bf, 10f)));
        //        DLista2.Add(new iTextSharp.text.ListItem("Kontener należy eksploatować zgodnie z ogólnymi zasadami BHP i Ppoż.", new Font(bf, 10f)));
        //        DLista2.Add(new iTextSharp.text.ListItem("Montaż kontenera powinna wykonywać osoba, która zapoznała się z poniższymi instrukcjami i zaleceniami producenta", new Font(bf, 10f)));
        //        DLista2.Add(new iTextSharp.text.ListItem("Naprawy serwisowe instalacji elektrycznej powinna wykonywać osoba wykwalifikowana z uprawnieniami elektrycznymi. Co najmniej raz w roku należy dokonać pomiarów instalacji elektrycznej, a wyniki udokumentować w protokole przeglądu", new Font(bf, 10f)));
        //        DLista2.Add(new iTextSharp.text.ListItem("Przed przystąpieniem do jakichkolwiek czynności serwisowych instalacji elektrycznej odłączyć zasilanie główne zewnętrzne kontenera.", new Font(bf, 10f)));
        //        DLista2.Add(new iTextSharp.text.ListItem("Nie zmieniać ustawień wodnego reduktora ciśnienia instalacji hydraulicznej ( niebezpieczeństwo zniszczenia lub rozszczelnienia instalacji. )", new Font(bf, 10f)));
        //        DLista2.Add(new iTextSharp.text.ListItem("Nie włączać (wyłączać) urządzeń elektrycznych wilgotnymi rękami", new Font(bf, 10f)));
        //        DLista2.Add(new iTextSharp.text.ListItem("Należy chronić zewnętrzny główny przewód zasilający przed uszkodzeniem, nie używać (nie ciągnąć) za przewód przy manewrowaniu i ustawianiu kontenera", new Font(bf, 10f)));
        //        DLista2.Add(new iTextSharp.text.ListItem("Nie wolno używać kontenera do innych celów niż określone w instrukcji eksploatacji i obsługi.", new Font(bf, 10f)));

        //        document.Add(ch0);
        //        document.Add(DLista2);

        //        iTextSharp.text.List DLista3 = new iTextSharp.text.List(iTextSharp.text.List.UNORDERED, 20f);
        //        DLista3.IndentationLeft = 20;
        //        DLista3.SetListSymbol("\u2022");
        //        DLista3.Add(new iTextSharp.text.ListItem("", new Font(bf)));

        //        Chunk ch7 = new Chunk("Załadunek i rozładunek kontenera dokonywany jest za pomocą dźwigu lub HDS. Zawiesia mocować za otwory w narożach górnych stalowej ramy kontenera ", new Font(bf,10f));
        //        Chunk ch8 = new Chunk("Nie dopuszcza się przenoszenia kontenerów obciążonych dodatkowym ładunkiem nie przewidzianym przez producenta !!!", new Font(bf2,10f));
        //        iTextSharp.text.Paragraph ch7ch8 = new iTextSharp.text.Paragraph();
        //        ch7ch8.Add(ch0);
        //        ch7ch8.Add(ch7);
        //        ch7ch8.Add(" ");
        //        ch7ch8.Add(ch8);

        //        iTextSharp.text.Paragraph DFraza7 = new iTextSharp.text.Paragraph();
        //        DFraza7.Font = new Font(bf2, 10f);
        //        DFraza7.Alignment = Element.ALIGN_LEFT;
        //        DFraza7.Add("\nZalecenia producenta dotyczące transportu i montażu kontenera(zestawu kontenerów)");
               

        //        DLista3.Add(new iTextSharp.text.ListItem("Kontener przeznaczony jest do transportu samochodowego lub kolejowego przy pomocy podwozia przystosowanego do tego typu ładunków. (Transport lądowy)", new Font(bf, 10f)));
        //        DLista3.Add(new iTextSharp.text.ListItem(ch7ch8));
        //        DLista3.Add(new iTextSharp.text.ListItem("Przed rozpoczęciem załadunku kontenera należy usunąć zalegający śnieg i lód z dachu używając do tego celu łopaty drewnianej lub z tworzywa sztucznego.", new Font(bf, 10f)));
        //        DLista3.Add(new iTextSharp.text.ListItem("Każdy kontener musi zostać posadowiony na przygotowanym fundamencie budowlanym posiadającym w przypadku kontenerów 10’ co najmniej 4 punkty podporowe a w przypadku kontenerów 20’ co najmniej 6 punktów. Rozmiar fundamentu oraz jego głębokość związana jest z obowiązującymi normami, lokalną głębokością przemarzania gruntu oraz właściwościami podłoża. ( minimalna powierzchnia fundamentu 20x20 cm)", new Font(bf,10f)));
        //        DLista3.Add(new iTextSharp.text.ListItem("Kontener należy ustawić na stabilnym, suchym i wypoziomowanym podłożu.", new Font(bf, 10f)));
        //        DLista3.Add(new iTextSharp.text.ListItem("Nie wolno ustawiać kontenera poniżej poziomu terenu oraz w zagłębieniach wypełnionych cieczą.", new Font(bf, 10f)));
        //        DLista3.Add(new iTextSharp.text.ListItem("Należy zapewnić swobodne rozsączanie się wód opadowych sprowadzonych pod kontener wewnętrznymi rurami spustowymi lub odprowadzić wody opadowe bezpośrednio do kanalizacji deszczowej.", new Font(bf, 10f)));
        //        DLista3.Add(new iTextSharp.text.ListItem("W przypadku zestawów wielomodułowych montaż musi odbywać się przy użyciu ściągów ( poziomych, pionowych, wewnętrznych), taśm uszczelniających oraz wszelkich izolacji i obróbek maskujących przewidzianych do danej technologii kontenera. Zestawy kontenerowe mogą być bezpiecznie eksploatowane przy ustawieniu maksymalnie dwóch kondygnacji. W przypadku 1-kondygnacyjnego zestawu, kontenery mogą być ustawione w dowolny sposób. Zestawy 2-kondygnacyjne można bezpiecznie eksploatować przy zestawieniu minimum dwóch modułów ze sobą ( zestawienie długimi bokami) na jednym poziomie.", new Font(bf, 10f)));
        //        DLista3.Add(new iTextSharp.text.ListItem("Przygotowanie kontenera do eksploatacji (czynności odpowiednio do rodzaju wyposażenia kontenera) ", new Font(bf, 10f)));
        //        DLista3.Add(new iTextSharp.text.ListItem("Wykonanie podłączenia kontenera do zewnętrznego obwodu ochronnego.", new Font(bf, 10f)));
        //        DLista3.Add(new iTextSharp.text.ListItem("Podłączenie zewnętrznego zasilania głównego kontenera", new Font(bf, 10f)));
        //        DLista3.Add(new iTextSharp.text.ListItem("Kolejno załączanie zabezpieczenia typu ,,S’’", new Font(bf, 10f)));
        //        DLista3.Add(new iTextSharp.text.ListItem("Sprawdzenie ciągłości przewodu ochronnego instalacji elektrycznej", new Font(bf, 10f)));
        //        DLista3.Add(new iTextSharp.text.ListItem("Sprawdzenie poprawności otwierania się drzwi i działania zamka.", new Font(bf, 10f)));
        //        DLista3.Add(new iTextSharp.text.ListItem("Sprawdzenie poprawności otwierania się okien i działania rolet.", new Font(bf, 10f)));
        //        DLista3.Add(new iTextSharp.text.ListItem("Podłączenie kontenera do zewnętrznej sieci wod-kan oraz izolacja termiczna przyłączy zewnętrznych", new Font(bf, 10f)));
        //        DLista3.Add(new iTextSharp.text.ListItem("Sprawdzenie szczelności układu hydraulicznego kontenera.", new Font(bf, 10f)));
        //        DLista3.Add(new iTextSharp.text.ListItem("Sprawdzenie czy instalacja i podgrzewacze są napełnione wodą (czy jest woda podłączona do instalacji i czy nie są zakręcone zawory na ,,zasilaniu i powrocie’’). Nie wolno włączać podgrzewaczy wody bez sprawdzenia (w przeciwnym wypadku nastąpi spalenie grzałek podgrzewacza).", new Font(bf, 10f)));
        //        DLista3.Add(new iTextSharp.text.ListItem("Sprawdzenie poprawności działania podgrzewaczy wody.", new Font(bf, 10f)));
        //        DLista3.Add(new iTextSharp.text.ListItem("Sprawdzenie poprawności działania spłuczek", new Font(bf, 10f)));
        //        DLista3.Add(new iTextSharp.text.ListItem("Sprawdzenie działania grzejnika elektrycznego (nie może być załączony bez równoczesnej pracy wentylatora grzejnika).", new Font(bf, 10f)));
        //        DLista3.Add(new iTextSharp.text.ListItem("Sprawdzenie drożności zewnętrznego i wewnętrznego systemu odprowadzenia wód opadowych", new Font(bf, 10f)));
        //        DLista3.Add(new iTextSharp.text.ListItem("Sprawdzenie stanu zewnętrznego konstrukcji stalowej oraz poszycia zewnętrznego stropodachu i ścian kontenera (uszkodzenia powłoki malarskiej, uszkodzenia mechaniczne poszyć ścian).", new Font(bf, 10f)));
        //        DLista3.Add(new iTextSharp.text.ListItem("Umycie i wyczyszczenie luster.", new Font(bf, 10f)));
        //        DLista3.Add(new iTextSharp.text.ListItem("Umycie wykładziny wewnątrz kontenera.", new Font(bf, 10f)));
        //        DLista3.Add(new iTextSharp.text.ListItem("Przed przystąpieniem do eksploatacji kontenera należy dokonać naprawy wszelkich uszkodzeń powstałych w trakcie transportu i montażu.", new Font(bf, 10f)));
        //        DLista3.Add(new iTextSharp.text.ListItem("W przypadku zarysowania powłok lakierniczych wykonać niezbędne zaprawki malarskie, aby zapobiec rozwijaniu się procesu korozji.", new Font(bf, 10f)));
        //        DLista3.Add(new iTextSharp.text.ListItem("Wszystkie przeróbki instalacji elektrycznej i hydraulicznej w trakcie montażu należy wcześniej skonsultować z producentem", new Font(bf, 10f)));
        //        DLista3.Add(new iTextSharp.text.ListItem("Wszelkie przeróbki trwale ingerujące w poszczególne elementy składowe kontenera należy wcześniej skonsultować z producentem.", new Font(bf, 10f)));
        //        DLista3.Add(new iTextSharp.text.ListItem("W przypadku kontenerów bez podłogi, w których zostanie wykonana posadzka metodą tradycyjną należy odpowiednio zabezpieczyć izolacją przeciwwilgociową oraz termiczną poszczególne elementy składowe kontenera, tak aby w trakcie wykonania, użytkowania i demontażu nie doprowadzić do trwałych uszkodzeń.\n(Należy zastosować wkładki oddzielające w miejscach styku posadzki z elementami kontenera umożliwiające późniejszy demontaż)", new Font(bf, 10f)));
        //        //  DLista3.Add(new iTextSharp.text.ListItem("", new Font(bf)));
        //        document.Add(DFraza7);
        //        document.Add(DLista3);


        //        Chunk ch9 = new Chunk("Zalecenia prodocenta dotyczące eksploatacji kontenera (zestawu kontenerów)\n",new Font (bf2,10f));
        //        ch9.SetUnderline(0.1f, -2f);
        //        Chunk ch10 = new Chunk("Charakterystyka dopuszczalnych obciążeń\n", new Font(bf, 10f));

        //        iTextSharp.text.List DLista4a = new iTextSharp.text.List(iTextSharp.text.List.UNORDERED, 20f);
        //        DLista4a.IndentationLeft = 20;
        //        DLista4a.Add(new iTextSharp.text.ListItem("Obciążenie użytkowe podłogi", new Font(bf,10f)));
        //        iTextSharp.text.List DLista4b = new iTextSharp.text.List(iTextSharp.text.List.UNORDERED, 20f);
        //        DLista4b.IndentationLeft = 20;
        //        DLista4b.SetListSymbol("\u2013");
        //        DLista4a.Add(DLista4b);
        //        DLista4b.Add(new iTextSharp.text.ListItem("parter – maksymalnie obciążenie 2,0 kN/m²", new Font(bf, 10f)));
        //        DLista4b.Add(new iTextSharp.text.ListItem("piętro – maksymalne obciążenie 1,5 kN/m²", new Font(bf, 10f)));

        //        DLista4a.Add(new iTextSharp.text.ListItem("Obciążenie stropodachu – maksymalnie obciążenie 1,0 kN/m²" +
        //            "\n W przypadku zalegania na dachu pokrywy śnieżnej powyżej 15cm grubości należy oczyścić dach ze śniegu", new Font(bf,10f)));
                               
                
        //        DLista4a.Add(new iTextSharp.text.ListItem("Obciążenie wiatrem – siła naporowa wiatru 25m/s", new Font(bf,10f)));

        //        document.Add(ch9);
        //        document.Add(ch10);
        //        document.Add(DLista4a);

        //        Chunk ch11 = new Chunk("W przypadku bardzo silnego wiatru konieczne jest dodatkowe, indywidualne zabezpieczenie kontenerów (odciągi, połączenia śrubowe, podpory itp.)\n", new Font(bf2, 10f));

        //        iTextSharp.text.List DLista5 = new iTextSharp.text.List(iTextSharp.text.List.UNORDERED, 20f);
        //        DLista5.IndentationLeft = 20;
        //        DLista5.SetListSymbol("\u2022");
        //        DLista5.Add(new iTextSharp.text.ListItem("Kontener należy użytkować zgodnie z jego przeznaczeniem.", new Font(bf, 10f)));
        //        DLista5.Add(new iTextSharp.text.ListItem("Wszystkie przeróbki instalacji elektrycznej i hydraulicznej w trakcie eksploatacji należy wcześniej skonsultować z producentem", new Font(bf, 10f)));

        //        document.Add(ch11);
        //        document.Add(DLista5);
        //        document.NewPage();




        //        //zdefiniowanie EFraza1
        //        iTextSharp.text.Paragraph EFraza1 = new iTextSharp.text.Paragraph();
        //        EFraza1.Font = new Font(bf2, 11f);
        //        EFraza1.Alignment = Element.ALIGN_LEFT;
        //        EFraza1.Add(new Chunk("Załącznik Nr 3 do Umowy Najmu Kontenerów nr: " + unumer + " z dnia: " + udatawystawienia.Remove(udatawystawienia.Length - 8) + "  \n\n\n", new Font(bf2)));
        //        document.Add(EFraza1);



        //        PdfPTable Etab1 = new PdfPTable(3);
        //        PdfPRow row3 = null;
        //        float[] wi3 = new float[] { 0.5f, 5f, 0.5f};
        //        Etab1.SetWidths(wi3);
        //        Etab1.WidthPercentage = 100;
        //        Etab1.PaddingTop = 10;

        //        Etab1.AddCell((new Phrase("LP", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("CENNIK NAPRAW", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("CENA NETTO [PLN]", new Font(bf, 10))));


        //        Etab1.AddCell((new Phrase("1", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("wymiana skrzydła drzwiowego wewnętrznego (kontener socjalny)-kpl", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("210,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("2", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("wymiana skrzydła drzwiowego wewnętrznego (kontener sanitarny)-kpl", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("280,00", new Font(bf, 10))));
              

        //        Etab1.AddCell((new Phrase("3", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("wymiana skrzydła drzwiowego zewnętrznego - kpl", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("345,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("4", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("wymiana panela drzwiowego z drzwiami stalowymi zewnętrznymi (kontener socjalny)", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("1 175,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("5", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("wymiana panela drzwiowego z drzwiami stalowymi zewnętrznymi (kontener sanitarny)", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("1 260,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("6", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("wymiana panela pełnego z montażem obróbek i silikonowaniem (kontener sanitarny)", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("570,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("7", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("wymiana panela pełnego z montażem obróbek i silikonowaniem (kontener socjalny)", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("500,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("8", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("usługa wymiany panela okiennego z montażem obróbek i silikonowaniem (kontener socjalny)", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("1 520,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("9", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("usługa wymiany panela okiennego z montażem obróbek i silikonowaniem (kontener sanitarny)", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("1 125,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("10", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("wymiana zamka drzwi zewnętrznych (wkładka + klamka)", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("120,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("11", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("wymiana zamka drzwi wewnętrznych (wkładka + klamka) kontener socjalny", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("115,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("12", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("wymiana zamka drzwi wewnętrznych sanitarnych (wkładka + klamka)", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("105,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("13", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("wymiana klamki drzwi wewnętrznych (kontener socjalny)", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("70,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("14", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("wymiana klamki drzwi wewnętrznych (kontener sanitarny)", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("75,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("15", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("wymiana klamki drzwi zewnętrznych", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("51,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("16", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("wymiana klamki okna", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("25,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("17", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("wymiana wkładki drzwi", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("45,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("18", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("wymiana ościeżnicy drzwi wewnętrznych z zawiasami w komplecie  (kontener socjalny i sanitarny)", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("380,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("19", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("wymiana ościeżnicy drzwi zewnętrznych z zawiasami w komplecie (kontener socjalny i sanitarny)", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("430,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("20", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("silikonowanie kontenera", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("85,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("21", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("usługa demontażu panela z obróbką- 1 szt", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("45,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("22", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("usługa montażu panela z obróbką i silikonowaniem- 1 szt", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("70,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("23", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("wymiana listwy paneli (PCV)", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("15,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("24", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("wymiana wykładziny PCV", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("620,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("25", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("wymiana wykładziny PCV kontener  10'", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("400,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("26", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("wymiana całej podłogi (wykładzina + płyta+wełna+folia)- kontener 20'", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("1 650,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("27", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("wymiana całej podłogi (wykładzina + płyta+wełna+folia)- kontener 10'", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("950,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("28", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("wymiana listwy przypodłogowej (sztuka)", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("30,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("29", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("wymiana zwijacza rolety", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("62,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("30", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("wymiana rolety", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("260,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("31", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("wymiana ścianki działowej pełnej", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("1 850,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("32", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("wymiana ścianki działowej z drzwiami", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("2 500,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("33", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("zaślepianie otworów do fi 1cm", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("15,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("34", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("czyszczenie z malowaniem wewnętrznej strony panela", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("200,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("35", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("czyszczenie z malowaniem zewnętrznej strony panela", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("200,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("36", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("czyszczenie z malowaniem ramy kontenera", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("900,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("37", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("czyszczenie z malowaniem całego kontenera 20'", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("1 760,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("38", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("czyszczenie z malowaniem całego kontenera 10'", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("1 100,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("39", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("naprawa okna", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("95,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("40", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("naprawa ściany kontenera do demontażu klimatyzatora podokiennego zamontowanego przez Najemcę ", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("200,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("41", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("wymiana grzejnika", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("400,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("42", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("wymiana umywalki", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("160,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("43", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("wymiana pisuaru", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("200,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("44", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("wymiana baterii pojedynczej", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("125,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("45", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("wymiana kabiny prysznicowej", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("810,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("46", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("wymiana zasłonki prysznicowej", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("41,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("47", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("wymiana baterii prysznicowej", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("230,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("48", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("wymiana muszli klozetowej", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("180,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("49", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("wymiana deski sedesowej ", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("60,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("50", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("wymiana podajnika papieru toaletowego", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("29,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("51", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("wymiana spłuczki do muszli klozetowej", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("85,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("52", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("wymiana bojlera ", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("1 530,00", new Font(bf, 10))));               

        //        Etab1.AddCell((new Phrase("53", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("wymiana rynny umywalkowej ", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("580,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("54", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("wymiana aneksu kuchennego", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("1 980,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("55", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("wymiana lustra", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("38,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("56", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("wymiana rury odpływowej", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("60,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("57", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("wymiana reduktora ciśnienia z manometrem", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("170,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("58", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("wymiana ścianki pisuarowej", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("160,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("59", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("wymiana półki pod lustro", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("38,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("60", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("wymiana spłuczki pisuar", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("170,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("61", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("wymiana podgrzewacza wody 10l", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("210,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("62", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("odtwarzanie instalacji sanitarnej cw, zw, kan. MS-SB3", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("330,00", new Font(bf, 10))));
               

        //        Etab1.AddCell((new Phrase("63", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("odtwarzanie instalacji sanitarnej cw, zw, kan. MS-S8 i MS-S9", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("570,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("64", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("wymiana obudowy skrzynki bezpieczników", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("210,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("65", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("wymiana zabezpieczenia 16-32A", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("52,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("66", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("wymiana wyłącznika różnicowego", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("164,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("67", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("wymiana gniazda/wtyku zewnętrznego", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("42,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("68", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("wymiana gniazda/wyłącznika wewnętrznego- kontener socjalny", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("34,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("69", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("wymiana gniazda/wyłącznika wewnętrznego- kontener sanitarny", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("39,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("70", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("wymiana lampy 2x36 W", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("181,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("71", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("wymiany plafonu", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("41,00", new Font(bf, 10))));

                              
        //        Etab1.AddCell((new Phrase("72", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("Odtwarzanie instalacji elektrycznej (robocizna sama)", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("300,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("73", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("specjalistyczne czyszczenie kontenera biurowego - zabrudzenia stałe", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("500,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("74", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("specjalistyczne czyszczenie kontenera sanitarnego - zabrudzenia stałe", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("800,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("75", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("wymiana wyłącznika- kontener sanitarny", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("34,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("76", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("wymiana wyłącznika- kontener socjalny", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("34,00", new Font(bf, 10))));

        //        Etab1.AddCell((new Phrase("77", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("wymiana obudowy skrzynki bezpieczników (rozdzielnia)", new Font(bf, 10))));
        //        Etab1.AddCell((new Phrase("215,00", new Font(bf, 10))));

        //        document.Add(Etab1);

        //    }
        //    catch (MySqlException ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }

         

        //    document.Close();
       
        //}
    }
    }

