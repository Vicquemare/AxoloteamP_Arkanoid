using System.Drawing;

namespace Metronoid.Classes.Game.Elements
{
    public partial class Portrait
    {
        public Rectangle Hitbox;
        public int State;

        public Portrait(Rectangle hitbox)
        {
            Hitbox = hitbox;
            State = 1;
        }
    }
}