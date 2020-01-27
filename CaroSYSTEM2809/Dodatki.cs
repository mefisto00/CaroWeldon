using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaroSYSTEM2809
{
    class Dodatki
    {


        private int did;
        private string dnazwadodatku;
        private double dcenadodatku;
        public int diloscdodatku;


        public int DId { get; set; }
        public string DNazwadodatku { get; set; }
        public double DCenadodatku { get; set; }
        public int DIloscdodatku { get; set; }

        public Dodatki() { }

        public Dodatki(int id, string nazwa, double cena, int ilosc)
        {
            did = id;
            dnazwadodatku = nazwa;
            dcenadodatku = cena;
            diloscdodatku = ilosc;




        }
    }
}
