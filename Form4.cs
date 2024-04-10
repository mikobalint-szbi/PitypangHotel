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
    public partial class Form4 : Form
    {
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
        
          
        }

   
    }
}
