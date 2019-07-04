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
        Boolean isPaused;
        private static Random rand = new Random();
        int rr = rand.Next(50,200);
        public Form1()
        {
            InitializeComponent();
            
            this.DoubleBuffered = true;


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            isPaused = false;
            igra = new Game(this.Bounds.Width, this.Bounds.Height);
            timer1.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
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
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!isPaused)
            {
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
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (!isPaused)
            {
                for (int j = 0; j < igra.columns; j++)
                {
                    for (int k = 0; k < igra.rows; k++)
                    {
                        Enemy en = igra.level.enemies[j, k];
                        if (i % en.random == 0 && en.projectile == null)
                        {
                            en.Fire();
                            en.random = rand.Next(50, 200);
                        }
                    }
                }
                i++;


                Invalidate(true);
            }
        }

        private void enemyMovement_Tick(object sender, EventArgs e)
        {
            if (!isPaused)
            {
                igra.level.moveEnemies();
                Invalidate();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void mvRight_Tick(object sender, EventArgs e)
        {
            if(!isPaused)
            igra.player.Move(1,this.Bounds.Width);
        }

        private void mvLeft_Tick(object sender, EventArgs e)
        {
            if (!isPaused)
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
            else if (e.KeyCode == Keys.Escape)
            {
                isPaused = true;
                DialogResult result = MessageBox.Show("Сакаш ли да се вратиш назад?", "Потврда", MessageBoxButtons.YesNo);
              
                if (result == DialogResult.Yes)
                {
                    StartForm form = new StartForm();
                    form.Show();
                    this.Hide();
                    isPaused = false;
                }
                else if (result == DialogResult.No)
                {
                    isPaused = false;
                }
            }
        }

        private void maxB_Paint(object sender, PaintEventArgs e)
        {
            maxB.Text = "Max Bullets: " + igra.nbrBullets.ToString();
        }

        private void pSpeed_Click(object sender, EventArgs e)
        {
           
        }

        private void pSpeed_Paint(object sender, PaintEventArgs e)
        {
            pSpeed.Text = "Projectile Speed: " + igra.speedProj.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Paint(object sender, PaintEventArgs e)
        {
            label1.Text = "x" + igra.lives.ToString();
        }

        private void lbDifficulty_Paint(object sender, PaintEventArgs e)
        {
            lbDifficulty.Text = "Wave : " + igra.CurrentLevel.ToString();
        }

        private void label2_Paint(object sender, PaintEventArgs e)
        {
            label2.Text = igra.Score.ToString();
        }
    }
}
