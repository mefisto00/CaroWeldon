using System;
using System.Data;
using System.Windows.Controls;
using MySql.Data.MySqlClient;

namespace CaroSYSTEM2809
{
    public  class MenadzerRaportyDB: PolaczenieDB
    {


        public MenadzerRaportyDB()
        {

           

        }

        public  void WypelnijTabeleUmowy(DataGrid grid_umowy)
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


        public void SprawdzRaport(string idUmowa, string rSumaCenKontenerow,string rIleKont,string rSumaTransport,
        string rSumaMeble, string rSumaMontazDemontaz, string rSumaMycie, string rSumaObciazenia, string rPrzychod,
        string rKNOgolnie, string rKNTrasportu, string rKNMontazDemontaz, string rKNMycia, string rKNNapraw,
        string rKoszt, string rRKont, string rRTran , string rRMebleSchody, string rRMonDem, string rRMyc, 
        string rRDod, string rRZysk, string txUmowaNumerI, string rKNKredAmo )
        {

            double sumaTransport = 0;
            double sumaMontazDemontaz = 0;
            double sumaKosztTransport = 0;
            double sumaKosztMonDemon = 0;
            double przychodTransport;
            double kosztTransport;
            double roznicaTransport;
/*
            double przychodMeblePodest;
            double kosztMeblePodest;
            double roznicaMeblePodest;

            double przychodMontazDemontaz;
            double kosztMontazDemontaz;
            double roznicaMontazDemontaz;

            double przychodMycie;
            double kosztMycie;
            double roznicaMycie;

            double przychodObciazenia;
            double kosztNettoNaprawy;
            double roznicaObciazeniaNetto;

            double przychodUmowa;
            double kosztUmowa;
            double  zyskUmowa;
            */


            try
            {


                MySqlConnection conn = polaczenieZBazaDanych();
                string stm = "SELECT VERSION()";
                MySqlCommand cmd1 = new MySqlCommand(stm, conn);
                MySqlCommand cmd2 = new MySqlCommand(stm, conn);
                MySqlCommand cmd3 = new MySqlCommand(stm, conn);
                cmd1.Connection = conn;
                cmd2.Connection = conn;
                cmd3.Connection = conn;

                cmd1.CommandText = "select sum(kontener.cenaNetto)," +
                    "count(kontener.id)," +
                    "sum(umowa.cenaTransDocelowy), " +
                    "sum(umowa.cenaTransPowrotny), " +
                    "sum(umowa.cenaMeble)," +
                    "sum(umowa.cenaMontaz), " +
                    "sum(umowa.cenaDemontaz), " +
                    "sum(umowa.cenaMycie), " +
                    "sum(umowa.cenaDodatek) " +
                    "from kontener, umowa " +
                    "where kontener.idumowy = umowa.id and umowa.id = @idumowy";

                cmd1.Prepare();
                cmd1.Parameters.AddWithValue("@idumowy", Convert.ToInt32(idUmowa));

                cmd1.ExecuteNonQuery();

                cmd3.CommandText = "select numer from umowa where id=@idumowy";
                cmd3.Prepare();
                cmd3.Parameters.AddWithValue("@idumowy", idUmowa);
                Console.WriteLine("Numer umowy to => " + cmd3.ExecuteScalar().ToString());
                txUmowaNumerI = "Raport dla umowy - " + cmd3.ExecuteScalar().ToString();


                cmd2.CommandText = "select sum(kontener.amortyzacja)," +
                    "sum(umowa.kosztTransDocelowy), " +
                    "sum(umowa.kosztTransPowrotny), " +
                    "sum(kontener.amortyzacja)," +
                    "sum(umowa.kosztMontaz), " +
                    "sum(umowa.kosztDemontaz), " +
                    "sum(umowa.kosztMycie), " +
                    "sum(umowa.kosztDodatek) " +
                    "from kontener, umowa " +
                    "where kontener.idumowy = umowa.id and umowa.id = @idumowy";

                cmd2.Prepare();
                cmd2.Parameters.AddWithValue("@idumowy", Convert.ToInt32(idUmowa));




                // Console.WriteLine("larum parum");
                MySqlDataReader rdr = cmd1.ExecuteReader();
                while (rdr.Read())
                {
                    //  Console.WriteLine(rdr.GetString(0).PadRight(18) + rdr.GetString(1).PadRight(18)+rdr.GetString(2));
                    if (!rdr.IsDBNull(0)) { rSumaCenKontenerow = rdr.GetString(0).ToString(); } else { rSumaCenKontenerow = "0"; }
                    // poleRSumaCenKontenerow.Text = rdr.GetString(0).ToString();
                    rIleKont = rdr.GetString(1).ToString();
                    sumaTransport = (Convert.ToDouble(rdr.GetString(2).ToString()) + Convert.ToDouble(rdr.GetString(3).ToString()));
                    rSumaTransport = sumaTransport.ToString();
                    rSumaMeble = rdr.GetString(4).ToString();
                    sumaMontazDemontaz = (Convert.ToDouble(rdr.GetString(5).ToString()) + Convert.ToDouble(rdr.GetString(6).ToString()));
                    rSumaMontazDemontaz = sumaMontazDemontaz.ToString();
                    rSumaMycie = rdr.GetString(7).ToString();
                    rSumaObciazenia = rdr.GetString(8).ToString();
                    rPrzychod = (Convert.ToDouble(rSumaCenKontenerow) + Convert.ToDouble(rSumaTransport) + Convert.ToDouble(rSumaMeble) + Convert.ToDouble(rSumaMontazDemontaz) + Convert.ToDouble(rSumaMycie) + Convert.ToDouble(rSumaObciazenia)).ToString();
                }
                rdr.Close();


                MySqlDataReader rdr2 = cmd2.ExecuteReader();
                while (rdr2.Read())
                {
                    //  Console.WriteLine(rdr.GetString(0).PadRight(18) + rdr.GetString(1).PadRight(18)+rdr.GetString(2));
                    if (!rdr2.IsDBNull(0)) { rKNOgolnie = rdr2.GetString(0).ToString();
                    }
                    else {
                        rKNOgolnie = "0";
                    }
                    // poleRSumaCenKontenerow.Text = rdr.GetString(0).ToString();
                    // poleRIleKont.Text = rdr2.GetString(1).ToString();
                    sumaKosztTransport = Convert.ToDouble(rdr2.GetString(1).ToString()) + Convert.ToDouble(rdr2.GetString(2).ToString());
                    rKNTrasportu = sumaKosztTransport.ToString();
                    if (!rdr2.IsDBNull(3))
                    {
                        rKNKredAmo = rdr2.GetString(3).ToString();
                    } else
                    {
                        rKNKredAmo = "0";
                    }
                    //  poleRKNKredAmo.Text = rdr2.GetString(4).ToString();
                    sumaKosztMonDemon = Convert.ToDouble(rdr2.GetString(4).ToString()) + Convert.ToDouble(rdr2.GetString(5).ToString());
                    rKNMontazDemontaz = sumaKosztMonDemon.ToString();
                    rKNMycia = rdr2.GetString(6).ToString();
                    rKNNapraw = rdr2.GetString(7).ToString();
                    rKoszt = (Convert.ToDouble(rKNOgolnie) + Convert.ToDouble(rKNTrasportu) + Convert.ToDouble(rKNKredAmo) + Convert.ToDouble(rKNMontazDemontaz) + Convert.ToDouble(rKNMycia) + Convert.ToDouble(rKNNapraw)).ToString();
                }
                rdr2.Close();


                rRKont = (Convert.ToDouble(rSumaCenKontenerow) - Convert.ToDouble(rKNOgolnie)).ToString();
                rRTran = (Convert.ToDouble(rSumaTransport) - Convert.ToDouble(rKNTrasportu)).ToString();
                rRMebleSchody = (Convert.ToDouble(rSumaMeble) - Convert.ToDouble(rKNKredAmo)).ToString();
                rRMonDem = (Convert.ToDouble(rSumaMontazDemontaz) - Convert.ToDouble(rKNMontazDemontaz)).ToString();
                rRMyc = (Convert.ToDouble(rSumaMycie) - Convert.ToDouble(rKNMycia)).ToString();
                rRDod = (Convert.ToDouble(rSumaObciazenia) - Convert.ToDouble(rKNNapraw)).ToString();
                rRZysk = (Convert.ToDouble(rPrzychod) - Convert.ToDouble(rKoszt)).ToString();


            }
            catch (MySqlException se)
            {
                System.Windows.MessageBox.Show("Wystąpił błąd połączenia: " + se.ToString());
            }


        }


    }
}

