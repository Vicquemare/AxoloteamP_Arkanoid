using System;
using System.Drawing;
using System.Windows.Forms;
using Metronoid.Classes.Game;
using Metronoid.Classes.Game.Graphics.Elements;
using Metronoid.Classes.Game.Levels;

namespace Metronoid
{
    public partial class MainGame : Form
    {
        public MainGame()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }
        private Engine _engine = null;
        private Level _lvlInfo = null; 
        private Brick[,] _bricks;
        private readonly Random _random = new Random();

        private void MainGame_Load(object sender, EventArgs e)
        {
            
        }

        private void MainGame_Shown(object sender, EventArgs e)
        {
            _lvlInfo = new Level1(ClientSize);
            LoadBricks();
            _engine = new Engine(this);
            /*Graphics g = this.CreateGraphics();
            g.DrawImage(megaman.anim.GetSprite(), 60, 10);
           
            megaman.anim.Start();*/
            _engine.Load(_lvlInfo);
            _engine.Start();
        }

        public void UpdateStage()
        {
            Invalidate();
        }

        private void MainGame_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Black, new Rectangle(0,0,Width, (int) (Height*0.3)));
            for (int i = 0; i < _lvlInfo.YAxis; i++)
            {
                for (int j = 0; j < _lvlInfo.XAxis; j++)
                {
                    if (_bricks[i ,j].Active)
                    {
                        e.Graphics.DrawImage(_lvlInfo.animBricks.anim.GetSprite(), _bricks[i ,j].Hitbox);
                    }
                }
            }
            //e.Graphics.DrawImage();
            
            
        }

        private void LoadBricks()
        {
            _bricks = new Brick[_lvlInfo.YAxis, _lvlInfo.XAxis];
            for (int i = 0; i < _lvlInfo.YAxis; i++)
            {
                for (int j = 0; j < _lvlInfo.XAxis; j++)
                {
                    Rectangle aux = new Rectangle(j * _lvlInfo.BrickWidth, i * _lvlInfo.BrickHeight, _lvlInfo.BrickWidth, _lvlInfo.BrickHeight);
                    int type = _random.Next(1, 4);
                    _bricks[i ,j] = new Brick(aux, type);
                    
                    /*Graphics g = this.CreateGraphics();
                    g.DrawRectangle(Pens.Blue, aux);
                    MessageBox.Show(aux.ToString());*/
                }
            }
        }
    }
}