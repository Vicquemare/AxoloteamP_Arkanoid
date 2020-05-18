using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Metronoid.Classes.Game;
using Metronoid.Classes.Game.Graphics.Animations;
using Metronoid.Classes.Game.Graphics.Templates;
using Metronoid.Classes.Game.Levels;

namespace Metronoid
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Megaman megaman = new Megaman();
        private Engine _engine = null;
        private void button1_Click(object sender, EventArgs e)
        {
            _engine = new Engine(this);
            Graphics g = this.CreateGraphics();
           g.DrawImage(megaman.anim.GetSprite(), 60, 10);
           
           megaman.anim.Start();
           _engine.Load(new Level1());
           _engine.Start();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            megaman.anim.Update();
            Graphics g = this.CreateGraphics();
            g.DrawImage(megaman.anim.GetSprite(), 60, 10);
        }

        public void UpdateGraphics()
        {
            megaman.anim.Update();
            Graphics g = this.CreateGraphics();
            g.DrawImage(megaman.anim.GetSprite(), 60, 10);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            megaman.anim.Stop();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            megaman.anim.Start();
        }
    }
}