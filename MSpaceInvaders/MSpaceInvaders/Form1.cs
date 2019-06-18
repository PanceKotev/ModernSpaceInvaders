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
        int i = 0;
        Game igra;
        private static Random rand = new Random();
        int rr = rand.Next(50,200);
        public Form1()
        {
            InitializeComponent();
            igra = new Game(this.Bounds.Width, this.Bounds.Height);
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
            /*  sh.Draw(e.Graphics);
              if (p != null) 
                  p.Draw(e.Graphics); 
              en.Draw(e.Graphics);*/
            igra.Draw(e.Graphics);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                igra.player.Move(0);
            }
            if (e.KeyCode == Keys.Right)
            {
                igra.player.Move(1);
            }
            if (e.KeyCode == Keys.Space)
            {
                igra.Shoot();
            }
            Invalidate(true);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            /*  if (p != null)
              {
                  if (!p.exists)
                  {
                      p = null;

                  }
                  else
                  p.Move(true);
                  if (en.isHit(p))
                      MessageBox.Show("It hit");

              }
              */
            if (igra.GameOver == true)
            {
                igra = new Game(this.Bounds.Width, this.Bounds.Height);
            }
            else
            {
                igra.moveProjectiles();
                igra.updateDir();
                igra.enemyHit();
                igra.shipHit();
            }
            Invalidate(true);
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
          /*  if (i % en.random==0)
            {
                en.Fire();
                en.random = rand.Next(50, 200);
            }
            if (en.projectile!=null)
            en.projMove(this.Bounds.Height);
            i++;
            */

            Invalidate(true);
        }

        private void enemyMovement_Tick(object sender, EventArgs e)
        {
            igra.moveEnemies();
            Invalidate(true);
        }
    }
}
