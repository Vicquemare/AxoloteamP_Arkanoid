using System.Drawing;
using Metronoid.Classes.Game.Graphics.Templates;

namespace Metronoid.Classes.Game.Graphics.Elements
{
    public class AnimBrick
    {
        private static string _spritesheet = "enemy1";
        private static string _spritesheet2 = "enemy2";
        private static string _spritesheet3 = "enemy3";
        
        private static readonly Bitmap[] _idle;
        private static readonly Bitmap[] _idle2;
        private static readonly Bitmap[] _idle3;
        
        //private static Metronoid.Classes.Game.Graphics.Templates.Animation _animIddle = new Metronoid.Classes.Game.Graphics.Templates.Animation(_idle, 10);
        //public Metronoid.Classes.Game.Graphics.Templates.Animation anim = _animIddle;
        public Animation[] animArr = {new Animation(_idle, 10), new Animation(_idle2, 10), new Animation(_idle3, 10)  };

        static AnimBrick()
        {
            _idle = new[] {
                Sprite.getSprite(0, 0, _spritesheet), Sprite.getSprite(1, 0, _spritesheet), Sprite.getSprite(2, 0, _spritesheet), Sprite.getSprite(3, 0, _spritesheet)
            };
            _idle2 = new[] {
                Sprite.getSprite(0, 0, _spritesheet2), Sprite.getSprite(1, 0, _spritesheet2), Sprite.getSprite(2, 0, _spritesheet2), Sprite.getSprite(3, 0, _spritesheet2)
            };
            _idle3 = new[] {
                Sprite.getSprite(0, 0, _spritesheet3), Sprite.getSprite(1, 0, _spritesheet3), Sprite.getSprite(2, 0, _spritesheet3), Sprite.getSprite(3, 0, _spritesheet3)
            };
        }

        public static Bitmap[] Idle
        {
            get => _idle;
        }

        /*public static Templates.Animation AnimIddle
        {
            get => _animIddle;
        }*/

        public Templates.Animation Anim
        {
            get => Anim;
            set => Anim = value;
        }
    }
}