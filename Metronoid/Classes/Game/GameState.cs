using System;
using Metronoid.Classes.Game.Elements;
using Metronoid.Classes.Game.Graphics.Elements;
using Metronoid.Classes.Game.Levels;

namespace Metronoid.Classes.Game
{
    public static class GameState
    {
        public static int Status = 0; //0 playing 1 end
        public static Engine _engine = null;
        public static Level _lvlInfo = null;
        public static Brick[,] _bricks;
        public static Player _player = null;
        public static MorphBall _ball = null;
        public static int _maxLife = 3;
        public static Life[] _life = null;
        public static int _currentLife = _maxLife;
        public static int _score = 0;
        public static int[] _reward = null;
        public static int _endGame;
        public static int _combo = 0;
        public static readonly Random _random = new Random();

        public static void Reset()
        {
            _engine.Stop();
            Status = 0; //0 playing 1 end
            _engine = null;
            _lvlInfo = null;
            
            _player = null;
            _ball = null;
            _maxLife = 3;
            _life = null;
            _currentLife = _maxLife;
            _score = 0;
            _reward = null;
            
            _combo = 0;
        }
    }
}