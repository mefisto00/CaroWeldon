using System.Data;
using System.Windows;


namespace CaroSYSTEM2809
{
    /// <summary>
    /// Logika interakcji dla klasy oknoRaporty.xaml
    /// </summary>
    public partial class oknoRaporty : Window
    {


        private string idUmowy;
        private string rSumaCenKonteneroW;
        private string rIleKont;
        private string rSumaTransport;
        private string rSumaMeble;
        private string rSumaMontazDemontaz;
        private string rSumaMycie;
        private string rSumaObciazenia;
        private string rPrzychod;
        private string rKNOgolnie;
        private string rKNTrasportu;
        private string rKNMontazDemontaz;
        private string rKNMycia;
        private string rKNNapraw;
        private string rKoszt;
        private string rRKont;
        private string rRTran;
        private string rRMebleSchody;
        private string rRMonDem;
        private string rRMyc;
        private string rRDod;
        private string rRZysk;
        private string txUmowaNumerI;
        private string rKNKredAmo;



        



        public string RKNKredAmo
        {
            get { return rKNKredAmo; }

            private set { rKNKredAmo = poleRKNKredAmo.Text; }

        }
        public string  TxUmowaNumerI
        {
            get { return txUmowaNumerI; }

            private set { txUmowaNumerI = txUmowaNumer.Text; }

        }
        public string RRZysk
        {
            get { return rRZysk; }

            private set { rRZysk = poleRRZysk.Text; }

        }
        public string RRDod
        {
            get { return rRDod; }

            private set
            {
                rRDod = poleRRDod.Text;
            }

        }
        public string RRMyc
        {
            get { return rRMyc; }

            private set { rRMyc = poleRRMyc.Text; }

        }
        public string RRMebleSchody
        {
            get { return rRMebleSchody; }

            private set { rRMebleSchody = poleRRMebleSchody.Text; }

        }
        public string RRMonDem
        {
            get { return rRMonDem; }

            private set { rRMonDem = poleRRMonDem.Text; }

        }
        public string RRTran
        {
            get { return rRTran; }

            private set { rRTran = poleRRTran.Text; }

        }
        public string RRKont
        {
            get { return rRKont; }

            private set { rRKont = poleRRKont.Text; }

        }
        public string RKoszt
        {
            get { return rKoszt; }

            private set { rKoszt = poleRKoszt.Text; }

        }
        public string RKNMontazDemontaz
        {
            get { return rKNMontazDemontaz; }

            private set { rKNMontazDemontaz = poleRKNMontazDemontaz.Text; }

        }
        public string RKNNapraw
        {
            get { return rKNNapraw; }

            private set { rKNNapraw = poleRKNNapraw.Text; }

        }


        public string RKNMycia
        {
            get { return rKNMycia; }

            private set { rKNMycia = poleRKNMycia.Text; }

        }

        public string RKNTrasportu
        {
            get { return rKNTrasportu; }

            private set { rKNTrasportu = poleRKNTrasportu.Text; }

        }
        public string RKNOgolnie
        {
            get { return RKNOgolnie; }

            private set { RKNOgolnie = poleRKNOgolnie.Text; }

        }
        public string RPrzychod
        {
            get { return rPrzychod; }

            private set { rPrzychod = poleRPrzychod.Text; }

        }

        public string RSumaMycie
        {
            get { return rSumaMycie; }

            private set { rSumaMycie = poleRSumaMycie.Text; }

        }

        public string RSumaMontazDemontaz
         {
            get { return rSumaMontazDemontaz; }

            private set { rSumaMontazDemontaz = poleRSumaMontazDemontaz.Text; }

         }

        public string RSumaTransport
        {
            get { return rSumaTransport; }

            private set { rSumaTransport = poleRSumaTransport.Text; }

        }



        public string RSumaObciazenia
        {
            get { return rSumaObciazenia; }

            private set { rSumaObciazenia = poleRSumaObciazenia.Text; }

        }



        public string RIleKont
        {
            get { return rIleKont; }

            private set { rIleKont = poleRIleKont.Text; }
        }

        public string RSumaMeble
        {
            get { return rSumaMeble; }

            private set { rSumaMeble = poleRSumaMeble.Text; }
        }

        public string RSumaCenKonteneroW
        {
            get { return rSumaCenKonteneroW; }

            private set { rSumaCenKonteneroW = poleRSumaCenKontenerow.Text; }
        }



        public string IdUmowy
        {
            get { return idUmowy; }

            private set { idUmowy = value; }
        }

      private  MenadzerRaportyDB menadzerRaportyDB = new MenadzerRaportyDB(); 


        public oknoRaporty()
            
        {
            InitializeComponent();
            menadzerRaportyDB.WypelnijTabeleUmowy(grid_umowy);
            uRaportWykaz.Visibility = Visibility.Visible;
            uRaportWybrany.Visibility = Visibility.Collapsed;
        }

        private void SprawdzRaport_Click(object sender, RoutedEventArgs e)
        {
            uRaportWykaz.Visibility = Visibility.Collapsed;
            uRaportWybrany.Visibility = Visibility.Visible;



            DataRowView row = (DataRowView)grid_umowy.SelectedItem as DataRowView;

            idUmowy = row[0].ToString();

            menadzerRaportyDB.SprawdzRaport(idUmowy, rSumaCenKonteneroW, rIleKont, rSumaTransport, rSumaMeble, rSumaMontazDemontaz, rSumaMycie, rSumaObciazenia, rPrzychod, rKNOgolnie, rKNTrasportu, rKNMontazDemontaz, rKNMycia, rKNNapraw, rKoszt, rRKont, rRTran, rRMebleSchody, rRMonDem, rRMyc, rRDod, rRZysk, txUmowaNumerI, rKNKredAmo);


        }

  

   
        private void PowrotSpisRaportBTN_Click(object sender, RoutedEventArgs e)
        {
            menadzerRaportyDB.WypelnijTabeleUmowy(grid_umowy);
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
