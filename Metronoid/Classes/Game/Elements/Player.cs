using System.Drawing;

namespace Metronoid.Classes.Game.Elements
{
    public partial class Player
    {
        public Rectangle Hitbox;

        public Player(Size clientSize)
        {
            Hitbox = new Rectangle(0, (int) (clientSize.Height * 0.8), (int) (clientSize.Width * 0.1), (int) (clientSize.Height * 0.05));
        }
    }
}