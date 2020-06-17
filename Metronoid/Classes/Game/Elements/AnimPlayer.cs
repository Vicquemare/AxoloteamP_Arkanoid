using System.Drawing;
using Metronoid.Classes.Game.Graphics.Templates;
namespace Metronoid.Classes.Game.Graphics.Elements
{
    public class AnimPlayer
    {
        private static string _spritesheet = "player";
                
                private static Bitmap[] _idle = {
                    Sprite.getSprite(0, 0, _spritesheet)
                };
                private static Metronoid.Classes.Game.Graphics.Templates.Animation _animIddle = new Metronoid.Classes.Game.Graphics.Templates.Animation(_idle, 20);
                public Metronoid.Classes.Game.Graphics.Templates.Animation anim = _animIddle;
        
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