using System;
using System.Windows.Forms;
using Metronoid.Classes.Controllers;

namespace Metronoid.Views
{
    public partial class Top : UserControl
    {
            Viewtop toop = new Viewtop();
        public Top()
        {
            InitializeComponent();
            Load();
        }
        public void Load()
        {
           dataGridView1.DataSource=null;
           dataGridView1.DataSource =  toop.Top();
           dataGridView1.Columns[0].Visible = false;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}