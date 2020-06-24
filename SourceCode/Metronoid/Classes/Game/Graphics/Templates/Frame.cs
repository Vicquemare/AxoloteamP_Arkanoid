using System.Drawing;

namespace Metronoid.Classes.Game.Graphics.Templates
{
    public partial class Frame
    {
        private Bitmap _frame;
        private int _duration;

        public Frame(Bitmap frame, int duration) {
            this._frame = frame;
            this._duration = duration;
        }
        public Bitmap Frames
        {
            get => _frame;
            set => _frame = value;
        }

        public int Duration
        {
            get => _duration;
            set => _duration = value;
        }
    }
}