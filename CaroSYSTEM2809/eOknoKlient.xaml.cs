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
    /// Logika interakcji dla klasy eOknoKlient.xaml
    /// </summary>
    public partial class eOknoKlient : Window
    {
      
        public string idklienta;
        public eOknoKlient()
        {
            InitializeComponent();
        }

        public eOknoKlient(string id, string nazwa, string adres1, string telefon, string mail, string osoba, string ocena, string nip, string data, string notatka)
        {
            InitializeComponent();
            idklienta = id;
            e_poleNazwaKlienta.Text = nazwa;
            e_poleAdresKlienta.Text = adres1;            
            e_poletelefon.Text = telefon;
            e_poleMail.Text = mail;
            e_poleOsobaDecyzyjna.Text = osoba;
            e_poleOcenaKlienta.Text = ocena;
            e_poleNip.Text = nip;
            e_dataWazna.Text = data;
            e_poleNotatka.Text = notatka;

        }


        private void DodajDoBazyKlient_Click(object sender, RoutedEventArgs e)
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
                cmdlog.CommandText = "INSERT INTO klient (nazwa, adres, telefon, mail, osobaKontaktowa, ocena, nip, datawazna, notatka) " +
                    "VALUES(@nazwa, @adres, @telefon, @mail, @osoba, @ocena, @nip, @datawazna, @notatka)";

                cmdlog.Prepare();
                

                if(!string.IsNullOrEmpty(e_poleNazwaKlienta.Text))
                {
                    cmdlog.Parameters.AddWithValue("@nazwa", e_poleNazwaKlienta.Text);
                }
                else
                {
                    cmdlog.Parameters.AddWithValue("@nazwa", DBNull.Value);
                }


                if (!string.IsNullOrEmpty(e_poleAdresKlienta.Text))
                {
                    cmdlog.Parameters.AddWithValue("@adres", e_poleAdresKlienta.Text);
                }
                else
                {
                    cmdlog.Parameters.AddWithValue("@adres", DBNull.Value);
                }


                if (!string.IsNullOrEmpty(e_poletelefon.Text))
                {
                    cmdlog.Parameters.AddWithValue("@telefon", e_poletelefon.Text);
                }
                else
                {
                    cmdlog.Parameters.AddWithValue("@telefon", DBNull.Value);
                }


                if (!string.IsNullOrEmpty(e_poleMail.Text))
                {
                    cmdlog.Parameters.AddWithValue("@mail", e_poleMail.Text);
                }
                else
                {
                    cmdlog.Parameters.AddWithValue("@mail", DBNull.Value);
                }


                if (!string.IsNullOrEmpty(e_poleOsobaDecyzyjna.Text))
                {
                    cmdlog.Parameters.AddWithValue("@osoba", e_poleOsobaDecyzyjna.Text);
                }
                else
                {
                    cmdlog.Parameters.AddWithValue("@osoba", DBNull.Value);
                }


                if (!string.IsNullOrEmpty(e_poleOcenaKlienta.Text))
                {
                    cmdlog.Parameters.AddWithValue("@ocena", e_poleOcenaKlienta.Text);
                }
                else
                {
                    cmdlog.Parameters.AddWithValue("@ocena", DBNull.Value);
                }

                if (!string.IsNullOrEmpty(e_poleNip.Text))
                {
                    cmdlog.Parameters.AddWithValue("@nip", e_poleNip.Text);
                }
                else
                {
                    cmdlog.Parameters.AddWithValue("@nip", DBNull.Value);
                }

                if (!string.IsNullOrEmpty(e_dataWazna.Text))
                {
                    cmdlog.Parameters.AddWithValue("@datawazna", e_dataWazna.SelectedDate.ToString());
                }
                else
                {
                    cmdlog.Parameters.AddWithValue("@datawazna", DBNull.Value);
                }

                if(!string.IsNullOrEmpty(e_poleNotatka.Text))
                {
                    cmdlog.Parameters.AddWithValue("@notatka", e_poleNotatka.Text);
                }
                else
                {
                    cmdlog.Parameters.AddWithValue("@notatka", DBNull.Value);
                }



                //cmdlog.Parameters.AddWithValue("@nazwa", e_poleNazwaKlienta.Text);
                //cmdlog.Parameters.AddWithValue("@adres", e_poleAdresKlienta.Text);               
                //cmdlog.Parameters.AddWithValue("@telefon", e_poletelefon.Text);
                //cmdlog.Parameters.AddWithValue("@mail", e_poleMail.Text);
                //cmdlog.Parameters.AddWithValue("@osoba", e_poleOsobaDecyzyjna.Text);
                //cmdlog.Parameters.AddWithValue("@ocena", e_poleOcenaKlienta.Text);
                //cmdlog.Parameters.AddWithValue("@nip", e_poleNip.Text);
                ////   cmdlog.Parameters.AddWithValue("@datawazna", MySqlDbType.Date).Value = e_dataWazna.SelectedDate;
                //cmdlog.Parameters.AddWithValue("@datawazna", e_dataWazna.SelectedDate.ToString());
                //cmdlog.Parameters.AddWithValue("@notatka", e_poleNotatka.Text);


                cmdlog.ExecuteNonQuery();

                MessageBox.Show("Pomyślnie dodano wpis do bazy");
                this.Close();

            }
            catch (MySqlException se)
            {
                MessageBox.Show("Wystąpił błąd połączenia: " + se.ToString());
            }




        }



        private void ZerujFormularzKlient_Click(object sender, RoutedEventArgs e)
        {
            e_poleNazwaKlienta.Clear();          
            e_poleAdresKlienta.Clear();
            e_poleMail.Clear();
            e_poleNip.Clear();
            e_poletelefon.Clear();
            e_poleOsobaDecyzyjna.Clear();
            e_poleOcenaKlienta.Text = "";
            e_poleNotatka.Text = "";
            e_dataWazna.Text = "";


        }

        private void EdytujKlientBaza_Click(object sender, RoutedEventArgs e)
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
                cmdlog.CommandText = "UPDATE klient SET nazwa=@nazwa, " +
                    "adres=@adres, " +              
                    "telefon=@telefon, " +
                    "mail=@mail, " +
                    "osobaKontaktowa=@osoba, " +
                    "ocena=@ocena, " +
                    "nip=@nip," +
                    "datawazna=@datawazna, " +
                    "notatka=@notatka " +
                    "WHERE id=@id";

                cmdlog.Prepare();



                if (!string.IsNullOrEmpty(e_poleNazwaKlienta.Text))
                {
                    cmdlog.Parameters.AddWithValue("@nazwa", e_poleNazwaKlienta.Text);
                }
                else
                {
                    cmdlog.Parameters.AddWithValue("@nazwa", DBNull.Value);
                }


                if (!string.IsNullOrEmpty(e_poleAdresKlienta.Text))
                {
                    cmdlog.Parameters.AddWithValue("@adres", e_poleAdresKlienta.Text);
                }
                else
                {
                    cmdlog.Parameters.AddWithValue("@adres", DBNull.Value);
                }


                if (!string.IsNullOrEmpty(e_poletelefon.Text))
                {
                    cmdlog.Parameters.AddWithValue("@telefon", e_poletelefon.Text);
                }
                else
                {
                    cmdlog.Parameters.AddWithValue("@telefon", DBNull.Value);
                }


                if (!string.IsNullOrEmpty(e_poleMail.Text))
                {
                    cmdlog.Parameters.AddWithValue("@mail", e_poleMail.Text);
                }
                else
                {
                    cmdlog.Parameters.AddWithValue("@mail", DBNull.Value);
                }


                if (!string.IsNullOrEmpty(e_poleOsobaDecyzyjna.Text))
                {
                    cmdlog.Parameters.AddWithValue("@osoba", e_poleOsobaDecyzyjna.Text);
                }
                else
                {
                    cmdlog.Parameters.AddWithValue("@osoba", DBNull.Value);
                }


                if (!string.IsNullOrEmpty(e_poleOcenaKlienta.Text))
                {
                    cmdlog.Parameters.AddWithValue("@ocena", e_poleOcenaKlienta.Text);
                }
                else
                {
                    cmdlog.Parameters.AddWithValue("@ocena", DBNull.Value);
                }

                if (!string.IsNullOrEmpty(e_poleNip.Text))
                {
                    cmdlog.Parameters.AddWithValue("@nip", e_poleNip.Text);
                }
                else
                {
                    cmdlog.Parameters.AddWithValue("@nip", DBNull.Value);
                }

                if (!string.IsNullOrEmpty(e_dataWazna.Text))
                {
                    cmdlog.Parameters.AddWithValue("@datawazna", e_dataWazna.SelectedDate.ToString());
                }
                else
                {
                    cmdlog.Parameters.AddWithValue("@datawazna", DBNull.Value);
                }

                if (!string.IsNullOrEmpty(e_poleNotatka.Text))
                {
                    cmdlog.Parameters.AddWithValue("@notatka", e_poleNotatka.Text);
                }
                else
                {
                    cmdlog.Parameters.AddWithValue("@notatka", DBNull.Value);
                }







                //cmdlog.Parameters.AddWithValue("@nazwa", e_poleNazwaKlienta.Text);
                //cmdlog.Parameters.AddWithValue("@adres", e_poleAdresKlienta.Text);
               
                //cmdlog.Parameters.AddWithValue("@telefon", e_poletelefon.Text);
                //cmdlog.Parameters.AddWithValue("@mail", e_poleMail.Text);
                //cmdlog.Parameters.AddWithValue("@osoba", e_poleOsobaDecyzyjna.Text);
                //cmdlog.Parameters.AddWithValue("@ocena", e_poleOcenaKlienta.Text);
                //cmdlog.Parameters.AddWithValue("@nip", e_poleNip.Text);
                ////   cmdlog.Parameters.AddWithValue("@datawazna", MySqlDbType.Date).Value = e_dataWazna.SelectedDate;
                //cmdlog.Parameters.AddWithValue("@datawazna", e_dataWazna.SelectedDate.ToString());
                //cmdlog.Parameters.AddWithValue("@notatka", e_poleNotatka.Text);
                cmdlog.Parameters.AddWithValue("@id", Convert.ToInt32(idklienta));

                cmdlog.ExecuteNonQuery();

                MessageBox.Show("Pomyślnie zmodyfikowano wpis w bazie!");

            }
            catch (MySqlException se)
            {
                MessageBox.Show("Wystąpił błąd połączenia: " + se.ToString());
            }






        }

        private void UsuńKlient_Click(object sender, RoutedEventArgs e)
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
                cmdlog.CommandText = "DELETE FROM klient WHERE id=@id";
                cmdlog.Prepare();

                cmdlog.Parameters.AddWithValue("@id", Convert.ToInt32(idklienta));
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

