using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Metronoid
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            _mainMenu = new MainMenu();
            Application.Run(_mainMenu);
        }
        public static MainMenu _mainMenu = null;
        public static MainGame _mainGame = null;
    }
}