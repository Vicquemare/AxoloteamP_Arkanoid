using System;
using System.Windows.Forms;
using Metronoid.Classes.Game;
using Metronoid.Views;

namespace Metronoid
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private UserControl _current = null;

        private void MainMenu_Load(object sender, EventArgs e)
        {
            //DisplayScore(24324, 3);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            //throw new System.NotImplementedException();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program._mainGame = new MainGame();
            this.Hide();
            Program._mainGame.Show();
        }

        public void DisplayScore(int sco, int lives)
        {
            tableLayoutPanel1.Controls.Remove(_current);
            _current = new FinalScore(sco, lives) {Dock = DockStyle.Fill};
            tableLayoutPanel1.Controls.Add(_current, 2, 0);
            tableLayoutPanel1.SetRowSpan(_current, 2);
            GameState.Reset();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Remove(_current);
            _current = null;
        }
    }
}