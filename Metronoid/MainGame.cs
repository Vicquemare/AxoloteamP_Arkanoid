using System;
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
            Width = ClientSize.Width;
            Height = ClientSize.Height;
            WindowState = FormWindowState.Maximized;
            _lvlInfo = new Level1(ClientSize);
            LoadBricks();
        }
        private Engine _engine = null;
        private Level _lvlInfo = null; 
        private Brick[,] _bricks;
        private void MainGame_Load(object sender, EventArgs e)
        {
            
        }

        private void MainGame_Shown(object sender, EventArgs e)
        {
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
            //throw new System.NotImplementedException();
        }

        private void LoadBricks()
        {
            _bricks = new Brick[_lvlInfo.YAxis, _lvlInfo.XAxis];
        }
    }
}