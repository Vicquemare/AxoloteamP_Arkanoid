using System.Drawing;
using Metronoid.Classes.Game.Elements;
using Metronoid.Classes.Game.Graphics.Elements;

namespace Metronoid.Classes.Game.Levels
{
    public abstract class Level
    {
        public int XAxis;
        public int YAxis;
        public int BrickHeight;
        public int BrickWidth;
        public AnimBrick AnimBricks;
        public AnimBackground AnimBackgrounds;
        public UiCollection UiElements;
        public StringFormat DrawFormat;
        public Font DrawFont;
        
        public class UiCollection
        {
            public Portrait Portrait;
            public AnimLife Life;
            public Rectangle ScoreHitbox = new Rectangle(); 
            public Rectangle LifeTextHitbox = new Rectangle(); 
            public Rectangle ComboHitbox = new Rectangle(); 
        } 
    }
}