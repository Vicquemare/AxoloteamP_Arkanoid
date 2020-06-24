using System.ComponentModel;

namespace Metronoid
{
    partial class MainGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MainGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 401);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainGame";
            this.Text = "MainGame";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainGame_FormClosing);
            this.Load += new System.EventHandler(this.MainGame_Load);
            this.Shown += new System.EventHandler(this.MainGame_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainGame_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainGame_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainGame_MouseMove);
            this.ResumeLayout(false);
        }

        #endregion
    }
}