using System;
using System.Data;
using System.Windows.Forms;
using Metronoid.Classes.Models;


namespace Metronoid.Views
{
    public partial class login : UserControl
    {
            adduser users =new adduser();
            private int iduser=0;
            
        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Vacio(textBox1.Text.Trim()))
            {
                            if (!users.Verifyusername())
                            {
                                MessageBox.Show("Bienvenido");
                                Program._mainGame = new MainGame();
                                this.Hide();
                                Program._mainGame.Show();
                                
                            }
                            else
                            {
                                MessageBox.Show("Usuario inexistente, se agregara para iniciar");
                                users.InsertUser();
                                Program._mainGame = new MainGame();
                                this.Hide();
                                Program._mainGame.Show();
                                
                            }
                        }
                        else
                        {
                            MessageBox.Show("No puede quedar ningun campo vacio");
                        }
           
        }
        public bool Vacio(String txt)
        {
            bool vacio = (txt.Length == 0);
            //lbEusuario.Text = ""+""+vacio;
            return vacio;
            
        }
        }
       }