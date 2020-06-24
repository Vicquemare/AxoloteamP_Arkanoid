using System;
using System.Windows.Forms;

namespace Metronoid.Classes.Controllers
{
    public class validator
    {
        public static string InputText(string message)
        {
            bool valid = false;
            string text = "";
            string error = "Texto invalido";
            do
            {
                try
                {
                    text = message;
                    if (string.IsNullOrEmpty(text) || string.IsNullOrWhiteSpace(text))
                    {
                        throw new Exception(error+"\n");
                    }
                    valid = true;
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            } while (string.IsNullOrEmpty(text)&& !valid);
            return text;
        }
    }
}