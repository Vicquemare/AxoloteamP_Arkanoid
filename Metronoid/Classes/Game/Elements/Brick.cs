using System.Drawing;

namespace Metronoid.Classes.Game.Graphics.Elements
{
    public partial class Brick
    {
        public Rectangle Hitbox;
        public int Type;

        public Brick(Rectangle hitbox, int type)
        {
            Hitbox = hitbox;
            Type = type;++
        }
    }
}