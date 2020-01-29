using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaroSYSTEM2809
{
  public  class Dodatki
    {


        private int did;
        private string dnazwadodatku;
        private double dcenadodatku;
        private int diloscdodatku;


        public int DId { get; set; }
        public string DNazwadodatku { get; set; }
        public double DCenadodatku { get; set; }
        public int DIloscdodatku { get; set; }

        public Dodatki() { }

        public Dodatki(int did, string dnazwadodatku, double dcenadodatku, int diloscdodatku)
        {
            this.did = DId;
            this.dnazwadodatku = dnazwadodatku;
            this.dcenadodatku = dcenadodatku;
            this.diloscdodatku = diloscdodatku;




        }
    }
}
