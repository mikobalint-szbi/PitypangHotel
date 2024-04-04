using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PitypangHotel;
using System.IO;

namespace PitypangHotel
{
    public partial class Form2 : Form
    {
        int erkezes;
        int sorszam;
        string valasztottEv;
        public bool mehet = false;
        public Form2(int erkezes, int sorszam, string valasztottEv)
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            
            label5.Text = erkezes.ToString();
            this.erkezes = erkezes;
            this.sorszam = sorszam;
            this.valasztottEv = valasztottEv;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string reggeli = radioButton1.Checked ? "1" : "0";
            var foglalasRaw = $"\n{sorszam} {comboBox1.SelectedItem.ToString()} {erkezes} {erkezes+numericUpDown1.Value} {numericUpDown2.Value} {reggeli} {textBox1.Text.Replace(" ","_")}";

            File.AppendText("Database//" + valasztottEv + ".txt");
            StreamWriter file = new StreamWriter("Database//" + valasztottEv + ".txt");
            file.WriteLine(foglalasRaw);
            file.Close();

            var foglalas = new Foglalas(foglalasRaw);

            this.Hide();
            mehet = true;
        }
    }
}
