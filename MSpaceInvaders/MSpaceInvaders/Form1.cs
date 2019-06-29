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
            
            this.DoubleBuffered = true;


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Comment
            
            igra = new Game(this.Bounds.Width, this.Bounds.Height);
            pictureBox1.Location = new Point(10, this.Bounds.Height - pictureBox1.Size.Height * 3);
            label1.Location = new Point(pictureBox1.Location.X + pictureBox1.Width, pictureBox1.Location.Y - pictureBox1.Height / 2 + label1.Size.Height);
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
                //  igra.player.Move(0);
                mvLeft.Start();
            }
            if (e.KeyCode == Keys.Right)
            {
                //igra.player.Move(1);
                mvRight.Start();
            }
            if (e.KeyCode == Keys.Space)
            {
                igra.Shoot();
            }
            Invalidate(true);
        }
        public void changeL()
        {
            this.BackgroundImage = igra.levels[igra.CurrentLevel].background;

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
                this.BackgroundImage = igra.levels[0].background;
                label1.Text = "x" + igra.lives.ToString();
            }
            else
            {
                igra.Update();
                label1.Text = "x" + igra.lives.ToString();
            }
            Invalidate(true);
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            for(int j = 0; j < igra.columns; j++) {
                for(int k = 0; k < igra.rows; k++)
                {
                    Enemy en = igra.levels[igra.CurrentLevel].enemies[j, k];
                    if (i % en.random == 0 && en.projectile==null)
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

        private void mvRight_Tick(object sender, EventArgs e)
        {
            igra.player.Move(1,this.Bounds.Width);
        }

        private void mvLeft_Tick(object sender, EventArgs e)
        {
            igra.player.Move(0,this.Bounds.Width);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                mvRight.Stop();
            }
            else if(e.KeyCode == Keys.Left)
            {
                mvLeft.Stop();
            }
        }
    }
}
