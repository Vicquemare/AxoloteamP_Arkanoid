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
        
        public class UiCollection
        {
            public Portrait Portrait;
            public AnimLife Life;
        } 
    }
}