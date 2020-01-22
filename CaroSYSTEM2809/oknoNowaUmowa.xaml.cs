﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using iTextSharp.text;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;
using System.Windows.Controls;

namespace CaroSYSTEM2809
{
    /// <summary>
    /// Logika interakcji dla klasy oknoNowaUmowa.xaml
    /// </summary>
    public partial class oknoNowaUmowa : Window
    {

      //  private System.Windows.Controls.DataGrid grid_klient;


        public class klasaDodatki
        {
            public int did { get; set; }
            public string dnazwadodatku { get; set; }
            public double dcenadodatku { get; set; }
            public int diloscdodatku { get; set; }

            public klasaDodatki() { }

            public klasaDodatki( int id, string nazwa, double cena, int ilosc)
            {
                did = id;
                dnazwadodatku = nazwa;
                dcenadodatku = cena;
                diloscdodatku = ilosc;
            }



            }
     
        public class klasaWyposazenie
        {
            public int wid { get; set; }
            public string wnazwawyposazenia { get; set; }
            public double wcenadodatku { get; set; }
            public int wiloscdodatku { get; set; }

            public klasaWyposazenie() { }

            public klasaWyposazenie(int id, string nazwa, double cena, int ilosc)
            {
                wid = id;
                wnazwawyposazenia = nazwa;
                wcenadodatku = cena;
                wiloscdodatku = ilosc;

            }

        }


        public class klasaKontener
        {
            public int ko_id { get; set; }
            public string ko_numercaro { get; set; }
            public string ko_numerweldon { get; set; }
            public string ko_amortyzacjakontenera { get; set; }
            public string ko_cenanetto { get; set; }
            public string ko_typkontenera { get; set; }
            public string ko_czyklimatyzowany { get; set; }
            public string ko_podstawowewyposazeniekontenera { get; set; }
            public string ko_dodatkowewyposazeniekontenera { get; set; }
            public string ko_lokalizacja { get; set; }
            public string ko_cenaminimalna { get; set; }

            public string ko_datazakupukontenera { get; set; }
            public string ko_datakoncaamo { get; set; }

            public string ko_notatka { get; set; }
            public string ko_czywynajety { get; set; }



            public klasaKontener() { }

            public klasaKontener(int idkont, string ncaro, string nweldon, string aort, string cennet, string tkont, string klim, string podwyp, string dodwyp, string lok, string cenamin, string dtzak, string dtkonamo, string nota, string wynaj)
            {
                ko_id = idkont;
                ko_numercaro = ncaro;
                ko_numerweldon = nweldon;
                ko_amortyzacjakontenera = aort;
                ko_cenanetto = cennet;
                ko_typkontenera = tkont;
                ko_czyklimatyzowany = klim;
                ko_podstawowewyposazeniekontenera = podwyp;
                ko_dodatkowewyposazeniekontenera = dodwyp;
                ko_lokalizacja = lok;
                ko_cenaminimalna = cenamin;
                ko_datazakupukontenera = dtzak;
                ko_datakoncaamo = dtkonamo;
                ko_notatka = nota;
                ko_czywynajety = wynaj;


            }

        }


        public int k_idKlient;
        public int u_idUmowy;

       public string knazwa;
      public  string kadres;
       public string kkontakt;
      public  string knip;
        public double razem0 =0;
        public string xsciezka;
        public string r_kontenerID;
        public string r_dodatekID;
        List<klasaKontener> listaKontener = new List<klasaKontener>();

        List<klasaDodatki> listaDodatki = new List<klasaDodatki>();

        List<klasaWyposazenie> listaWyposazenie = new List<klasaWyposazenie>();


        public static string s_login;

        public System.Windows.Controls.DataGrid grid_klient
        {
            get;

            private set;

        }

        public oknoNowaUmowa()
    {
    InitializeComponent();
            uHome.Visibility = Visibility.Visible;
            uKontenery.Visibility = Visibility.Collapsed;
            uUmowa.Visibility = Visibility.Collapsed;
            this.grid_klient = grid_klient;

            MenadzerKlientDB menadzer = new MenadzerKlientDB(grid_klient);
                 
              

            poleNowaCenaNetto.Visibility = Visibility.Collapsed;
            wprowadzNowaCenaNettoBTN.Visibility = Visibility.Collapsed;

           

        }


        public oknoNowaUmowa(string login)
    {
             InitializeComponent();
              s_login = login;
              uHome.Visibility = Visibility.Visible;
              uKontenery.Visibility = Visibility.Collapsed;
              uUmowa.Visibility = Visibility.Collapsed;
            MenadzerKlientDB menadzer = new MenadzerKlientDB(dgKlient);






            poleNowaCenaNetto.Visibility = Visibility.Collapsed;
            wprowadzNowaCenaNettoBTN.Visibility = Visibility.Collapsed;

            listaDodatki.Add(new klasaDodatki(1, "schodnia", 0, 0));
            listaDodatki.Add(new klasaDodatki(2, "podest duży", 0, 0));
            listaDodatki.Add(new klasaDodatki(3, "podest mały", 0, 0));
            listaDodatki.Add(new klasaDodatki(4, "klimatyzacja", 0, 0));

            listaDodatki.Add(new klasaDodatki(5, "krzesło sosnowe", 10, 0));
            listaDodatki.Add(new klasaDodatki(6, "stół sosnowy 118x78 cm", 20, 0));

            listaDodatki.Add(new klasaDodatki(7, "regał na segregatory otwarty", 20, 0));

            listaDodatki.Add(new klasaDodatki(8, "szafka na dokumenty, zamykana wysoka", 30, 0));

            listaDodatki.Add(new klasaDodatki(9, "wieszak na ubrania stojący", 10, 0));

            listaDodatki.Add(new klasaDodatki(10, "biurko", 20, 0));

            listaDodatki.Add(new klasaDodatki(11, "krzeslo biurowe obrotowe", 20, 0));

            listaDodatki.Add(new klasaDodatki(12, "szafka BHP podwójna", 25, 0));

            listaDodatki.Add(new klasaDodatki(13, "klimatyzacja", 100, 0));

          

            odswiezPokazDodatki();

            poleListaNowaIlosc.Visibility = Visibility.Collapsed;
            poleListaNowaCena.Visibility = Visibility.Collapsed;




    }


        
        private void BWybranoKlient_Click(object sender, RoutedEventArgs e)
        {
            uHome.Visibility = Visibility.Collapsed;
            uKontenery.Visibility = Visibility.Visible;
            uUmowa.Visibility = Visibility.Collapsed;

            if (dgKlient.SelectedIndex != -1)
            {
                DataRowView row = (DataRowView)dgKlient.SelectedItems[0];
                k_idKlient = Convert.ToInt32(row[0].ToString());
                wypelnijTabeleKontener();
                MenadzerKlientDB menadzer = new MenadzerKlientDB(dgKlient);

            }
            else
            {
                k_idKlient = 999999;
                wypelnijTabeleKontener();
            }

           
        }

        private void BWybranoKontener_Click(object sender, RoutedEventArgs e)
        {
            uHome.Visibility = Visibility.Collapsed;
            uKontenery.Visibility = Visibility.Collapsed;
            uUmowa.Visibility = Visibility.Visible;




        }

        private void BWpisanoUmowe_Click(object sender, RoutedEventArgs e)
        {
            // System.Windows.MessageBox.Show("DD");

            MenadzerUtworzNowaUmoweDB dodajUmowe = new MenadzerUtworzNowaUmoweDB();
            dodajUmowe.utworzNowaUmowe();

            string sciezka = "baza.config";
            string konfiguracja = File.ReadAllText(sciezka);
            try
            {

                MySqlConnection conn = null;
                conn = new MySqlConnection(konfiguracja);
                conn.Open();

                string stm = "SELECT VERSION()";
                MySqlCommand cmd1 = new MySqlCommand(stm, conn);
                MySqlCommand cmd2 = new MySqlCommand(stm, conn);

                cmd1.Connection = conn;

                cmd1.CommandText = "INSERT INTO umowa(numer, dataRozpoczecia, dataZakonczenia, czyAneks, numerAneks, osobaZalogowana, cenaMeble, kosztMeble, cenaTransDocelowy, kosztTransDocelowy, cenaTransPowrotny, kosztTransPowrotny, cenaPodestSchody, kosztPodestSchody, cenaMontaz, kosztMontaz, cenaDemontaz, kosztDemontaz, cenaMycie, kosztMycie, cenaDodatek, kosztDodatek, cenaKaucja, terminZaplaty, fakturowanie, dataWystawienia, notatka, idklienta, miejsceWynajmu, dzierzawaSumaZaMsc, miejsceZwrotuKontenera, osobaDecyzyjna, cenaTransDocSchodyPodest, kosztTransDocSchodyPodest, cenaTransPowSchodyPodest, kosztTransPowSchodyPodest, cenaMontazPodest, kosztMontazPodest, cenaMontazSchody, kosztMontazSchody, cenaPoziomowanie, cenaDemontazSchody, kosztDemontazSchody, cenaDemontazPodesty, kosztDemontazPodesty, cenaPraceDodatkowe)" +
                    " VALUES(@numer, @dataRozpoczecia, @dataZakonczenia, @czyAneks, @numerAneks, @osobaZalogowana, @cenaMeble, @kosztMeble, @cenaTransDocelowy, @kosztTransDocelowy, @cenaTransPowrotny, @kosztTransPowrotny, @cenaPodestSchody, @kosztPodestSchody, @cenaMontaz, @kosztMontaz, @cenaDemontaz, @kosztDemontaz, @cenaMycie, @kosztMycie, @cenaDodatek, @kosztDodatek, @cenaKaucja, @terminZaplaty, @fakturowanie, @dataWystawienia, @notatka, @idklienta, @miejsceWynajmu, @dzierzawaSumaZaMsc, @miejsceZwrotuKontenera, @osobaDecyzyjna, @cenaTransDocSchodyPodest, @kosztTransDocSchodyPodest, @cenaTransPowSchodyPodest, @kosztTransPowSchodyPodest, @cenaMontazPodest, @kosztMontazPodest, @cenaMontazSchody, @kosztMontazSchody, @cenaPoziomowanie, @cenaDemontazSchody, @kosztDemontazSchody, @cenaDemontazPodesty, @kosztDemontazPodesty, @cenaPraceDodatkowe)";
                cmd1.Prepare();
                cmd1.Parameters.AddWithValue("@numer", poleNrUmowy.Text);
                cmd1.Parameters.AddWithValue("@dataRozpoczecia", poleDataRozpUm.Text);
                cmd1.Parameters.AddWithValue("@dataZakonczenia", poleDataZakUm.Text);
                cmd1.Parameters.AddWithValue("@czyAneks", Convert.ToInt32(poleCzyAneks.IsChecked));
                cmd1.Parameters.AddWithValue("@numerAneks", poleNumerUmowyAneksu.Text);
                cmd1.Parameters.AddWithValue("@dzierzawaSumaZaMsc", 0);
                cmd1.Parameters.AddWithValue("@osobaZalogowana", s_login);
                if (!string.IsNullOrEmpty(poleCenaMeble.Text))
                {
                    cmd1.Parameters.AddWithValue("@cenaMeble", przecinekNaKropke(poleCenaMeble.Text));

                }
                else
                {
                    cmd1.Parameters.AddWithValue("@cenaMeble", 0);
                }

                if (!string.IsNullOrEmpty(poleKosztMeble.Text))
                {
                    cmd1.Parameters.AddWithValue("@kosztMeble", przecinekNaKropke(poleKosztMeble.Text));

                }
                else
                {
                    cmd1.Parameters.AddWithValue("@kosztMeble", 0);
                }

                if (!string.IsNullOrEmpty(poleCenaTranDoc.Text))
                {
                    cmd1.Parameters.AddWithValue("@cenaTransDocelowy", przecinekNaKropke(poleCenaTranDoc.Text));

                }
                else
                {
                    cmd1.Parameters.AddWithValue("@cenaTransDocelowy", 0);
                }

                if (!string.IsNullOrEmpty(poleKosztTranDoc.Text))
                {
                    cmd1.Parameters.AddWithValue("@kosztTransDocelowy", przecinekNaKropke(poleKosztTranDoc.Text));

                }
                else
                {
                    cmd1.Parameters.AddWithValue("@kosztTransDocelowy", 0);
                }

                if (!string.IsNullOrEmpty(poleCenaTranPowr.Text))
                {
                    cmd1.Parameters.AddWithValue("@cenaTransPowrotny", przecinekNaKropke(poleCenaTranPowr.Text));

                }
                else
                {
                    cmd1.Parameters.AddWithValue("@cenaTransPowrotny", 0);
                }

                if (!string.IsNullOrEmpty(poleKosztTranPowr.Text))
                {
                    cmd1.Parameters.AddWithValue("@kosztTransPowrotny", przecinekNaKropke(poleKosztTranPowr.Text));

                }
                else
                {
                    cmd1.Parameters.AddWithValue("@kosztTransPowrotny", 0);
                }

                if (!string.IsNullOrEmpty(poleCenaPodestySchody.Text))
                {
                    cmd1.Parameters.AddWithValue("@cenaPodestSchody", przecinekNaKropke(poleCenaPodestySchody.Text));

                }
                else
                {
                    cmd1.Parameters.AddWithValue("@cenaPodestSchody", 0);
                }

                if (!string.IsNullOrEmpty(poleKosztPodestySchody.Text))
                {
                    cmd1.Parameters.AddWithValue("@kosztPodestSchody", przecinekNaKropke(poleKosztPodestySchody.Text));

                }
                else
                {
                    cmd1.Parameters.AddWithValue("@kosztPodestSchody", 0);
                }

                if (!string.IsNullOrEmpty(poleCenaMontaz.Text))
                {
                    cmd1.Parameters.AddWithValue("@cenaMontaz", przecinekNaKropke(poleCenaMontaz.Text));

                }
                else
                {
                    cmd1.Parameters.AddWithValue("@cenaMontaz", 0);
                }

                if (!string.IsNullOrEmpty(poleKosztMontaz.Text))
                {
                    cmd1.Parameters.AddWithValue("@kosztMontaz", przecinekNaKropke(poleKosztMontaz.Text));

                }
                else
                {
                    cmd1.Parameters.AddWithValue("@kosztMontaz", 0);
                }

                if (!string.IsNullOrEmpty(poleCenaDemontaz.Text))
                {
                    cmd1.Parameters.AddWithValue("@cenaDemontaz", przecinekNaKropke(poleCenaDemontaz.Text));

                }
                else
                {
                    cmd1.Parameters.AddWithValue("@cenaDemontaz", 0);
                }

                if (!string.IsNullOrEmpty(poleKosztDemontaz.Text))
                {
                    cmd1.Parameters.AddWithValue("@kosztDemontaz", przecinekNaKropke(poleKosztDemontaz.Text));

                }
                else
                {
                    cmd1.Parameters.AddWithValue("@kosztDemontaz", 0);
                }

                if (!string.IsNullOrEmpty(poleCenaMycia.Text))
                {
                    cmd1.Parameters.AddWithValue("@cenaMycie", przecinekNaKropke(poleCenaMycia.Text));

                }
                else
                {
                    cmd1.Parameters.AddWithValue("@cenaMycie", 0);
                }

                if (!string.IsNullOrEmpty(poleKosztMycia.Text))
                {
                    cmd1.Parameters.AddWithValue("@kosztMycie", przecinekNaKropke(poleKosztMycia.Text));

                }
                else
                {
                    cmd1.Parameters.AddWithValue("@kosztMycie", 0);
                }

                if (!string.IsNullOrEmpty(poleCenaDodatkowa.Text))
                {
                    cmd1.Parameters.AddWithValue("@cenaDodatek", przecinekNaKropke(poleCenaDodatkowa.Text));

                }
                else
                {
                    cmd1.Parameters.AddWithValue("@cenaDodatek", 0);
                }

                if (!string.IsNullOrEmpty(poleKosztDodatkowy.Text))
                {
                    cmd1.Parameters.AddWithValue("@kosztDodatek", przecinekNaKropke(poleKosztDodatkowy.Text));

                }
                else
                {
                    cmd1.Parameters.AddWithValue("@kosztDodatek", 0);
                }

                if (!string.IsNullOrEmpty(poleKaucja.Text))
                {
                    cmd1.Parameters.AddWithValue("@cenaKaucja", przecinekNaKropke(poleKaucja.Text));

                }
                else
                {
                    cmd1.Parameters.AddWithValue("@cenaKaucja", 0);
                }

                if (!string.IsNullOrEmpty(poleCenaTransDocSchPod.Text))
                {
                    cmd1.Parameters.AddWithValue("@cenaTransDocSchodyPodest", przecinekNaKropke(poleCenaTransDocSchPod.Text));

                }
                else
                {
                    cmd1.Parameters.AddWithValue("@cenaTransDocSchodyPodest", 0);
                }

                if (!string.IsNullOrEmpty(poleKosztTransDocSchPod.Text))
                {
                    cmd1.Parameters.AddWithValue("@kosztTransDocSchodyPodest", przecinekNaKropke(poleKosztTransDocSchPod.Text));

                }
                else
                {
                    cmd1.Parameters.AddWithValue("@kosztTransDocSchodyPodest", 0);
                }
                if (!string.IsNullOrEmpty(poleCenaTransPowSchPod.Text))
                {
                    cmd1.Parameters.AddWithValue("@cenaTransPowSchodyPodest", przecinekNaKropke(poleCenaTransPowSchPod.Text));

                }
                else
                {
                    cmd1.Parameters.AddWithValue("@cenaTransPowSchodyPodest", 0);
                }
                if (!string.IsNullOrEmpty(poleKosztTransPowSchPod.Text))
                {
                    cmd1.Parameters.AddWithValue("@kosztTransPowSchodyPodest", przecinekNaKropke(poleKosztTransPowSchPod.Text));

                }
                else
                {
                    cmd1.Parameters.AddWithValue("@kosztTransPowSchodyPodest", 0);
                }
                if (!string.IsNullOrEmpty(poleCenaMontazPodest.Text))
                {
                    cmd1.Parameters.AddWithValue("@cenaMontazPodest", przecinekNaKropke(poleCenaMontazPodest.Text));

                }
                else
                {
                    cmd1.Parameters.AddWithValue("@cenaMontazPodest", 0);
                }
                if (!string.IsNullOrEmpty(poleKosztMontazPodest.Text))
                {
                    cmd1.Parameters.AddWithValue("@kosztMontazPodest", przecinekNaKropke(poleKosztMontazPodest.Text));

                }
                else
                {
                    cmd1.Parameters.AddWithValue("@kosztMontazPodest", 0);
                }
                if (!string.IsNullOrEmpty(poleCenaMontazSchodow.Text))
                {
                    cmd1.Parameters.AddWithValue("@cenaMontazSchody", przecinekNaKropke(poleCenaMontazSchodow.Text));

                }
                else
                {
                    cmd1.Parameters.AddWithValue("@cenaMontazSchody", 0);
                }
                if (!string.IsNullOrEmpty(poleKosztMontazSchodow.Text))
                {
                    cmd1.Parameters.AddWithValue("@kosztMontazSchody", przecinekNaKropke(poleKosztMontazSchodow.Text));

                }
                else
                {
                    cmd1.Parameters.AddWithValue("@kosztMontazSchody", 0);
                }
                if (!string.IsNullOrEmpty(polePoziomowanie.Text))
                {
                    cmd1.Parameters.AddWithValue("@cenaPoziomowanie", przecinekNaKropke(polePoziomowanie.Text));

                }
                else
                {
                    cmd1.Parameters.AddWithValue("@cenaPoziomowanie", 0);
                }
                if (!string.IsNullOrEmpty(poleCenaDemontazSchodow.Text))
                {
                    cmd1.Parameters.AddWithValue("@cenaDemontazSchody", przecinekNaKropke(poleCenaDemontazSchodow.Text));

                }
                else
                {
                    cmd1.Parameters.AddWithValue("@cenaDemontazSchody", 0);
                }
                if (!string.IsNullOrEmpty(poleKosztDemontazSchodow.Text))
                {
                    cmd1.Parameters.AddWithValue("@kosztDemontazSchody", przecinekNaKropke(poleKosztDemontazSchodow.Text));

                }
                else
                {
                    cmd1.Parameters.AddWithValue("@kosztDemontazSchody", 0);
                }
                if (!string.IsNullOrEmpty(poleCenaDemontazPodestow.Text))
                {
                    cmd1.Parameters.AddWithValue("@cenaDemontazPodesty", przecinekNaKropke(poleCenaDemontazPodestow.Text));

                }
                else
                {
                    cmd1.Parameters.AddWithValue("@cenaDemontazPodesty", 0);
                }
                if (!string.IsNullOrEmpty(poleKosztDemontazPodestow.Text))
                {
                    cmd1.Parameters.AddWithValue("@kosztDemontazPodesty", przecinekNaKropke(poleKosztDemontazPodestow.Text));

                }
                else
                {
                    cmd1.Parameters.AddWithValue("@kosztDemontazPodesty", 0);
                }
                if (!string.IsNullOrEmpty(poleCenaPraceDodatkowe.Text))
                {
                    cmd1.Parameters.AddWithValue("@cenaPraceDodatkowe", przecinekNaKropke(poleCenaPraceDodatkowe.Text));

                }
                else
                {
                    cmd1.Parameters.AddWithValue("@cenaPraceDodatkowe", 0);
                }


                cmd1.Parameters.AddWithValue("@terminZaplaty", poleTerminPlatnosci.SelectedValue.ToString());
                cmd1.Parameters.AddWithValue("@fakturowanie", poleFakturowanie.SelectedValue.ToString());
                DateTime theDate = DateTime.Now;
                theDate.ToString("yyyy-MM-dd H:mm:ss");
                cmd1.Parameters.AddWithValue("@dataWystawienia", theDate);
                cmd1.Parameters.AddWithValue("@notatka", poleUwagi.Text);
                cmd1.Parameters.AddWithValue("@miejsceWynajmu", poleMiejsceWynajmu.Text);
                cmd1.Parameters.AddWithValue("@miejsceZwrotuKontenera", poleMiejsceZwrotuKontenera.SelectedValue.ToString());
               
                cmd1.Parameters.AddWithValue("@osobaDecyzyjna", poleOsobaDecyzyjna.Text);

                cmd1.Parameters.AddWithValue("@idklienta", k_idKlient);
                cmd1.ExecuteNonQuery();

                cmd2.Connection = conn;
                cmd2.CommandText = "SELECT id FROM umowa WHERE numer=@numer";
                cmd2.Prepare();
                cmd2.Parameters.AddWithValue("@numer", poleNrUmowy.Text);
                                           
                u_idUmowy = Convert.ToInt32(cmd2.ExecuteScalar());


                foreach (var item in listaKontener)
                {

                    try
                    {

                        conn = new MySqlConnection(konfiguracja);
                        conn.Open();
                        MySqlCommand cmdKontener = new MySqlCommand(stm, conn);
                        cmdKontener.CommandText = "UPDATE kontener SET idumowy=@idumowy, idklienta=@idklienta, czyWynajety=1 WHERE id=@idkont";
                        cmdKontener.Prepare();
                        cmdKontener.Parameters.AddWithValue("@idumowy", u_idUmowy);
                        cmdKontener.Parameters.AddWithValue("@idklienta", k_idKlient);
                        cmdKontener.Parameters.AddWithValue("@idkont", item.ko_id);
                        cmdKontener.ExecuteNonQuery();

                        //Console.WriteLine("CHUJ CHUJ" + item.ko_id);

                    }
                    catch (MySqlException se)
                    {
                        System.Windows.MessageBox.Show("Wystąpił błąd połączenia: " + se.ToString());
                    }
                }



                //Generacja PDF UMOWY
                string iloscpelnychmiesiecyumowy;
                string FONT = "c:/windows/fonts/times.ttf";
                string FONT2 = "c:/windows/fonts/timesbd.ttf";

                BaseFont bf = BaseFont.CreateFont(FONT, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                //  BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
                BaseFont bf2 = BaseFont.CreateFont(FONT2, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                string nazwaUmowyDokument = "U_" + poleNrUmowy.Text.ToUpper()+"_2019";

                Document document = new Document();
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(@"Umowy/"+nazwaUmowyDokument+".pdf", FileMode.Create));
                document.Open();

                iTextSharp.text.Paragraph CNaglowek = new iTextSharp.text.Paragraph();

                CNaglowek.Alignment = Element.ALIGN_CENTER;
                CNaglowek.Font = new Font(bf2, 13f);
                CNaglowek.Add("UMOWA NAJMU KONTENERÓW nr  U/" + poleNrUmowy.Text.ToString() + "/2019\n");
              
                foreach(var item in listaKontener)
                {
                    CNaglowek.Add("\nKONTENER TYP: " + item.ko_typkontenera.ToString() + " O NR " + item.ko_numercaro.ToString() +" / "+item.ko_numerweldon.ToString()+"");
                }

                //Dodanie nagłówka
                document.Add(CNaglowek);
               

                conn = new MySqlConnection(konfiguracja);
                conn.Open();
                MySqlCommand cmdlog1 = new MySqlCommand(stm, conn);
                cmdlog1.Connection = conn;
                cmdlog1.CommandText = "SELECT klient.nazwa, klient.adres, klient.nip, klient.osobaKontaktowa from klient where klient.id=@idklienta";
                cmdlog1.Prepare();
                cmdlog1.Parameters.AddWithValue("@idklienta", k_idKlient);

                MySqlCommand cmdlogX = new MySqlCommand(stm, conn);
                cmdlogX.Connection = conn;
                cmdlogX.CommandText = "select timestampdiff(month, @dataRozpoczeciaUmowy, @dataZakonczeniaUmowy) as mm;";
                cmdlogX.Prepare();
                cmdlogX.Parameters.AddWithValue("@dataRozpoczeciaUmowy", poleDataRozpUm.Text);
                cmdlogX.Parameters.AddWithValue("@dataZakonczeniaUmowy", poleDataZakUm.Text);
                iloscpelnychmiesiecyumowy = cmdlogX.ExecuteScalar().ToString();

                MySqlDataReader rdr2 = cmdlog1.ExecuteReader();
                while (rdr2.Read())
                {
                    knazwa = rdr2.GetString(0).ToString();
                    kadres = rdr2.GetString(1).ToString();


                    if (rdr2["nip"] != DBNull.Value)
                    {
                        knip = rdr2["nip"].ToString();
                    }
                    else
                    {
                        knip = "NULL";
                    }

                    kkontakt = rdr2.GetString(3).ToString();
                }
                rdr2.Close();


                    //Zdefiniowanie CFrazy1

                    iTextSharp.text.Paragraph CFraza1 = new iTextSharp.text.Paragraph();
                CFraza1.Font = new Font(bf, 10f);
                CFraza1.Add("\nzawarta w Brzezówce dnia: ");
                string tempC = poleDataPodpisaniaUmowy.ToString();

                CFraza1.Add(new Chunk(tempC.Remove(tempC.Length-8), new Font(bf2)));
                CFraza1.Add(" pomiędzy: \n");

                CFraza1.Add(knazwa + "\n");
                CFraza1.Add(kadres + "\n");
                CFraza1.Add("reprezentowaną przez: \n");
                CFraza1.Add(new Chunk(poleOsobaDecyzyjna.Text + "\n",new Font(bf2)));
                CFraza1.Add("Zwanym dalej ");
                CFraza1.Add(new Chunk("Najemcą", new Font(bf2)));

                //dodanie CFrazy1 do dokumentu
                document.Add(CFraza1);

                iTextSharp.text.Paragraph CFraza2 = new iTextSharp.text.Paragraph();
                CFraza2.Font = new Font(bf2, 10f);
                CFraza2.Alignment = Element.ALIGN_CENTER;
                CFraza2.Add("a");

                //dodanie CFraza2 do dokumentu
                document.Add(CFraza2);

                //zdefiniowanie CFraza3
                iTextSharp.text.Paragraph CFraza3 = new iTextSharp.text.Paragraph();
                CFraza3.Font = new Font(bf, 10f);
                CFraza3.Alignment = Element.ALIGN_LEFT;

                CFraza3.Add(new Chunk("CARO Design Sp. z o.o. \n", new Font(bf2)));
                CFraza3.Add("Brzezówka 90A\n");
                CFraza3.Add("39-102 Brzezówka\n\n");
                CFraza3.Add("zarejestrowaną przez Sąd Rejonowy w Rzeszowie pod numerem KRS 00000281864\n");
                CFraza3.Add("NIP 537-24-56-851, Regon 060235541\n");
                CFraza3.Add("reprezentowaną przez\n");
                CFraza3.Add(new Chunk("Monika Różańska - V-ce Prezes Zarządu\n", new Font(bf2)));
                CFraza3.Add(new Chunk("Anna Krzystyniak-Gonet - Członek Zarządu\n", new Font(bf2)));

                CFraza3.Add("zwaną dalej ");
                CFraza3.Add(new Chunk("Wynajmującym", new Font(bf2)));

                //Dodanie CFraza3 do dokumentu
                document.Add(CFraza3);

                //zdefiniowanie CFraza4
                int xtemp = 2;
                iTextSharp.text.Paragraph CFraza4 = new iTextSharp.text.Paragraph();
                CFraza4.Font = new Font(bf2, 11f);
                CFraza4.Alignment = Element.ALIGN_CENTER;
                CFraza4.Add("\n§1. Przedmiot Umowy");

                document.Add(CFraza4);
                //zdefiniowanie CListy1
                iTextSharp.text.List CLista1 = new iTextSharp.text.List(iTextSharp.text.List.ORDERED, 20f);
                CLista1.IndentationLeft = 20f;

                // zdefiniowanie podlisty CListy1


                CLista1.Add(new iTextSharp.text.ListItem("Przedmiotem niniejszej umowy są zasady wynajmu przez Wynajmującego na rzecz Najemcy kontenerów określonych w zapisach Załącznika NR1 stanowącego integralną część niniejszej Umowy", new Font(bf, 10f)));
                CLista1.Add(new iTextSharp.text.ListItem("Zakres umowy nie obejmuje", new Font(bf, 10f)));

                iTextSharp.text.List subList = new iTextSharp.text.List(iTextSharp.text.List.ORDERED);
                subList.PreSymbol = string.Format("{0}.", xtemp);


                subList.Add(new iTextSharp.text.ListItem("Przygotowania podłoża pod kontenery (tj. niwelacja terenu/wypoziomowanie, płyty betonowe/ stopy fundamentowe pod naroża kontenerów, itp)", new Font(bf, 10f)));
                subList.Add(new iTextSharp.text.ListItem("połączenia wewnętrznych instalacji z zewnętrznymi sieciami zasilającymi, tj. prąd, woda, kanalizacja, uziemienie zewnętrzne, instalacja telefoniczna, RTV, komputerowa, klimatyzacyjna,  itp.,", new Font(bf, 10f)));
                subList.Add(new iTextSharp.text.ListItem("pomiarów elektrycznych kontenerów po podłączeniu do zewnętrznych sieci zasilających (pomiary zerowania instalacji elektrycznej oraz przeciwporażeniowej)", new Font(bf, 10f)));
                subList.Add(new iTextSharp.text.ListItem("pomiarów zużycia energii elektrycznej kontenera,", new Font(bf, 10f)));
                subList.Add(new iTextSharp.text.ListItem("dokumentacji architektoniczno-budowlanej kontenera", new Font(bf, 10f)));
                subList.Add(new iTextSharp.text.ListItem("wszelkich wymaganych zezwoleń urzędowych", new Font(bf, 10f)));
                CLista1.Add(subList);

                //dodanie Clista1 do dokumentu
                document.Add(CLista1);

                //zdefiniowanie CFraza5

                iTextSharp.text.Paragraph CFraza5 = new iTextSharp.text.Paragraph();
                CFraza5.Font = new Font(bf2, 11f);
                CFraza5.Alignment = Element.ALIGN_CENTER;
                CFraza5.Add("\n§2. Płatności");

                //zdefiniowanie Clisty2
                iTextSharp.text.List CLista2 = new iTextSharp.text.List(iTextSharp.text.List.ORDERED, 20f);
                CLista2.IndentationLeft = 20f;
                CLista2.Add(new iTextSharp.text.ListItem("Na podstawie niniejszej umowy Najemca zobowiązuje się zapłacić Wynajmującemu opłaty określone w Załączniku Nr 1", new Font(bf, 10f)));
                // CLista2.Add(new iTextSharp.text.ListItem( , new Font(bf, 10f)));
                CLista2.Add(new iTextSharp.text.ListItem("Załącznik Nr 1 określa cenę netto wynajmu oraz zakres i wysokość dodatkowych kosztów wynajmu", new Font(bf, 10f)));
                CLista2.Add(new iTextSharp.text.ListItem("Ceny określone w niniejszej Umowie wyrażone są w wartościach netto. Każdorazowo doliczony zostanie do nich podatek VAT w wysokości zgodnej z obowiązującą ustawą", new Font(bf, 10f)));
                CLista2.Add(new iTextSharp.text.ListItem("W przypadku, gdy okres najmu nie będzie obejmował pełnego miesiąca, czynsz najmu za taki okres wyliczany będzie jako iloczyn 1/30 –tej miesięcznego czynszu najmu oraz ilości dni", new Font(bf, 10f)));
                CLista2.Add(new iTextSharp.text.ListItem("Szczegółowe warunki płatności określone są w Załączniku Nr1 do niniejszej Umowy", new Font(bf, 10f)));
                CLista2.Add(new iTextSharp.text.ListItem("Za dzień dokonania płatności przyjmuje się dzień wpływu środków pieniężnych na konto Wynajmującego", new Font(bf, 10f)));
                CLista2.Add(new iTextSharp.text.ListItem("Wszystkie wpłaty będą uregulowane przez Najemcę w formie przelewu na rzecz Wynajmującego, na rachunek bankowy w banku: BGŻ SA, konto nr:  95 2030 0045 1110 0000 0184 9640.", new Font(bf, 10f)));
                CLista2.Add(new iTextSharp.text.ListItem("W przypadku nie zapłacenia w terminie jakiejkolwiek należności lub jej części wynikającej z niniejszej umowy, Wynajmujący zastrzega sobie prawo do naliczenia odsetek ustawowych", new Font(bf, 10f)));
                CLista2.Add(new iTextSharp.text.ListItem("Wynajmujący oświadcza, że jest płatnikiem podatku VAT od towarów i usług o numerze identyfikacyjnym NIP 537-24-56-851", new Font(bf, 10f)));
                CLista2.Add(new iTextSharp.text.ListItem("Najemca oświadcza, że jest płatnikiem podatku VAT od towarów i usług o numerze identyfikacyjnym NIP " + knip + " oraz upoważnia Wynajmującego do wystawiania faktur VAT bez podpisu odbierającego. ", new Font(bf, 10f)));

                //dodanie CFrazy5
                document.Add(CFraza5);

                //dodanie Clisty2
                document.Add(CLista2);

                //zdefiniowanie CFraza6

                iTextSharp.text.Paragraph CFraza6 = new iTextSharp.text.Paragraph();
                CFraza6.Font = new Font(bf2, 11f);
                CFraza6.Alignment = Element.ALIGN_CENTER;
                CFraza6.Add("\n§3. Okres wynajmu");

                //zdefiniowanie Clisty3
                iTextSharp.text.List CLista3 = new iTextSharp.text.List(iTextSharp.text.List.ORDERED, 20f);
                CLista3.IndentationLeft = 20f;
                CLista3.Add(new iTextSharp.text.ListItem("Okres wynajmu kontenera określony jest w Załączniku Nr 1 do niniejszej Umowy", new Font(bf, 10f)));
                CLista3.Add(new iTextSharp.text.ListItem("Okres wynajmu rozpoczyna się od dnia protokolarnego odbioru kontenera przez Najemcę, a kończy z dniem protokolarnego zwrotu kontenera przez Najemcę do Wynajmującego", new Font(bf, 10f)));
                CLista3.Add(new iTextSharp.text.ListItem("Strony zastrzegają możliwość przedłużenia lub skrócenia okresu wynajmu na warunkach określonych w niniejszej umowie", new Font(bf, 10f)));
                CLista3.Add(new iTextSharp.text.ListItem("Przedłużenie okresu najmu możliwe jest na pisemny wniosek Najemcy dostarczony Wynajmującemu nie później, niż na 7 dni przed końcem okresu wynajmu przewidzianego w Załączniku Nr 1", new Font(bf, 10f)));
                CLista3.Add(new iTextSharp.text.ListItem("Przedłużenie okresu najmu wymaga pisemnego aneksu do niniejszej Umowy", new Font(bf, 10f)));
                CLista3.Add(new iTextSharp.text.ListItem("Skrócenie okresu wynajmu przez Najemcę i wcześniejszy zwrot kontenerów, wymaga pisemnego wypowiedzenia niniejszej Umowy, dostarczonego Wynajmującemu przez Najemcę listem poleconym lub pocztą elektroniczną, najpóźniej przed upływem 7 dni przed planowanym wcześniejszym zwrotem, przy czym Wynajmujący będzie w takim wypadku uprawniony do obciążenia Najemcy opłatą dodatkową stanowiącą równowartość miesięcznego czynszu za wynajem przedmiotu najmu podlegającego wcześniejszemu zwrotowi", new Font(bf, 10f)));
                CLista3.Add(new iTextSharp.text.ListItem("Wypowiedzenie i/lub skrócenie Umowy przez Wynajmującego może nastąpić tylko z ważnych uzasadnionych przyczyn. W szczególności Wynajmujący może wypowiedzieć Umowę ze skutkiem natychmiastowym w przypadku rażącego naruszenia postanowień Umowy przez Najemcę (np. naruszenie terminu zapłaty czynszu o co najmniej 30 dni), ", new Font(bf, 10f)));
                CLista3.Add(new iTextSharp.text.ListItem("W przypadku wypowiedzenia przez Wynajmującego Umowy ze skutkiem natychmiastowym, Najemca zobowiązuje się bezzwłocznie, bez dodatkowego wezwania przygotować przedmiot najmu do odbioru oraz wydać go Wynajmującemu w terminie wskazanym przez tego ostatniego", new Font(bf, 10f)));
                CLista3.Add(new iTextSharp.text.ListItem("W przypadku wypowiedzenia Umowy przez Wynajmującego ze skutkiem natychmiastowym, uzasadnionego rażącym naruszaniem przez Najemcę warunków Umowy, Wynajmujący uprawniony będzie do zajęcia zdeponowanej u niego przez Najemcę kaucji, o której mowa w Załączniku Nr 1", new Font(bf, 10f)));
                // CLista2.Add(new iTextSharp.text.ListItem( , new Font(bf, 10f)));

                //dodanie CFrazy6
                document.Add(CFraza6);

                //dodanie Clisty3
                document.Add(CLista3);

                //zdefiniowanie CFraza7

                iTextSharp.text.Paragraph CFraza7 = new iTextSharp.text.Paragraph();
                CFraza7.Font = new Font(bf2, 11f);
                CFraza7.Alignment = Element.ALIGN_CENTER;
                CFraza7.Add("\n§4. Wydanie przedmiotu najmu");


                //zdefiniowanie Clisty4
                iTextSharp.text.List CLista4 = new iTextSharp.text.List(iTextSharp.text.List.ORDERED, 20f);
                CLista4.IndentationLeft = 20f;
                CLista4.Add(new iTextSharp.text.ListItem("Wydanie i zwrot kontenera odbywają się w drodze protokolarnego przekazania", new Font(bf, 10f)));
                CLista4.Add(new iTextSharp.text.ListItem("W przypadku, kiedy transport kontenera nie zostaje zlecony Wynajmującemu, ryzyko związane z przewozem kontenera ponosi Najemca, który jest uprawniony do osobistego, lub poprzez upoważnionego przedstawiciela dokonania technicznego odbioru przedmiotu najmu przed załadunkiem w siedzibie Wynajmującego oraz jego protokolarnego zdania po okresie najmu. Jeśli Najemca rezygnuje z tego prawa, tym samym zgadza się, aby wydania i odbioru dokonał jednostronnie Wynajmujący, tym samym przyjmując jego wszelkie deklaracje i zastrzeżenia co do stanu technicznego kontenerów", new Font(bf, 10f)));
                CLista4.Add(new iTextSharp.text.ListItem("Najemca jest zobowiązany być obecnym w trakcie rozładunku przy dostawie i załadunku w trakcie odbioru kontenera oraz nadzorować ich właściwy przebieg", new Font(bf, 10f)));
                CLista4.Add(new iTextSharp.text.ListItem("Najemca zobowiązany jest zapewnić dojazd i miejsce manewrowe dla samochodów dostarczających oraz odbierających kontenery, a także źródło prądu oraz wody na czas ewentualnego montażu obiektów wielomodułowych. ", new Font(bf, 10f)));
                CLista4.Add(new iTextSharp.text.ListItem("O ile Strony nie uzgodnią inaczej na piśmie, Najemca zobowiązuje się do stosownego przygotowania podłoża przed dostawą przedmiotu najmu (w tym w szczególności jego odpowiedniego utwardzenia i wypoziomowania), co stanowi warunek niezbędny dla posadowienia kontenera/obiektu modułowego", new Font(bf, 10f)));

                //dodanie CFrazy7
                document.Add(CFraza7);

                //dodanie Clisty4
                document.Add(CLista4);

                //zdefiniowanie CFraza8

                iTextSharp.text.Paragraph CFraza8 = new iTextSharp.text.Paragraph();
                CFraza8.Font = new Font(bf2, 11f);
                CFraza8.Alignment = Element.ALIGN_CENTER;
                CFraza8.Add("\n§5. Zwrot przedmiotu najmu");

                //zdefiniowanie Clisty5
                iTextSharp.text.List CLista5 = new iTextSharp.text.List(iTextSharp.text.List.ORDERED, 20f);
                CLista5.IndentationLeft = 20f;
                CLista5.Add(new iTextSharp.text.ListItem("Wraz z upływem okresu najmu, tj. nie później, niż do pierwszego dnia po zakończeniu najmu, Najemca powinien doprowadzić kontener do pełnej gotowości do odbioru. Dotyczy to również zakończenia najmu w drodze wcześniejszego wypowiedzenia Umowy przez którąkolwiek ze stron", new Font(bf, 10f)));

                //zdefiniowanie subListy1
                iTextSharp.text.List subList1 = new iTextSharp.text.List(iTextSharp.text.List.UNORDERED);
                subList1.SetListSymbol("\u2012");
                subList1.Add(new iTextSharp.text.ListItem(" doprowadzenie kontenera do stanu pierwotnego, tj. z dnia jego odbioru przez Najemcę", new Font(bf, 10f)));
                subList1.Add(new iTextSharp.text.ListItem(" opróżnienie z kontenera wszelkich przedmiotów nienależących do jego właściwego wyposażenia", new Font(bf, 10f)));
                subList1.Add(new iTextSharp.text.ListItem(" opróżnienie bojlera oraz odpływów (opłata za nieopróżniony bojler podana jest w Załączniku Nr1)", new Font(bf, 10f)));
                // subList.Add(new iTextSharp.text.ListItem("", new Font(bf, 10f)));
                CLista5.Add(subList1);

                CLista5.Add(new iTextSharp.text.ListItem("Po zakończeniu okresu najmu, Najemca zobowiązany jest bezzwłocznie wydać przedmiot najmu na żądanie Wynajmującego", new Font(bf, 10f)));
                CLista5.Add(new iTextSharp.text.ListItem("O ile obie Strony nie ustalą inaczej na piśmie, zwrot przedmiotu najmu nastąpi w miejscu/na placu budowy, na którym kontener został wydany Najemcy. Zwrotu Najemca powinien dokonać nie później, niż następnego dnia roboczego następującego po dniu rozwiązania umowy", new Font(bf, 10f)));
                CLista5.Add(new iTextSharp.text.ListItem("W przypadku nie wydania kontenera w terminie o którym mowa w ust. 3, Najemca upoważnia nieodwołanie Wynajmującego do samodzielnego odbioru kontenera i wejścia w takim przypadku na teren będący w posiadaniu Najemcy, w tym do otwarcia niezbędnych zamknięć i zabezpieczeń, bez jakichkolwiek roszczeń odszkodowawczych wobec Wynajmującego", new Font(bf, 10f)));
                CLista5.Add(new iTextSharp.text.ListItem("O dacie odbioru przedmiotu najmu Najemca zostanie poinformowany przez Wynajmującego pisemnie z min. 3-dniowym wyprzedzeniem", new Font(bf, 10f)));
                CLista5.Add(new iTextSharp.text.ListItem("W przypadku braku gotowości kontenera do odbioru w ustalonym przez Wynajmującego terminie, Najemca upoważnia Wynajmującego do opróżnienia kontenera z przedmiotów wykraczających poza jego pierwotne wyposażenie. Usunięte w takich okolicznościach z kontenera przedmioty nienależące do Wynajmującego, zostaną przez niego protokolarnie zinwentaryzowane i zdeponowane na magazynie Wynajmującego, na koszt Najemcy, na co Najemca niniejszym wyraża zgodę", new Font(bf, 10f)));
                CLista5.Add(new iTextSharp.text.ListItem("W przypadku opóźnienia terminu zwrotu kontenera Wynajmującemu, z przyczyn leżących po stronie Najemcy, na Najemcy spoczywa obowiązek uiszczenia na rzecz Wynajmującego tytułem wynagrodzenia za bezumowne korzystanie z przedmiotu najmu należności, odpowiadającej wartości czynszu najmu  za  okres   do chwili właściwego protokolarnego przekazania kontenera Wynajmującemu", new Font(bf, 10f)));
                CLista5.Add(new iTextSharp.text.ListItem("W razie przekroczenia ustalonego w umowie terminu zwrotu kontenera, z przyczyn leżących po stronie Najemcy, Wynajmujący uprawniony będzie do podjęcia kroków stosownych do wyegzekwowania  zwrotu kontenera i obciążenia Najemcy wszelkimi kosztami egzekucji, na co Najemca niniejszym wyraża zgodę.", new Font(bf, 10f)));
                CLista5.Add(new iTextSharp.text.ListItem("Ponadto w przypadku zawinionej przez Najemcę zwłoki w zwrocie kontenera, Wynajmujący uprawniony będzie do obciążenia Najemcy karą umowną w wysokości 100zł, za każdy dzień takiej zwłoki", new Font(bf, 10f)));
                CLista5.Add(new iTextSharp.text.ListItem("Najemca wyraża zgodę na obciążenie go przez Wynajmującego dodatkowymi opłatami wynikłymi z:", new Font(bf, 10f)));
                //zdefiniowanie subListy1
                iTextSharp.text.List subList2 = new iTextSharp.text.List(iTextSharp.text.List.UNORDERED);
                subList2.SetListSymbol("\u2012");
                subList2.Add(new iTextSharp.text.ListItem(" braku możliwości dojazdu i/lub rozładunku/załadunku kontenerów", new Font(bf, 10f)));
                subList2.Add(new iTextSharp.text.ListItem(" braku stosownego przygotowania podłoża pod kontener(y),", new Font(bf, 10f)));
                subList2.Add(new iTextSharp.text.ListItem(" opóźnień w rozładunku i/lub załadunku kontenerów powstałych z przyczyn nie leżących po stronie Wynajmującego", new Font(bf, 10f)));
                CLista5.Add(subList2);
                CLista5.Add(new iTextSharp.text.ListItem("Wysokość kosztów, o których mowa powyżej określa Załącznik Nr 1 stanowiący integralną część niniejszej Umowy", new Font(bf, 10f)));
                // CLista5.Add(new iTextSharp.text.ListItem("", new Font(bf, 10f)));


                //dodanie CFrazy8
                document.Add(CFraza8);

                //dodanie Clisty5
                document.Add(CLista5);


                //zdefiniowanie CFraza9
                iTextSharp.text.Paragraph CFraza9 = new iTextSharp.text.Paragraph();
                CFraza9.Font = new Font(bf2, 11f);
                CFraza9.Alignment = Element.ALIGN_CENTER;
                CFraza9.Add("\n§6. Stan techniczny przedmiotu najmu");

                //zdefiniowanie Clisty6
                iTextSharp.text.List CLista6 = new iTextSharp.text.List(iTextSharp.text.List.ORDERED, 20f);
                CLista6.IndentationLeft = 20f;
                CLista6.Add(new iTextSharp.text.ListItem("Po zakończeniu okresu najmu kontener poddany zostanie inspekcji technicznej przeprowadzonej przez przedstawicieli obu stron, co udokumentowane zostanie stosownym podpisanym przez upoważnionych reprezentantów Stron protokołem odbioru kontenera od Najemcy. Protokół zawierać będzie opis stanu i czystości kontenera oraz w razie potrzeby opis typu i zakresu ewentualnych uszkodzeń, wykraczających poza normalne zużycie wynikające z prawidłowego użytkowania kontenera", new Font(bf, 10f)));
                CLista6.Add(new iTextSharp.text.ListItem("Nie przystąpienie przez Najemcę do odbioru w wyznaczonym przez Wynajmującego terminie będzie jednoznaczne ze zgodą Najemcy na jednostronne zaprotokołowanie odbioru przez Wynajmującego oraz akceptacją wszelkich deklaracji i zastrzeżeń co do stanu technicznego przedmiotu najmu w chwili odbioru", new Font(bf, 10f)));
                CLista6.Add(new iTextSharp.text.ListItem("Wszelkie ubytki, uszkodzenia, defekty kontenera i zainstalowanego w nim wyposażenia, wykraczające poza normalne zużycie eksploatacyjne, a zaistniałe w okresie wynajmu, będą przywracane do stanu pierwotnego na koszt Najemcy, a Wynajmujący będzie uprawniony do wystawienia dodatkowej faktury, obciążającej Najemcę w tego tytułu (np. za konieczne naprawy, wymianę części zamiennych, usuwanie zanieczyszczeń z odpływów, koszty dodatkowego czyszczenia i remontów).", new Font(bf, 10f)));
                CLista6.Add(new iTextSharp.text.ListItem("Obowiązek udokumentowania, iż zwracany kontener jest w stanie z dnia wydania kontenera leży po stronie Najemcy.", new Font(bf, 10f)));

                //dodanie CFrazy9
                document.Add(CFraza9);

                //dodanie Clisty6
                document.Add(CLista6);
                //zdefiniowanie CFraza10
                iTextSharp.text.Paragraph CFraza10 = new iTextSharp.text.Paragraph();
                CFraza10.Font = new Font(bf2, 11f);
                CFraza10.Alignment = Element.ALIGN_CENTER;
                CFraza10.Add("\n§7. Warunki eksploatacji i użytkowania");

                //zdefiniowanie Clisty7
                iTextSharp.text.List CLista7 = new iTextSharp.text.List(iTextSharp.text.List.ORDERED, 20f);
                CLista7.IndentationLeft = 20;
                CLista7.Add(new iTextSharp.text.ListItem("Kontener może być używany tylko i wyłącznie na terytorium Rzeczypospolitej Polskiej, zgodnie ze swoim przeznaczeniem oraz wszelkimi zaleceniami Wynajmującego, jak również wytycznymi zawartymi w Instrukcji Eksploatacji i Obsługi Kontenera stanowiącej Załącznik nr 2 do niniejszej Umowy", new Font(bf, 10f)));
                CLista7.Add(new iTextSharp.text.ListItem("Wszelkie próby i przypadki połączenia kontenera z obiektami, instalacjami, przedmiotami lub kontenerami osób trzecich, wymagają uprzedniego pisemnego poinformowania Wynajmującego przez Najemcę o takim zamiarze oraz uprzedniego uzyskania od niego pisemnej zgody na realizację takich działań, która powinna być wyrażona w tej formie pod rygorem nieważności. Wynajmujący zastrzega sobie jednak prawo do odmowy udzielenia takiej zgody", new Font(bf, 10f)));
                CLista7.Add(new iTextSharp.text.ListItem("Bez względu na okoliczności, Najemca w każdym w/w przypadku ponosi pełną odpowiedzialność za prawidłowy montaż i demontaż oraz bierze na siebie wszelkie ryzyko oraz koszty z tym związane, w tym w szczególności wszelkie koszty ewentualnych usterek i napraw wynikłych wskutek takiego działania", new Font(bf, 10f)));
                CLista7.Add(new iTextSharp.text.ListItem("Bez pisemnej zgody wydanej przez Wynajmującego, przedmiot najmu nie może być zarządzany przez osoby trzecie i niezatrudnione przez Najemcę. Zgoda, o której mowa w zdaniu poprzednim powinna być wyrażona w formie pisemnej pod rygorem nieważnośc", new Font(bf, 10f)));
                CLista7.Add(new iTextSharp.text.ListItem("Podczas całego okresu najmu, Najemca jest zobowiązany do dbałości o stan techniczny kontenera, przeprowadzania regularnych kontroli stanu kontenera oraz usuwania wszelkich czynników mogących mieć wpływ na jego pogorszenie.", new Font(bf, 10f)));
                CLista7.Add(new iTextSharp.text.ListItem("W okresie najmu, Najemca może dokonywać napraw przedmiotu najmu we własnym zakresie wyłącznie po wcześniejszym pisemnym zgłoszeniu usterki Wynajmującemu oraz na podstawie pisemnych instrukcji przesyłanych każdorazowo przez Wynajmującego", new Font(bf, 10f)));
                CLista7.Add(new iTextSharp.text.ListItem("W przypadku wystąpienia w okresie najmu uszkodzenia przedmiotu najmu, Najemca zawiadomi Wynajmującego o uszkodzeniu pisemnie (faxem lub e-mailem). ", new Font(bf, 10f)));
                CLista7.Add(new iTextSharp.text.ListItem("Koszty przeglądów i drobnych napraw związanych z bieżącym użytkowaniem każdego kontenera w trakcie najmu, w tym w szczególności wymiany świetlówek, wkładów zamków, bezpieczników itp. ponoszone są przez Najemcę.", new Font(bf, 10f)));
                CLista7.Add(new iTextSharp.text.ListItem("Najemca zobowiązuje się do używania w okresie najmu wyłącznie materiałów eksploatacyjnych tej samej klasy i standardu jak te, które zamontowane były przez Wynajmującego", new Font(bf, 10f)));

                //dodanie CFrazy10
                document.Add(CFraza10);

                //dodanie Clisty7
                document.Add(CLista7);


                //zdefiniowanie CFraza11
                iTextSharp.text.Paragraph CFraza11 = new iTextSharp.text.Paragraph();
                CFraza11.Font = new Font(bf2, 11f);
                CFraza11.Alignment = Element.ALIGN_CENTER;
                CFraza11.Add("\n§8. Odpowiedzialność materialna i prawna");

                //zdefiniowanie Clisty8
                iTextSharp.text.List CLista8 = new iTextSharp.text.List(iTextSharp.text.List.ORDERED, 20f);
                CLista8.IndentationLeft = 20;
                CLista8.Add(new iTextSharp.text.ListItem("Z chwilą protokolarnego odbioru kontenera do momentu jego protokolarnego zwrotu, na Najemcy spoczywa wszelka odpowiedzialność materialna i prawna, wszelkie ryzyko związane z zabezpieczeniem i dozorem kontenera, jak również jego utrzymaniem w dobrym stanie technicznym", new Font(bf, 10f)));
                CLista8.Add(new iTextSharp.text.ListItem("W przypadku, kiedy transport kontenera nie zostaje zlecony Wynajmującemu, Najemca przejmuje wszelkie ryzyko oraz pełną odpowiedzialność materialną i prawną za przedmiot najmu od momentu jego pobrania w siedzibie Wynajmującego, aż do chwili jego protokolarnego zwrotu", new Font(bf, 10f)));
                CLista8.Add(new iTextSharp.text.ListItem("Najemca bierze na siebie pełną odpowiedzialność materialną za właściwą eksploatację przedmiotu najmu oraz jego właściwe zabezpieczenie przed zniszczeniem i kradzieżą", new Font(bf, 10f)));
                CLista8.Add(new iTextSharp.text.ListItem("Za jakikolwiek uszczerbek/usterkę kontenerów będących przedmiotem wynajmu Najemca odpowiada wobec Wynajmującego. Dotyczy to również przypadków, kiedy taki uszczerbek/usterka jest następstwem działania osób trzecich.", new Font(bf, 10f)));
                CLista8.Add(new iTextSharp.text.ListItem("W wypadku uszkodzeń powstałych w okresie najmu, Najemca zostanie obciążony i pokryje wszelkie koszty napraw, w tym koszty części zamiennych, robocizny oraz koszty dodatkowe powstałe na skutek dalszego użytkowania kontenera z uszkodzeniem, określone w cenniku, który stanowi Załącznik nr 3 do niniejszej Umowy", new Font(bf, 10f)));
                CLista8.Add(new iTextSharp.text.ListItem("W razie trwałego i nieodwracalnego uszkodzenia, zniszczenia lub utraty przedmiotu najmu, Najemca zobowiązany jest do zapłaty Wynajmującemu odszkodowania odpowiadającego wartości odtworzeniowej przedmiotu najmu, przy czym Najemca ma obowiązek uiszczenia w takim przypadku czynszu w wysokości umownej za okres od dnia zajścia zdarzenia do dnia zapłaty wspomnianego odszkodowania. ", new Font(bf, 10f)));
                CLista8.Add(new iTextSharp.text.ListItem("Najemca ponosi odpowiedzialność za szkody wynikłe z naruszania zasad BHP w trakcie używania przedmiotu najmu, w tym w szczególności w przypadku, gdy przedmiot najmu jest obsługiwany przez osoby nie posiadające odpowiednich, wymaganych przez prawo uprawnień. Nieznajomość tych zasad obciąża Najemcę.", new Font(bf, 10f)));
                CLista8.Add(new iTextSharp.text.ListItem("W przypadku przesunięcia terminu zwrotu kontenera Wynajmującemu, na Najemcy spoczywa obowiązek dozoru oraz dbałości o utrzymanie kontenera w dobrym stanie technicznym, aż do chwili protokolarnego przekazania kontenera Wynajmującemu.", new Font(bf, 10f)));
                CLista8.Add(new iTextSharp.text.ListItem("W dniu podpisania niniejszej umowy, Najemca wpłaci Wynajmującemu kaucję określoną w Załączniku Nr 1 do niniejszej umowy, tytułem zabezpieczenia kosztów ewentualnych napraw i szkód powstałych w czasie trwania najmu. O ile nie zaistnieją uzasadnione przesłanki do potrącenia kaucji na poczet nieuregulowanych rozliczeń Najemcy wobec Wynajmującego (w tym w szczególności za najem, transport, mycie lub naprawę usterek kontenera po okresie najmu, kar umownych, itp.), kaucja zostanie zwrócona Najemcy w terminie do 10 dni roboczych od daty zwrotu kontenera, po sprawdzeniu jego stanu technicznego lub w innym terminie ustalonym przez strony.", new Font(bf, 10f)));
                CLista8.Add(new iTextSharp.text.ListItem("Kontener nie może być użytkowany poza terytorium państwa polskiego.", new Font(bf, 10f)));

                //dodanie CFrazy1
                document.Add(CFraza11);

                //dodanie Clisty8
                document.Add(CLista8);

                //zdefiniowanie CFraza12
                iTextSharp.text.Paragraph CFraza12 = new iTextSharp.text.Paragraph();
                CFraza12.Font = new Font(bf2, 11f);
                CFraza12.Alignment = Element.ALIGN_CENTER;
                CFraza12.Add("\n§9. Pozostałe");

                //zdefiniowanie Clisty9
                iTextSharp.text.List CLista9 = new iTextSharp.text.List(iTextSharp.text.List.ORDERED, 20f);
                CLista9.IndentationLeft = 20;
                CLista9.Add(new iTextSharp.text.ListItem("Wszelkie zmiany w treści umowy wymagają, pod rygorem nieważności, pisemnego aneksu, skutecznego po podpisaniu go przez obie strony", new Font(bf, 10f)));
                CLista9.Add(new iTextSharp.text.ListItem("Strony zgodnie oświadczają, że osoby reprezentujące Najemcę i Wynajmującego przy zawieraniu niniejszej Umowy są prawnie umocowane do reprezentowania Stron zgodnie z wymogami zasad reprezentacji prawa polskiego. W związku z powyższym nie będą powoływać się na brak umocowania osoby reprezentującej w przypadku jakichkolwiek sporów, mogących wyniknąć z niniejszej Umowy", new Font(bf, 10f)));
                CLista9.Add(new iTextSharp.text.ListItem("Przedmiot najmu pozostaje własnością Wynajmującego przez cały okres najmu", new Font(bf, 10f)));
                CLista9.Add(new iTextSharp.text.ListItem("Strony mają obowiązek wzajemnego informowania się o wszelkich zmianach statusu prawnego swojej firmy, a także o wszczęciu postępowania upadłościowego, układowego i likwidacyjnego", new Font(bf, 10f)));
                CLista9.Add(new iTextSharp.text.ListItem("Podczas trwania umowy najmu Wynajmujący zastrzega sobie prawo do przeniesienia praw i obowiązków wynikających z niniejszej Umowy na stronę trzecią, o czym niezwłocznie poinformuje Najemcę ", new Font(bf, 10f)));
                CLista9.Add(new iTextSharp.text.ListItem("Wynajmujący oświadcza, że przedmiotowe kontenery są objęte polisą ubezpieczeniową NR 320000052559 w zakresie Ubezpieczenia mienia od ognia, kradzieży i innych zdarzeń losowych", new Font(bf, 10f)));
                CLista9.Add(new iTextSharp.text.ListItem("Jeżeli którekolwiek postanowienie niniejszej umowy okaże się w części lub w całości nieważne, okoliczność ta nie będzie miała wpływu na ważność pozostałych postanowień.", new Font(bf, 10f)));
                CLista9.Add(new iTextSharp.text.ListItem("Prawem obowiązującym dla niniejszej umowy jest prawo polskie. ", new Font(bf, 10f)));
                CLista9.Add(new iTextSharp.text.ListItem("Sądem właściwym dla rozstrzygnięcia sporu będzie sąd właściwy dla siedziby Wynajmującego", new Font(bf, 10f)));
                CLista9.Add(new iTextSharp.text.ListItem("Umowę niniejszą sporządzono w 2 jednobrzmiących egzemplarzach - każdy na prawach oryginału, przeznaczonych po 1 dla każdej ze stron. ", new Font(bf, 10f)));
                CLista9.Add(new iTextSharp.text.ListItem("Umowa wchodzi w życie z dniem podpisania. ", new Font(bf, 10f)));

                //dodanie CFrazy12
                document.Add(CFraza12);

                //dodanie Clisty9
                document.Add(CLista9);
                // CLista5.Add(new iTextSharp.text.ListItem("", new Font(bf, 10f)));

                //zdefiniowanie CFraza13
                iTextSharp.text.Paragraph CFraza13 = new iTextSharp.text.Paragraph();
                CFraza13.Font = new Font(bf2, 11f);
                CFraza13.Alignment = Element.ALIGN_LEFT;
                CFraza13.Add("\n\nZałączniki:");

                //zdefiniowanie CFraza14
                iTextSharp.text.Paragraph CFraza14 = new iTextSharp.text.Paragraph();
                CFraza14.Font = new Font(bf2, 11f);
                CFraza14.Alignment = Element.ALIGN_LEFT;
                CFraza14.IndentationLeft = 30;
                CFraza14.Add(new Chunk("Załącznik nr 1 -", new Font(bf2)));
                CFraza14.Add(new Chunk(" Opis kontenerów i szczegółowe warunki finansowe wynajmu.\n", new Font(bf)));

                CFraza14.Add(new Chunk("Załącznik nr 2 -", new Font(bf2)));
                CFraza14.Add(new Chunk(" Instrukcja Montażu, Eksploatacji i Obsługi kontenerów biurowych, socjalnych, sanitarnych, socjalno-sanitarnych\n", new Font(bf)));

                CFraza14.Add(new Chunk("Załącznik nr 3 -", new Font(bf2)));
                CFraza14.Add(new Chunk(" Cennik napraw\n\n\n\n\n\n\n", new Font(bf)));

                document.Add(CFraza13);
                document.Add(CFraza14);

                //zdefiniowanie CFraza15
                iTextSharp.text.Paragraph CFraza15 = new iTextSharp.text.Paragraph();
                CFraza15.Font = new Font(bf2, 10f);
                CFraza15.Alignment = Element.ALIGN_LEFT;
                CFraza15.Add(new Chunk("Wynajmujący                                                                                                                   Najemca", new Font(bf2)));

                document.Add(CFraza15);
                document.NewPage();

                ///Nowa strona
                ///



                int jednostkowy = 1;
                int liczSocBiu = 0;
                int liczSoc = 0;
                int liczSan = 0;
                int liczMag = 0;
                int liczPort = 0;
                int liczZF = 0;

                string socBiu = "socjalno - biurowy: ";
                string soc = "socjalny: ";
                string san = "sanitarny: ";
                string mag = "magazynowy: ";
                string port = "portiernia: ";
                string zbfek = "zbiornik na fekalia: ";

                foreach (var item in listaKontener)
                {
                    string tempZlicz;
                    if (item.ko_typkontenera.Contains("SB1") || item.ko_typkontenera.Contains("sb1") || item.ko_typkontenera.Contains("SB2") || item.ko_typkontenera.Contains("SB3")) liczSocBiu++;
                    if (item.ko_typkontenera.Contains("SB4") || item.ko_typkontenera.Contains("sb4")) liczSoc++;
                    if (item.ko_typkontenera.Contains("SB8") || item.ko_typkontenera.Contains("SB9") || item.ko_typkontenera.Contains("SB10") || item.ko_typkontenera.Contains("SB11") || item.ko_typkontenera.Contains("D-M")) liczSan++;
                    if (item.ko_typkontenera.Contains("MORSKI") || item.ko_typkontenera.Contains("morski")) liczMag++;
                    if (item.ko_typkontenera.Contains("P1") || item.ko_typkontenera.Contains("p1") || item.ko_typkontenera.Contains("P2") || item.ko_typkontenera.Contains("p2")) liczPort++;
                    if (item.ko_typkontenera.Contains("ZF") || item.ko_typkontenera.Contains("zf")) liczZF++;

                }

                StringBuilder zrzutKont = new StringBuilder();
                if (liczSocBiu > 0) zrzutKont.Append(socBiu + " " + liczSocBiu + " \n");
                if (liczSoc > 0) zrzutKont.Append(soc + " " + liczSoc + " \n");
                if (liczSan > 0) zrzutKont.Append(san + " " + liczSan + " \n");
                if (liczMag > 0) zrzutKont.Append(mag + " " + liczMag + " \n");
                if (liczPort > 0) zrzutKont.Append(port + " " + liczPort + " \n");
                if (liczZF > 0) zrzutKont.Append(zbfek + " " + liczZF + " \n");


                StringBuilder zrzutKontenerSamaNazwa = new StringBuilder();
                if (liczSocBiu > 0) zrzutKontenerSamaNazwa.Append(socBiu + " \n");
                if (liczSoc > 0) zrzutKontenerSamaNazwa.Append(soc + "\n");
                if (liczSan > 0) zrzutKontenerSamaNazwa.Append(san + " \n");
                if (liczMag > 0) zrzutKontenerSamaNazwa.Append(mag + " \n");
                if (liczPort > 0) zrzutKontenerSamaNazwa.Append(port + " \n");
                if (liczZF > 0) zrzutKontenerSamaNazwa.Append(zbfek +" \n");



                //zdefiniowanie DFraza1

                iTextSharp.text.Paragraph DFraza1 = new iTextSharp.text.Paragraph();
                DFraza1.Font = new Font(bf2, 11f, 1);
                DFraza1.Alignment = Element.ALIGN_LEFT;
                DFraza1.Add(new Chunk("Załącznik Nr 1 \n", new Font(bf2)));
                DFraza1.Add(new Chunk("do Umowy Najmu Kontenerów nr: U/" + poleNrUmowy.Text + "/2019 z dnia: " + poleDataPodpisaniaUmowy.ToString().Remove(poleDataPodpisaniaUmowy.ToString().Length - 8) + "  \n\n\n", new Font(bf2)));
                document.Add(DFraza1);


                PdfPTable dtab1 = new PdfPTable(7);
                PdfPRow row1 = null;
                float[] wi1 = new float[] { 1f, 2f, 1f, 1f, 1f, 1f, 1f};
                dtab1.SetWidths(wi1);
                dtab1.WidthPercentage = 100;
                dtab1.AddCell((new Phrase("LP", new Font(bf, 11))));
                dtab1.AddCell((new Phrase("RODZAJ KONTENERA", new Font(bf, 11))));
                dtab1.AddCell((new Phrase("TYP", new Font(bf, 11))));
                dtab1.AddCell((new Phrase("ILOŚĆ", new Font(bf, 11))));
                dtab1.AddCell((new Phrase("CENA 1m-c [PLN] netto", new Font(bf, 11))));
                dtab1.AddCell((new Phrase("UBEZPIECZENIE 5% ceny netto kontenera [PLN]", new Font(bf, 11))));
                
                dtab1.AddCell((new Phrase("ŁĄCZNIE 1m-c [PLN] netto", new Font(bf, 11))));
                int xint = 1;

                double wynik1;
                double wynik2 = 0;
                double wyniktabeli;

                foreach (var item in listaKontener)
                {
                    dtab1.AddCell((new Phrase(xint.ToString(), new Font(bf, 11))));
                    // dtab1.AddCell((new Phrase(item.ko_numercaro.ToString(), new Font(bf, 11))));
                    dtab1.AddCell((new Phrase(zrzutKontenerSamaNazwa.ToString(), new Font(bf, 11))));
                    dtab1.AddCell((new Phrase(item.ko_typkontenera.ToString(), new Font(bf, 11))));
                    dtab1.AddCell((new Phrase("1", new Font(bf, 11))));
                    if (string.IsNullOrEmpty(item.ko_cenanetto.ToString())) item.ko_cenanetto = 0.ToString();
                    dtab1.AddCell((new Phrase(item.ko_cenanetto.ToString(), new Font(bf, 11))));                   
                    double ubezpieczenie = Convert.ToDouble(item.ko_cenanetto) * 0.05;
                    dtab1.AddCell((new Phrase(ubezpieczenie.ToString(), new Font(bf, 11))));
                    double razem = Convert.ToDouble(item.ko_cenanetto) + ubezpieczenie;
                    razem0 = Convert.ToDouble(item.ko_cenanetto.ToString()) + razem0;
                    dtab1.AddCell((new Phrase(item.ko_cenanetto.ToString(), new Font(bf, 11))));
                    xint++;
                }

                foreach (var item in listaDodatki)
                {
                    dtab1.AddCell((new Phrase(xint.ToString(), new Font(bf, 11))));
                    dtab1.AddCell((new Phrase(item.dnazwadodatku.ToString(), new Font(bf, 11))));
                    dtab1.AddCell((new Phrase(" ", new Font(bf, 11))));
                    dtab1.AddCell((new Phrase(item.diloscdodatku.ToString(), new Font(bf, 11))));
                    dtab1.AddCell((new Phrase(item.dcenadodatku.ToString(), new Font(bf, 11))));
                    dtab1.AddCell((new Phrase(" ", new Font(bf, 11))));
                    double wynikwiersza = item.dcenadodatku * item.diloscdodatku;
                    dtab1.AddCell((new Phrase(wynikwiersza.ToString(), new Font(bf, 11))));
                    wynik2 = Convert.ToDouble(wynikwiersza + wynik2);
                    xint++;
                }

                PdfPCell dtab1cell1 = new PdfPCell(new Phrase("Suma 1 m-c", new Font(bf, 11)));
                dtab1cell1.BackgroundColor = new BaseColor(190, 190, 190);

                PdfPCell dtab1cell0 = new PdfPCell(new Phrase("", new Font(bf, 11)));
                dtab1cell1.BackgroundColor = new BaseColor(190, 190, 190);
                dtab1cell0.Border = 0;

                //dtab1.AddCell((new Phrase("", new Font(bf, 11))));
                //dtab1.AddCell((new Phrase("", new Font(bf, 11))));
                //dtab1.AddCell((new Phrase("", new Font(bf, 11))));
                //dtab1.AddCell((new Phrase("", new Font(bf, 11))));
                //dtab1.AddCell((new Phrase("", new Font(bf, 11))));
                dtab1.AddCell(dtab1cell0);
                dtab1.AddCell(dtab1cell0);
                dtab1.AddCell(dtab1cell0);
                dtab1.AddCell(dtab1cell0);
                dtab1.AddCell(dtab1cell0);

                dtab1.AddCell(dtab1cell1);

                double dtab1Suma = razem0 + wynik2;
                dtab1.AddCell((new Phrase(dtab1Suma.ToString(), new Font(bf, 11))));

                document.Add(dtab1);

                //przerwa lubener
                iTextSharp.text.Paragraph CEnte1r = new iTextSharp.text.Paragraph();
                CEnte1r.Font = new Font(bf2, 10f);
                CEnte1r.Alignment = Element.ALIGN_LEFT;
                CEnte1r.Add(" \n \n \n \n");

                //druga tabela



                PdfPTable dtab2 = new PdfPTable(6);
                PdfPRow row2 = null;
                float[] wi2 = new float[] { 0.5f, 1f, 1f, 1f, 1f, 1f };
                dtab2.SetWidths(wi2);
                dtab2.WidthPercentage = 100;
                dtab2.PaddingTop = 10;

                dtab2.AddCell((new Phrase("LP", new Font(bf, 11))));
                dtab2.AddCell((new Phrase("DODATKOWE KOSZTY JEDNORAZOWE", new Font(bf, 11))));
                dtab2.AddCell((new Phrase("OPIS", new Font(bf, 11))));
                dtab2.AddCell((new Phrase("STAWKA [PLN] netto", new Font(bf, 11))));
                dtab2.AddCell((new Phrase("ILOŚĆ", new Font(bf, 11))));
                dtab2.AddCell((new Phrase("ŁĄCZNIE [PLN] netto", new Font(bf, 11))));

                //int jednostkowy = 1;
                //int liczSocBiu = 0;
                //int liczSoc = 0;
                //int liczSan = 0;
                //int liczMag = 0;
                //int liczPort = 0;
                //int liczZF = 0;

                //string socBiu = "socjalno - biurowy: ";
                //string soc = "socjalny: ";
                //string san = "sanitarny: ";
                //string mag = "magazynowy: ";
                //string port = "portiernia: ";
                //string zbfek = "zbiornik na fekalia: ";

                //foreach (var item in listaKontener)
                //{
                //    string tempZlicz;
                //    if (item.ko_typkontenera.Contains("SB1") || item.ko_typkontenera.Contains("sb1") || item.ko_typkontenera.Contains("SB2") || item.ko_typkontenera.Contains("SB3")) liczSocBiu++;
                //    if (item.ko_typkontenera.Contains("SB4") || item.ko_typkontenera.Contains("sb4")) liczSoc++;
                //    if (item.ko_typkontenera.Contains("SB8") || item.ko_typkontenera.Contains("SB9") || item.ko_typkontenera.Contains("SB10") || item.ko_typkontenera.Contains("SB11") || item.ko_typkontenera.Contains("D-M")) liczSan++;
                //    if (item.ko_typkontenera.Contains("MORSKI") || item.ko_typkontenera.Contains("morski")) liczMag++;
                //    if (item.ko_typkontenera.Contains("P1") || item.ko_typkontenera.Contains("p1") || item.ko_typkontenera.Contains("P2") || item.ko_typkontenera.Contains("p2")) liczPort++;
                //    if (item.ko_typkontenera.Contains("ZF") || item.ko_typkontenera.Contains("zf") ) liczZF++;

                //}

                int razemKontenerow = listaKontener.Count;
                int transportyPelne = razemKontenerow / 2;
                int transportNiepelny = razemKontenerow % 2;

                int transportPoPodliczeniu = transportyPelne + transportNiepelny;
                dtab2.AddCell((new Phrase("1", new Font(bf, 11))));
                dtab2.AddCell((new Phrase("Transport docelowy z rozładunkiem (2 kontenery)", new Font(bf, 11))));
                dtab2.AddCell((new Phrase(poleMiejsceWynajmu.Text, new Font(bf, 11))));
                dtab2.AddCell((new Phrase(poleCenaTranDoc.Text, new Font(bf, 11))));
             //   StringBuilder zrzutKont = new StringBuilder();
                //if (liczSocBiu > 0) zrzutKont.Append(socBiu + " " + liczSocBiu +" \n");
                //if (liczSoc > 0) zrzutKont.Append(soc + " " + liczSoc + " \n");
                //if (liczSan > 0) zrzutKont.Append(san + " " + liczSan + " \n");
                //if (liczMag > 0) zrzutKont.Append(mag + " " + liczMag + " \n");
                //if (liczPort > 0) zrzutKont.Append(port + " " + liczPort + " \n");
                //if (liczZF > 0) zrzutKont.Append(zbfek + " " + liczZF + " \n");

                dtab2.AddCell((new Phrase(transportPoPodliczeniu.ToString(), new Font(bf, 11))));
                dtab2.AddCell((new Phrase((Convert.ToDouble(poleCenaTranDoc.Text)* transportPoPodliczeniu).ToString(), new Font(bf, 11))));

                dtab2.AddCell((new Phrase("2", new Font(bf, 11))));
                dtab2.AddCell((new Phrase("Transport powrotny z rozładunkiem (2 kontenery)", new Font(bf, 11))));
                dtab2.AddCell((new Phrase(poleMiejsceWynajmu.Text, new Font(bf, 11))));
                dtab2.AddCell((new Phrase(poleCenaTranDoc.Text, new Font(bf, 11))));
                dtab2.AddCell((new Phrase(transportPoPodliczeniu.ToString(), new Font(bf, 11))));
                dtab2.AddCell((new Phrase((Convert.ToDouble(poleCenaTranPowr.Text) * transportPoPodliczeniu).ToString(), new Font(bf, 11))));

                dtab2.AddCell((new Phrase("3", new Font(bf, 11))));
                dtab2.AddCell((new Phrase("Usługa mycia kontenera po wynajmie", new Font(bf, 11))));
                StringBuilder wszystkiekontenery = new StringBuilder();
               
                
                dtab2.AddCell((new Phrase(zrzutKont.ToString(), new Font(bf, 11))));
                dtab2.AddCell((new Phrase(poleCenaMycia.Text, new Font(bf, 11))));
                dtab2.AddCell((new Phrase(listaKontener.Count.ToString(), new Font(bf, 11))));
                double x0 = Convert.ToDouble(poleCenaMycia.Text) * Convert.ToInt16(listaKontener.Count.ToString());
                dtab2.AddCell((new Phrase(x0.ToString(), new Font(bf, 11))));

                string tempBRAK = "n/d";


                dtab2.AddCell((new Phrase("4", new Font(bf, 11))));
                dtab2.AddCell((new Phrase("Transport docelowy z rozładunkiem (schodnia+podesty)", new Font(bf, 11))));
                dtab2.AddCell((new Phrase(poleMiejsceWynajmu.Text, new Font(bf, 11))));
                if (poleCenaTransDocSchPod.Text == "" || poleCenaTransDocSchPod.Text == "0")
                {
                    dtab2.AddCell((new Phrase(tempBRAK, new Font(bf, 11))));
                    dtab2.AddCell((new Phrase(tempBRAK, new Font(bf, 11))));
                    dtab2.AddCell((new Phrase(tempBRAK, new Font(bf, 11))));

                }
                else
                {
                   // dtab2.AddCell((new Phrase(poleMiejsceWynajmu.Text, new Font(bf, 11))));
                    dtab2.AddCell((new Phrase(poleCenaTransDocSchPod.Text, new Font(bf, 11))));
                    dtab2.AddCell((new Phrase("1", new Font(bf, 11))));
                    dtab2.AddCell((new Phrase(poleCenaTransDocSchPod.Text, new Font(bf, 11))));

                }


                dtab2.AddCell((new Phrase("5", new Font(bf, 11))));
                dtab2.AddCell((new Phrase("Transport docelowy z załadunkiem (schodnia+podesty)", new Font(bf, 11))));
                dtab2.AddCell((new Phrase(poleMiejsceWynajmu.Text, new Font(bf, 11))));
                if (poleCenaTransPowSchPod.Text == "" || poleCenaTransPowSchPod.Text == "0")
                {
                    dtab2.AddCell((new Phrase(tempBRAK, new Font(bf, 11))));
                    dtab2.AddCell((new Phrase(tempBRAK, new Font(bf, 11))));
                    dtab2.AddCell((new Phrase(tempBRAK, new Font(bf, 11))));

                }
                else
                {
                   // dtab2.AddCell((new Phrase(poleMiejsceWynajmu.Text, new Font(bf, 11))));
                    dtab2.AddCell((new Phrase(poleCenaTransPowSchPod.Text, new Font(bf, 11))));
                    dtab2.AddCell((new Phrase("1", new Font(bf, 11))));
                    dtab2.AddCell((new Phrase(poleCenaTransPowSchPod.Text, new Font(bf, 11))));

                }



                dtab2.AddCell((new Phrase("6", new Font(bf, 11))));
                dtab2.AddCell((new Phrase("Montaż kontenerów", new Font(bf, 11))));
                dtab2.AddCell((new Phrase(poleMiejsceWynajmu.Text, new Font(bf, 11))));
                dtab2.AddCell((new Phrase(poleCenaMontaz.Text, new Font(bf, 11))));
                dtab2.AddCell((new Phrase(listaKontener.Count.ToString(), new Font(bf, 11))));
                double t1 = Convert.ToDouble(poleCenaMontaz.Text) * Convert.ToDouble(listaKontener.Count.ToString());
                dtab2.AddCell((new Phrase(t1.ToString(), new Font(bf, 11))));


                dtab2.AddCell((new Phrase("7", new Font(bf, 11))));
                dtab2.AddCell((new Phrase("Demontaż kontenerów", new Font(bf, 11))));
                dtab2.AddCell((new Phrase(poleMiejsceWynajmu.Text, new Font(bf, 11))));
                dtab2.AddCell((new Phrase(poleCenaDemontaz.Text, new Font(bf, 11))));
                dtab2.AddCell((new Phrase(listaKontener.Count.ToString(), new Font(bf, 11))));
                double t2 = Convert.ToDouble(poleCenaDemontaz.Text) * Convert.ToDouble(listaKontener.Count.ToString());
                dtab2.AddCell((new Phrase(t2.ToString(), new Font(bf, 11))));


                dtab2.AddCell((new Phrase("8", new Font(bf, 11))));
                dtab2.AddCell((new Phrase("Rozpięcie kontenerów", new Font(bf, 11))));
                dtab2.AddCell((new Phrase(poleMiejsceWynajmu.Text, new Font(bf, 11))));
                dtab2.AddCell((new Phrase(poleRozpiecie.Text, new Font(bf, 11))));
                dtab2.AddCell((new Phrase(listaKontener.Count.ToString(), new Font(bf, 11))));
                double t3 = Convert.ToDouble(poleRozpiecie.Text) * Convert.ToDouble(listaKontener.Count.ToString());
                dtab2.AddCell((new Phrase(t3.ToString(), new Font(bf, 11))));


                dtab2.AddCell((new Phrase("9", new Font(bf, 11))));
                dtab2.AddCell((new Phrase("Montaż schodni", new Font(bf, 11))));
                dtab2.AddCell((new Phrase(poleMiejsceWynajmu.Text, new Font(bf, 11))));
                dtab2.AddCell((new Phrase(poleCenaMontazSchodow.Text, new Font(bf, 11))));
                dtab2.AddCell((new Phrase("1", new Font(bf, 11))));
                double t4 = Convert.ToDouble(poleCenaMontazSchodow.Text) * 1;
                dtab2.AddCell((new Phrase(t4.ToString(), new Font(bf, 11))));



                dtab2.AddCell((new Phrase("10", new Font(bf, 11))));
                dtab2.AddCell((new Phrase("Demontaż schodni", new Font(bf, 11))));
                dtab2.AddCell((new Phrase(poleMiejsceWynajmu.Text, new Font(bf, 11))));
                dtab2.AddCell((new Phrase(poleCenaDemontazSchodow.Text, new Font(bf, 11))));
                dtab2.AddCell((new Phrase("1", new Font(bf, 11))));
                double t5 = Convert.ToDouble(poleCenaDemontazSchodow.Text) * 1;
                dtab2.AddCell((new Phrase(t5.ToString(), new Font(bf, 11))));

                int tempPodest = 0;
                foreach (var item in listaDodatki)
                {
                    if (item.dnazwadodatku == "podest duży" || item.dnazwadodatku=="podest mały")
                    {
                        tempPodest++;
                    }

                }

                    dtab2.AddCell((new Phrase("11", new Font(bf, 11))));
                dtab2.AddCell((new Phrase("Montaż podestów", new Font(bf, 11))));
                dtab2.AddCell((new Phrase(poleMiejsceWynajmu.Text, new Font(bf, 11))));
                dtab2.AddCell((new Phrase(poleCenaMontazPodest.Text, new Font(bf, 11))));
                dtab2.AddCell((new Phrase(tempPodest.ToString(), new Font(bf, 11))));
                double t6 = Convert.ToDouble(poleCenaMontazPodest.Text) * Convert.ToDouble(tempPodest);
                dtab2.AddCell((new Phrase(t6.ToString(), new Font(bf, 11))));



                dtab2.AddCell((new Phrase("12", new Font(bf, 11))));
                dtab2.AddCell((new Phrase("Demontaż podestów", new Font(bf, 11))));
                dtab2.AddCell((new Phrase(poleMiejsceWynajmu.Text, new Font(bf, 11))));
                dtab2.AddCell((new Phrase(poleCenaDemontazPodestow.Text, new Font(bf, 11))));
                dtab2.AddCell((new Phrase(tempPodest.ToString(), new Font(bf, 11))));
                double t7 = Convert.ToDouble(poleCenaDemontazPodestow.Text) * Convert.ToDouble(tempPodest);
                dtab2.AddCell((new Phrase(t7.ToString(), new Font(bf, 11))));


                dtab2.AddCell((new Phrase("13", new Font(bf, 11))));
                dtab2.AddCell((new Phrase("Prace dodatkowe", new Font(bf, 11))));
                dtab2.AddCell((new Phrase(poleMiejsceWynajmu.Text, new Font(bf, 11))));
                dtab2.AddCell((new Phrase(poleCenaPraceDodatkowe.Text, new Font(bf, 11))));
                dtab2.AddCell((new Phrase("1", new Font(bf, 11))));
                double t8 = Convert.ToDouble(poleCenaPraceDodatkowe.Text) * 1;
                dtab2.AddCell((new Phrase(t8.ToString(), new Font(bf, 11))));


                dtab2.AddCell((new Phrase("14", new Font(bf, 11))));
                dtab2.AddCell((new Phrase("Poziomowanie kontenerów na życzenie klienta (potwierdzone protokołem)", new Font(bf, 11))));
                dtab2.AddCell((new Phrase(poleMiejsceWynajmu.Text, new Font(bf, 11))));
                dtab2.AddCell((new Phrase(polePoziomowanie.Text, new Font(bf, 11))));
                dtab2.AddCell((new Phrase("1", new Font(bf, 11))));
                double t9 = Convert.ToDouble(polePoziomowanie.Text) * 1;
                dtab2.AddCell((new Phrase(t9.ToString(), new Font(bf, 11))));



                //dtab2.AddCell((new Phrase("4.", new Font(bf, 11))));
                //dtab2.AddCell((new Phrase("Dzierżawa", new Font(bf, 11))));
                ////TODO DOLICZNEIE
                //dtab2.AddCell((new Phrase("XXX" + " zł", new Font(bf, 11))));
                //double dzierzawaRazem = Convert.ToDouble(1) * Convert.ToDouble(iloscpelnychmiesiecyumowy);
                //dtab2.AddCell((new Phrase(dzierzawaRazem.ToString()+" zł", new Font(bf, 11))));



                document.Add(CEnte1r);
                document.Add(dtab2);

                //Zdefiniowanie DFraza2
                iTextSharp.text.Paragraph DFraza2 = new iTextSharp.text.Paragraph();
                DFraza2.Font = new Font(bf, 10f, 1);
                DFraza2.Alignment = Element.ALIGN_LEFT;

                DFraza2.Add("\nWarunki dostawy: ");
                DFraza2.Add(new Chunk(poleMiejsceWynajmu.Text, new Font(bf2)));

                DFraza2.Add("\nWarunki zwrotu: ");
                DFraza2.Add(new Chunk(poleMiejsceZwrotuKontenera.SelectedValue.ToString(), new Font(bf2)));
                string tempA = poleDataRozpUm.ToString();
                string tempB = poleDataZakUm.ToString();
                DFraza2.Add("\nOkres wynajmu: od " + tempA.Remove(tempA.Length-8) + " do " + tempB.Remove(tempB.Length - 8) + " z możliwością przedłużenia i wszcześniejszego wypowiedzenia. \n");

                document.Add(DFraza2);

                Chunk underline = new Chunk("Szczegółowe warunki płatności:" +
                    "\n- opłata najmu płatna jest przelewem na: " + poleFakturowanie.SelectedValue.ToString() +
                    "\n- termin płatności wynosi "+ poleTerminPlatnosci.SelectedValue.ToString() +" dni (od dnia wystawienia faktury VAT przez Wynajmującego)" +
                    "\n- kaucja płatna na podstawie faktury pro-forma, przed postawieniem kontenerów w wysokości: " + poleKaucja.Text + " zł\n\n", new Font(bf2, 10f));

                underline.SetUnderline(0.1f, -2f); //0.1 thick, -2 y-location
                document.Add(underline);

                //zdefiniowanie Dfraza3
                iTextSharp.text.Paragraph DFraza3 = new iTextSharp.text.Paragraph();
                DFraza3.Font = new Font(bf, 10f, 1);
                DFraza3.Alignment = Element.ALIGN_LEFT;
                DFraza3.Add("\nUwagi:");

                document.Add(DFraza3);
                iTextSharp.text.List DLista1 = new iTextSharp.text.List(iTextSharp.text.List.UNORDERED, 20f);
                DLista1.IndentationLeft = 20;


                // CLista9.Add(new iTextSharp.text.ListItem(new Chunk("Loco:... \n"), new Font(bf, 10f)));
                Chunk ch0 = new Chunk(" ", new Font(bf, 10f));
                Chunk ch1 = new Chunk("opłata dodatkowa za poziomowanie kontenera", new Font(bf2, 10f));
                Chunk ch2 = new Chunk("naliczana w razie braku stosownego przygotowania podłoża pod kontener(y) wynosi - 150zł netto/1kontener", new Font(bf, 10f));
                iTextSharp.text.Paragraph ch1ch2 = new iTextSharp.text.Paragraph();
                ch1ch2.Add(ch0);
                ch1ch2.Add(ch1);
                ch1ch2.Add(" ");
                ch1ch2.Add(ch2);
                DLista1.Add(new iTextSharp.text.ListItem(ch1ch2));

                Chunk ch3 = new Chunk("opłata dodatkowa za przestój środka transportu ", new Font(bf2, 10f));
                Chunk ch4 = new Chunk("wynikły z przyczyn leżących po stronie Najemcy (np. brak możliwości wjazdu na budowę po przyjeździe HDSa na miejsce) wynosi - 150zł netto/godzina. ", new Font(bf, 10f));
                iTextSharp.text.Paragraph ch3ch4 = new iTextSharp.text.Paragraph();
                ch3ch4.Add(ch0);
                ch3ch4.Add(ch3);
                ch3ch4.Add(" ");
                ch3ch4.Add(ch4);
                DLista1.Add(new iTextSharp.text.ListItem(ch3ch4));

                Chunk ch5 = new Chunk("opłata za brak spuszczonej wody z bojlera i/lub odpływów ", new Font(bf2, 10f));
                Chunk ch6 = new Chunk("w chwili odbioru kontenera, wynosi 200zł netto.", new Font(bf, 10f));
                iTextSharp.text.Paragraph ch5ch6 = new iTextSharp.text.Paragraph();
                ch5ch6.Add(ch0);
                ch5ch6.Add(ch5);
                ch5ch6.Add(" ");
                ch5ch6.Add(ch6);
                DLista1.Add(new iTextSharp.text.ListItem(ch5ch6));
                DLista1.Add(new iTextSharp.text.ListItem(" Jeśli okres wynajmu kontenera przekracza 6 m-cy Wynajmujący w przypadku wzrostu kosztów spowodowanych ogólnymi warunkami gospodarczymi zastrzega sobie prawo zmiany cen najmu kontenera oraz kosztów jego zwrotu. Podwyższone opłaty obowiązywać będą od pierwszego dnia miesiąca następującego po miesiącu, z którym Najemca został poinformowany o zmianie warunków.", new Font(bf, 10f)));
                document.Add(DLista1);

                document.NewPage();

                //zdefiniowanie DFrazy4
                iTextSharp.text.Paragraph DFraza4 = new iTextSharp.text.Paragraph();
                DFraza4.Font = new Font(bf2, 11f);
                DFraza4.Alignment = Element.ALIGN_LEFT;
                DFraza4.Add(new Chunk("Załącznik Nr 2 do Umowy Najmu Kontenerów nr: U/" + poleNrUmowy.Text + "/2019 z dnia: " + poleDataPodpisaniaUmowy.ToString().Remove(poleDataPodpisaniaUmowy.ToString().Length - 8) + "  \n\n\n", new Font(bf2)));
                document.Add(DFraza4);

                Chunk DFraza5 = new Chunk("INSTRUKCJA MONTAŻU, EKSPLOATACJI KONTENERA, KONTENERÓW BIUROWYCH, SOCJALNYCH, SANITARNYCH , SOCJALNO-SANITARNEGO\n", new Font(bf, 10f));
                DFraza5.SetUnderline(0.1f, -2f);
                document.Add(DFraza5);

                Chunk DFraza6 = new Chunk("\nZasady bezpieczeństwa:\n", new Font(bf2, 10f));
                DFraza5.SetUnderline(0.1f, -2f);
                document.Add(DFraza6);

                iTextSharp.text.List DLista2 = new iTextSharp.text.List(iTextSharp.text.List.UNORDERED, 20f);
                DLista2.IndentationLeft = 20;
                DLista2.SetListSymbol("\u2022");
                DLista2.Add(new iTextSharp.text.ListItem("Przed rozpoczęciem użytkowania kontenera, należy zapoznać się z zasadami bezpieczeństwa, zaleceniami producenta, instrukcją eksploatacji i obsługi.", new Font(bf, 10f)));
                DLista2.Add(new iTextSharp.text.ListItem("Zachować szczególną ostrożność przy pracach związanych z transportem, montażem oraz serwisowaniem kontenera. W trakcie w/w czynności należy przestrzegać ogólnych zasad BHP.", new Font(bf, 10f)));
                DLista2.Add(new iTextSharp.text.ListItem("Kontener należy eksploatować zgodnie z ogólnymi zasadami BHP i Ppoż.", new Font(bf, 10f)));
                DLista2.Add(new iTextSharp.text.ListItem("Montaż kontenera powinna wykonywać osoba, która zapoznała się z poniższymi instrukcjami i zaleceniami producenta", new Font(bf, 10f)));
                DLista2.Add(new iTextSharp.text.ListItem("Naprawy serwisowe instalacji elektrycznej powinna wykonywać osoba wykwalifikowana z uprawnieniami elektrycznymi. Co najmniej raz w roku należy dokonać pomiarów instalacji elektrycznej, a wyniki udokumentować w protokole przeglądu", new Font(bf, 10f)));
                DLista2.Add(new iTextSharp.text.ListItem("Przed przystąpieniem do jakichkolwiek czynności serwisowych instalacji elektrycznej odłączyć zasilanie główne zewnętrzne kontenera.", new Font(bf, 10f)));
                DLista2.Add(new iTextSharp.text.ListItem("Nie zmieniać ustawień wodnego reduktora ciśnienia instalacji hydraulicznej ( niebezpieczeństwo zniszczenia lub rozszczelnienia instalacji. )", new Font(bf, 10f)));
                DLista2.Add(new iTextSharp.text.ListItem("Nie włączać (wyłączać) urządzeń elektrycznych wilgotnymi rękami", new Font(bf, 10f)));
                DLista2.Add(new iTextSharp.text.ListItem("Należy chronić zewnętrzny główny przewód zasilający przed uszkodzeniem, nie używać (nie ciągnąć) za przewód przy manewrowaniu i ustawianiu kontenera", new Font(bf, 10f)));
                DLista2.Add(new iTextSharp.text.ListItem("Nie wolno używać kontenera do innych celów niż określone w instrukcji eksploatacji i obsługi.", new Font(bf, 10f)));

                document.Add(ch0);
                document.Add(DLista2);

                iTextSharp.text.List DLista3 = new iTextSharp.text.List(iTextSharp.text.List.UNORDERED, 20f);
                DLista3.IndentationLeft = 20;
                DLista3.SetListSymbol("\u2022");
                DLista3.Add(new iTextSharp.text.ListItem("", new Font(bf)));

                Chunk ch7 = new Chunk("Załadunek i rozładunek kontenera dokonywany jest za pomocą dźwigu lub HDS. Zawiesia mocować za otwory w narożach górnych stalowej ramy kontenera ", new Font(bf, 10f));
                Chunk ch8 = new Chunk("Nie dopuszcza się przenoszenia kontenerów obciążonych dodatkowym ładunkiem nie przewidzianym przez producenta !!!", new Font(bf2, 10f));
                iTextSharp.text.Paragraph ch7ch8 = new iTextSharp.text.Paragraph();
                ch7ch8.Add(ch0);
                ch7ch8.Add(ch7);
                ch7ch8.Add(" ");
                ch7ch8.Add(ch8);

                iTextSharp.text.Paragraph DFraza7 = new iTextSharp.text.Paragraph();
                DFraza7.Font = new Font(bf2, 10f);
                DFraza7.Alignment = Element.ALIGN_LEFT;
                DFraza7.Add("\nZalecenia producenta dotyczące transportu i montażu kontenera(zestawu kontenerów)");


                DLista3.Add(new iTextSharp.text.ListItem("Kontener przeznaczony jest do transportu samochodowego lub kolejowego przy pomocy podwozia przystosowanego do tego typu ładunków. (Transport lądowy)", new Font(bf, 10f)));
                DLista3.Add(new iTextSharp.text.ListItem(ch7ch8));
                DLista3.Add(new iTextSharp.text.ListItem("Przed rozpoczęciem załadunku kontenera należy usunąć zalegający śnieg i lód z dachu używając do tego celu łopaty drewnianej lub z tworzywa sztucznego.", new Font(bf, 10f)));
                DLista3.Add(new iTextSharp.text.ListItem("Każdy kontener musi zostać posadowiony na przygotowanym fundamencie budowlanym posiadającym w przypadku kontenerów 10’ co najmniej 4 punkty podporowe a w przypadku kontenerów 20’ co najmniej 6 punktów. Rozmiar fundamentu oraz jego głębokość związana jest z obowiązującymi normami, lokalną głębokością przemarzania gruntu oraz właściwościami podłoża. ( minimalna powierzchnia fundamentu 20x20 cm)", new Font(bf, 10f)));
                DLista3.Add(new iTextSharp.text.ListItem("Kontener należy ustawić na stabilnym, suchym i wypoziomowanym podłożu.", new Font(bf, 10f)));
                DLista3.Add(new iTextSharp.text.ListItem("Nie wolno ustawiać kontenera poniżej poziomu terenu oraz w zagłębieniach wypełnionych cieczą.", new Font(bf, 10f)));
                DLista3.Add(new iTextSharp.text.ListItem("Należy zapewnić swobodne rozsączanie się wód opadowych sprowadzonych pod kontener wewnętrznymi rurami spustowymi lub odprowadzić wody opadowe bezpośrednio do kanalizacji deszczowej.", new Font(bf, 10f)));
                DLista3.Add(new iTextSharp.text.ListItem("W przypadku zestawów wielomodułowych montaż musi odbywać się przy użyciu ściągów ( poziomych, pionowych, wewnętrznych), taśm uszczelniających oraz wszelkich izolacji i obróbek maskujących przewidzianych do danej technologii kontenera. Zestawy kontenerowe mogą być bezpiecznie eksploatowane przy ustawieniu maksymalnie dwóch kondygnacji. W przypadku 1-kondygnacyjnego zestawu, kontenery mogą być ustawione w dowolny sposób. Zestawy 2-kondygnacyjne można bezpiecznie eksploatować przy zestawieniu minimum dwóch modułów ze sobą ( zestawienie długimi bokami) na jednym poziomie.", new Font(bf, 10f)));
                DLista3.Add(new iTextSharp.text.ListItem("Przygotowanie kontenera do eksploatacji (czynności odpowiednio do rodzaju wyposażenia kontenera) ", new Font(bf, 10f)));
                DLista3.Add(new iTextSharp.text.ListItem("Wykonanie podłączenia kontenera do zewnętrznego obwodu ochronnego.", new Font(bf, 10f)));
                DLista3.Add(new iTextSharp.text.ListItem("Podłączenie zewnętrznego zasilania głównego kontenera", new Font(bf, 10f)));
                DLista3.Add(new iTextSharp.text.ListItem("Kolejno załączanie zabezpieczenia typu ,,S’’", new Font(bf, 10f)));
                DLista3.Add(new iTextSharp.text.ListItem("Sprawdzenie ciągłości przewodu ochronnego instalacji elektrycznej", new Font(bf, 10f)));
                DLista3.Add(new iTextSharp.text.ListItem("Sprawdzenie poprawności otwierania się drzwi i działania zamka.", new Font(bf, 10f)));
                DLista3.Add(new iTextSharp.text.ListItem("Sprawdzenie poprawności otwierania się okien i działania rolet.", new Font(bf, 10f)));
                DLista3.Add(new iTextSharp.text.ListItem("Podłączenie kontenera do zewnętrznej sieci wod-kan oraz izolacja termiczna przyłączy zewnętrznych", new Font(bf, 10f)));
                DLista3.Add(new iTextSharp.text.ListItem("Sprawdzenie szczelności układu hydraulicznego kontenera.", new Font(bf, 10f)));
                DLista3.Add(new iTextSharp.text.ListItem("Sprawdzenie czy instalacja i podgrzewacze są napełnione wodą (czy jest woda podłączona do instalacji i czy nie są zakręcone zawory na ,,zasilaniu i powrocie’’). Nie wolno włączać podgrzewaczy wody bez sprawdzenia (w przeciwnym wypadku nastąpi spalenie grzałek podgrzewacza).", new Font(bf, 10f)));
                DLista3.Add(new iTextSharp.text.ListItem("Sprawdzenie poprawności działania podgrzewaczy wody.", new Font(bf, 10f)));
                DLista3.Add(new iTextSharp.text.ListItem("Sprawdzenie poprawności działania spłuczek", new Font(bf, 10f)));
                DLista3.Add(new iTextSharp.text.ListItem("Sprawdzenie działania grzejnika elektrycznego (nie może być załączony bez równoczesnej pracy wentylatora grzejnika).", new Font(bf, 10f)));
                DLista3.Add(new iTextSharp.text.ListItem("Sprawdzenie drożności zewnętrznego i wewnętrznego systemu odprowadzenia wód opadowych", new Font(bf, 10f)));
                DLista3.Add(new iTextSharp.text.ListItem("Sprawdzenie stanu zewnętrznego konstrukcji stalowej oraz poszycia zewnętrznego stropodachu i ścian kontenera (uszkodzenia powłoki malarskiej, uszkodzenia mechaniczne poszyć ścian).", new Font(bf, 10f)));
                DLista3.Add(new iTextSharp.text.ListItem("Umycie i wyczyszczenie luster.", new Font(bf, 10f)));
                DLista3.Add(new iTextSharp.text.ListItem("Umycie wykładziny wewnątrz kontenera.", new Font(bf, 10f)));
                DLista3.Add(new iTextSharp.text.ListItem("Przed przystąpieniem do eksploatacji kontenera należy dokonać naprawy wszelkich uszkodzeń powstałych w trakcie transportu i montażu.", new Font(bf, 10f)));
                DLista3.Add(new iTextSharp.text.ListItem("W przypadku zarysowania powłok lakierniczych wykonać niezbędne zaprawki malarskie, aby zapobiec rozwijaniu się procesu korozji.", new Font(bf, 10f)));
                DLista3.Add(new iTextSharp.text.ListItem("Wszystkie przeróbki instalacji elektrycznej i hydraulicznej w trakcie montażu należy wcześniej skonsultować z producentem", new Font(bf, 10f)));
                DLista3.Add(new iTextSharp.text.ListItem("Wszelkie przeróbki trwale ingerujące w poszczególne elementy składowe kontenera należy wcześniej skonsultować z producentem.", new Font(bf, 10f)));
                DLista3.Add(new iTextSharp.text.ListItem("W przypadku kontenerów bez podłogi, w których zostanie wykonana posadzka metodą tradycyjną należy odpowiednio zabezpieczyć izolacją przeciwwilgociową oraz termiczną poszczególne elementy składowe kontenera, tak aby w trakcie wykonania, użytkowania i demontażu nie doprowadzić do trwałych uszkodzeń.\n(Należy zastosować wkładki oddzielające w miejscach styku posadzki z elementami kontenera umożliwiające późniejszy demontaż)", new Font(bf, 10f)));
                //  DLista3.Add(new iTextSharp.text.ListItem("", new Font(bf)));
                document.Add(DFraza7);
                document.Add(DLista3);


                Chunk ch9 = new Chunk("Zalecenia prodocenta dotyczące eksploatacji kontenera (zestawu kontenerów)\n", new Font(bf2, 10f));
                ch9.SetUnderline(0.1f, -2f);
                Chunk ch10 = new Chunk("Charakterystyka dopuszczalnych obciążeń\n", new Font(bf, 10f));

                iTextSharp.text.List DLista4a = new iTextSharp.text.List(iTextSharp.text.List.UNORDERED, 20f);
                DLista4a.IndentationLeft = 20;
                DLista4a.Add(new iTextSharp.text.ListItem("Obciążenie użytkowe podłogi", new Font(bf, 10f)));
                iTextSharp.text.List DLista4b = new iTextSharp.text.List(iTextSharp.text.List.UNORDERED, 20f);
                DLista4b.IndentationLeft = 20;
                DLista4b.SetListSymbol("\u2013");
                DLista4a.Add(DLista4b);
                DLista4b.Add(new iTextSharp.text.ListItem("parter – maksymalnie obciążenie 2,0 kN/m²", new Font(bf, 10f)));
                DLista4b.Add(new iTextSharp.text.ListItem("piętro – maksymalne obciążenie 1,5 kN/m²", new Font(bf, 10f)));

                DLista4a.Add(new iTextSharp.text.ListItem("Obciążenie stropodachu – maksymalnie obciążenie 1,0 kN/m²" +
                    "\n W przypadku zalegania na dachu pokrywy śnieżnej powyżej 15cm grubości należy oczyścić dach ze śniegu", new Font(bf, 10f)));


                DLista4a.Add(new iTextSharp.text.ListItem("Obciążenie wiatrem – siła naporowa wiatru 25m/s", new Font(bf, 10f)));

                document.Add(ch9);
                document.Add(ch10);
                document.Add(DLista4a);

                Chunk ch11 = new Chunk("W przypadku bardzo silnego wiatru konieczne jest dodatkowe, indywidualne zabezpieczenie kontenerów (odciągi, połączenia śrubowe, podpory itp.)\n", new Font(bf2, 10f));

                iTextSharp.text.List DLista5 = new iTextSharp.text.List(iTextSharp.text.List.UNORDERED, 20f);
                DLista5.IndentationLeft = 20;
                DLista5.SetListSymbol("\u2022");
                DLista5.Add(new iTextSharp.text.ListItem("Kontener należy użytkować zgodnie z jego przeznaczeniem.", new Font(bf, 10f)));
                DLista5.Add(new iTextSharp.text.ListItem("Wszystkie przeróbki instalacji elektrycznej i hydraulicznej w trakcie eksploatacji należy wcześniej skonsultować z producentem", new Font(bf, 10f)));

                document.Add(ch11);
                document.Add(DLista5);
                document.NewPage();

                iTextSharp.text.Paragraph EFraza1 = new iTextSharp.text.Paragraph();
                EFraza1.Font = new Font(bf2, 11f);
                EFraza1.Alignment = Element.ALIGN_LEFT;
                EFraza1.Add(new Chunk("Załącznik Nr 3 do Umowy Najmu Kontenerów nr: U/" + poleNrUmowy.Text + "/2019 z dnia: " + theDate.ToShortDateString().ToString() + "  \n\n\n", new Font(bf2)));
                document.Add(EFraza1);

                PdfPTable Etab1 = new PdfPTable(3);
                PdfPRow row3 = null;
                float[] wi3 = new float[] { 0.5f, 5f, 0.5f };
                Etab1.SetWidths(wi3);
                Etab1.WidthPercentage = 100;
                Etab1.PaddingTop = 10;

                Etab1.AddCell((new Phrase("LP", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("CENNIK NAPRAW", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("CENA NETTO [PLN]", new Font(bf, 10))));


                Etab1.AddCell((new Phrase("1", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("wymiana skrzydła drzwiowego wewnętrznego (kontener socjalny)-kpl", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("210,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("2", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("wymiana skrzydła drzwiowego wewnętrznego (kontener sanitarny)-kpl", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("280,00", new Font(bf, 10))));


                Etab1.AddCell((new Phrase("3", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("wymiana skrzydła drzwiowego zewnętrznego - kpl", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("345,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("4", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("wymiana panela drzwiowego z drzwiami stalowymi zewnętrznymi (kontener socjalny)", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("1 175,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("5", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("wymiana panela drzwiowego z drzwiami stalowymi zewnętrznymi (kontener sanitarny)", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("1 260,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("6", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("wymiana panela pełnego z montażem obróbek i silikonowaniem (kontener sanitarny)", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("570,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("7", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("wymiana panela pełnego z montażem obróbek i silikonowaniem (kontener socjalny)", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("500,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("8", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("usługa wymiany panela okiennego z montażem obróbek i silikonowaniem (kontener socjalny)", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("1 520,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("9", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("usługa wymiany panela okiennego z montażem obróbek i silikonowaniem (kontener sanitarny)", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("1 125,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("10", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("wymiana zamka drzwi zewnętrznych (wkładka + klamka)", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("120,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("11", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("wymiana zamka drzwi wewnętrznych (wkładka + klamka) kontener socjalny", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("115,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("12", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("wymiana zamka drzwi wewnętrznych sanitarnych (wkładka + klamka)", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("105,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("13", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("wymiana klamki drzwi wewnętrznych (kontener socjalny)", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("70,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("14", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("wymiana klamki drzwi wewnętrznych (kontener sanitarny)", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("75,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("15", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("wymiana klamki drzwi zewnętrznych", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("51,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("16", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("wymiana klamki okna", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("25,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("17", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("wymiana wkładki drzwi", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("45,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("18", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("wymiana ościeżnicy drzwi wewnętrznych z zawiasami w komplecie  (kontener socjalny i sanitarny)", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("380,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("19", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("wymiana ościeżnicy drzwi zewnętrznych z zawiasami w komplecie (kontener socjalny i sanitarny)", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("430,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("20", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("silikonowanie kontenera", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("85,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("21", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("usługa demontażu panela z obróbką- 1 szt", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("45,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("22", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("usługa montażu panela z obróbką i silikonowaniem- 1 szt", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("70,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("23", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("wymiana listwy paneli (PCV)", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("15,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("24", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("wymiana wykładziny PCV", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("620,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("25", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("wymiana wykładziny PCV kontener  10'", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("400,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("26", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("wymiana całej podłogi (wykładzina + płyta+wełna+folia)- kontener 20'", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("1 650,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("27", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("wymiana całej podłogi (wykładzina + płyta+wełna+folia)- kontener 10'", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("950,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("28", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("wymiana listwy przypodłogowej (sztuka)", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("30,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("29", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("wymiana zwijacza rolety", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("62,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("30", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("wymiana rolety", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("260,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("31", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("wymiana ścianki działowej pełnej", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("1 850,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("32", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("wymiana ścianki działowej z drzwiami", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("2 500,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("33", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("zaślepianie otworów do fi 1cm", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("15,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("34", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("czyszczenie z malowaniem wewnętrznej strony panela", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("200,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("35", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("czyszczenie z malowaniem zewnętrznej strony panela", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("200,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("36", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("czyszczenie z malowaniem ramy kontenera", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("900,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("37", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("czyszczenie z malowaniem całego kontenera 20'", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("1 760,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("38", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("czyszczenie z malowaniem całego kontenera 10'", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("1 100,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("39", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("naprawa okna", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("95,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("40", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("naprawa ściany kontenera do demontażu klimatyzatora podokiennego zamontowanego przez Najemcę ", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("200,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("41", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("wymiana grzejnika", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("400,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("42", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("wymiana umywalki", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("160,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("43", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("wymiana pisuaru", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("200,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("44", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("wymiana baterii pojedynczej", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("125,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("45", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("wymiana kabiny prysznicowej", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("810,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("46", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("wymiana zasłonki prysznicowej", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("41,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("47", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("wymiana baterii prysznicowej", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("230,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("48", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("wymiana muszli klozetowej", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("180,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("49", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("wymiana deski sedesowej ", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("60,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("50", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("wymiana podajnika papieru toaletowego", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("29,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("51", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("wymiana spłuczki do muszli klozetowej", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("85,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("52", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("wymiana bojlera ", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("1 530,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("53", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("wymiana rynny umywalkowej ", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("580,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("54", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("wymiana aneksu kuchennego", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("1 980,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("55", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("wymiana lustra", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("38,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("56", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("wymiana rury odpływowej", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("60,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("57", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("wymiana reduktora ciśnienia z manometrem", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("170,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("58", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("wymiana ścianki pisuarowej", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("160,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("59", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("wymiana półki pod lustro", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("38,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("60", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("wymiana spłuczki pisuar", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("170,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("61", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("wymiana podgrzewacza wody 10l", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("210,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("62", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("odtwarzanie instalacji sanitarnej cw, zw, kan. MS-SB3", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("330,00", new Font(bf, 10))));


                Etab1.AddCell((new Phrase("63", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("odtwarzanie instalacji sanitarnej cw, zw, kan. MS-S8 i MS-S9", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("570,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("64", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("wymiana obudowy skrzynki bezpieczników", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("210,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("65", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("wymiana zabezpieczenia 16-32A", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("52,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("66", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("wymiana wyłącznika różnicowego", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("164,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("67", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("wymiana gniazda/wtyku zewnętrznego", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("42,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("68", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("wymiana gniazda/wyłącznika wewnętrznego- kontener socjalny", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("34,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("69", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("wymiana gniazda/wyłącznika wewnętrznego- kontener sanitarny", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("39,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("70", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("wymiana lampy 2x36 W", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("181,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("71", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("wymiany plafonu", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("41,00", new Font(bf, 10))));


                Etab1.AddCell((new Phrase("72", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("Odtwarzanie instalacji elektrycznej (robocizna sama)", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("300,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("73", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("specjalistyczne czyszczenie kontenera biurowego - zabrudzenia stałe", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("500,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("74", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("specjalistyczne czyszczenie kontenera sanitarnego - zabrudzenia stałe", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("800,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("75", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("wymiana wyłącznika- kontener sanitarny", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("34,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("76", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("wymiana wyłącznika- kontener socjalny", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("34,00", new Font(bf, 10))));

                Etab1.AddCell((new Phrase("77", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("wymiana obudowy skrzynki bezpieczników (rozdzielnia)", new Font(bf, 10))));
                Etab1.AddCell((new Phrase("215,00", new Font(bf, 10))));

                document.Add(Etab1);
              //  writer.Close();
                document.Close();



            System.Windows.MessageBox.Show("Pomyślnie wprowadzono umowę do bazy!");
                xsciezka = " Umowy / " + nazwaUmowyDokument + ".pdf";
                

                this.Close();

            }
            catch (MySqlException se)
            {
                System.Windows.MessageBox.Show("Wystąpił błąd połączenia: " + se.ToString());
            }

            Thread.Sleep(1500);
            Process.Start("AcroRd32.exe", xsciezka);



        }

        private void DodajDoZestawieniaBTN_Click(object sender, RoutedEventArgs e)
        {
         
            DataRowView row = (DataRowView)dgKontener.SelectedItems[0];
          
          

            string idWybrKont = row[0].ToString();

            string sciezka = "baza.config";
            string konfiguracja = File.ReadAllText(sciezka);


            int temp_id;
            string temp_numercaro;
            string temp_numerweldon;
            string temp_amortyzacjakontenera;
            string temp_cenanetto;
            string temp_typkontenera;
            string temp_czyklimatyzowany;
            string temp_czywynajety;
            string temp_podstawowewyposazeniekontenera;
            string temp_dodatkowewyposazeniekontenera;
            string temp_lokalizacja;
            string temp_cenaminimalna;
            string temp_datazakupukontenera;
            string temp_datakoncaamortyzacji;
            string temp_notatka;

            try
            {

                MySqlConnection conn = null;
                conn = new MySqlConnection(konfiguracja);
                conn.Open();

                string stm = "SELECT VERSION()";
                MySqlCommand cmdlog = new MySqlCommand(stm, conn);
                cmdlog.Connection = conn;
                cmdlog.CommandText = "select * from kontener where id=@id;";
                cmdlog.Prepare();

                cmdlog.Parameters.AddWithValue("@id", Convert.ToInt32(idWybrKont));

                MySqlDataReader dataReader = cmdlog.ExecuteReader();
                if (dataReader.Read())
                {
                    temp_id = Convert.ToInt32(dataReader["id"].ToString());
                    temp_numercaro = dataReader["nrCaro"].ToString();
                    temp_numerweldon = dataReader["nrWeldon"].ToString();
                    temp_amortyzacjakontenera = dataReader["amortyzacja"].ToString();
                    temp_cenanetto = dataReader["cenaNetto"].ToString();
                    temp_typkontenera = dataReader["typKontenera"].ToString();
                    temp_czyklimatyzowany = dataReader["czyKlimatyzowany"].ToString();
                    temp_czywynajety = dataReader["czyWynajety"].ToString();
                    temp_podstawowewyposazeniekontenera = dataReader["podstWyposazenie"].ToString();
                    temp_dodatkowewyposazeniekontenera = dataReader["dodatWyposazenie"].ToString();
                    temp_lokalizacja = dataReader["lokalizacja"].ToString();
                    temp_cenaminimalna = dataReader["cenaMinimalna"].ToString();
                    temp_datazakupukontenera = dataReader["dataZakupu"].ToString();
                    temp_datakoncaamortyzacji = dataReader["dataKoncaAmo"].ToString();
                    temp_notatka = dataReader["notatka"].ToString();


                    listaKontener.Add(new klasaKontener(temp_id, temp_numercaro, temp_numerweldon, temp_amortyzacjakontenera, temp_cenanetto, temp_typkontenera, temp_czyklimatyzowany, temp_czywynajety, temp_podstawowewyposazeniekontenera, temp_dodatkowewyposazeniekontenera, temp_lokalizacja, temp_cenaminimalna, temp_datazakupukontenera, temp_datakoncaamortyzacji, temp_notatka));
                }
                odswiezPokaz();
            }
            catch (MySqlException se)
            {
                System.Windows.MessageBox.Show("Wystąpił błąd połączenia: " + se.ToString());
            }
        }

        private void BlistaUsun_Click(object sender, RoutedEventArgs e)
        {

            // ObservableCollection<klasaKontener> collection2 = new ObservableCollection<klasaKontener>(listaKontener);
            // Console.WriteLine("*** " + collection2[0].ko_id.ToString());

            // Console.WriteLine(collection2[0].ko_numercaro.ToString());
            // Console.WriteLine("#######################");
            // var test3 = collection2.ToList();
            //test3.s
            // foreach (var item in test3)
            // {
            //     Console.WriteLine("X X"+item.ko_id);
            // }


            //klasaKontener client = lsWybrane.SelectedItem as klasaKontener;
            //if (client != null)
            //    listaKontener.Remove(client);
            //odswiezPokaz();



            //  lsWybrane.Items.RemoveAt(lsWybrane.Items.IndexOf(lsWybrane.SelectedItem));




            //{
            //    if (0 == lsWybrane.SelectedItems.Count)
            //    {
            //        return;
            //    }
            //    string test = ((klasaKontener)lsWybrane.SelectedItem).ko_id.ToString();
            //    System.Windows.MessageBox.Show(test);
            //    // Console.WriteLine("#ID WYBRANEGO " + test);
            //    // listaKontener.Remove(test);
            //    listaKontener.RemoveAll(x => x.ko_id == Convert.ToInt16(test));
            //    // Console.WriteLine("Krok 2");
            //    odswiezPokaz();
            //}

            System.Windows.Controls.Button button = sender as System.Windows.Controls.Button;
            klasaKontener kont = button.DataContext as klasaKontener;
            int a = kont.ko_id;
            string hkontId = a.ToString();
          //  System.Windows.MessageBox.Show(hkontId);

            var kon = listaKontener.FirstOrDefault<klasaKontener>(d => d.ko_id == Convert.ToInt16(hkontId));
            listaKontener.RemoveAll(x => x.ko_id == Convert.ToInt16(hkontId));
            odswiezPokaz();


            //System.Windows.Controls.Button cmd = (System.Windows.Controls.Button)sender;
            //    if (cmd.DataContext is klasaKontener)
            //    {

            //        klasaKontener deleteme = (klasaKontener)cmd.DataContext;
            //        listaKontener.Remove(deleteme);

            //    }
            //Console.Write("XX");
            //odswiezPokaz();


            //DataRowView dataRowView = (DataRowView)((System.Windows.Controls.Button)e.Source).DataContext;
            //string idWybrane = dataRowView[0].ToString();
            //Console.WriteLine("]]]" + idWybrane);


            //DataRowView dataRowView = (DataRowView)((System.Windows.Controls.Button)e.Source).DataContext;
            //string idWybrane = dataRowView[0].ToString();

        }

        public void odswiezPokaz()
        {
            var source = new BindingSource();
            ObservableCollection<klasaKontener> collection = new ObservableCollection<klasaKontener>(listaKontener);
            source.DataSource = collection;
            lsWybrane.ItemsSource = source;
            lsWybrane2.ItemsSource = source;
            if (collection.Count != 0)
            {
                Console.WriteLine(collection[0].ko_numercaro.ToString());
                Console.WriteLine("-------------------");
                var test2 = collection.ToList();
                foreach (var item in test2)
                {
                    Console.WriteLine(item.ko_id);
                }
            }
            else System.Windows.MessageBox.Show("Umowa musi zawierać przynajmniej jeden kontener!");

        }
    



        public void odswiezPokazDodatki()
        {
            var source1 = new BindingSource();
            ObservableCollection<klasaDodatki> collection = new ObservableCollection<klasaDodatki>(listaDodatki);
            source1.DataSource = collection;
            lsDodatki.ItemsSource = source1;

        }

        public string przecinekNaKropke(string wejscie)
        {
            string temp = wejscie.Replace(',', '.');
            return temp;
        }

      
        
    /*   
        public void wypelnijTabeleKlient()
        {
            


            //try
            //{

            //    MySqlConnection conn = PolaczenieDB.polaczenieZBazaDanych();
            //    string stm = "SELECT VERSION()";
            //    MySqlCommand cmdlog = new MySqlCommand(stm, conn);
            //    cmdlog.Connection = conn;
            //    cmdlog.CommandText = "select * from klient;";
            //    cmdlog.Prepare();

            //    cmdlog.ExecuteNonQuery();
            //    MySqlDataAdapter da = new MySqlDataAdapter(cmdlog);
            //    MySqlCommandBuilder ccc = new MySqlCommandBuilder(da);
            //    //DataTable dt = new DataTable();
            //    DataTable dt = new DataTable();

            //    da.Fill(dt);
            //    dgKlient.DataContext = dt;

            //}
            //catch (MySqlException se)
            //{
            //    System.Windows.MessageBox.Show("Wystąpił błąd połączenia: " + se.ToString());
            //}


        }
*/
        public void wypelnijTabeleKontener()
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
                cmdlog.CommandText = "select * from kontener;";
                cmdlog.Prepare();

                cmdlog.ExecuteNonQuery();
                MySqlDataAdapter da = new MySqlDataAdapter(cmdlog);
                MySqlCommandBuilder ccc = new MySqlCommandBuilder(da);
                //DataTable dt = new DataTable();
                DataTable dt = new DataTable();

                da.Fill(dt);
                dgKontener.DataContext = dt;

            }
            catch (MySqlException se)
            {
                System.Windows.MessageBox.Show("Wystąpił błąd połączenia: " + se.ToString());
            }


        }

        private void SzukajNowaUmowaKlientBTN_Click(object sender, RoutedEventArgs e)
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
                string temp1 = "%" + poleKlientSzukaj.Text + "%";
                cmdlog.Parameters.AddWithValue("@frazaszukana", temp1);
                Console.WriteLine(cmdlog.CommandText.ToString());
                cmdlog.ExecuteNonQuery();
                MySqlDataAdapter da = new MySqlDataAdapter(cmdlog);
                MySqlCommandBuilder ccc = new MySqlCommandBuilder(da);
                //DataTable dt = new DataTable();
                DataTable dt = new DataTable();

                da.Fill(dt);
                dgKlient.DataContext = dt;
            }
            catch (MySqlException se)
            {
                System.Windows.MessageBox.Show("Wystąpił błąd połączenia: " + se.ToString());
            }
        }

        private void SzukajNowaUmowaKontenerBTN_Click(object sender, RoutedEventArgs e)
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
                string temp1 = "%" + poleKontenerSzukaj.Text + "%";
                cmdlog.Parameters.AddWithValue("@frazaszukana", temp1);
                Console.WriteLine(cmdlog.CommandText.ToString());
                cmdlog.ExecuteNonQuery();
                MySqlDataAdapter da = new MySqlDataAdapter(cmdlog);
                MySqlCommandBuilder ccc = new MySqlCommandBuilder(da);
                //DataTable dt = new DataTable();
                DataTable dt = new DataTable();

                da.Fill(dt);
                dgKontener.DataContext = dt;
            }
            catch (MySqlException se)
            {
                System.Windows.MessageBox.Show("Wystąpił błąd połączenia: " + se.ToString());
            }
        }

        private void ResetSzukajNowaUmowaKontenerBTN_Click(object sender, RoutedEventArgs e)
        {
            wypelnijTabeleKontener();
            poleKontenerSzukaj.Text = "";
        }

        private void ResetSzukajNowaUmowaKlientBTN_Click(object sender, RoutedEventArgs e)
        {
            MenadzerKlientDB menadzer = new MenadzerKlientDB(grid_klient);


            poleKlientSzukaj.Text = "";
        }

        private void PoleKlientSzukaj_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
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
                    string temp1 = "%" + poleKlientSzukaj.Text + "%";
                    cmdlog.Parameters.AddWithValue("@frazaszukana", temp1);
                    Console.WriteLine(cmdlog.CommandText.ToString());
                    cmdlog.ExecuteNonQuery();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmdlog);
                    MySqlCommandBuilder ccc = new MySqlCommandBuilder(da);
                    //DataTable dt = new DataTable();
                    DataTable dt = new DataTable();

                    da.Fill(dt);
                    dgKlient.DataContext = dt;
                }
                catch (MySqlException se)
                {
                    System.Windows.MessageBox.Show("Wystąpił błąd połączenia: " + se.ToString());
                }
            }
        }

        private void PoleKontenerSzukaj_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
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
                    string temp1 = "%" + poleKontenerSzukaj.Text + "%";
                    cmdlog.Parameters.AddWithValue("@frazaszukana", temp1);
                    Console.WriteLine(cmdlog.CommandText.ToString());
                    cmdlog.ExecuteNonQuery();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmdlog);
                    MySqlCommandBuilder ccc = new MySqlCommandBuilder(da);
                    //DataTable dt = new DataTable();
                    DataTable dt = new DataTable();

                    da.Fill(dt);
                    dgKontener.DataContext = dt;
                }
                catch (MySqlException se)
                {
                    System.Windows.MessageBox.Show("Wystąpił błąd połączenia: " + se.ToString());
                }
            }
        }

        private void BPowrotDoKlienta_Click(object sender, RoutedEventArgs e)
        {
            uHome.Visibility = Visibility.Visible;
            uKontenery.Visibility = Visibility.Collapsed;
            uUmowa.Visibility = Visibility.Collapsed;
            MenadzerKlientDB menadzer = new MenadzerKlientDB(dgKlient);
        }

        private void BPowrotDoKOntenerow_Click(object sender, RoutedEventArgs e)
        {
            uHome.Visibility = Visibility.Collapsed;
            uKontenery.Visibility = Visibility.Visible;
            uUmowa.Visibility = Visibility.Collapsed;
        }

        private void WprowadzNowaCenaNettoBTN_Click(object sender, RoutedEventArgs e)
        {
            var praco = listaKontener.FirstOrDefault<klasaKontener>(d => d.ko_id == Convert.ToInt16(r_kontenerID));
            if (praco != null) { praco.ko_cenanetto = poleNowaCenaNetto.Text; }

            poleNowaCenaNetto.Visibility = Visibility.Collapsed;
            wprowadzNowaCenaNettoBTN.Visibility = Visibility.Collapsed;

            odswiezPokaz();
        }

        private void BlsNowaCena_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button button = sender as System.Windows.Controls.Button;
            klasaKontener cust = button.DataContext as klasaKontener;

            int x = cust.ko_id;

            r_kontenerID = x.ToString();
            poleNowaCenaNetto.Visibility = Visibility.Visible;
            wprowadzNowaCenaNettoBTN.Visibility = Visibility.Visible;
            poleNowaCenaNetto.Clear();

        }

        private void BlsNoweWlasciwosci_Click(object sender, RoutedEventArgs e)
        {

            System.Windows.Controls.Button button = sender as System.Windows.Controls.Button;
            klasaDodatki dod = button.DataContext as klasaDodatki;

            int x = dod.did;
            r_dodatekID = x.ToString();
            poleListaNowaCena.Visibility = Visibility.Visible;
            poleListaNowaIlosc.Visibility = Visibility.Visible;
            wprowadzNoweWlasciwosci.Visibility = Visibility.Visible;
        }

        private void WprowadzNoweWlasciwosci_Click(object sender, RoutedEventArgs e)
        {
            var temp1 = listaDodatki.FirstOrDefault<klasaDodatki>(d => d.did == Convert.ToInt16(r_dodatekID));
            if (temp1 != null) {
             //   temp1.dcenadodatku = Convert.ToDouble(przecinekNaKropke(poleListaNowaCena.Text));
                if (!string.IsNullOrEmpty(poleListaNowaCena.Text))
                {
                    temp1.dcenadodatku = Convert.ToDouble(poleListaNowaCena.Text);

                }
                else temp1.dcenadodatku = 0;

                Console.WriteLine("Wprowadzone cena: " + temp1.dcenadodatku);

                if (!string.IsNullOrEmpty(poleListaNowaIlosc.Text))
                {
                    temp1.diloscdodatku = Convert.ToInt16(poleListaNowaIlosc.Text);

                }
                else temp1.diloscdodatku = 0;
                Console.WriteLine("Wprowadzone ilosc: " + temp1.diloscdodatku);
            }

            poleListaNowaCena.Text = "";
            poleListaNowaIlosc.Text = "0";
            poleListaNowaCena.Visibility = Visibility.Collapsed;
            poleListaNowaIlosc.Visibility = Visibility.Collapsed;
            wprowadzNoweWlasciwosci.Visibility = Visibility.Collapsed;

            odswiezPokazDodatki();

        }
    }
}
