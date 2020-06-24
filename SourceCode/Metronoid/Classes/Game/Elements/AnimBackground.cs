using System.Drawing;
using Metronoid.Classes.Game.Graphics.Templates;
namespace Metronoid.Classes.Game.Graphics.Elements
{
    public class AnimBackground
    {
        private static string _spritesheet = "background";
        private static string _spritesheet2 = "UI";
        public Rectangle UiHitbox;
                        
                        private static Bitmap[] _idle = {
                            Sprite.getSprite(0, 0, _spritesheet), Sprite.getSprite(1, 0, _spritesheet), Sprite.getSprite(2, 0, _spritesheet), Sprite.getSprite(3, 0, _spritesheet), Sprite.getSprite(4, 0, _spritesheet), 
                            Sprite.getSprite(0, 1, _spritesheet), Sprite.getSprite(1, 1, _spritesheet), Sprite.getSprite(2, 1, _spritesheet), Sprite.getSprite(3, 1, _spritesheet), Sprite.getSprite(4, 1, _spritesheet),
                            Sprite.getSprite(0, 2, _spritesheet), Sprite.getSprite(1, 2, _spritesheet), Sprite.getSprite(2, 2, _spritesheet), Sprite.getSprite(3, 2, _spritesheet), Sprite.getSprite(4, 2, _spritesheet), 
                            Sprite.getSprite(0, 3, _spritesheet), Sprite.getSprite(1, 3, _spritesheet)
                        };
                        private static Bitmap[] _idleUI = {
                            Sprite.getSprite(0, 0, _spritesheet2)
                        };
                        private static Metronoid.Classes.Game.Graphics.Templates.Animation _animIddle = new Metronoid.Classes.Game.Graphics.Templates.Animation(_idle, 10);
                        private static Metronoid.Classes.Game.Graphics.Templates.Animation _animIddleUI = new Metronoid.Classes.Game.Graphics.Templates.Animation(_idleUI, 10);
                        public Metronoid.Classes.Game.Graphics.Templates.Animation anim = _animIddle;
                        public Metronoid.Classes.Game.Graphics.Templates.Animation animUI = _animIddleUI;
                
                        public static Bitmap[] Idle
                        {
                            get => _idle;
                        }
                
                        public static Templates.Animation AnimIddle
                        {
                            get => _animIddle;
                        }
                
                        public Templates.Animation Anim
                        {
                            get => Anim;
                            set => Anim = value;
                        }
    }
}