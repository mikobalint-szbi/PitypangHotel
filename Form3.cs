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

namespace PitypangHotel
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            var betuTipus = new PrivateFontCollection();
            betuTipus.AddFontFile("Belanosima-Regular.ttf");
            label1.Text = "Üdvözlünk a Pitypang Hotel alkalmazásában";
            label1.Font = new Font(betuTipus.Families[0], 13, FontStyle.Regular);

            label1.ForeColor = Color.FromArgb(0, 59, 149);

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form1().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Form4().ShowDialog();
        }
    }
}
