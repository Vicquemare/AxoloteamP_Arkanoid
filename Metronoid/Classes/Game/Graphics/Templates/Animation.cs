using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Metronoid.Classes.Game.Graphics.Templates
{
    public class Animations
    {
        private int _frameCount; // Counts ticks for change
        private int _frameDelay; // frame delay 1-12 (You will have to play around with this)
        private int _currentFrame; // animations current frame
        private int _animationDirection; // animation direction (i.e counting forward or backward)
        private int _totalFrames; // total amount of frames for your animation
        private bool _stopped; // has animations stopped

        private List<Frame> _frames = new List<Frame>(); // Arraylist of frames 

        public Animations(Bitmap[] frames, int frameDelay)
        {
            _frameDelay = frameDelay;
            _stopped = true;

            for (int i = 0; i < _frames.Count; i++)
            {
                AddFrame(frames[i], frameDelay);
            }

            _frameCount = 0;
            _frameDelay = frameDelay;
            _currentFrame = 0;
            _animationDirection = 1;
            _totalFrames = _frames.Count;

        }

        public void Start()
        {
            if (!_stopped)
            {
                return;
            }

            if (_frames.Count == 0)
            {
                return;
            }

            _stopped = false;
        }

        public void Stop()
        {
            if (_frames.Count == 0)
            {
                return;
            }

            _stopped = true;
        }

        public void Restart()
        {
            if (_frames.Count == 0)
            {
                return;
            }

            _stopped = false;
            _currentFrame = 0;
        }

        public void Reset()
        {
            _stopped = true;
            _frameCount = 0;
            _currentFrame = 0;
        }

        //////////////Añadido////////////////////
        public int NumTotalDeFrames()
        {
            return _totalFrames;
        }

        public int NumActualDeFrames()
        {
            return _currentFrame;
        }
        /////////////////////////////////////////

        private void AddFrame(Bitmap frame, int duration)
        {
            if (duration <= 0)
            {
                MessageBox.Show("Invalid duration: " + duration.ToString());
                throw new Exception("Invalid duration: " + duration.ToString());
            }

            _frames.Add(new Frame(frame, duration));
            _currentFrame = 0;
        }

        public Bitmap GetSprite()
        {
            return _frames[_currentFrame].Frames;
        }

        public void Update()
        {
            if (!_stopped)
            {
                _frameCount++;

                if (_frameCount > _frameDelay)
                {
                    _frameCount = 0;
                    _currentFrame += _animationDirection;

                    if (_currentFrame > _totalFrames - 1)
                    {
                        _currentFrame = 0;
                    }
                    else if (_currentFrame < 0)
                    {
                        _currentFrame = _totalFrames - 1;
                    }
                }
            }
        }
    }

    public partial class Frame
    {
    }
}