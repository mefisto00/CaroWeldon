using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Input;
using MySql.Data.MySqlClient;

namespace CaroSYSTEM2809
{
    /// <summary>
    /// Logika interakcji dla klasy loginBox.xaml
    /// </summary>
    public partial class loginBox : Window
    {
        public loginBox()
        {
            InitializeComponent();
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
                walidacja(logowanie_login.Text,logowanie_password.Password.ToString());

         
        }


        public string kodowanieDoMD5(string wartosc)
        {

            // byte array representation of that string
            byte[] encodedPassword = new UTF8Encoding().GetBytes(wartosc);

            // need MD5 to calculate the hash
            byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);

            // string representation (similar to UNIX format)
            string encoded = BitConverter.ToString(hash)
               // without dashes
               .Replace("-", string.Empty)
               // make lowercase
               .ToLower();
            return encoded;
        }



        public void walidacja(string login, string haslo)
        {

              string haslmd5 = kodowanieDoMD5(haslo);
          try
            {

                MenadzerDB menadzerDB = new MenadzerDB();
                MySqlCommand cmdlog = menadzerDB.pobierzDaneZLogowania(login);
                MySqlDataReader rdr = cmdlog.ExecuteReader();
                while (rdr.Read())
                {                    
                    if (rdr.GetString(2) == haslmd5)
                    {
                        MainWindow mw = new MainWindow(login);
                        this.Close();
                        mw.Show();
                        System.Uri uri = new System.Uri("pack://application:,,,,/CaroSYSTEM2809;component/MainWindow.xaml");
                        Application.Current.MainWindow = mw;
                    }
                    else
                    {
                        MessageBox.Show("Twoje dane logowania są nieprawidłowe!", "Błąd logowania!", MessageBoxButton.OK, MessageBoxImage.Error);
                        this.Close();

                    }
                }
          }catch (MySqlException se)
            {
                MessageBox.Show("Wystąpił błąd połączenia: " + se.ToString());
            }
               
        }
            private void Logowanie_password_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.Key == Key.Enter)
                {
                this.walidacja(logowanie_login.Text, logowanie_password.Password.ToString());
                }


             }






        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

