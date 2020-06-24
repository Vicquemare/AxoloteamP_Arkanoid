using System.Drawing;
using Metronoid.Classes.Game.Graphics.Templates;

namespace Metronoid.Classes.Game.Elements
{
    public partial class MorphBall
    {
        private static string _spritesheet = "morphball";
                
                private static Bitmap[] _idle = {
                    Sprite.getSprite(0, 0, _spritesheet), Sprite.getSprite(1, 0, _spritesheet), Sprite.getSprite(2, 0, _spritesheet), Sprite.getSprite(3, 0, _spritesheet), 
                    Sprite.getSprite(0, 1, _spritesheet), Sprite.getSprite(1, 1, _spritesheet), Sprite.getSprite(2, 1, _spritesheet), Sprite.getSprite(3, 1, _spritesheet)
                };
                private static Metronoid.Classes.Game.Graphics.Templates.Animation _animIddle = new Metronoid.Classes.Game.Graphics.Templates.Animation(_idle, 5);
                public Metronoid.Classes.Game.Graphics.Templates.Animation anim = _animIddle;
        
                public static Bitmap[] Idle
                {
                    get => _idle;
                }
        
                public static Animation AnimIddle
                {
                    get => _animIddle;
                }
        
                public Animation Anim
                {
                    get => Anim;
                    set => Anim = value;
        }
    }
}