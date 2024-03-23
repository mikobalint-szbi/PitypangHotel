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

            this.StartPosition = FormStartPosition.CenterScreen;

            tableLayoutPanel2.BackColor = Color.FromArgb(0, 59, 149);
            tableLayoutPanel1.BackColor = Color.FromArgb(255, 255, 255);
            tableLayoutPanel5.BackColor = Color.FromArgb(0, 59, 149);


            var betuTipus = new PrivateFontCollection();
            betuTipus.AddFontFile("Belanosima-Regular.ttf"); 
            label1.Font = new Font(betuTipus.Families[0], 14, FontStyle.Regular);


        }

        int unit = 1;

        private void Form1_Load(object sender, EventArgs e)
        {

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

            label2.Font = new Font("Microsoft YaHei UI", 10, FontStyle.Regular);
            label3.Font = new Font("Microsoft YaHei UI", 10, FontStyle.Bold);

            /* Statisztika kódja ide */



        }
    }
}
