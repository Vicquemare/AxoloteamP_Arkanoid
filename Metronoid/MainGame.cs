using System;
using System.Drawing;
using System.Windows.Forms;
using Metronoid.Classes.Game;
using Metronoid.Classes.Game.Elements;
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
        private Player _player = null;
        private MorphBall _ball = null;
        private int _maxLife = 3;
        private Life[] _life = null;
        private readonly Random _random = new Random();

        private void MainGame_Load(object sender, EventArgs e)
        {
            
        }

        private void MainGame_Shown(object sender, EventArgs e)
        {
            _lvlInfo = new Level1(ClientSize);
            _player = new Player(ClientSize);
            int ballWidth = (int) (Width * 0.05);
            int ballHeight = (int) (Width * 0.05);
            int x = _player.Hitbox.X + (_player.Hitbox.Width / 2) - (ballWidth / 2);
            int y = _player.Hitbox.Y - ballHeight;
            _ball = new MorphBall(new Rectangle(x, y, ballWidth, ballHeight));
            
            _life = new Life[_maxLife];
            int lifeWidth = _lvlInfo.AnimBackgrounds.UiHitbox.Height/2;
            int xLife = (int) (_lvlInfo.AnimBackgrounds.UiHitbox.X + _lvlInfo.AnimBackgrounds.UiHitbox.Width * 0.25);
            int yLife = (int) (_lvlInfo.AnimBackgrounds.UiHitbox.Y + _lvlInfo.AnimBackgrounds.UiHitbox.Height/2 - lifeWidth/2);
            
            for (int i = 0; i < _maxLife; i++)
            {
                _life[i] = new Life(new Rectangle(i* lifeWidth + xLife, yLife, lifeWidth, lifeWidth) );
            }
            
            LoadBricks();
            _engine = new Engine(this);
            
            _engine.Load(_lvlInfo);
            _engine.Start();
            _lvlInfo.AnimBackgrounds.anim.Start();
            _ball.anim.Start();
            _player.anim.Start();
            for (int i = 0; i < 3; i++)
            {
                _lvlInfo.AnimBricks.animArr[i].Start();
            }
            _lvlInfo.UiElements.Portrait.anim.Start();
            _lvlInfo.UiElements.Life.anim.Start();
            
        }

        public void UpdateStage()
        {
            Invalidate();
            _lvlInfo.AnimBackgrounds.anim.Update();
            _ball.anim.Update();
            _player.anim.Update();
            for (int i = 0; i < 3; i++)
            {
                _lvlInfo.AnimBricks.animArr[i].Update();
            }
            _lvlInfo.UiElements.Portrait.anim.Update();
            _lvlInfo.UiElements.Life.anim.Update();
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
                        e.Graphics.DrawImage(_lvlInfo.AnimBricks.animArr[(_bricks[i, j].Type-1)].GetSprite(), _bricks[i ,j].Hitbox);
                    }
                }
            }
            e.Graphics.DrawImage(_lvlInfo.AnimBackgrounds.anim.GetSprite(), new Rectangle(0,(int) (Height*0.3),Width, (int) (Height*0.7)));
            e.Graphics.DrawImage(_player.anim.GetSprite(), _player.Hitbox);
            e.Graphics.DrawImage(_ball.anim.GetSprite(), _ball.Hitbox);
            //e.Graphics.DrawRectangle(Pens.Black, _ball.Hitbox);
            e.Graphics.DrawImage(_lvlInfo.AnimBackgrounds.animUI.GetSprite(), _lvlInfo.AnimBackgrounds.UiHitbox);
            e.Graphics.DrawRectangle(Pens.Chartreuse, _lvlInfo.AnimBackgrounds.UiHitbox);
            e.Graphics.DrawImage(_lvlInfo.UiElements.Portrait.anim.GetSprite(), _lvlInfo.UiElements.Portrait.Hitbox);
            for (int i = 0; i < _maxLife; i++)
            {
                e.Graphics.DrawImage(_lvlInfo.UiElements.Life.anim.GetSprite(), _life[i].Hitbox);
                //e.Graphics.DrawRectangle(Pens.Cyan,_life[i].Hitbox);
                
            }
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

        private void MainGame_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X > (_player.Hitbox.Width/2) && e.X < (Width - (_player.Hitbox.Width/2)))
            {
                _player.Hitbox.X = e.X - (_player.Hitbox.Width/2);
                //_ball.Hitbox.X = _player.Hitbox.X + (_player.Hitbox.Width / 2) - (_ball.Hitbox.Width / 2);
                _ball.Hitbox.X = e.X - (_ball.Hitbox.Width/2);
                //.Show(_player.Hitbox.Y.ToString());
                //_ball.Hitbox.Y = _player.Hitbox.Y + _ball.Hitbox.Height;
            }
            
        }
    }
}