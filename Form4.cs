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



        private void Form4_Load(object sender, EventArgs e)
        {
            File.Delete("bevetel_teszt.txt");

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

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




            StreamWriter sw = new StreamWriter("bevetel.txt", true, Encoding.ASCII);

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
                sw.Write(sorocska);

            }

            sw.Close();
            //label1.Text = "A fájlba írás sikeres volt";

        }

   
    }
}
