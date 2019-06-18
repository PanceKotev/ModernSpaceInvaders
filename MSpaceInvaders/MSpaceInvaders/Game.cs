using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSpaceInvaders
{
    public class Game
    {
        public List<Projectile> firedP { get; set; }
        public Ship player { get; set; }
        public Enemy[,] enemies { get; set; }
        public bool GameOver { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int columns { get; set; }
        public int rows { get; set; }
        Direction enemyDirection { get; set; }
        public Game(int width,int height)
        {
            Width = width;
            Height = height;
            columns = 5;
            rows = 3;
            GameOver = false;
            enemyDirection = Direction.RIGHT;
            firedP = new List<Projectile>();
            player = new Ship(Width / 2, Height-80);
            enemies = new Enemy[columns, rows];
            for (int i = 0; i < columns;i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    enemies[i, j] = new Enemy(new Point(i * 50+((Width-200)/2), j * 50));
                }
               

            }


        }
        public void Shoot()
        {
            if (firedP.Count < 3)
            {
                Projectile p = new Projectile(new Point(player.X + 20, player.Y - 10), true);
                firedP.Add(p);
            }
        }
        public void shipHit()
        {
            if (!GameOver)
            {
                for (int i = 0; i < columns; i++)
                {
                    bool flag = false;
                    for (int j = 0; j < rows; j++)
                    {
                        if (enemies[i, j].isHit(player))
                        {
                            GameOver = true;
                            flag = true;
                            break;
                        }
                        else if (enemies[i, j].projectile != null)
                        {
                            if (player.isHit(enemies[i, j].projectile))
                            {
                                GameOver = true;
                                flag = true;
                                break;
                            }
                        }
                    }
                    if (flag)
                        break;
                }
            }
        }
        public void enemyHit()
        {
            for(int i = 0; i < firedP.Count; i++)
            {
                for(int j = 0; j < columns; j++)
                {
                    bool flag = false;
                    for(int k = 0; k < rows; k++)
                    {
                        if (enemies[j, k].isHit(firedP[i]) && !enemies[j,k].isDead)
                        {
                            firedP.RemoveAt(i);
                            enemies[j, k].isDead = true;
                            flag = true;
                            break;
                        }

                    }
                    if (flag)
                        break;
                }
            }
        }
        public void Draw(Graphics g)
        {

            player.Draw(g);
            foreach(Projectile p in firedP)
            {
                p.Draw(g);
            }
            for(int i = 0; i < columns; i++)
            {
                for(int j = 0; j < rows; j++)
                {
                    if (!enemies[i, j].isDead)
                        enemies[i, j].Draw(g);
                }
            }



        }
        public void moveEnemies()
        {
            for(int i = 0; i < columns; i++)
            {
                for(int j = 0; j < rows; j++)
                {
                    enemies[i, j].Move(enemyDirection);
                   /* if (enemies[0, 2].location.X + enemies[0, 2].size.Width >= Width)
                    {
                        enemies[i, j].Move(Direction.DOWN);
                        enemies[i, j].Move(Direction.LEFT);
                    }
                    else if (enemies[0, 0].location.X <= enemies[0, 0].size.Width / 2)
                    {
                        enemies[i, j].Move(Direction.DOWN);
                        enemies[i, j].Move(Direction.RIGHT);
                    }
                    else
                        enemies[i, j].Move(Direction.RIGHT);*/
                }
            }
        }
        public void updateDir()
        {
            if (enemies[4, 0].location.X + enemies[4, 0].size.Width >= Width)
            {
                for(int i = 0; i < columns; i++)
                {
                    for(int j = 0; j < rows; j++)
                    {
                        enemies[i, j].Move(Direction.DOWN);
                    }
                }
                enemyDirection = Direction.LEFT;
            }

            else if (enemies[0, 0].location.X <= enemies[0, 0].size.Width / 2)
            {
                for (int i = 0; i < columns; i++)
                {
                    for (int j = 0; j < rows; j++)
                    {
                        enemies[i, j].Move(Direction.DOWN);
                    }
                }
                enemyDirection = Direction.RIGHT;
            }

        }
        public void moveProjectiles()
        {
            if (firedP.Count >= 1)
            {
                for (int i=0; i < firedP.Count; i++)
                {
                    if (firedP[i].start.Y - firedP[i].size.Height <= 0)
                    {
                        firedP.RemoveAt(i);
                    }
                    else
                    {
                        firedP[i].Move(true);
                    }
                }
            }
        }
        public void enemyMoveProj()
        {
            for(int i = 0; i < columns; i++)
            {
                Enemy en;
                for (int j = 0; j < rows; j++)
                {
                    en = enemies[i, j];
                    if (en.projectile != null)
                        en.projMove(Height);
                }
            }
           
        }


     
        

    }
}
