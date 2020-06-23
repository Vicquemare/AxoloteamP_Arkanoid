using System;
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
                MessageBox.Show("Error al cargar el archivo de destino");
            }

            return sprite;
        }

        public static Bitmap getSprite(int xGrid, int yGrid, String spritesheet) {

            // if (spriteSheet == null) {
            spriteSheet = loadSprite("Resources/Sprites/"+ spritesheet + ".png");
            //}

            switch (spritesheet)
            {
                case "morphball":
                    _tileSize = 121;
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
                    _tileSizeX = 137;
                    _tileSizeY = 38;
                    break;
                case "2":
                    _notSquare = true;
                    _tileSizeX = 47;
                    _tileSizeY = 13;
                    break;
                case "background":
                    _notSquare = true;
                    _tileSizeX = 816;
                    _tileSizeY = 480;
                    break;
                case "enemy1":
                    _notSquare = true;
                    _tileSizeX = 40;
                    _tileSizeY = 15;
                    break;
                case "enemy2":
                    _notSquare = true;
                    _tileSizeX = 40;
                    _tileSizeY = 15;
                    break;
                case "enemy3":
                    _notSquare = true;
                    _tileSizeX = 40;
                    _tileSizeY = 15;
                    break;
                case "portrait":
                    _tileSize = 92;
                    break;
                case "life":
                    _tileSize = 126;
                    break;
                case "UI":
                    _notSquare = true;
                    _tileSizeX = 1863;
                    _tileSizeY = 538;
                    break;
            }

            try{
            if (!_notSquare) {
                return spriteSheet.Clone(new Rectangle(xGrid * _tileSize, yGrid * _tileSize, _tileSize, _tileSize), spriteSheet.PixelFormat );
            } else {
                _notSquare = false;
                return spriteSheet.Clone(new Rectangle(xGrid * _tileSizeX, yGrid * _tileSizeY, _tileSizeX, _tileSizeY), spriteSheet.PixelFormat );
            }
            }
            } catch (IOException e) {
                MessageBox.Show("Error al cargar el elemento");
            }




            //return spriteSheet.getSubimage(xGrid * 168, yGrid * 211, 168, 211);
        }

    }
}