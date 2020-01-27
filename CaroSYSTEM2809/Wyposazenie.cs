using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaroSYSTEM2809
{
    class Wyposazenie
    {

        private int wid;
        private string wnazwawyposazenia;
        private double wcenadodatku;
        private int wiloscdodatku;

        public int WId { get; set; }
        public string Wnazwawyposazenia { get; set; }
        public double WCenadodatku { get; set; }
        public int WIloscdodatku { get; set; }

        public Wyposazenie() { }

        public Wyposazenie(int id, string nazwa, double cena, int ilosc)
        {
            wid = id;
            wnazwawyposazenia = nazwa;
            wcenadodatku = cena;
            wiloscdodatku = ilosc;



        }



        }
    }
