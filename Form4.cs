using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PitypangHotel
{
    public partial class Form4 : Form
    {

        static List<Class1> foglalasok = new List<Class1>();

        public Form4()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            tableLayoutPanel2.BackColor = Color.FromArgb(0, 59, 149);
            tableLayoutPanel1.BackColor = Color.FromArgb(255, 255, 255);


            var betuTipus = new PrivateFontCollection();
            betuTipus.AddFontFile("Belanosima-Regular.ttf");
            label1.Font = new Font(betuTipus.Families[0], 12, FontStyle.Regular);
        }

        int unit = 1;
        TableLayoutPanel tableLayoutPanel6 = new TableLayoutPanel();

        public Foglalas[] foglalasok2;
        int foglalasokSzama;
        Honap[] honapok;
        string valasztottEv;
        string[] osszesEv;
        //TextBox textBox;

        private void Form4_Load(object sender, EventArgs e)
        {
            //File.Delete("bevetel_teszt.txt");




            // string[] honapok = { "JAN", "FEB", "MÁRC", "ÁPR", "MÁJ", "JÚN", "JÚL", "AUG", "SZEPT", "OKT", "NOV", "DEC" };











            StreamReader sr = new StreamReader("pitypang_teszt.txt", Encoding.UTF8);
            //sr.ReadLine(); //984
            string sor = "0";
            while (!sr.EndOfStream)
            {
                sor = sr.ReadLine();
                Class1 h = new Class1(sor);
                foglalasok.Add(h);
            }

            sr.Close();

            string maxNev = "";
            int maxErkezes = 0;
            int maxEltoltott = foglalasok[1].TavozasNapja - foglalasok[1].ErkezesNapja; ;


            for (int i = 0; i < foglalasok.Count; i++)
            {
                int tempEltoltott = foglalasok[i].TavozasNapja - foglalasok[i].ErkezesNapja;
                if (tempEltoltott > maxEltoltott)
                {
                    maxEltoltott = tempEltoltott;
                    maxErkezes = foglalasok[i].ErkezesNapja;
                    maxNev = foglalasok[i].Nev;
                }
            }

            textBox1.Text = maxNev + " (" + maxErkezes + ") - " + maxEltoltott;


            List<string> temp = new List<string>();

            //StreamWriter sw = new StreamWriter("bevetel.txt", true, Encoding.ASCII);

            for (int i = 0; i < foglalasok.Count; i++)
            {



                int szobaAr = 9000;
                if (foglalasok[i].ErkezesNapja >= 121 && foglalasok[i].ErkezesNapja < 244)
                {
                    szobaAr = 10000;
                }
                else if (foglalasok[i].ErkezesNapja >= 244)
                {
                    szobaAr = 8000;
                }


                int tempnapokSzama = foglalasok[i].TavozasNapja - foglalasok[i].ErkezesNapja;


                int tempOsszeg = (tempnapokSzama * szobaAr) + (tempnapokSzama * foglalasok[i].VendegekSzama * 1100);


                if (foglalasok[i].VendegekSzama != 2)
                {
                    tempOsszeg += tempnapokSzama * 2000;

                }


                int tempSorszam = foglalasok[i].Sorszam;

                string sorocska = tempSorszam + ";" + tempOsszeg + "\n";
                //textBox2.Text = Environment.NewLine + sorocska;
                temp.Add(sorocska);
                //sw.Write(sorocska);

            }

            textBox2.Text = String.Join(Environment.NewLine, temp);
            //sw.Close();
            //label1.Text = "A fájlba írás sikeres volt";












            //StreamReader pitypang = new StreamReader("Database\\" + ev + ".txt");
            StreamWriter bevetel = new StreamWriter("bevetel.txt");

           // foglalasokSzama = int.Parse(pitypang.ReadLine());
            foglalasok2 = new Foglalas[foglalasokSzama];
            string output = "";

            int maxI = 0;
            int maxV = 0;

            int[] vendegejStatisztika = new int[12];


            for (int i = 0; i < foglalasokSzama; i++)
            {
    

                if (foglalasok2[i].ejszakakSzama() == 1) // 4. feladat
                {
                    for (int j = 11; j >= 0; j--)
                    {

                        if (foglalasok2[i].erkezes > honapok[j].elsoNap)
                        {
                            vendegejStatisztika[j]++;
                            break;
                        }

                    }

                }


            }






            List<string> kii = new List<string>();


            for (int i = 0; i < 12; i++)
            {
                kii.Add($"{i + 1}: {vendegejStatisztika[i]} vendégéj\n");
            }

            textBox3.Text = String.Join(Environment.NewLine, kii);

        }






        class Honap
        {
            public string nev;
            public int hossz;
            public int elsoNap;

            public Honap(string nev, string hossz, string elsoNap)
            {
                this.nev = nev;
                this.hossz = int.Parse(hossz);
                this.elsoNap = int.Parse(elsoNap);
            }
        }


        public class Foglalas
        {
            public int sorszam;
            public int szobaszam;
            public int erkezes;
            public int tavozas;
            public int vendegSzam;
            public bool reggeli;
            public string vendegID;

            public Foglalas(string sor)
            {
                string[] szet = sor.Split(' ');

                sorszam = int.Parse(szet[0]);
                szobaszam = int.Parse(szet[1]);
                erkezes = int.Parse(szet[2]);
                tavozas = int.Parse(szet[3]);
                vendegSzam = int.Parse(szet[4]);
                reggeli = szet[5] == "1";
                vendegID = szet[6];
            }

            public int ejszakakSzama()
            {
                return this.tavozas - this.erkezes;
            }

            public int arSzamolas()
            {
                int osszeg = 0;

                if (this.erkezes < 121) // Tavasz
                {
                    osszeg += 9000;
                }
                else if (this.erkezes < 244) // Nyár
                {
                    osszeg += 10000;
                }
                else // Ősz
                {
                    osszeg += 8000;
                }

                if (this.vendegSzam > 2)
                {
                    osszeg += 2000;
                }

                if (this.reggeli)
                {
                    osszeg += this.vendegSzam * 1100;
                }

                return osszeg * this.ejszakakSzama();

            }
        }
    }
}
