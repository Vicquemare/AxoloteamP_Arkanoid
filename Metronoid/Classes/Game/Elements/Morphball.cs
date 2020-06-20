using System.Drawing;

namespace Metronoid.Classes.Game.Elements
{
    public partial class MorphBall
    {
        public Rectangle Hitbox;
        public int State; // 0 on player, 1 bouncing
        public int XSpeed;
        public int YSpeed;

        public MorphBall(Rectangle hitbox)
        {
            Hitbox = hitbox;
            State = 0;
            XSpeed = 20*2;
            YSpeed = -5*2;
        }
    }
}