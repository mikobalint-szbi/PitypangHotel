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

namespace PitypangHotel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            tableLayoutPanel2.BackColor = Color.FromArgb(0, 127, 115);
            tableLayoutPanel1.BackColor = Color.FromArgb(255, 255, 255);

            tableLayoutPanel5.BackColor = Color.FromArgb(0, 127, 115);

            var pfc = new PrivateFontCollection();
            pfc.AddFontFile("Belanosima-Regular.ttf"); 
            label1.Font = new Font(pfc.Families[0], 14, FontStyle.Regular);

            label6.Font = new Font(pfc.Families[0], 13, FontStyle.Regular);



        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            tableLayoutPanel4.Visible = true;
        }
    }
}
