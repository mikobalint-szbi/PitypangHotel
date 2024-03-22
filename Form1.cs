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

            tableLayoutPanel2.BackColor = Color.FromArgb(55, 140, 231);
            tableLayoutPanel1.BackColor = Color.FromArgb(223, 245, 255);

           /* var pfc = new PrivateFontCollection();
            pfc.AddFontFile("Lexend-VariableFont_wght.ttf");  //Bitmgothic.ttf
            label1.Font = new Font(pfc.Families[0], 16, FontStyle.Regular);*/

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
