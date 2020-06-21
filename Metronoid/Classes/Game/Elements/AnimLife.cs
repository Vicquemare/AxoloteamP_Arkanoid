using System.Drawing;
using Metronoid.Classes.Game.Graphics.Templates;

namespace Metronoid.Classes.Game.Elements
{
    public class AnimLife
    {
        private static string _spritesheet = "life";
        
        private static Bitmap[] _idle = {
            Sprite.getSprite(0, 0, _spritesheet), Sprite.getSprite(1, 0, _spritesheet), Sprite.getSprite(2, 0, _spritesheet), 
            Sprite.getSprite(0, 1, _spritesheet), Sprite.getSprite(1, 1, _spritesheet), Sprite.getSprite(2, 1, _spritesheet)
        };
        private static Metronoid.Classes.Game.Graphics.Templates.Animation _animIddle = new Metronoid.Classes.Game.Graphics.Templates.Animation(_idle, 5);
        
        private static Bitmap[] _idle1 = {
            Sprite.getSprite(0, 2, _spritesheet)
        };
        private static Metronoid.Classes.Game.Graphics.Templates.Animation _animIddle1 = new Metronoid.Classes.Game.Graphics.Templates.Animation(_idle1, 20);
        
        public Metronoid.Classes.Game.Graphics.Templates.Animation anim = _animIddle;
        public Metronoid.Classes.Game.Graphics.Templates.Animation anim1 = _animIddle1;

        public static Bitmap[] Idle
        {
            get => _idle;
        }

        public static Animation AnimIddle
        {
            get => _animIddle;
        }
        
        public static Bitmap[] Idle1
        {
            get => _idle1;
        }

        public static Animation AnimIddle1
        {
            get => _animIddle1;
        }

        public Animation Anim
        {
            get => Anim;
            set => Anim = value;
        }
    }
}