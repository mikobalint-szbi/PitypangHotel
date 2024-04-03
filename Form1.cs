using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;
using System.IO;
using System.Diagnostics;

namespace PitypangHotel
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            tableLayoutPanel2.BackColor = Color.FromArgb(0, 59, 149);
            tableLayoutPanel1.BackColor = Color.FromArgb(255, 255, 255);
            tableLayoutPanel5.BackColor = Color.FromArgb(0, 59, 149);


            var betuTipus = new PrivateFontCollection();
            betuTipus.AddFontFile("Belanosima-Regular.ttf"); 
            label1.Font = new Font(betuTipus.Families[0], 14, FontStyle.Regular);

        }

        int unit = 1;
        TableLayoutPanel tableLayoutPanel6 = new TableLayoutPanel();

        Foglalas[] foglalasok;
        int foglalasokSzama;
        Honap[] honapok;
        string valasztottEv;
        string[] osszesEv;
        TextBox textBox;

        private void Form1_Load(object sender, EventArgs e)
        {
            osszesEv = Directory.GetFiles("Database");
            valasztottEv = osszesEv[osszesEv.Length-1];

            foreach (var ev in osszesEv)
            {
                comboBox1.Items.Add(ev.Split('\\')[1].Split('.')[0]);
            }
            comboBox1.SelectedIndex = comboBox1.Items.Count-1;




            // string[] honapok = { "JAN", "FEB", "MÁRC", "ÁPR", "MÁJ", "JÚN", "JÚL", "AUG", "SZEPT", "OKT", "NOV", "DEC" };

            StreamReader honapokFile = new StreamReader("honapok.txt");
            honapok = new Honap[12];

            for (int i = 0; i < 12; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].HeaderCell.Value = (i+1).ToString("D2");

                honapok[i] = new Honap(honapokFile.ReadLine(), honapokFile.ReadLine(), honapokFile.ReadLine());
            }


            honapokFile.Close();

            comboBox2.SelectedIndex = 0;


            string output = evFeldolgozas(comboBox1.SelectedItem.ToString());
            szobaSzamitas(1);





            tableLayoutPanel6.Visible = false;
            tableLayoutPanel6.ColumnCount = 3;
            tableLayoutPanel6.RowCount = 3;

            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 90F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));

            tableLayoutPanel6.Dock = DockStyle.Fill;

            tableLayoutPanel1.Controls.Add(tableLayoutPanel6);

            textBox = new TextBox();
            tableLayoutPanel6.Controls.Add(textBox, 1, 1);
            tableLayoutPanel6.Visible = false;
            textBox.Multiline = true;
            textBox.Enabled = false;
            textBox.ForeColor = Color.Black;
            textBox.Dock = DockStyle.Fill;
            textBox.Text = output.Replace("\n",Environment.NewLine);
            textBox.Font = new Font("Consolas", 14);

            var betuTipus = new PrivateFontCollection();
            betuTipus.AddFontFile("Belanosima-Regular.ttf");

            this.BackColor = Color.FromArgb(0, 59, 149);

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;


            Label nagySzoveg = new Label()
;           this.Controls.Add(nagySzoveg);
            nagySzoveg.Top = 120;
            nagySzoveg.Left = 120;
            unit = unit + 1;
            nagySzoveg.ForeColor = Color.White;
            nagySzoveg.Font = new Font(betuTipus.Families[0], 46, FontStyle.Regular);
            nagySzoveg.Size = new Size(800, 180);
            nagySzoveg.TextAlign = ContentAlignment.MiddleCenter;
            nagySzoveg.Text = "Üdvözlünk a Pitypang Hotel asztali alkalmazásában";

            Label kisSzoveg = new Label();           
            this.Controls.Add(kisSzoveg);
            kisSzoveg.Top = 547;
            kisSzoveg.Left = 10;
            unit = unit + 1;
            kisSzoveg.ForeColor = Color.White;
            kisSzoveg.Size = new Size(1000, 15);
            kisSzoveg.Text = "Készítette: Mikó Bálint, Benyeda Gábor, Vinars Dániel, Szalkai-Szabó Ádám és Horváth Dániel";
            kisSzoveg.Font = new Font("Microsoft YaHei UI", 7, FontStyle.Regular);



            Button foglalas = new Button();
            foglalas.Height = 50;
            foglalas.Width = 120;
            foglalas.BackColor = Color.White; 
            foglalas.ForeColor = Color.FromArgb(0, 59, 149);
            foglalas.Location = new Point(370, 300);
            foglalas.Text = "Foglalás";
            foglalas.Name = "foglalasButton";
            foglalas.Font = new Font(betuTipus.Families[0], 14, FontStyle.Regular);
            foglalas.Click += new EventHandler(foglalasButton_Click);
            Controls.Add(foglalas);

            Button stat = new Button();
            stat.Height = 50;
            stat.Width = 120;
            stat.BackColor = Color.White;
            stat.ForeColor = Color.FromArgb(0, 59, 149);
            stat.Location = new Point(520, 300);
            stat.Text = "Statisztika";
            stat.Name = "statButton";
            stat.Font = new Font(betuTipus.Families[0], 14, FontStyle.Regular);
            stat.Click += new EventHandler(statButton_Click);
            Controls.Add(stat);

        }

        public string evFeldolgozas(string ev)
        {
            if (int.Parse(ev) % 4 == 0 && int.Parse(ev) % 100 != 0)
            {
                if (honapok[1].hossz == 28)
                {
                    honapok[1].hossz++;

                    for (int i = 2; i < 12; i++)
                    {
                        honapok[i].elsoNap++;
                    }
                }
                
            }
            else
            {
                if (honapok[1].hossz == 29)
                {
                    honapok[1].hossz--;

                    for (int i = 2; i < 12; i++)
                    {
                        honapok[i].elsoNap--;
                    }
                }
            }


                StreamReader pitypang = new StreamReader("Database\\" + ev + ".txt");
            StreamWriter bevetel = new StreamWriter("bevetel.txt");

            foglalasokSzama = int.Parse(pitypang.ReadLine());
            foglalasok = new Foglalas[foglalasokSzama];
            string output = "";

            int maxI = 0;
            int maxV = 0;

            int[] vendegejStatisztika = new int[12];


            for (int i = 0; i < foglalasokSzama; i++)
            {
                foglalasok[i] = new Foglalas(pitypang.ReadLine());

                if (foglalasok[i].ejszakakSzama() > maxV) // 2. feladat
                {
                    maxI = i;
                    maxV = foglalasok[i].ejszakakSzama();
                }

                if (foglalasok[i].ejszakakSzama() == 1) // 4. feladat
                {
                    for (int j = 11; j >= 0; j--)
                    {

                        if (foglalasok[i].erkezes > honapok[j].elsoNap)
                        {
                            vendegejStatisztika[j]++;
                            break;
                        }

                    }

                }



                bevetel.WriteLine($"{foglalasok[i].sorszam}:{foglalasok[i].arSzamolas()}"); // 3. feladat
            }

            output += $"2. feladat:\n{foglalasok[maxI].vendegID} ({foglalasok[maxI].erkezes}) – {maxV}\n\n";

            output += "4. feladat:\n";
            for (int i = 0; i < 12; i++)
            {
                output += $"{i + 1}: {vendegejStatisztika[i]} vendégéj\n";
            }

            pitypang.Close();
            bevetel.Close();

            return output;
        }

        public void szobaSzamitas(int szobaSzam)
        {

            for (int row = 0; row < 12; row++)
            {
                for (int col = 0; col < 31; col++)
                {
                    if (col < honapok[row].hossz)
                        dataGridView1.Rows[row].Cells[col].Style.BackColor = Color.FromArgb(0, 59, 149);
                    else
                        dataGridView1.Rows[row].Cells[col].Style.BackColor = Color.Gray;
                }
            }

            for (int i = 0; i < foglalasokSzama; i++)
            {

                if (foglalasok[i].szobaszam == szobaSzam)
                {

                    int erkez_ho = 0;
                    int erkez_nap = foglalasok[i].erkezes;

                    while (erkez_nap > honapok[erkez_ho].hossz)
                    {
                        erkez_nap -= honapok[erkez_ho].hossz;
                        erkez_ho++;
                    }

                    int tavoz_ho = 0;
                    int tavoz_nap = foglalasok[i].tavozas;

                    while (tavoz_nap > honapok[tavoz_ho].hossz)
                    {
                        tavoz_nap -= honapok[tavoz_ho].hossz;
                        tavoz_ho++;
                    }

                    while (!(erkez_ho == tavoz_ho && erkez_nap == tavoz_nap))
                    {
                        dataGridView1.Rows[erkez_ho].Cells[erkez_nap - 1].Style.BackColor = Color.Red;

                        if (erkez_nap == honapok[erkez_ho].hossz)
                        {
                            erkez_nap = 1;
                            erkez_ho++;
                        }
                        else
                        {
                            erkez_nap++;
                        }
                    }

                    
                }


            }
        }

        private void foglalasButton_Click(object sender, EventArgs e)
        {

            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.MinimumSize = new System.Drawing.Size(600, 600);

            tableLayoutPanel1.Visible = true;

            label2.Font = new Font("Microsoft YaHei UI", 10, FontStyle.Bold);
            label3.Font = new Font("Microsoft YaHei UI", 10, FontStyle.Regular);

            /* Foglalás kódja ide */



        }

        private void statButton_Click(object sender, EventArgs e)
        {

            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.MinimumSize = new System.Drawing.Size(600, 600);

            tableLayoutPanel1.Visible = true;
            tableLayoutPanel4.Visible = false;
            tableLayoutPanel6.Visible = true;

            label2.Font = new Font("Microsoft YaHei UI", 10, FontStyle.Regular);
            label3.Font = new Font("Microsoft YaHei UI", 10, FontStyle.Bold);


            /* Statisztika kódja ide */

            

        }

        private void label2_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Visible = true;
            tableLayoutPanel4.Visible = true;

            label2.Font = new Font("Microsoft YaHei UI", 10, FontStyle.Bold);
            label3.Font = new Font("Microsoft YaHei UI", 10, FontStyle.Regular);

            /* Foglalás kódja ide */



        }

        private void label3_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Visible = true;
            tableLayoutPanel4.Visible = false;
            tableLayoutPanel6.Visible = true;

            label2.Font = new Font("Microsoft YaHei UI", 10, FontStyle.Regular);
            label3.Font = new Font("Microsoft YaHei UI", 10, FontStyle.Bold);

            /* Statisztika kódja ide */



        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            szobaSzamitas(int.Parse(comboBox2.SelectedItem.ToString()));
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (honapok != null)
            {
                textBox.Text = evFeldolgozas(comboBox1.SelectedItem.ToString()).Replace("\n", Environment.NewLine);
                szobaSzamitas(int.Parse(comboBox2.SelectedItem.ToString()));
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Form2 dialog = new Form2(honapok[e.RowIndex].elsoNap + e.ColumnIndex + 1,foglalasokSzama+1);
            dialog.ShowDialog();


        }
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
