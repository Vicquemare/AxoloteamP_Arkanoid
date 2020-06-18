using System.Drawing;
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
            animBricks = new AnimBrick();
            animBackgrounds = new AnimBackground();
            animBackgrounds.UiHitbox = new Rectangle(0, (int) (clientSize.Height * 0.85), clientSize.Width, (int) (clientSize.Height*0.15));
        }
    }
}