using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CaroSYSTEM2809
{
    public class MenadzerUtworzNowaUmoweDB : PolaczenieDB
    {
        



        public List<Kontener> utworzNowaUmowe(List<Kontener>listaKontener,   string polecenaMeble, string kosztMeble, string cenaTranDoc,
           string kosztTranDoc, string cenaTranPowr, string kosztTranPowr, string cenaPodestySchody, string kosztPodestySchody, string cenaMontaz, string kosztMontaz,
            string cenaDemontaz, string kosztDemontaz, string cenaMycia, string kosztMycia, string cenaDodatkowa, string kosztDodatkowy, string kaucja, string cenaTransDocSchPod, string kosztTransDocSchPod, string cenaTransPowSchPod, string kosztTransPowSchPod, string cenaMontazPodest, string kosztMontazPodest, string cenaMontazSchodow, string kosztMontazSchodow,
        string poziomowanie, string cenaDemontazSchodow, string kosztDemontazSchodow, string cenaDemontazPodestow, string kosztDemontazPodestow, string cenaPraceDodatkowe, string nrUmowy, string dataRozpUm, string dataZakUm, bool czyAneks, string numerUmowyAneksu, string login,int idKlient , int idUmowy,string terminPlatnosci,string fakturowanie,string uwagi,string miejsceWynajmu,string miejsceZwrotuKontenera, string osobaDecyzyjna,int idklient)
        {

         //   List<Kontener> listaKontener = new List<Kontener>();

            try
            {

                MySqlConnection conn = polaczenieZBazaDanych();
                string stm = "SELECT VERSION()";
                conn.Open();
                MySqlCommand cmd1 = new MySqlCommand(stm, conn);
                MySqlCommand cmd2 = new MySqlCommand(stm, conn);

                //cmd1.Connection = conn;

                cmd1.CommandText = "INSERT INTO umowa(numer, dataRozpoczecia, dataZakonczenia, czyAneks, numerAneks, osobaZalogowana, cenaMeble, kosztMeble, cenaTransDocelowy, kosztTransDocelowy, cenaTransPowrotny, kosztTransPowrotny, cenaPodestSchody, kosztPodestSchody, cenaMontaz, kosztMontaz, cenaDemontaz, kosztDemontaz, cenaMycie, kosztMycie, cenaDodatek, kosztDodatek, cenaKaucja, terminZaplaty, fakturowanie, dataWystawienia, notatka, idklienta, miejsceWynajmu, dzierzawaSumaZaMsc, miejsceZwrotuKontenera, osobaDecyzyjna, cenaTransDocSchodyPodest, kosztTransDocSchodyPodest, cenaTransPowSchodyPodest, kosztTransPowSchodyPodest, cenaMontazPodest, kosztMontazPodest, cenaMontazSchody, kosztMontazSchody, cenaPoziomowanie, cenaDemontazSchody, kosztDemontazSchody, cenaDemontazPodesty, kosztDemontazPodesty, cenaPraceDodatkowe)" +
                  " VALUES(@numer, @dataRozpoczecia, @dataZakonczenia, @czyAneks, @numerAneks, @osobaZalogowana, @cenaMeble, @kosztMeble, @cenaTransDocelowy, @kosztTransDocelowy, @cenaTransPowrotny, @kosztTransPowrotny, @cenaPodestSchody, @kosztPodestSchody, @cenaMontaz, @kosztMontaz, @cenaDemontaz, @kosztDemontaz, @cenaMycie, @kosztMycie, @cenaDodatek, @kosztDodatek, @cenaKaucja, @terminZaplaty, @fakturowanie, @dataWystawienia, @notatka, @idklienta, @miejsceWynajmu, @dzierzawaSumaZaMsc, @miejsceZwrotuKontenera, @osobaDecyzyjna, @cenaTransDocSchodyPodest, @kosztTransDocSchodyPodest, @cenaTransPowSchodyPodest, @kosztTransPowSchodyPodest, @cenaMontazPodest, @kosztMontazPodest, @cenaMontazSchody, @kosztMontazSchody, @cenaPoziomowanie, @cenaDemontazSchody, @kosztDemontazSchody, @cenaDemontazPodesty, @kosztDemontazPodesty, @cenaPraceDodatkowe)";
                cmd1.Prepare();
                cmd1.Parameters.AddWithValue("@numer", nrUmowy);
                cmd1.Parameters.AddWithValue("@dataRozpoczecia", dataRozpUm);
                cmd1.Parameters.AddWithValue("@dataZakonczenia", dataZakUm);
                cmd1.Parameters.AddWithValue("@czyAneks", Convert.ToInt32(czyAneks));
                cmd1.Parameters.AddWithValue("@numerAneks", numerUmowyAneksu);
                cmd1.Parameters.AddWithValue("@dzierzawaSumaZaMsc", 0);
                cmd1.Parameters.AddWithValue("@osobaZalogowana", login);

                if (!string.IsNullOrEmpty(polecenaMeble))
                {
                    cmd1.Parameters.AddWithValue("@cenaMeble", przecinekNaKropke(polecenaMeble));

                }
                else
                {
                    cmd1.Parameters.AddWithValue("@cenaMeble", 0);
                }

                if (!string.IsNullOrEmpty(kosztMeble))
                {
                    cmd1.Parameters.AddWithValue("@kosztMeble", przecinekNaKropke(kosztMeble));

                }
                else
                {
                    cmd1.Parameters.AddWithValue("@kosztMeble", 0);
                }

                if (!string.IsNullOrEmpty(cenaTranDoc))
                {
                    cmd1.Parameters.AddWithValue("@cenaTransDocelowy", przecinekNaKropke(cenaTranDoc));

                }
                else
                {
                    cmd1.Parameters.AddWithValue("@cenaTransDocelowy", 0);
                }

                if (!string.IsNullOrEmpty(kosztTranDoc))
                {
                    cmd1.Parameters.AddWithValue("@kosztTransDocelowy", przecinekNaKropke(kosztTranDoc));

                }
                else
                {
                    cmd1.Parameters.AddWithValue("@kosztTransDocelowy", 0);
                }

                if (!string.IsNullOrEmpty(cenaTranPowr))
                {
                    cmd1.Parameters.AddWithValue("@cenaTransPowrotny", przecinekNaKropke(cenaTranPowr));

                }
                else
                {
                    cmd1.Parameters.AddWithValue("@cenaTransPowrotny", 0);
                }

                if (!string.IsNullOrEmpty(kosztTranPowr))
                {
                    cmd1.Parameters.AddWithValue("@kosztTransPowrotny", przecinekNaKropke(kosztTranPowr));

                }
                else
                {
                    cmd1.Parameters.AddWithValue("@kosztTransPowrotny", 0);
                }

                if (!string.IsNullOrEmpty(cenaPodestySchody))
                {
                    cmd1.Parameters.AddWithValue("@cenaPodestSchody", przecinekNaKropke(cenaPodestySchody));

                }
                else
                {
                    cmd1.Parameters.AddWithValue("@cenaPodestSchody", 0);
                }

                if (!string.IsNullOrEmpty(kosztPodestySchody))
                {
                    cmd1.Parameters.AddWithValue("@kosztPodestSchody", przecinekNaKropke(kosztPodestySchody));

                }
                else
                {
                    cmd1.Parameters.AddWithValue("@kosztPodestSchody", 0);
                }

                if (!string.IsNullOrEmpty(cenaMontaz))
                {
                    cmd1.Parameters.AddWithValue("@cenaMontaz", przecinekNaKropke(cenaMontaz));

                }
                else
                {
                    cmd1.Parameters.AddWithValue("@cenaMontaz", 0);
                }

                if (!string.IsNullOrEmpty(kosztMontaz))
                {
                    cmd1.Parameters.AddWithValue("@kosztMontaz", przecinekNaKropke(kosztMontaz));

                }
                else
                {
                    cmd1.Parameters.AddWithValue("@kosztMontaz", 0);
                }

                if (!string.IsNullOrEmpty(cenaDemontaz))
                {
                    cmd1.Parameters.AddWithValue("@cenaDemontaz", przecinekNaKropke(cenaDemontaz));

                }
                else
                {
                    cmd1.Parameters.AddWithValue("@cenaDemontaz", 0);
                }

                if (!string.IsNullOrEmpty(kosztDemontaz))
                {
                    cmd1.Parameters.AddWithValue("@kosztDemontaz", przecinekNaKropke(kosztDemontaz));

                }
                else
                {
                    cmd1.Parameters.AddWithValue("@kosztDemontaz", 0);
                }

                if (!string.IsNullOrEmpty(cenaMycia))
                {
                    cmd1.Parameters.AddWithValue("@cenaMycie", przecinekNaKropke(cenaMycia));

                }
                else
                {
                    cmd1.Parameters.AddWithValue("@cenaMycie", 0);
                }

                if (!string.IsNullOrEmpty(kosztMycia))
                {
                    cmd1.Parameters.AddWithValue("@kosztMycie", przecinekNaKropke(kosztMycia));

                }
                else
                {
                    cmd1.Parameters.AddWithValue("@kosztMycie", 0);
                }

                if (!string.IsNullOrEmpty(cenaDodatkowa))
                {
                    cmd1.Parameters.AddWithValue("@cenaDodatek", przecinekNaKropke(cenaDodatkowa));

                }
                else
                {
                    cmd1.Parameters.AddWithValue("@cenaDodatek", 0);
                }

                if (!string.IsNullOrEmpty(kosztDodatkowy))
                {
                    cmd1.Parameters.AddWithValue("@kosztDodatek", przecinekNaKropke(kosztDodatkowy));

                }
                else
                {
                    cmd1.Parameters.AddWithValue("@kosztDodatek", 0);
                }

                if (!string.IsNullOrEmpty(kaucja))
                {
                    cmd1.Parameters.AddWithValue("@cenaKaucja", przecinekNaKropke(kaucja));

                }
                else
                {
                    cmd1.Parameters.AddWithValue("@cenaKaucja", 0);
                }

                if (!string.IsNullOrEmpty(cenaTransDocSchPod))
                {
                    cmd1.Parameters.AddWithValue("@cenaTransDocSchodyPodest", przecinekNaKropke(cenaTransDocSchPod));

                }
                else
                {
                    cmd1.Parameters.AddWithValue("@cenaTransDocSchodyPodest", 0);
                }

                if (!string.IsNullOrEmpty(kosztTransDocSchPod))
                {
                    cmd1.Parameters.AddWithValue("@kosztTransDocSchodyPodest", przecinekNaKropke(kosztTransDocSchPod));

                }
                else
                {
                    cmd1.Parameters.AddWithValue("@kosztTransDocSchodyPodest", 0);
                }
                if (!string.IsNullOrEmpty(cenaTransPowSchPod))
                {
                    cmd1.Parameters.AddWithValue("@cenaTransPowSchodyPodest", przecinekNaKropke(cenaTransPowSchPod));

                }
                else
                {
                    cmd1.Parameters.AddWithValue("@cenaTransPowSchodyPodest", 0);
                }
                if (!string.IsNullOrEmpty(kosztTransPowSchPod))
                {
                    cmd1.Parameters.AddWithValue("@kosztTransPowSchodyPodest", przecinekNaKropke(kosztTransPowSchPod));

                }
                else
                {
                    cmd1.Parameters.AddWithValue("@kosztTransPowSchodyPodest", 0);
                }
                if (!string.IsNullOrEmpty(cenaMontazPodest))
                {
                    cmd1.Parameters.AddWithValue("@cenaMontazPodest", przecinekNaKropke(cenaMontazPodest));

                }
                else
                {
                    cmd1.Parameters.AddWithValue("@cenaMontazPodest", 0);
                }
                if (!string.IsNullOrEmpty(kosztMontazPodest))
                {
                    cmd1.Parameters.AddWithValue("@kosztMontazPodest", przecinekNaKropke(kosztMontazPodest));

                }
                else
                {
                    cmd1.Parameters.AddWithValue("@kosztMontazPodest", 0);
                }
                if (!string.IsNullOrEmpty(cenaMontazSchodow))
                {
                    cmd1.Parameters.AddWithValue("@cenaMontazSchody", przecinekNaKropke(cenaMontazSchodow));

                }
                else
                {
                    cmd1.Parameters.AddWithValue("@cenaMontazSchody", 0);
                }
                if (!string.IsNullOrEmpty(kosztMontazSchodow))
                {
                    cmd1.Parameters.AddWithValue("@kosztMontazSchody", przecinekNaKropke(kosztMontazSchodow));

                }
                else
                {
                    cmd1.Parameters.AddWithValue("@kosztMontazSchody", 0);
                }
                if (!string.IsNullOrEmpty(poziomowanie))
                {
                    cmd1.Parameters.AddWithValue("@cenaPoziomowanie", przecinekNaKropke(poziomowanie));

                }
                else
                {
                    cmd1.Parameters.AddWithValue("@cenaPoziomowanie", 0);
                }
                if (!string.IsNullOrEmpty(cenaDemontazSchodow))
                {
                    cmd1.Parameters.AddWithValue("@cenaDemontazSchody", przecinekNaKropke(cenaDemontazSchodow));

                }
                else
                {
                    cmd1.Parameters.AddWithValue("@cenaDemontazSchody", 0);
                }
                if (!string.IsNullOrEmpty(kosztDemontazSchodow))
                {
                    cmd1.Parameters.AddWithValue("@kosztDemontazSchody", przecinekNaKropke(kosztDemontazSchodow));

                }
                else
                {
                    cmd1.Parameters.AddWithValue("@kosztDemontazSchody", 0);
                }
                if (!string.IsNullOrEmpty(cenaDemontazPodestow))
                {
                    cmd1.Parameters.AddWithValue("@cenaDemontazPodesty", przecinekNaKropke(cenaDemontazPodestow));

                }
                else
                {
                    cmd1.Parameters.AddWithValue("@cenaDemontazPodesty", 0);
                }
                if (!string.IsNullOrEmpty(kosztDemontazPodestow))
                {
                    cmd1.Parameters.AddWithValue("@kosztDemontazPodesty", przecinekNaKropke(kosztDemontazPodestow));

                }
                else
                {
                    cmd1.Parameters.AddWithValue("@kosztDemontazPodesty", 0);
                }
                if (!string.IsNullOrEmpty(cenaPraceDodatkowe))
                {
                    cmd1.Parameters.AddWithValue("@cenaPraceDodatkowe", przecinekNaKropke(cenaPraceDodatkowe));

                }
                else
                {
                    cmd1.Parameters.AddWithValue("@cenaPraceDodatkowe", 0);
                }


                cmd1.Parameters.AddWithValue("@terminZaplaty", terminPlatnosci);
                cmd1.Parameters.AddWithValue("@fakturowanie", fakturowanie);
                DateTime theDate = DateTime.Now;
                theDate.ToString("yyyy-MM-dd H:mm:ss");
                cmd1.Parameters.AddWithValue("@dataWystawienia", theDate);
                cmd1.Parameters.AddWithValue("@notatka", uwagi);
                cmd1.Parameters.AddWithValue("@miejsceWynajmu", miejsceWynajmu);
                cmd1.Parameters.AddWithValue("@miejsceZwrotuKontenera", miejsceZwrotuKontenera);

                cmd1.Parameters.AddWithValue("@osobaDecyzyjna", osobaDecyzyjna);

                cmd1.Parameters.AddWithValue("@idklienta",idKlient);
                cmd1.ExecuteNonQuery();

                cmd2.Connection = conn;
                cmd2.CommandText = "SELECT id FROM umowa WHERE numer=@numer";
                cmd2.Prepare();
                cmd2.Parameters.AddWithValue("@numer", nrUmowy);

               idUmowy = Convert.ToInt32(cmd2.ExecuteScalar());




                foreach (var item in listaKontener)
                {

                    try
                    {

                        conn = polaczenieZBazaDanych();
                        conn.Open();
                        MySqlCommand cmdKontener = new MySqlCommand(stm, conn);
                        cmdKontener.CommandText = "UPDATE kontener SET idumowy=@idumowy, idklienta=@idklienta, czyWynajety=1 WHERE id=@idkont";
                        cmdKontener.Prepare();
                        cmdKontener.Parameters.AddWithValue("@idumowy", idUmowy);
                        cmdKontener.Parameters.AddWithValue("@idklienta", idKlient);
                        cmdKontener.Parameters.AddWithValue("@idkont", item.Ko_Id);
                        cmdKontener.ExecuteNonQuery();



                    }
                    catch (MySqlException se)
                    {
                        System.Windows.MessageBox.Show("Wystąpił błąd połączenia: " + se.ToString());
                    }


                   
                }
            }catch (MySqlException se) 

            {


            }
            return listaKontener;
        }    
        private string przecinekNaKropke(string wejscie)
        {
            string temp = wejscie.Replace(',', '.');
            return temp;
        }

    }
}   
