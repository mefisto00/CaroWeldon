using System;
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
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using System.IO;

namespace CaroSYSTEM2809
{
    /// <summary>
    /// Logika interakcji dla klasy eOknoKontener.xaml
    /// </summary>
    public partial class eOknoKontener : Window
    {
        public eOknoKontener()
        {
            InitializeComponent();
        }
               
      
        public eOknoKontener(string idWybranegoKont, string ncar, string nwel, string amo, string cenanet, string typkon, string czyklima, string podwyp, string dodwyp, string lok, string cenamin, string datazak, string datakon, string not, string czywynaj)
        {

            InitializeComponent();
            id = Convert.ToInt32(idWybranegoKont);
            e_poleNumerCaro.Text = ncar;
            e_poleNumerWeldon.Text = nwel;
            e_poleAmortyzacjaKontenera.Text = amo;
            e_poleCenaNetto.Text = cenanet;
            e_poleTypKontenera.Text = typkon;
            e_polePodstawoweWyposazenieKontenera.Text = podwyp;
            e_poleDodatkoweWyposazenieKontenera.Text = dodwyp;
            //  Console.WriteLine("\n \n === "+ Convert.ToBoolean(Convert.ToInt32(czywynaj)));
            bool bVal = Convert.ToBoolean(Convert.ToInt16(czyklima));
            Console.WriteLine("Wartość liczbowa " + bVal);
            e_czyKlimatyzowany.IsChecked = bVal;
            e_poleLokalizacja.Text = lok;
            e_poleCenaMinimalna.Text = cenamin;
            e_poleDataZakupuKontenera.Text = datazak;
            e_poleDataKoniecAmo.Text = datakon;
            e_poleNotatka.Text = not;
            e_czyWynajety.IsChecked = Convert.ToBoolean(Convert.ToInt16(czywynaj));
        }

        public int id;

        private void DodajDoBazyKontener_Click(object sender, RoutedEventArgs e)
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
                cmdlog.CommandText = "INSERT INTO kontener (nrCaro, nrWeldon, amortyzacja, cenaNetto, typKontenera, czyKlimatyzowany, podstWyposazenie, dodatWyposazenie, lokalizacja, cenaMinimalna, dataZakupu, dataKoncaAmo, notatka, czyWynajety)" +
                    "VALUES(@nrCaro, @nrWeldon, @amortyzacja, @cenaNetto, @typKontenera, @czyKlimatyzowany, @podstWyposazenie, @dodatWyposazenie, @lokalizacja, @cenaMinimalna, @dataZakupu, @dataKoncaAmo, @notatka, @czyWynajety)";
                    cmdlog.Prepare();

                if (!string.IsNullOrEmpty(e_poleNumerCaro.Text))
                {
                    cmdlog.Parameters.AddWithValue("@nrCaro", e_poleNumerCaro.Text);
                }
                else
                {
                    cmdlog.Parameters.AddWithValue("@nrCaro", DBNull.Value);

                }

                if (!string.IsNullOrEmpty(e_poleNumerWeldon.Text))
                {
                    cmdlog.Parameters.AddWithValue("@nrWeldon", e_poleNumerWeldon.Text);
                }
                else
                {
                    cmdlog.Parameters.AddWithValue("@nrWeldon", DBNull.Value);
                }

                if (!string.IsNullOrEmpty(e_poleAmortyzacjaKontenera.Text))
                {
                    cmdlog.Parameters.AddWithValue("@amortyzacja", przecinekNaKropke(e_poleAmortyzacjaKontenera.Text));
                }
                else
                {
                    cmdlog.Parameters.AddWithValue("@amortyzacja", 0);

                }


                if (!string.IsNullOrEmpty(e_poleCenaNetto.Text))
                {
                    cmdlog.Parameters.AddWithValue("@cenaNetto", przecinekNaKropke(e_poleCenaNetto.Text));

                }
                else
                {
                    cmdlog.Parameters.AddWithValue("@cenaNetto", 0);

                }


                if (!string.IsNullOrEmpty(e_czyKlimatyzowany.IsChecked.ToString()))
                {
                    cmdlog.Parameters.AddWithValue("@czyKlimatyzowany", Convert.ToInt16(e_czyKlimatyzowany.IsChecked.ToString()));
                }
                else
                {
                    cmdlog.Parameters.AddWithValue("@czyKlimatyzowany", e_czyKlimatyzowany.IsChecked = false);
                }


                if (!string.IsNullOrEmpty(e_polePodstawoweWyposazenieKontenera.Text))
                {
                    cmdlog.Parameters.AddWithValue("@podstWyposazenie", e_polePodstawoweWyposazenieKontenera.Text);
                }
                else
                {
                    cmdlog.Parameters.AddWithValue("@podstWyposazenie", DBNull.Value);
                }


                if (!string.IsNullOrEmpty(e_poleDodatkoweWyposazenieKontenera.Text))
                {
                    cmdlog.Parameters.AddWithValue("@dodatWyposazenie", e_poleDodatkoweWyposazenieKontenera.Text);
                }
                else
                {
                    cmdlog.Parameters.AddWithValue("@dodatWyposazenie", DBNull.Value);
                }


                if (!string.IsNullOrEmpty(e_poleLokalizacja.Text))
                {
                    cmdlog.Parameters.AddWithValue("@lokalizacja", e_poleLokalizacja.Text);
                }
                else
                {
                    cmdlog.Parameters.AddWithValue("@lokalizacja", DBNull.Value);
                }


                if (!string.IsNullOrEmpty(e_poleCenaMinimalna.Text))
                {
                    cmdlog.Parameters.AddWithValue("@cenaMinimalna", przecinekNaKropke(e_poleCenaMinimalna.Text));
                }
                else
                {
                    cmdlog.Parameters.AddWithValue("@cenaMinimalna", 0);
                }




                if(!string.IsNullOrEmpty(e_poleDataZakupuKontenera.Text))
                {
                    cmdlog.Parameters.AddWithValue("@dataZakupu", e_poleDataZakupuKontenera.SelectedDate.ToString());

                }
                else
                {
                    cmdlog.Parameters.AddWithValue("@dataZakupu", DBNull.Value);
                }



                if (!string.IsNullOrEmpty(e_poleDataKoniecAmo.Text))
                {
                    cmdlog.Parameters.AddWithValue("@dataKoncaAmo", e_poleDataKoniecAmo.SelectedDate.ToString());

                }
                else
                {
                    cmdlog.Parameters.AddWithValue("@dataKoncaAmo", DBNull.Value);
                }



                if (!string.IsNullOrEmpty(e_poleNotatka.Text))
                {
                    cmdlog.Parameters.AddWithValue("@notatka", e_poleNotatka.Text);
                }
                else
                {
                    cmdlog.Parameters.AddWithValue("@notatka", DBNull.Value);
                }



                if (!string.IsNullOrEmpty(e_czyWynajety.IsChecked.ToString()))
                {
                    cmdlog.Parameters.AddWithValue("@czyWynajety", Convert.ToInt16(e_czyWynajety.IsChecked.ToString()));
                
                }
                else
                {
                    cmdlog.Parameters.AddWithValue("@czyWynajety", Convert.ToInt16(e_czyWynajety.IsChecked = false));
                }

               


                //cmdlog.Parameters.AddWithValue("@nrWeldon", Convert.ToInt32(e_poleNumerWeldon.Text));
                //cmdlog.Parameters.AddWithValue("@amortyzacja", przecinekNaKropke(e_poleAmortyzacjaKontenera.Text));
                //cmdlog.Parameters.AddWithValue("@cenaNetto", przecinekNaKropke(e_poleCenaNetto.Text));
                //cmdlog.Parameters.AddWithValue("@typKontenera", e_poleTypKontenera.Text);
                //cmdlog.Parameters.AddWithValue("@czyKlimatyzowany", Convert.ToInt32(e_czyKlimatyzowany.IsChecked));
                //cmdlog.Parameters.AddWithValue("@podstWyposazenie", e_polePodstawoweWyposazenieKontenera.Text);
                //cmdlog.Parameters.AddWithValue("@dodatWyposazenie", e_poleDodatkoweWyposazenieKontenera.Text);
                //cmdlog.Parameters.AddWithValue("@lokalizacja", e_poleOdzialMagazynowania.Text);
                //cmdlog.Parameters.AddWithValue("@cenaMinimalna", Convert.ToInt32(e_poleNumerCaro.Text));
                //cmdlog.Parameters.AddWithValue("@dataZakupu", e_poleDataZakupuKontenera.SelectedDate.ToString());
                //cmdlog.Parameters.AddWithValue("@dataKoncaAmo", e_poleDataKoniecAmo.SelectedDate.ToString());
                //cmdlog.Parameters.AddWithValue("@notatka", e_poleNotatka.Text);
                //cmdlog.Parameters.AddWithValue("@czyWynajety", Convert.ToInt32(e_czyKlimatyzowany.IsChecked));
              

                cmdlog.ExecuteNonQuery();

                MessageBox.Show("Pomyślnie dodano wpis do bazy");

            }
            catch (MySqlException se)
            {
                MessageBox.Show("Wystąpił błąd połączenia: " + se.ToString());
            }



        }

        private void ZerujFormularzKontener_Click(object sender, RoutedEventArgs e)
        {
            InitializeComponent();
           
            e_poleNumerCaro.Text = "";
            e_poleNumerWeldon.Text = "";
            e_poleAmortyzacjaKontenera.Text = "";
            e_poleCenaNetto.Text = "";
            e_poleTypKontenera.Text = "";
            e_polePodstawoweWyposazenieKontenera.Text = "";
            e_poleDodatkoweWyposazenieKontenera.Text = "";
            e_czyKlimatyzowany.IsChecked = false;
            e_poleLokalizacja.Text = "";
            e_poleCenaMinimalna.Text = "";
            e_poleDataZakupuKontenera.Text = "";
            e_poleDataKoniecAmo.Text = "";
            e_poleNotatka.Text = "";
            e_czyWynajety.IsChecked = false;

        }


        public string przecinekNaKropke(string wejscie)
        {
            string temp = wejscie.Replace(',', '.');
            return temp;
        }

        private void EdytujWpisKontener_Click(object sender, RoutedEventArgs e)
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
                cmdlog.Connection = conn;
                cmdlog.CommandText = "UPDATE kontener SET" +
                    " nrCaro=@nrCaro, " +
                    "nrWeldon=@nrWeldon, " +
                    "amortyzacja=@amortyzacja, " +
                    "cenaNetto=@cenaNetto, " +
                    "typKontenera=@typKontenera, " +
                    "czyKlimatyzowany=@czyKlimatyzowany, " +
                    "podstWyposazenie=@podstWyposazenie, " +
                    "dodatWyposazenie=@dodatWyposazenie, " +
                    "lokalizacja=@lokalizacja, " +
                    "cenaMinimalna=@cenaMinimalna, " +
                    "dataZakupu=@dataZakupu, " +
                    "dataKoncaAmo=@dataKoncaAmo," +
                    " notatka=@notatka, " +
                    "czyWynajety=@czyWynajety"+
                    " WHERE id=@id";
                                     


                cmdlog.Prepare();


                if (!string.IsNullOrEmpty(e_poleNumerCaro.Text))
                {
                    cmdlog.Parameters.AddWithValue("@nrCaro", e_poleNumerCaro.Text);
                }
                else
                {
                    cmdlog.Parameters.AddWithValue("@nrCaro", DBNull.Value);

                }

                if (!string.IsNullOrEmpty(e_poleNumerWeldon.Text))
                {
                    cmdlog.Parameters.AddWithValue("@nrWeldon", e_poleNumerWeldon.Text);
                }
                else
                {
                    cmdlog.Parameters.AddWithValue("@nrWeldon", DBNull.Value);
                }

                if (!string.IsNullOrEmpty(e_poleAmortyzacjaKontenera.Text))
                {
                    cmdlog.Parameters.AddWithValue("@amortyzacja", przecinekNaKropke(e_poleAmortyzacjaKontenera.Text));
                }
                else
                {
                    cmdlog.Parameters.AddWithValue("@amortyzacja", 0);

                }


                if (!string.IsNullOrEmpty(e_poleCenaNetto.Text))
                {
                    cmdlog.Parameters.AddWithValue("@cenaNetto", przecinekNaKropke(e_poleCenaNetto.Text));

                }
                else
                {
                    cmdlog.Parameters.AddWithValue("@cenaNetto", 0);

                }

            
                if (!string.IsNullOrEmpty(e_poleTypKontenera.Text))
                {
                    cmdlog.Parameters.AddWithValue("@typKontenera", e_poleTypKontenera.Text);

                }
                else
                {
                    cmdlog.Parameters.AddWithValue("@typKontenera", DBNull.Value);

                }


                if (!string.IsNullOrEmpty(e_czyKlimatyzowany.IsChecked.ToString()))
                {
                    //Console.WriteLine("Konwersja na int 16, zaznaczenia checkboxa na string " + Convert.ToInt16(e_czyKlimatyzowany.IsChecked.ToString()));
                    bool tempedit = Convert.ToBoolean(Convert.ToInt16(e_czyKlimatyzowany.IsChecked));
                    cmdlog.Parameters.AddWithValue("@czyKlimatyzowany", tempedit);
                }
                else
                {
                    cmdlog.Parameters.AddWithValue("@czyKlimatyzowany", e_czyKlimatyzowany.IsChecked = false);
                }


                if (!string.IsNullOrEmpty(e_polePodstawoweWyposazenieKontenera.Text))
                {
                    cmdlog.Parameters.AddWithValue("@podstWyposazenie", e_polePodstawoweWyposazenieKontenera.Text);
                }
                else
                {
                    cmdlog.Parameters.AddWithValue("@podstWyposazenie", DBNull.Value);
                }


                if (!string.IsNullOrEmpty(e_poleDodatkoweWyposazenieKontenera.Text))
                {
                    cmdlog.Parameters.AddWithValue("@dodatWyposazenie", e_poleDodatkoweWyposazenieKontenera.Text);
                }
                else
                {
                    cmdlog.Parameters.AddWithValue("@dodatWyposazenie", DBNull.Value);
                }


                if (!string.IsNullOrEmpty(e_poleLokalizacja.Text))
                {
                    cmdlog.Parameters.AddWithValue("@lokalizacja", e_poleLokalizacja.Text);
                }
                else
                {
                    cmdlog.Parameters.AddWithValue("@lokalizacja", DBNull.Value);
                }


                if (!string.IsNullOrEmpty(e_poleCenaMinimalna.Text))
                {
                    cmdlog.Parameters.AddWithValue("@cenaMinimalna", przecinekNaKropke(e_poleCenaMinimalna.Text));
                }
                else
                {
                    cmdlog.Parameters.AddWithValue("@cenaMinimalna", 0);
                }




                if (!string.IsNullOrEmpty(e_poleDataZakupuKontenera.Text))
                {
                    cmdlog.Parameters.AddWithValue("@dataZakupu", e_poleDataZakupuKontenera.SelectedDate.ToString());

                }
                else
                {
                    cmdlog.Parameters.AddWithValue("@dataZakupu", DBNull.Value);
                }



                if (!string.IsNullOrEmpty(e_poleDataKoniecAmo.Text))
                {
                    cmdlog.Parameters.AddWithValue("@dataKoncaAmo", e_poleDataKoniecAmo.SelectedDate.ToString());

                }
                else
                {
                    cmdlog.Parameters.AddWithValue("@dataKoncaAmo", DBNull.Value);
                }



                if (!string.IsNullOrEmpty(e_poleNotatka.Text))
                {
                    cmdlog.Parameters.AddWithValue("@notatka", e_poleNotatka.Text);
                }
                else
                {
                    cmdlog.Parameters.AddWithValue("@notatka", DBNull.Value);
                }



                if (!string.IsNullOrEmpty(e_czyWynajety.IsChecked.ToString()))
                {
                    bool tempedit2 = Convert.ToBoolean(Convert.ToInt16(e_czyWynajety.IsChecked));
                    cmdlog.Parameters.AddWithValue("@czyWynajety", tempedit2);
                    
                }
                else
                {
                    cmdlog.Parameters.AddWithValue("@czyWynajety", Convert.ToInt16(e_czyWynajety.IsChecked = false));
                }




                //cmdlog.Parameters.AddWithValue("@nrCaro", e_poleNumerCaro.Text);
                //cmdlog.Parameters.AddWithValue("@nrWeldon", e_poleNumerWeldon.Text);
                //cmdlog.Parameters.AddWithValue("@amortyzacja", przecinekNaKropke(e_poleAmortyzacjaKontenera.Text));
                //cmdlog.Parameters.AddWithValue("@cenaNetto", przecinekNaKropke(e_poleCenaNetto.Text));
                //cmdlog.Parameters.AddWithValue("@typKontenera", e_poleTypKontenera.Text);
                //cmdlog.Parameters.AddWithValue("@czyKlimatyzowany", Convert.ToInt32(e_czyKlimatyzowany.IsChecked));
                //cmdlog.Parameters.AddWithValue("@podstWyposazenie", e_polePodstawoweWyposazenieKontenera.Text);
                //cmdlog.Parameters.AddWithValue("@dodatWyposazenie", e_poleDodatkoweWyposazenieKontenera.Text);
                //cmdlog.Parameters.AddWithValue("@lokalizacja", e_poleOdzialMagazynowania.Text);
                //cmdlog.Parameters.AddWithValue("@cenaMinimalna", przecinekNaKropke(e_poleCenaMinimalna.Text));
                //cmdlog.Parameters.AddWithValue("@dataZakupu", e_poleDataZakupuKontenera.SelectedDate.ToString());
                //cmdlog.Parameters.AddWithValue("@dataKoncaAmo", e_poleDataKoniecAmo.SelectedDate.ToString());
                //cmdlog.Parameters.AddWithValue("@notatka", e_poleNotatka.Text);
                //cmdlog.Parameters.AddWithValue("@czyWynajety", Convert.ToInt32(e_czyKlimatyzowany.IsChecked));

                cmdlog.Parameters.AddWithValue("@id", id);


                cmdlog.ExecuteNonQuery();

                MessageBox.Show("Pomyślnie uaktualniono wpis w bazie");
               

            }
            catch (MySqlException se)
            {
                MessageBox.Show("Wystąpił błąd połączenia: " + se.ToString());
            }

        }



        private void UsunKontener_Click(object sender, RoutedEventArgs e)
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
                cmdlog.CommandText = "DELETE FROM kontener WHERE kont_id=@id";
                cmdlog.Prepare();

                cmdlog.Parameters.AddWithValue("@id", Convert.ToInt32(id));
                cmdlog.ExecuteNonQuery();
                MessageBox.Show("Pomyślnie usunięto wpis z bazy");

            }
            catch (MySqlException se)
            {
                MessageBox.Show("Wystąpił błąd połączenia: " + se.ToString());
            }

        }
    }
}

