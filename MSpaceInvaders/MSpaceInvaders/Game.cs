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
        public int CurrentLevel { get; set; }
        public int nbrBullets { get; set; }
        public List<Level> levels { get; set; }
        Direction enemyDirection { get; set; }
        public Game(int width,int height)
        {
            CurrentLevel = 0;
            Width = width;
            Height = height;
            levels = new List<Level>();
            levels.Add(new Level(Width, Height, 1));
            levels.Add(new Level(Width, Height, 2));
            nbrBullets = 1;

            columns = levels[CurrentLevel].columns;
            rows = levels[CurrentLevel].rows;
            //columns = 5;
            // rows = 3;
            GameOver = false;
           // enemyDirection = Direction.RIGHT;
            firedP = new List<Projectile>();
            player = new Ship(Width / 2, Height-80);
           /* enemies = new Enemy[columns, rows];
            for (int i = 0; i < columns;i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    enemies[i, j] = new Enemy(new Point(i * 50+((Width-200)/2), j * 50));
                }
               

            }*/


        }
        public void Shoot()
        {
            if (firedP.Count < nbrBullets)
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
                        if (levels[CurrentLevel].enemies[i, j].isHit(player))
                        {
                            GameOver = true;
                            flag = true;
                            break;
                        }
                        else if (levels[CurrentLevel].enemies[i, j].projectile != null)
                        {
                            if (player.isHit(levels[CurrentLevel].enemies[i, j].projectile))
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
                        if (levels[CurrentLevel].enemies[j, k].isHit(firedP[i]) && !levels[CurrentLevel].enemies[j,k].isDead)
                        {
                            firedP.RemoveAt(i);
                            levels[CurrentLevel].enemies[j, k].isDead = true;
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

            
            levels[CurrentLevel].Draw(g);
            foreach(Projectile p in firedP)
            {
                p.Draw(g);
            }
            player.Draw(g);




        }
       /* public void moveEnemies()
        {
            for(int i = 0; i < columns; i++)
            {
                for(int j = 0; j < rows; j++)
                {
                    enemies[i, j].Move(enemyDirection);
                }
            }
        }*/
       /* public void updateDir()
        {
            if (enemies[columns-1, 0].location.X + enemies[columns - 1, 0].size.Width >= Width-enemies[0,0].velocityX)
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

            else if (enemies[0, 0].location.X <= 0+ enemies[0, 0].velocityX)
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

        }*/
        public void moveProjectiles()
        {
            if (firedP.Count >= 1)
            {
                for (int i=0; i < firedP.Count; i++)
                {
                    if (firedP[i].start.Y - firedP[i].size.Height <= 0-firedP[i].speed)
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
        /*    public void enemyMoveProj()
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

            }*/
        public void nextLevel()
        {
            if (CurrentLevel < levels.Count-1)
            {
                if (levels[CurrentLevel].allDead())
                {
                    CurrentLevel++;
                    firedP.Clear();
                    columns = levels[CurrentLevel].columns;
                    rows = levels[CurrentLevel].rows;
                }
            }
        }
        public void Update()
        {
            if (!GameOver)
            {
                nextLevel();
                moveProjectiles();
                levels[CurrentLevel].enemyMoveProj();
                levels[CurrentLevel].updateDir();
                enemyHit();
                shipHit();
               
            }
        }

     
        

    }
}
