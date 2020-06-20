using System;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        

        private void MainGame_Shown(object sender, EventArgs e)
        {
            GameState._lvlInfo = new Level1(ClientSize);
            GameState._player = new Player(ClientSize);
            int ballWidth = (int) (Width * 0.05);
            int ballHeight = (int) (Width * 0.05);
            int x = GameState._player.Hitbox.X + (GameState._player.Hitbox.Width / 2) - (ballWidth / 2);
            int y = GameState._player.Hitbox.Y - ballHeight;
            GameState._ball = new MorphBall(new Rectangle(x, y, ballWidth, ballHeight));
            
            GameState._life = new Life[GameState._maxLife];
            int lifeWidth = GameState._lvlInfo.AnimBackgrounds.UiHitbox.Height/2;
            int xLife = (int) (GameState._lvlInfo.AnimBackgrounds.UiHitbox.X + GameState._lvlInfo.AnimBackgrounds.UiHitbox.Width * 0.25);
            int yLife = (int) (GameState._lvlInfo.AnimBackgrounds.UiHitbox.Y + GameState._lvlInfo.AnimBackgrounds.UiHitbox.Height/2 - lifeWidth/2);
            
            for (int i = 0; i < GameState._maxLife; i++)
            {
                GameState._life[i] = new Life(new Rectangle(i* lifeWidth + xLife, yLife, lifeWidth, lifeWidth) );
            }
            //HitboxDelScore
            GameState._lvlInfo.UiElements.ScoreHitbox = new Rectangle((GameState._maxLife * lifeWidth + xLife), yLife , (int) (GameState._lvlInfo.AnimBackgrounds.UiHitbox.Width * 0.5),lifeWidth);
            // HitboxDelTextoDeVidas
            GameState._lvlInfo.UiElements.LifeTextHitbox = new Rectangle((GameState._lvlInfo.UiElements.Portrait.Hitbox.X + GameState._lvlInfo.UiElements.Portrait.Hitbox.Width), yLife , lifeWidth * GameState._maxLife,lifeWidth);
            
            LoadBricks();

            GameState._reward = new[] {100, 400, 500};
            GameState._endGame = GameState._lvlInfo.XAxis * GameState._lvlInfo.YAxis;
            GameState._engine = new Engine(this);
            
            GameState._engine.Load(GameState._lvlInfo);
            GameState._engine.Start();
            GameState._lvlInfo.AnimBackgrounds.anim.Start();
            GameState._ball.anim.Start();
            GameState._player.anim.Start();
            for (int i = 0; i < 3; i++)
            {
                GameState._lvlInfo.AnimBricks.animArr[i].Start();
            }
            GameState._lvlInfo.UiElements.Portrait.anim.Start();
            GameState._lvlInfo.UiElements.Life.anim.Start();
            
        }

        public void UpdateStage()
        {
            Invalidate();
            GameState._lvlInfo.AnimBackgrounds.anim.Update();
            GameState._ball.anim.Update();
            GameState._player.anim.Update();
            for (int i = 0; i < 3; i++)
            {
                GameState._lvlInfo.AnimBricks.animArr[i].Update();
            }
            GameState._lvlInfo.UiElements.Portrait.anim.Update();
            GameState._lvlInfo.UiElements.Life.anim.Update();

            BounceBall();
        }

        private void MainGame_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Black, new Rectangle(0,0,Width, (int) (Height*0.3)));
            for (int i = 0; i < GameState._lvlInfo.YAxis; i++)
            {
                for (int j = 0; j < GameState._lvlInfo.XAxis; j++)
                {
                    if (GameState._bricks[i ,j].Active)
                    {
                        e.Graphics.DrawImage(GameState._lvlInfo.AnimBricks.animArr[(GameState._bricks[i, j].Type-1)].GetSprite(), GameState._bricks[i ,j].Hitbox);
                    }
                }
            }
            e.Graphics.DrawImage(GameState._lvlInfo.AnimBackgrounds.anim.GetSprite(), new Rectangle(0,(int) (Height*0.3),Width, (int) (Height*0.7)));
            e.Graphics.DrawImage(GameState._player.anim.GetSprite(), GameState._player.Hitbox);
            e.Graphics.DrawImage(GameState._ball.anim.GetSprite(), GameState._ball.Hitbox);
            //e.Graphics.DrawRectangle(Pens.Black, GameState._player.Hitbox);
            //e.Graphics.DrawRectangle(Pens.Black, GameState._ball.Hitbox);
            e.Graphics.DrawImage(GameState._lvlInfo.AnimBackgrounds.animUI.GetSprite(), GameState._lvlInfo.AnimBackgrounds.UiHitbox);
            //e.Graphics.DrawRectangle(Pens.Chartreuse, GameState._lvlInfo.AnimBackgrounds.UiHitbox);
            e.Graphics.DrawImage(GameState._lvlInfo.UiElements.Portrait.anim.GetSprite(), GameState._lvlInfo.UiElements.Portrait.Hitbox);
            for (int i = 0; i < GameState._maxLife; i++)
            {
                e.Graphics.DrawImage(GameState._lvlInfo.UiElements.Life.anim.GetSprite(), GameState._life[i].Hitbox);
                //e.Graphics.DrawRectangle(Pens.Cyan,_life[i].Hitbox);
                
            }
            
            /*Rectangle rectangle3 = Rectangle.Intersect(GameState._player.Hitbox, GameState._ball.Hitbox);
            if (!rectangle3.IsEmpty)
            {
                e.Graphics.FillRectangle(Brushes.Green, rectangle3);
            }*/
            
            e.Graphics.DrawString("score: "+GameState._score.ToString(), GameState._lvlInfo.DrawFont, Brushes.White, GameState._lvlInfo.UiElements.ScoreHitbox, GameState._lvlInfo.DrawFormat);
            e.Graphics.DrawString("lives: ", GameState._lvlInfo.DrawFont, Brushes.White, GameState._lvlInfo.UiElements.LifeTextHitbox, GameState._lvlInfo.DrawFormat);

        }
        
        /* private void updateScore(string texto)
        {
            Bitmap bmp = new Bitmap(800,800);
            RectangleF rectf = new RectangleF(70, 90, 300, 300);
            Graphics g = Graphics.FromImage(bmp);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.DrawString(texto, new Font("Metroid Fusion",24), Brushes.White, rectf);

            g.Flush();

            score = bmp;
        }*/

        private void LoadBricks()
        {
            GameState._bricks = new Brick[GameState._lvlInfo.YAxis, GameState._lvlInfo.XAxis];
            for (int i = 0; i < GameState._lvlInfo.YAxis; i++)
            {
                for (int j = 0; j < GameState._lvlInfo.XAxis; j++)
                {
                    Rectangle aux = new Rectangle(j * GameState._lvlInfo.BrickWidth, i * GameState._lvlInfo.BrickHeight, GameState._lvlInfo.BrickWidth, GameState._lvlInfo.BrickHeight);
                    int type = GameState._random.Next(1, 4);
                    GameState._bricks[i ,j] = new Brick(aux, type);
                    
                    /*Graphics g = this.CreateGraphics();
                    g.DrawRectangle(Pens.Blue, aux);
                    MessageBox.Show(aux.ToString());*/
                }
            }
        }
        
        private void MainGame_Load(object sender, EventArgs e)
            {
               // string texto = "score: 18062020";
               // updateScore(texto);
            }

        private void MainGame_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X > (GameState._player.Hitbox.Width/2) && e.X < (Width - (GameState._player.Hitbox.Width/2)))
            {
                GameState._player.Hitbox.X = e.X - (GameState._player.Hitbox.Width/2);
                //_ball.Hitbox.X = _player.Hitbox.X + (_player.Hitbox.Width / 2) - (_ball.Hitbox.Width / 2);
                if (GameState._ball.State == 0) //La pelota se encuentra en la plataforma
                {
                    GameState._ball.Hitbox.X = e.X - (GameState._ball.Hitbox.Width/2);
                }
                //.Show(_player.Hitbox.Y.ToString());
                //_ball.Hitbox.Y = _player.Hitbox.Y + _ball.Hitbox.Height;
            }
            
        }

        /// <summary>
        /// Metodos para las fisicas de la pelota
        /// </summary>
        /// <returns></returns>
        private void BounceBall()
        {
            //Pelota
            if (GameState._ball.State == 1)
            {
                GameState._ball.Hitbox.X += GameState._ball.XSpeed;
                GameState._ball.Hitbox.Y += GameState._ball.YSpeed;
                
                //Bordes Laterales
                if (GameState._ball.Hitbox.X + GameState._ball.Hitbox.Width >= Width)
                {
                    GameState._ball.XSpeed = Math.Abs(GameState._ball.XSpeed) * (-1);
                } else if (GameState._ball.Hitbox.X <= 0)
                {
                    GameState._ball.XSpeed = Math.Abs(GameState._ball.XSpeed);
                }
                
                //Borde Superior
                if (GameState._ball.Hitbox.Y <= 0)
                {
                    GameState._ball.YSpeed = Math.Abs(GameState._ball.YSpeed);
                }
                //Bloques
                if (GameState._ball.Hitbox.Y <= Height*0.3)
                {
                    for (int i = GameState._lvlInfo.YAxis-1; i >= 0; i--)
                    {
                        for (int j = 0; j < GameState._lvlInfo.XAxis; j++)
                        {
                            if (GameState._ball.Hitbox.IntersectsWith(GameState._bricks[i, j].Hitbox) && GameState._bricks[i, j].Active)
                            {
                                GameState._bricks[i, j].Type -= 1;
                                GameState._score += GameState._reward[GameState._bricks[i, j].Type];
                                if (GameState._bricks[i, j].Type == 0)
                                {
                                    GameState._bricks[i, j].Active = false;
                                    GameState._endGame -= 1;
                                    if (GameState._endGame == 0)
                                    {
                                        GameState.Status = 1;
                                        MessageBox.Show("Juego terminado awa");
                                    }
                                }

                                //GameState._ball.XSpeed *= -1;
                                //GameState._ball.YSpeed *= -1;

                                bool[] collision = Collisions(GameState._bricks[i, j].Hitbox); //arriba, abajo, derecha, izquierda
                                if (collision[0])
                                {
                                    GameState._ball.YSpeed *= -1;
                                }
                                if (collision[1])
                                {
                                    GameState._ball.YSpeed = Math.Abs(GameState._ball.YSpeed) * -1;
                                }
                                if (collision[2])
                                {
                                    GameState._ball.XSpeed *= -1;
                                }

                                if (collision[3])
                                {
                                    GameState._ball.XSpeed *= -1;
                                }
                                
                                return;
                            }
                        }
                    }
                }
                
                //Jugador

                if (GameState._ball.Hitbox.Bottom >= Height*0.8)
                {
                    if (GameState._ball.Hitbox.IntersectsWith(GameState._player.Hitbox))
                    {
                        GameState._ball.YSpeed *= -1;
                        GameState._ball.Hitbox.Y = GameState._player.Hitbox.Y-GameState._ball.Hitbox.Height;
                        
                        
                        return;
                    }
                }

                if (GameState._ball.Hitbox.Y + GameState._ball.Hitbox.Height >= Height)
                {
                    GameState._ball.State = 0;
                    GameState._ball.Hitbox.X = GameState._player.Hitbox.X + (GameState._player.Hitbox.Width / 2) - (GameState._ball.Hitbox.Width / 2);
                    GameState._ball.Hitbox.Y = GameState._player.Hitbox.Y - GameState._ball.Hitbox.Height;
                    GameState._ball.XSpeed = Math.Abs(GameState._ball.XSpeed);
                    GameState._ball.YSpeed = Math.Abs(GameState._ball.YSpeed) * -1;
                }
            }

        }

        private void MainGame_MouseClick(object sender, MouseEventArgs e)
        {
            GameState.Status = 1;
            GameState._ball.State = 1;
        }
        
        public bool[] Collisions(Rectangle rect)
        {
            var intersection = Rectangle.Intersect(GameState._ball.Hitbox, rect);
            if(intersection.IsEmpty){
                return new []{ false, false, false, false };
            }

            bool hitSomethingAbove = GameState._ball.Hitbox.Top == intersection.Top;
            bool hitSomethingBelow = GameState._ball.Hitbox.Bottom == intersection.Bottom;
            bool hitSomethingOnTheRight = GameState._ball.Hitbox.Right == intersection.Right;
            bool hitSomethingOnTheLeft = GameState._ball.Hitbox.Left == intersection.Left;

            return new bool[] 
            { 
                hitSomethingAbove, 
                hitSomethingBelow, 
                hitSomethingOnTheRight, 
                hitSomethingOnTheLeft, 
            };
        }
    }
}