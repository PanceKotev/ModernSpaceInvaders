using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSpaceInvaders
{
    public partial class Form1 : Form
    {

        public Ship sh;
        Projectile p;
        Enemy en;
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Comment
            sh= new Ship(Size.Width / 2, Size.Height-80);
            en = new Enemy(new Point(23,60));
            timer1.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            sh.Draw(e.Graphics);
            if (p != null)
                p.Draw(e.Graphics);
            en.Draw(e.Graphics);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                sh.Move(0);
            }
            if (e.KeyCode == Keys.Right)
            {
                sh.Move(1);
            }
            if (e.KeyCode == Keys.Space)
            {
                p = new Projectile(new Point(sh.X+sh.Img.Size.Width/2, sh.Y-20));
                p.Type = Projectile_Type.NORMAL;
            }
            Invalidate(true);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (p != null)
            {
                if (!p.exists)
                {
                    p = null;
                    
                }
                else
                p.Move(this.Height);
                
            }
            Invalidate(true);
            
        }
    }
}
