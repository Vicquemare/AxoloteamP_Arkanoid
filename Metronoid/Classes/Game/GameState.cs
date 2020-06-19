using System;
using Metronoid.Classes.Game.Elements;
using Metronoid.Classes.Game.Graphics.Elements;
using Metronoid.Classes.Game.Levels;

namespace Metronoid.Classes.Game
{
    public static class GameState
    {
        public static int Status = 0;
        public static Engine _engine = null;
        public static Level _lvlInfo = null;
        public static Brick[,] _bricks;
        public static Player _player = null;
        public static MorphBall _ball = null;
        public static int _maxLife = 3;
        public static Life[] _life = null;
        public static int _score = 0;
        public static readonly Random _random = new Random();
    }
}