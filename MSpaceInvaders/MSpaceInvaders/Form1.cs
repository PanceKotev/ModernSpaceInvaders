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
        
        int i = 1;
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
            if (e.KeyCode == Keys.Left && !(igra.player.X-igra.player.size.Width<=0-igra.player.size.Width/2))
            {
                igra.player.Move(0);
            }
            if (e.KeyCode == Keys.Right && !(igra.player.X+igra.player.size.Width >= this.Bounds.Width-igra.player.size.Width/2))
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
                igra.Update();
            }
            Invalidate(true);
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            for(int j = 0; j < igra.columns; j++) {
                for(int k = 0; k < igra.rows; k++)
                {
                    Enemy en = igra.levels[igra.CurrentLevel].enemies[j, k];
                    if (i % en.random == 0)
                    {
                        en.Fire();
                        en.random = rand.Next(50, 200);
                    }
                }
            }
            i++;
            

            Invalidate(true);
        }

        private void enemyMovement_Tick(object sender, EventArgs e)
        {
            igra.levels[igra.CurrentLevel].moveEnemies();
            Invalidate(true);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
