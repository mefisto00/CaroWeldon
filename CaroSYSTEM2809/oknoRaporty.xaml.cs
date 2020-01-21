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
using MySql.Data.MySqlClient;
using Microsoft.Win32;
using System.Data;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace CaroSYSTEM2809
{
    /// <summary>
    /// Logika interakcji dla klasy oknoRaporty.xaml
    /// </summary>
    public partial class oknoRaporty : Window
    {
        public string idUmowy;
        public oknoRaporty()
        {
            InitializeComponent();
            wypelnijTabeleUmowy();
            uRaportWykaz.Visibility = Visibility.Visible;
            uRaportWybrany.Visibility = Visibility.Collapsed;
        }

        private void SprawdzRaport_Click(object sender, RoutedEventArgs e)
        {
            uRaportWykaz.Visibility = Visibility.Collapsed;
            uRaportWybrany.Visibility = Visibility.Visible;


            DataRowView row = (DataRowView)grid_umowy.SelectedItem as DataRowView;

            idUmowy = row[0].ToString();
            string sciezka = "baza.config";
            string konfiguracja = File.ReadAllText(sciezka);



            double sumaTransport = 0;
            double sumaMontazDemontaz = 0;
            double sumaKosztTransport = 0;
            double sumaKosztMonDemon = 0;
            double przychodTransport;
            double kosztTransport;
            double roznicaTransport;

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
            double zyskUmowa;



            try
            {
                

                MySqlConnection conn = null;
                conn = new MySqlConnection(konfiguracja);
                conn.Open();

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
                cmd1.Parameters.AddWithValue("@idumowy", Convert.ToInt32(idUmowy));

                cmd1.ExecuteNonQuery();

                cmd3.CommandText = "select numer from umowa where id=@idumowy";
                cmd3.Prepare();
                cmd3.Parameters.AddWithValue("@idumowy", idUmowy);
                Console.WriteLine("Numer umowy to => " + cmd3.ExecuteScalar().ToString());
                txUmowaNumer.Text= "Raport dla umowy - " + cmd3.ExecuteScalar().ToString();


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
                cmd2.Parameters.AddWithValue("@idumowy", Convert.ToInt32(idUmowy));




                // Console.WriteLine("larum parum");
                MySqlDataReader rdr = cmd1.ExecuteReader();
                while (rdr.Read())
                {
                    //  Console.WriteLine(rdr.GetString(0).PadRight(18) + rdr.GetString(1).PadRight(18)+rdr.GetString(2));
                    if (!rdr.IsDBNull(0)) { poleRSumaCenKontenerow.Text = rdr.GetString(0).ToString(); } else { poleRSumaCenKontenerow.Text = "0"; }
                    // poleRSumaCenKontenerow.Text = rdr.GetString(0).ToString();
                    poleRIleKont.Text = rdr.GetString(1).ToString();
                    sumaTransport = Convert.ToDouble(rdr.GetString(2).ToString()) + Convert.ToDouble(rdr.GetString(3).ToString());
                    poleRSumaTransport.Text = sumaTransport.ToString();
                    poleRSumaMeble.Text = rdr.GetString(4).ToString();
                    sumaMontazDemontaz = Convert.ToDouble(rdr.GetString(5).ToString()) + Convert.ToDouble(rdr.GetString(6).ToString());
                    poleRSumaMontazDemontaz.Text = sumaMontazDemontaz.ToString();
                    poleRSumaMycie.Text = rdr.GetString(7).ToString();
                    poleRSumaObciazenia.Text = rdr.GetString(8).ToString();
                    poleRPrzychod.Text = (Convert.ToDouble(poleRSumaCenKontenerow.Text) + Convert.ToDouble(poleRSumaTransport.Text) + Convert.ToDouble(poleRSumaMeble.Text) + Convert.ToDouble(poleRSumaMontazDemontaz.Text) + Convert.ToDouble(poleRSumaMycie.Text) + Convert.ToDouble(poleRSumaObciazenia.Text)).ToString();
                }
                rdr.Close();


                MySqlDataReader rdr2 = cmd2.ExecuteReader();
                while (rdr2.Read())
                {
                    //  Console.WriteLine(rdr.GetString(0).PadRight(18) + rdr.GetString(1).PadRight(18)+rdr.GetString(2));
                    if (!rdr2.IsDBNull(0)) { poleRKNOgolnie.Text = rdr2.GetString(0).ToString(); } else { poleRKNOgolnie.Text = "0"; }
                    // poleRSumaCenKontenerow.Text = rdr.GetString(0).ToString();
                    // poleRIleKont.Text = rdr2.GetString(1).ToString();
                    sumaKosztTransport = Convert.ToDouble(rdr2.GetString(1).ToString()) + Convert.ToDouble(rdr2.GetString(2).ToString());
                    poleRKNTrasportu.Text = sumaKosztTransport.ToString();
                    if (!rdr2.IsDBNull(3)) { poleRKNKredAmo.Text = rdr2.GetString(3).ToString(); } else { poleRKNKredAmo.Text = "0"; }
                    //  poleRKNKredAmo.Text = rdr2.GetString(4).ToString();
                    sumaKosztMonDemon = Convert.ToDouble(rdr2.GetString(4).ToString()) + Convert.ToDouble(rdr2.GetString(5).ToString());
                    poleRKNMontazDemontaz.Text = sumaKosztMonDemon.ToString();
                    poleRKNMycia.Text = rdr2.GetString(6).ToString();
                    poleRKNNapraw.Text = rdr2.GetString(7).ToString();
                    poleRKoszt.Text = (Convert.ToDouble(poleRKNOgolnie.Text) + Convert.ToDouble(poleRKNTrasportu.Text) + Convert.ToDouble(poleRKNKredAmo.Text) + Convert.ToDouble(poleRKNMontazDemontaz.Text) + Convert.ToDouble(poleRKNMycia.Text) + Convert.ToDouble(poleRKNNapraw.Text)).ToString();
                }
                rdr2.Close();


                poleRRKont.Text = (Convert.ToDouble(poleRSumaCenKontenerow.Text) - Convert.ToDouble(poleRKNOgolnie.Text)).ToString();
                poleRRTran.Text = (Convert.ToDouble(poleRSumaTransport.Text) - Convert.ToDouble(poleRKNTrasportu.Text)).ToString();
                poleRRMebleSchody.Text= (Convert.ToDouble(poleRSumaMeble.Text) - Convert.ToDouble(poleRKNKredAmo.Text)).ToString();
                poleRRMonDem.Text = (Convert.ToDouble(poleRSumaMontazDemontaz.Text) - Convert.ToDouble(poleRKNMontazDemontaz.Text)).ToString();
                poleRRMyc.Text = (Convert.ToDouble(poleRSumaMycie.Text) - Convert.ToDouble(poleRKNMycia.Text)).ToString();
                poleRRDod.Text = (Convert.ToDouble(poleRSumaObciazenia.Text) - Convert.ToDouble(poleRKNNapraw.Text)).ToString();
                poleRRZysk.Text= (Convert.ToDouble(poleRPrzychod.Text) - Convert.ToDouble(poleRKoszt.Text)).ToString();


            }
            catch (MySqlException se)
            {
                System.Windows.MessageBox.Show("Wystąpił błąd połączenia: " + se.ToString());
            }
            

        }

        public void wypelnijTabeleUmowy()
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

        private void PowrotSpisRaportBTN_Click(object sender, RoutedEventArgs e)
        {
            wypelnijTabeleUmowy();
            uRaportWykaz.Visibility = Visibility.Visible;
            uRaportWybrany.Visibility = Visibility.Collapsed;
        
    }

        private void DrukujRaportExcelBTN_Click(object sender, RoutedEventArgs e)
        {
          
        }

        private void DrukujRaportWordBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DrukujRaportPDFBTN_Click(object sender, RoutedEventArgs e)
        {

            //string FONT = "c:/windows/fonts/arial.ttf";
           
            //BaseFont bf = BaseFont.CreateFont(FONT, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
           

            //Document document = new Document();
            //PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(nazwaRaportu, FileMode.Create));
            //document.Open();
            //// iTextSharp.text.Font font5 = iTextSharp.text.FontFactory.GetFont(FontFactory.TIMES, 5);
            //PdfPTable table = new PdfPTable(5);
            //PdfPRow row = null;
            //float[] widths = new float[] { 4f, 4f, 2.5f, 4f, 4f };

            //table.SetWidths(widths);

            //table.WidthPercentage = 100;
            //int iCol = 0;
            //string colname = "";
            //PdfPCell cell = new PdfPCell(new Phrase("Raport"));

            //iTextSharp.text.Paragraph para0 = new iTextSharp.text.Paragraph();
            //para0.Alignment = Element.ALIGN_CENTER;
            //para0.Font = new Font(bf2, 14f, 1);
            //para0.SpacingAfter = 10;
            //para0.Add("Raport premiowy");
        }
    }
}
