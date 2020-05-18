﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Metronoid.Classes.Game.Graphics.Animations;
using Metronoid.Classes.Game.Graphics.Templates;

namespace Metronoid
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Megaman megaman = new Megaman();
        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
           g.DrawImage(megaman.anim.GetSprite(), 60, 10);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}