using System;
using System.Data;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using Metronoid.Classes.Game.Levels;

namespace Metronoid.Classes.Game
{
    public class Engine
    {
        private Level _myLevel;

        /// <summary>
        /// Status of GameLoop
        /// </summary>
        public bool Running { get; private set; }
        public Engine(Form1 frm)
        {
            _frm = frm;
        }

        private Form1 _frm;
        /// <summary>
        /// Load Game into GameLoop
        /// </summary>
        public void Load(Level levelObj)
        {
            _myLevel = levelObj;
        }

        
        
        /// <summary>
        /// Start GameLoop
        /// </summary>
        public async void Start()
        {
            if (_myLevel== null) throw new ArgumentException("Game not loaded!");
            // Load game content
            //_myLevel.Load();
            // Set gameloop state
            Running = true;
            // Set and start the gametime stopwatch
            Stopwatch _stopwatch = Stopwatch.StartNew();
            
            while (Running)
            {
                // get elapsed time since the last game loop cycle
                long _gameTimeElasped = _stopwatch.ElapsedMilliseconds;
                // reset the game time stopwatch
                _stopwatch.Restart();
                // Update the game
                //_myLevel.Update(_gameTimeElasped);
                Update(_gameTimeElasped);
                // Update Game at 60fps
                await Task.Delay((int)Math.Max(8 - _stopwatch.ElapsedMilliseconds, 0));                
            }
        }

        public void Update(long gameTime)
        {
            _frm.UpdateGraphics();
        }

        /// <summary>
        /// Stop GameLoop
        /// </summary>
        public void Stop()
        {
            Running = false;
            //_myLevel?.Unload();
        }

        /// <summary>
        /// Draw Game Graphics
        /// </summary>
        /*public void Draw(Graphics gfx)
        {
            _myLevel.Draw(gfx);
        }*/
    }
}