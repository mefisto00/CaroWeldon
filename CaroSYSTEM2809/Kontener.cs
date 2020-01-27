using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaroSYSTEM2809
{
    public class Kontener
    {

        private int ko_id;
        private string ko_numercaro;
        private string ko_numerweldon;
        private string ko_amortyzacjakontenera;
        private string ko_cenanetto;
        private string ko_typkontenera;
        private string ko_czyklimatyzowany;
        private string ko_podstawowewyposazeniekontenera;
        private string ko_dodatkowewyposazeniekontenera;
        private string ko_lokalizacja;
        private string ko_cenaminimalna;
        private string ko_datazakupukontenera;
        private string ko_datakoncaamo;

        private string ko_notatka;
        private string ko_czywynajety;





        public int Ko_Id { get; set; }
        public string Ko_Numercaro { get; set; }
        public string Ko_Numerweldon { get; set; }
        public string Ko_Amortyzacjakontenera { get; set; }
        public string Ko_Cenanetto { get; set; }
        public string Ko_Typkontenera { get; set; }
        public string Ko_Czyklimatyzowany { get; set; }
        public string Ko_Podstawowewyposazeniekontenera { get; set; }
        public string Ko_Dodatkowewyposazeniekontenera { get; set; }
        public string Ko_Lokalizacja { get; set; }
        public string Ko_Cenaminimalna { get; set; }

        public string Ko_Datazakupukontenera { get; set; }
        public string Ko_Datakoncaamo { get; set; }

        public string Ko_Notatka { get; set; }
        public string Ko_Czywynajety { get; set; }



        public Kontener() { }

        public Kontener(int idkont, string ncaro, string nweldon, string aort, string cennet, string tkont, string klim, string podwyp, string dodwyp, string lok, string cenamin, string dtzak, string dtkonamo, string nota, string wynaj)
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
}