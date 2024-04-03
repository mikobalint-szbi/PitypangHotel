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

namespace PitypangHotel
{
    public partial class Form2 : Form
    {
        public Form2(int erkezes, int sorszam)
        {
            InitializeComponent();
            
            label5.Text = erkezes.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            var x = new Foglalas("");
            int szoba_szama;
            int tavozas_napja;
            int vendegek_szama;
            bool reggeli;
            string vendegID;
        }
    }
}
