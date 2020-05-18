using System.Drawing;
using Metronoid.Classes.Game.Graphics.Templates;

namespace Metronoid.Classes.Game.Graphics.Animations
{
    public class Megaman
    {
        private static string _spritesheet = "megaman";
        
        private static Bitmap[] _idle = {
            Sprite.getSprite(0, 0, _spritesheet), Sprite.getSprite(1, 0, _spritesheet), Sprite.getSprite(2, 0, _spritesheet), Sprite.getSprite(3, 0, _spritesheet), Sprite.getSprite(4, 0, _spritesheet), 
            Sprite.getSprite(0, 1, _spritesheet), Sprite.getSprite(1, 1, _spritesheet), Sprite.getSprite(2, 1, _spritesheet), Sprite.getSprite(3, 1, _spritesheet), Sprite.getSprite(4, 1, _spritesheet)
        };
        private static Metronoid.Classes.Game.Graphics.Templates.Animations _animIddle = new Metronoid.Classes.Game.Graphics.Templates.Animations(_idle, 10);
        public Metronoid.Classes.Game.Graphics.Templates.Animations anim = _animIddle;

        public static Bitmap[] Idle
        {
            get => _idle;
        }

        public static Templates.Animations AnimIddle
        {
            get => _animIddle;
        }

        public Templates.Animations Anim
        {
            get => Anim;
            set => Anim = value;
        }
    }
}