using System.Drawing;
using System;
using System.IO;
using System.Windows.Forms;
using Metronoid.Classes.Game.Elements;
using Metronoid.Classes.Game.Graphics.Elements;

namespace Metronoid.Classes.Game.Levels
{
    public class Level1: Level
    {
        public Level1(Size clientSize)
        {
            XAxis = 10; 
            YAxis = 5;
            BrickHeight = (int) (clientSize.Height * 0.3) / YAxis;
            BrickWidth = clientSize.Width / XAxis;
            AnimBricks = new AnimBrick();
            AnimBackgrounds = new AnimBackground();
            AnimBackgrounds.UiHitbox = new Rectangle(0, (int) (clientSize.Height * 0.85), clientSize.Width, (int) (clientSize.Height*0.15));
            UiElements = new UiCollection {Life = new AnimLife(), Portrait = new Portrait(new Rectangle((int) (AnimBackgrounds.UiHitbox.X + (AnimBackgrounds.UiHitbox.Width * 0.05)), (int) (AnimBackgrounds.UiHitbox.Y + (AnimBackgrounds.UiHitbox.Height * 0.15)), (int) (AnimBackgrounds.UiHitbox.Height - ((AnimBackgrounds.UiHitbox.Height * 0.15)*2)), (int) (AnimBackgrounds.UiHitbox.Height - ((AnimBackgrounds.UiHitbox.Height * 0.15)*2)) )), ScoreHitbox = new Rectangle(), LifeTextHitbox = new Rectangle(), ComboHitbox = new Rectangle()};
            DrawFormat = new StringFormat();
            //DrawFormat.Alignment = StringAlignment.Center;
            DrawFormat.LineAlignment = StringAlignment.Center;
            try{
            DrawFont = new Font("Metroid Fusion", 24);
            
            } catch (IOException e) {
                MessageBox.Show("Error al cargar el elemento");
            }

        }
    }
}