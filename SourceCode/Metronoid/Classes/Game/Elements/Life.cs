using System.Drawing;

namespace Metronoid.Classes.Game.Elements
{
    public class Life
    {
        public Rectangle Hitbox;
        public bool Active;

        public Life(Rectangle hitbox)
        {
            Hitbox = hitbox;
            Active = true;
        }
    }
}