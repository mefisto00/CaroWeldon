using System;
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



namespace CaroSYSTEM2809
{
    /// <summary>
    /// Logika interakcji dla klasy oknoNowaUmowa.xaml
    /// </summary>
    public partial class oknoNowaUmowa : Window
    {
        private int idKlient;
        private int idUmowy;

        private  string knazwa;
        private string kadres;
        private string kkontakt;
        private string knip;
        private double razem;
        private string xsciezka;
        private string r_kontenerID;
        private string r_dodatekID;

        //  public static string s_login;


        private DateTime theDate;
        private string cenaMeble;
        private string kosztMeble;
        private string cenaTranDoc;
        private string kosztTranDoc;
        private string cenaTranPowr;
        private string kosztTranPowr;
        private string cenaPodestySchody;
        private string kosztPodestySchody;
        private string cenaMontaz;
        private string kosztMontaz;
        private string cenaDemontaz;
        private string kosztDemontaz;
        private string cenaMycia;
        private string kosztMycia;
        private string cenaDodatkowa;
        private string kosztDodatkowy;
        private string kaucja;
        private string cenaTransDocSchPod;
        private string kosztTransDocSchPod;
        private string cenaTransPowSchPod;
        private string miejsceWynajmu;
        private string miejsceZwrotuKontenera;


        private string kosztTransPowSchPod;
        private string cenaMontazPodest;
        private string kosztMontazPodest;
        private string cenaMontazSchodow;
        private string kosztMontazSchodow;


        private string poziomowanie;
        private string cenaDemontazSchodow;
        private string kosztDemontazSchodow;
        private string cenaDemontazPodestow;
        private string kosztDemontazPodestow;
        private string fakturowanie;
        private string terminPlatnosci;


        private string cenaPraceDodatkowe;
        private string rozpiecie;


        private string nrUmowy;
        private string  dataRozpUm;
        private string dataZakUm;
        private bool czyAneks;
        private string numerUmowyAneksu;
        private string login;
        private string dataPodpisaniaUmowy;
        private string osobaDecyzyjna;
        private string uwagi;

        public int temp_id;
        public string temp_numercaro;
        public string temp_numerweldon;
        public string temp_amortyzacjakontenera;
        public string temp_cenanetto;
        public string temp_typkontenera;
        public string temp_czyklimatyzowany;
        public string temp_czywynajety;
        public string temp_podstawowewyposazeniekontenera;
        public string temp_dodatkowewyposazeniekontenera;
        public string temp_lokalizacja;
        public string temp_cenaminimalna;
        public string temp_datazakupukontenera;
        public string temp_datakoncaamortyzacji;
        public string temp_notatka;
        


        private Kontener kontener;

        public  Kontener Kontener
        {
            get { return kontener; }

            private set { kontener = value; }

        }

        public string Uwagi
        {
            get { return uwagi; }

            private set { uwagi = poleUwagi.Text; }


        }

        public string TerminPlatnosci
        {
            get { return terminPlatnosci; }

            private set { terminPlatnosci = poleTerminPlatnosci.SelectedValue.ToString(); }

        }
        public string Fakturowanie
        {
            get { return fakturowanie; }

            private set { fakturowanie = poleFakturowanie.SelectedValue.ToString(); }

        }


        public string MiejsceZwrotuKontenera
        {
            get { return miejsceZwrotuKontenera; }

            private set { miejsceZwrotuKontenera = poleMiejsceZwrotuKontenera.SelectedValue.ToString(); }

        }



        public string Rozpiecie
        {
            get { return rozpiecie; }

            private set { rozpiecie = poleRozpiecie.Text; }

        }



        public string MiejsceWynajmu
        {
            get { return miejsceWynajmu; }

            private set { miejsceWynajmu = poleMiejsceWynajmu.Text; }


        }

        public string OsobaDecyzyjna
        {
            get { return osobaDecyzyjna; }

            private set { osobaDecyzyjna = poleOsobaDecyzyjna.Text; }

        }

        public string  Knazwa
        {
            get { return knazwa; }

            private set { knazwa  = value; }

        }
        public string DataPodpisaniaUmowy
        {
            get { return dataPodpisaniaUmowy; }

            private set { dataPodpisaniaUmowy = poleDataPodpisaniaUmowy.Text; }

        }


        public string Kadres
        {
            get { return kadres; }

            private set { kadres = value; }

        }

        public string KKontakt
        {
            get { return kkontakt; }

            private set { kkontakt = value; }

        }

        
        
        
        

        public string Knip
        {
            get { return knip; }

            private set { knip = value; }

        }
        public double Razem
        {
            get { return razem; }

            private set { razem = 0; }

        }

        public string Xsciezka
        {
            get { return xsciezka; }

            private set { xsciezka = value; }

        }

        public string R_kontenerID
        {
            get { return r_kontenerID; }

            private set { r_kontenerID = value; }

        }

        public string R_dodatekID
        {
            get { return r_dodatekID; }

            private set { r_dodatekID = value; }

        }


        
        public DateTime TheDate
        {
            get { return theDate; }

            private set { theDate = value; }

        }

        public int IdKlient 
        {
            get { return idKlient; }

            private set { idKlient = value; }

        }

        public int IdUmowy
        {
            get { return idUmowy; }

            private set { idUmowy = value; }

        }





        public string NrUmowy
        {
            get { return nrUmowy; }

            private set { nrUmowy = poleNrUmowy.Text; }

        }


        public bool CzyAneks
        {
            get { return czyAneks; }

            private set { czyAneks = (bool)poleCzyAneks.IsChecked; }

        }
        public string NumerUmowyAneksu
        {
            get { return numerUmowyAneksu; }

            private set { numerUmowyAneksu = poleNumerUmowyAneksu.Text; }

        }
        public string  DataRozpUm
        {
            get { return dataRozpUm; }

            private set { dataRozpUm = poleDataRozpUm.Text; }

        }

        public string DataZakUm
        {
            get { return dataZakUm; }

            private set { dataZakUm = poleDataZakUm.Text; }

        }

        public string CenaMeble
        {
            get { return cenaMeble; }

            private set { cenaMeble = poleCenaMeble.Text; }

        }



        public string KosztMeble
        {
            get { return kosztMeble; }

            private set { kosztMeble = poleKosztMeble.Text; }

        }

        public string CenaTranDoc
        {
            get { return cenaTranDoc; }

            private set { cenaTranDoc = poleCenaTranDoc.Text; }

        }

        public string KosztTranDoc
        {
            get { return kosztTranDoc; }

            private set { kosztTranDoc = poleKosztTranDoc.Text; }

        }

        public string CenaTranPowr
        {
            get { return cenaTranPowr; }

            private set { cenaTranPowr = poleCenaTranPowr.Text; }

        }

        public string KosztTranPowr
        {
            get { return kosztTranPowr; }

            private set { kosztTranPowr = poleKosztTranPowr.Text; }

        }

        public string CenaPodestySchody
        {
            get { return cenaPodestySchody; }

            private set { cenaPodestySchody = poleCenaPodestySchody.Text; }

        }


        public string KosztPodestySchody
        {
            get { return kosztPodestySchody; }

            private set { kosztPodestySchody = poleKosztPodestySchody.Text; }

        }

        public string CenaMontaz
        {
            get { return cenaMontaz; }

            private set { cenaMontaz = poleCenaMontaz.Text; }

        }


        public string KosztMontaz
        {
            get { return kosztMontaz; }

            private set { kosztMontaz = poleKosztMontaz.Text; }

        }

        public string CenaDemontaz
        {
            get { return cenaDemontaz; }

            private set { cenaDemontaz = poleCenaDemontaz.Text; }

        }

        public string KosztDemontaz
        {
            get { return kosztDemontaz; }

            private set { kosztDemontaz = poleKosztDemontaz.Text; }

        }


        public string CenaMycia
        {
            get { return cenaMycia; }

            private set { cenaMycia = poleCenaMycia.Text; }

        }

        public string KosztMycia
        {
            get { return kosztMycia; }

            private set { kosztMycia = poleKosztMycia.Text; }

        }

        public string CenaDodatkowa
        {
            get { return cenaDodatkowa; }

            private set { cenaDodatkowa = poleCenaDodatkowa.Text; }

        }

        public string KosztDodatkowy
        {
            get { return kosztDodatkowy; }

            private set { kosztDodatkowy = poleKosztDodatkowy.Text; }

        }

        public string Kaucja
        {
            get { return kaucja; }

            private set { kaucja = poleKaucja.Text; }

        }

        public string CenaTransDocSchPod
        {
            get { return cenaTransDocSchPod; }

            private set { cenaTransDocSchPod = poleCenaTransDocSchPod.Text; }

        }

        public string KosztTransDocSchPod
        {
            get { return kosztTransDocSchPod; }

            private set { kosztTransDocSchPod = poleKosztTransDocSchPod.Text; }

        }

        public string CenaTransPowSchPod
        {
            get { return cenaTransPowSchPod; }

            private set { cenaTransPowSchPod = poleCenaTransPowSchPod.Text; }

        }

        public string KosztTransPowSchPod
        {
            get { return kosztTransPowSchPod; }

            private set { kosztTransPowSchPod = poleKosztTransPowSchPod.Text; }

        }

        public string CenaMontazPodest
        {
            get { return cenaMontazPodest; }

            private set { cenaMontazPodest = poleCenaMontazPodest.Text; }


        }
        public string KosztMontazPodest
        {
            get { return kosztMontazPodest; }

            private set { kosztMontazPodest = poleKosztMontazPodest.Text; }

        }



        public string CenaMontazSchodow
        {
            get { return cenaMontazSchodow; }

            private set { cenaMontazSchodow = poleCenaMontazSchodow.Text; }

        }

        public string KosztMontazSchodow
        {
            get { return kosztMontazSchodow; }

            private set { kosztMontazSchodow = poleKosztMontazSchodow.Text; }

        }

        public string Poziomowanie
        {
            get { return poziomowanie; }

            private set { poziomowanie = polePoziomowanie.Text; }

        }


        public string CenaDemontazSchodow
        {
            get { return cenaDemontazSchodow; }

            private set { cenaDemontazSchodow = poleCenaDemontazSchodow.Text; }

        }

        public string KosztDemontazSchodow
        {
            get { return kosztDemontazSchodow; }

            private set { kosztDemontazSchodow = poleKosztDemontazSchodow.Text; }

        }

        public string CenaDemontazPodestow
        {
            get { return cenaDemontazPodestow; }

            private set { cenaDemontazPodestow = poleCenaDemontazPodestow.Text; }

        }
        public string KosztDemontazPodestow
        {
            get { return kosztDemontazPodestow; }

            private set { kosztDemontazPodestow = poleKosztDemontazPodestow.Text; }

        }

        public string CenaPraceDodatkowe
        {
            get { return cenaPraceDodatkowe; }

            private set { cenaPraceDodatkowe = poleCenaPraceDodatkowe.Text; }

        }

        public System.Windows.Controls.DataGrid DgKlient
        {
            get { return dgKlient; }
            set { dgKlient = value; }

        }


        List<Kontener> listaKontener = new List<Kontener>();
        List<Dodatki> listaDodatki = new List<Dodatki>();
        List<Wyposazenie> listaWyposazenie = new List<Wyposazenie>();



        public oknoNowaUmowa()
        {
            InitializeComponent();
            MenadzerKlientDB menadzer = new MenadzerKlientDB(dgKlient);
            // menadzer.DgKlient = dgKlient;    

            //  uHome.Visibility = Visibility.Visible;
            //  uKontenery.Visibility = Visibility.Collapsed;
            //  uUmowa.Visibility = Visibility.Collapsed;
            //   grid_klient = grid_klient;
            //  poleNowaCenaNetto.Visibility = Visibility.Collapsed;
            //  wprowadzNowaCenaNettoBTN.Visibility = Visibility.Collapsed;

        }

        public oknoNowaUmowa(string login)
        {
            InitializeComponent();
            this.login = login;
            MenadzerKlientDB menadzer = new MenadzerKlientDB(dgKlient);
            //    menadzer.DgKlient = dgKlient;
            //    uHome.Visibility = Visibility.Visible;
            //    uKontenery.Visibility = Visibility.Collapsed;
            //   uUmowa.Visibility = Visibility.Collapsed;
            //  grid_klient    = grid_klient;

            //   poleNowaCenaNetto.Visibility = Visibility.Collapsed;
            //   wprowadzNowaCenaNettoBTN.Visibility = Visibility.Collapsed;

            listaDodatki.Add(new Dodatki(1, "schodnia", 0, 0));
            listaDodatki.Add(new Dodatki(2, "podest duży", 0, 0));
            listaDodatki.Add(new Dodatki(3, "podest mały", 0, 0));
            listaDodatki.Add(new Dodatki(4, "klimatyzacja", 0, 0));

            listaDodatki.Add(new Dodatki(5, "krzesło sosnowe", 10, 0));
            listaDodatki.Add(new Dodatki(6, "stół sosnowy 118x78 cm", 20, 0));

            listaDodatki.Add(new Dodatki(7, "regał na segregatory otwarty", 20, 0));

            listaDodatki.Add(new Dodatki(8, "szafka na dokumenty, zamykana wysoka", 30, 0));

            listaDodatki.Add(new Dodatki(9, "wieszak na ubrania stojący", 10, 0));

            listaDodatki.Add(new Dodatki(10, "biurko", 20, 0));

            listaDodatki.Add(new Dodatki(11, "krzeslo biurowe obrotowe", 20, 0));

            listaDodatki.Add(new Dodatki(12, "szafka BHP podwójna", 25, 0));

            listaDodatki.Add(new Dodatki(13, "klimatyzacja", 100, 0));



                odswiezPokazDodatki();

            //   poleListaNowaIlosc.Visibility = Visibility.Collapsed;
            //   poleListaNowaCena.Visibility = Visibility.Collapsed;
        }

        private void BWybranoKlient_Click(object sender, RoutedEventArgs e)
        {
            uHome.Visibility = Visibility.Collapsed;
            uKontenery.Visibility = Visibility.Visible;
            uUmowa.Visibility = Visibility.Collapsed;

            if (dgKlient.SelectedIndex != -1)
            {
                DataRowView row = (DataRowView)dgKlient.SelectedItems[0];
                idKlient = Convert.ToInt32(row[0].ToString());
                MenadzerKlientDB menadzer = new MenadzerKlientDB(dgKlient);


            }
            else
            {

                int idKlient = 999999;
                MenadzerKlientDB menadzer = new MenadzerKlientDB(idKlient);
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

            var dodajUmowe = new MenadzerUtworzNowaUmoweDB();
            var objgeneratorPDF = new GeneratorPDF();
            MenadzerKlientDB menadzerKlientDB = new MenadzerKlientDB(dgKlient);
          

            var listaKontener2 = new List<Kontener>();




            listaKontener2 =  dodajUmowe.utworzNowaUmowe(listaKontener, cenaMeble, kosztMeble, cenaTranDoc,
            kosztTranDoc, cenaTranPowr, kosztTranPowr, cenaPodestySchody, kosztPodestySchody, cenaMontaz, kosztMontaz,
            cenaDemontaz, kosztDemontaz, cenaMycia, kosztMycia, cenaDodatkowa, kosztDodatkowy, kaucja, cenaTransDocSchPod, kosztTransDocSchPod, cenaTransPowSchPod, kosztTransPowSchPod, cenaMontazPodest, kosztMontazPodest, cenaMontazSchodow, kosztMontazSchodow,
            poziomowanie, cenaDemontazSchodow, kosztDemontazSchodow, cenaDemontazPodestow, kosztDemontazPodestow,
            cenaPraceDodatkowe, nrUmowy, dataRozpUm, dataZakUm, czyAneks, numerUmowyAneksu, login, idKlient, IdUmowy,terminPlatnosci,fakturowanie,uwagi,miejsceWynajmu,MiejsceZwrotuKontenera,osobaDecyzyjna,idKlient);

             objgeneratorPDF.generatorPDF(nrUmowy,dataRozpUm,dataZakUm, idKlient,idUmowy,knazwa,kadres, kkontakt, knip, razem ,  xsciezka, r_kontenerID ,  r_dodatekID, dataPodpisaniaUmowy, osobaDecyzyjna, cenaTranDoc, miejsceWynajmu, cenaTranPowr , cenaMycia, cenaTransDocSchPod, cenaTransPowSchPod, cenaMontaz , cenaDemontaz, rozpiecie, cenaMontazSchodow , cenaDemontazSchodow , cenaMontazPodest , cenaDemontazPodestow , cenaPraceDodatkowe, poziomowanie , miejsceZwrotuKontenera, theDate, kaucja ,
                 fakturowanie, terminPlatnosci, listaKontener2, listaDodatki );

            menadzerKlientDB.pobierzListeKontenerow(listaKontener: listaKontener2, idUmowy: idUmowy, idKlient: idKlient);

        }
        private void DodajDoZestawieniaBTN_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = (DataRowView)dgKontener.SelectedItems[0];
            string idWybrKont = row[0].ToString();

            try
            {
                MySqlConnection conn2 = PolaczenieDB.polaczenieZBazaDanych();
                string stm2 = "SELECT VERSION()";
                MySqlCommand cmdlog = new MySqlCommand(stm2, conn2);
                cmdlog.Connection = conn2;
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


                    listaKontener.Add(new Kontener(temp_id, temp_numercaro, temp_numerweldon, temp_amortyzacjakontenera, temp_cenanetto, temp_typkontenera, temp_czyklimatyzowany, temp_czywynajety, temp_podstawowewyposazeniekontenera, temp_dodatkowewyposazeniekontenera, temp_lokalizacja, temp_cenaminimalna, temp_datazakupukontenera, temp_datakoncaamortyzacji, temp_notatka));
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

          

            System.Windows.Controls.Button button = sender as System.Windows.Controls.Button;
            Kontener kont = button.DataContext as Kontener;
            int a = kont.Ko_Id;
            string hkontId = a.ToString();
            //  System.Windows.MessageBox.Show(hkontId);

            var kon = listaKontener.FirstOrDefault<Kontener>(d => d.Ko_Id == Convert.ToInt16(hkontId));
            listaKontener.RemoveAll(x => x.Ko_Id == Convert.ToInt16(hkontId));
            odswiezPokaz();


          

        }

       public  void odswiezPokaz()
        {
            var source = new BindingSource();
            ObservableCollection<Kontener> collection = new ObservableCollection<Kontener>(listaKontener);
            source.DataSource = collection;
            lsWybrane.ItemsSource = source;
            lsWybrane2.ItemsSource = source;
            if (collection.Count != 0)
            {
                Console.WriteLine(collection[0].Ko_Numercaro.ToString());
                Console.WriteLine("-------------------");
                var test2 = collection.ToList();
                foreach (var item in test2)
                {
                    Console.WriteLine(item.Ko_Id);
                }
            }
            else System.Windows.MessageBox.Show("Umowa musi zawierać przynajmniej jeden kontener!");

        }




        public void odswiezPokazDodatki()
        {
            var source1 = new BindingSource();
            ObservableCollection<Dodatki> collection = new ObservableCollection<Dodatki>(listaDodatki);
            source1.DataSource = collection;
            lsDodatki.ItemsSource = source1;

        }

        public string przecinekNaKropke(string wejscie)
        {
            string temp = wejscie.Replace(',', '.');
            return temp;
        }

        private void SzukajNowaUmowaKlientBTN_Click(object sender, RoutedEventArgs e)
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
           // string sciezka = "baza.config";
           // string konfiguracja = File.ReadAllText(sciezka);
            try
            {

                MySqlConnection conn = PolaczenieDB.polaczenieZBazaDanych();
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
            var menadzerKlientDB = new MenadzerKlientDB(dgKlient);
           
            poleKontenerSzukaj.Text = "";
        }

        private void ResetSzukajNowaUmowaKlientBTN_Click(object sender, RoutedEventArgs e)
        {
            MenadzerKlientDB menadzer = new MenadzerKlientDB(dgKlient);


            poleKlientSzukaj.Text = "";
        }

        private void PoleKlientSzukaj_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
              //  string sciezka = "baza.config";
              //  string konfiguracja = File.ReadAllText(sciezka);
                try
                {

                    MySqlConnection conn = PolaczenieDB.polaczenieZBazaDanych();
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
             //   string sciezka = "baza.config";
             //   string konfiguracja = File.ReadAllText(sciezka);
                try
                {

                    MySqlConnection conn = PolaczenieDB.polaczenieZBazaDanych();
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
            var praco = listaKontener.FirstOrDefault<Kontener>(d => d.Ko_Id == Convert.ToInt16(r_kontenerID));
            if (praco != null) { praco.Ko_Cenanetto = poleNowaCenaNetto.Text; }

            poleNowaCenaNetto.Visibility = Visibility.Collapsed;
            wprowadzNowaCenaNettoBTN.Visibility = Visibility.Collapsed;

            odswiezPokaz();
        }

        private void BlsNowaCena_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button button = sender as System.Windows.Controls.Button;
            Kontener cust = button.DataContext as Kontener;

            int x = cust.Ko_Id;

            r_kontenerID = x.ToString();
            poleNowaCenaNetto.Visibility = Visibility.Visible;
            wprowadzNowaCenaNettoBTN.Visibility = Visibility.Visible;
            poleNowaCenaNetto.Clear();

        }

        private void BlsNoweWlasciwosci_Click(object sender, RoutedEventArgs e)
        {

            System.Windows.Controls.Button button = sender as System.Windows.Controls.Button;
            Dodatki dod = button.DataContext as Dodatki;

            int x = dod.DId;
            r_dodatekID = x.ToString();
            poleListaNowaCena.Visibility = Visibility.Visible;
            poleListaNowaIlosc.Visibility = Visibility.Visible;
            wprowadzNoweWlasciwosci.Visibility = Visibility.Visible;
        }

        private void WprowadzNoweWlasciwosci_Click(object sender, RoutedEventArgs e)
        {
            var temp1 = listaDodatki.FirstOrDefault<Dodatki>(d => d.DId == Convert.ToInt16(r_dodatekID));
            if (temp1 != null) {
                //   temp1.dcenadodatku = Convert.ToDouble(przecinekNaKropke(poleListaNowaCena.Text));
                if (!string.IsNullOrEmpty(poleListaNowaCena.Text))
                {
                    temp1.DCenadodatku = Convert.ToDouble(poleListaNowaCena.Text);

                }
                else temp1.DCenadodatku = 0;

                Console.WriteLine("Wprowadzone cena: " + temp1.DCenadodatku);

                if (!string.IsNullOrEmpty(poleListaNowaIlosc.Text))
                {
                    temp1.DIloscdodatku = Convert.ToInt16(poleListaNowaIlosc.Text);

                }
                else temp1.DIloscdodatku = 0;
                Console.WriteLine("Wprowadzone ilosc: " + temp1.DIloscdodatku);
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
