﻿using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Metronoid.Classes.Game.Graphics.Templates
{
    public class Sprite {

        private static Bitmap spriteSheet;
        private static int _tileSize = 211;
        private static int _tileSizeX = 211;
        private static int _tileSizeY = 211;
        private static bool _notSquare = false;




        public static Bitmap loadSprite(String file) {

            Bitmap sprite = null;

            try {
                sprite = new Bitmap(file);
            } catch (IOException e) {
                MessageBox.Show(e.Message);
            }

            return sprite;
        }

        public static Bitmap getSprite(int xGrid, int yGrid, String spritesheet) {

            // if (spriteSheet == null) {
            spriteSheet = loadSprite("Resources/Sprites/"+ spritesheet + ".png");
            //}

            switch (spritesheet)
            {
                case "morphoball":
                    _tileSize = 20;
                    break;
                case "megaman":
                    _notSquare = true;
                    _tileSizeX = 164;
                    _tileSizeY = 175;
                    break;
                case "1":
                    _notSquare = true;
                    _tileSizeX = 98;
                    _tileSizeY = 27;
                    break;
                case "player":
                    _notSquare = true;
                    _tileSizeX = 84;
                    _tileSizeY = 22;
                    break;
                case "2":
                    _notSquare = true;
                    _tileSizeX = 47;
                    _tileSizeY = 13;
                    break;
                case "background":
                    _notSquare = true;
                    _tileSizeX = 1632;
                    _tileSizeY = 960;
                    break;
            }


            if (!_notSquare) {
                return spriteSheet.Clone(new Rectangle(xGrid * _tileSize, yGrid * _tileSize, _tileSize, _tileSize), spriteSheet.PixelFormat );
            } else {
                _notSquare = false;
                return spriteSheet.Clone(new Rectangle(xGrid * _tileSizeX, yGrid * _tileSizeY, _tileSizeX, _tileSizeY), spriteSheet.PixelFormat );


            }




            //return spriteSheet.getSubimage(xGrid * 168, yGrid * 211, 168, 211);
        }

    }
}