using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PitypangHotel
{
    internal class Class1
    {

        private int sorszam;
        private int szobakSzama;
        private int erkezesNapja;
        private int tavozasNapja;
        private int vendegekSzama;
        private int reggeli;
        private string nev;



        public Class1(string sor)
        {
            string[] d = sor.Split(' ');


            sorszam = Convert.ToInt32(d[0]);
            szobakSzama = Convert.ToInt32(d[1]);
            erkezesNapja = Convert.ToInt32(d[2]);
            tavozasNapja = Convert.ToInt32(d[3]);
            vendegekSzama = Convert.ToInt32(d[4]);
            reggeli = Convert.ToInt32(d[5]);
            nev = d[6];


        }

        public int Sorszam { get => sorszam; set => sorszam = value; }
        public int SzobakSzama { get => szobakSzama; set => szobakSzama = value; }

        public int ErkezesNapja { get => erkezesNapja; set => erkezesNapja = value; }

        public int TavozasNapja { get => tavozasNapja; set => tavozasNapja = value; }

        public int VendegekSzama { get => vendegekSzama; set => vendegekSzama = value; }

        public int Reggeli { get => reggeli; set => reggeli = value; }

        public string Nev { get => nev; set => nev = value; }





    }
}