using Metronoid.Classes.Game.Graphics.Elements;

namespace Metronoid.Classes.Game.Levels
{
    public abstract class Level
    {
        public int XAxis;
        public int YAxis;
        public int BrickHeight;
        public int BrickWidth;
        public AnimBrick animBricks;
        public AnimBackground animBackgrounds;
    }
}