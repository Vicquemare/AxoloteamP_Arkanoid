using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        public Form1(int sc)
        {
            InitializeComponent();
            //finalScore1.ChangeText(sc);
        }
        /*Megaman megaman = new Megaman();
        private Engine _engine = null;
        private readonly Random _random = new Random();*/
        private void button1_Click(object sender, EventArgs e)
        {
            //_engine = new Engine(this);
            /*Graphics g = this.CreateGraphics();
           g.DrawImage(megaman.anim.GetSprite(), 60, 10);
           
           megaman.anim.Start();
           _engine.Load(new Level1(ClientSize));
           _engine.Start();*/
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*megaman.anim.Update();
            Graphics g = this.CreateGraphics();
            g.DrawImage(megaman.anim.GetSprite(), 60, 10);*/
        }

        public void UpdateGraphics()
        {
            Invalidate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           // megaman.anim.Stop();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            //megaman.anim.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            /*megaman.anim.Update();
            //Graphics g = this.CreateGraphics();
            e.Graphics.DrawImage(megaman.anim.GetSprite(), 60, 10);
            //g.DrawImage(new Bitmap(1, 1), 90, 10);
            GraphicsUnit units = GraphicsUnit.Point;
            //RectangleF bmpRectangleF = megaman.anim.GetSprite().GetBounds(ref units);
            Rectangle bmpRectangle = Rectangle.Round(megaman.anim.GetSprite().GetBounds(ref units));
            bmpRectangle.X += 60;
            bmpRectangle.Y += 10;
            e.Graphics.DrawRectangle(Pens.Blue, bmpRectangle );*/

        }

        private void finalScore1_Load(object sender, EventArgs e)
        {
            
        }
    }
}