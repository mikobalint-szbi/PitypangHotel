﻿using System;
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

            tableLayoutPanel2.BackColor = Color.FromArgb(0, 127, 115);
            tableLayoutPanel1.BackColor = Color.FromArgb(255, 255, 255);
            tableLayoutPanel5.BackColor = Color.FromArgb(0, 127, 115);


            var betuTipus = new PrivateFontCollection();
            betuTipus.AddFontFile("Belanosima-Regular.ttf"); 
            label1.Font = new Font(betuTipus.Families[0], 14, FontStyle.Regular);


        }

        int unit = 1;

        private void Form1_Load(object sender, EventArgs e)
        {

            this.BackColor = Color.FromArgb(0, 127, 115);

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            Label nagySzoveg = new Label()
;           this.Controls.Add(nagySzoveg);

            nagySzoveg.Top = 120;
            nagySzoveg.Left = 120;
            unit = unit + 1;

            nagySzoveg.ForeColor = Color.White;

            var betuTipus = new PrivateFontCollection();
            betuTipus.AddFontFile("Belanosima-Regular.ttf");
            nagySzoveg.Font = new Font(betuTipus.Families[0], 46, FontStyle.Regular);


            nagySzoveg.Size = new Size(800, 180);
            nagySzoveg.TextAlign = ContentAlignment.MiddleCenter;
            nagySzoveg.Text = "Üdvözlünk a Pitypang Hotel asztali alkalmazásában";



            Button foglalas = new Button();
            foglalas.Height = 50;
            foglalas.Width = 120;
            //foglalas.BackColor = Color.Red;
            foglalas.ForeColor = Color.White;
            foglalas.Location = new Point(360, 300);
            foglalas.Text = "Foglalás";
            foglalas.Name = "foglalasButton";
            foglalas.Font = new Font(betuTipus.Families[0], 14, FontStyle.Regular);
            foglalas.Click += new EventHandler(foglalasButton_Click);
            Controls.Add(foglalas);

            Button stat = new Button();
            stat.Height = 50;
            stat.Width = 120;
            //stat.BackColor = Color.Red;
            stat.ForeColor = Color.White;
            stat.Location = new Point(550, 300);
            stat.Text = "Statisztika";
            stat.Name = "statButton";
            stat.Font = new Font(betuTipus.Families[0], 14, FontStyle.Regular);
            stat.Click += new EventHandler(statButton_Click);
            Controls.Add(stat);

        }

        private void foglalasButton_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Visible = true;

            label2.Font = new Font("Microsoft YaHei UI", 10, FontStyle.Bold);
            label3.Font = new Font("Microsoft YaHei UI", 10, FontStyle.Regular);

        }

        private void statButton_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Visible = true;
            tableLayoutPanel4.Visible = false;

            label2.Font = new Font("Microsoft YaHei UI", 10, FontStyle.Regular);
            label3.Font = new Font("Microsoft YaHei UI", 10, FontStyle.Bold);

        }

        private void label2_Click(object sender, EventArgs e)
        {
           // tableLayoutPanel4.Visible = true;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }
    }
}
