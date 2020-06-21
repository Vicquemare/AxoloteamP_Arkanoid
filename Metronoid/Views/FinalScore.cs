using System;
using System.Drawing;
using System.Windows.Forms;

namespace Metronoid.Views
{
    public partial class FinalScore : UserControl
    {
        public FinalScore(int sco, int lives)
        {
            InitializeComponent();
            var pos = this.PointToScreen(pictureBox2.Location);
            pos = pictureBox1.PointToClient(pos);
            pictureBox2.Parent = pictureBox1;
            pictureBox2.Location = pos;
            pictureBox2.BackColor = Color.Transparent;
            pos = this.PointToScreen(pictureBox3.Location);
            pos = pictureBox1.PointToClient(pos);
            pictureBox3.Parent = pictureBox1;
            pictureBox3.Location = pos;
            pictureBox3.BackColor = Color.Transparent;
            label1.Location = new Point(0,0);
            ChangeText(sco, lives);
            
        }
        string text = "Score: \n \n 12435 \n \n \n bonus por vidas restantes x3";

        private void FinalScore_Load(object sender, EventArgs e)
        {
            //throw new System.NotImplementedException();
        }

        public void ChangeText(int sco, int lives)
        {
            text = "Score: \n \n "+ sco.ToString() +" \n \n \n bonus por vidas restantes x"+ lives.ToString() + "\n Total: \n \n" +  (lives > 0 ? (sco*lives).ToString() : sco.ToString());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //throw new System.NotImplementedException();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //throw new System.NotImplementedException();
        }

        private void FinalScore_SizeChanged(object sender, EventArgs e)
        {
            pictureBox2.Size = new Size(Width/2, Height);
            pictureBox3.Size = new Size(Width/2, Height);
            label1.Size = new Size(Width, 34);
            label1.Location = new Point(0,0);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //throw new System.NotImplementedException();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //throw new System.NotImplementedException();
        }

        private void pictureBox3_Paint(object sender, PaintEventArgs e)
        {
            
            using (Font myFont = new Font("Metroid Fusion", 20))
            {
                e.Graphics.DrawString(text, myFont, Brushes.White, new Point((int) (pictureBox3.Width*0.10), (int) (pictureBox3.Height*0.3)));
            }
        }
        }
    }
