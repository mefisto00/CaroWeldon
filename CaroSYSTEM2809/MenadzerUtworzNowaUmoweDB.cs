using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CaroSYSTEM2809
{
   public class MenadzerUtworzNowaUmoweDB :PolaczenieDB
    {


       public void utworzNowaUmowe()
        {
            //try
            //{

            //    MySqlConnection conn = PolaczenieDB.polaczenieZBazaDanych();
            //    string stm = "SELECT VERSION()";
            //    conn.Open();
            //    MySqlCommand cmd1 = new MySqlCommand(stm, conn);
            //    MySqlCommand cmd2 = new MySqlCommand(stm, conn);

            //    cmd1.Connection = conn;

            //    cmd1.CommandText = "INSERT INTO umowa(numer, dataRozpoczecia, dataZakonczenia, czyAneks, numerAneks, osobaZalogowana, cenaMeble, kosztMeble, cenaTransDocelowy, kosztTransDocelowy, cenaTransPowrotny, kosztTransPowrotny, cenaPodestSchody, kosztPodestSchody, cenaMontaz, kosztMontaz, cenaDemontaz, kosztDemontaz, cenaMycie, kosztMycie, cenaDodatek, kosztDodatek, cenaKaucja, terminZaplaty, fakturowanie, dataWystawienia, notatka, idklienta, miejsceWynajmu, dzierzawaSumaZaMsc, miejsceZwrotuKontenera, osobaDecyzyjna, cenaTransDocSchodyPodest, kosztTransDocSchodyPodest, cenaTransPowSchodyPodest, kosztTransPowSchodyPodest, cenaMontazPodest, kosztMontazPodest, cenaMontazSchody, kosztMontazSchody, cenaPoziomowanie, cenaDemontazSchody, kosztDemontazSchody, cenaDemontazPodesty, kosztDemontazPodesty, cenaPraceDodatkowe)" +
            //        " VALUES(@numer, @dataRozpoczecia, @dataZakonczenia, @czyAneks, @numerAneks, @osobaZalogowana, @cenaMeble, @kosztMeble, @cenaTransDocelowy, @kosztTransDocelowy, @cenaTransPowrotny, @kosztTransPowrotny, @cenaPodestSchody, @kosztPodestSchody, @cenaMontaz, @kosztMontaz, @cenaDemontaz, @kosztDemontaz, @cenaMycie, @kosztMycie, @cenaDodatek, @kosztDodatek, @cenaKaucja, @terminZaplaty, @fakturowanie, @dataWystawienia, @notatka, @idklienta, @miejsceWynajmu, @dzierzawaSumaZaMsc, @miejsceZwrotuKontenera, @osobaDecyzyjna, @cenaTransDocSchodyPodest, @kosztTransDocSchodyPodest, @cenaTransPowSchodyPodest, @kosztTransPowSchodyPodest, @cenaMontazPodest, @kosztMontazPodest, @cenaMontazSchody, @kosztMontazSchody, @cenaPoziomowanie, @cenaDemontazSchody, @kosztDemontazSchody, @cenaDemontazPodesty, @kosztDemontazPodesty, @cenaPraceDodatkowe)";
            //    cmd1.Prepare();
            //    cmd1.Parameters.AddWithValue("@numer", poleNrUmowy.Text);
            //    cmd1.Parameters.AddWithValue("@dataRozpoczecia", poleDataRozpUm.Text);
            //    cmd1.Parameters.AddWithValue("@dataZakonczenia", poleDataZakUm.Text);
            //    cmd1.Parameters.AddWithValue("@czyAneks", Convert.ToInt32(poleCzyAneks.IsChecked));
            //    cmd1.Parameters.AddWithValue("@numerAneks", poleNumerUmowyAneksu.Text);
            //    cmd1.Parameters.AddWithValue("@dzierzawaSumaZaMsc", 0);
            //    cmd1.Parameters.AddWithValue("@osobaZalogowana", s_login);





            }



    }
}
