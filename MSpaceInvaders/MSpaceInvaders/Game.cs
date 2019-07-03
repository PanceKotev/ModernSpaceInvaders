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
        public int speedProj { get; set; }
        public List<Star> stars { get; set; }
        public int rows { get; set; }
        public int CurrentLevel { get; set; }
        public List<Gift> gifts { get; set; }
        public int nbrBullets { get; set; }
        public int lives { get; set; }
        public static Random random = new Random();
        public List<Level> levels { get; set; }

        Direction enemyDirection { get; set; }
        public Game(int width,int height)
        {
            CurrentLevel = 0;
            speedProj = 10;
            lives = 3;
            Width = width;
            Height = height;
            gifts = new List<Gift>();
            levels = new List<Level>();
            stars = new List<Star>();
            GenerateStars();
            levels.Add(new Level(Width, Height, 1));
            levels.Add(new Level(Width, Height, 2));
            levels.Add(new Level(Width, Height, 3));
            nbrBullets = 1;
            columns = levels[CurrentLevel].columns;
            rows = levels[CurrentLevel].rows;
            GameOver = false;
            firedP = new List<Projectile>();
            player = new Ship(Width / 2, Height-115);


        }
        public void Shoot()
        {
            if (firedP.Count < nbrBullets)
            {
                Projectile p = new Projectile(new Point(player.X + 20, player.Y - 10), true,speedProj);
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
                        if (levels[CurrentLevel].enemies[i, j].isHit(player) && !flag)
                        {

                            lives--;
                            if (lives == 0)
                            {
                                GameOver = true;
                            }
                            flag = true;
                            break;
                        }
                        else if (levels[CurrentLevel].enemies[i, j].projectile != null)
                        {
                            if (player.isHit(levels[CurrentLevel].enemies[i, j].projectile) &&!flag)
                            {

                                lives--;
                                if (lives == 0)
                                {
                                    GameOver = true;
                                }
                                levels[CurrentLevel].enemies[i, j].projectile = null;
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
                            generateGift(levels[CurrentLevel].enemies[j, k].location);
                            levels[CurrentLevel].decideMost();
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

            foreach(Star s in stars)
            {
                s.Draw(g);
            }
            levels[CurrentLevel].Draw(g);
            foreach(Gift gI in gifts)
            {
                gI.Draw(g);
            }
            foreach(Projectile p in firedP)
            {
                p.Draw(g);
            }
            player.Draw(g);




        }
        public void generateGift(Point p)
        {
            int b = random.Next(1, 20);
            if (b == 4)
            {
                gifts.Add(new Gift(new Point(p.X-levels[0].enemies[0,0].size.Width/2,p.Y-10)));
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
        public void nextLevel()
        {
            if (CurrentLevel < levels.Count-1)
            {
                if (levels[CurrentLevel].allDead())
                {
                    GenerateStars();
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
                moveGifts();
                takeGift(player);
                enemyHit();
                shipHit();
               
            }
        }
        public void GenerateStars()
        {
            Random r = new Random();
            stars.Clear();
           int nbr= r.Next(32, 45);
            for (int i = 0; i < nbr; i++)
            {
                stars.Add(new Star(Width, Height - 35));
            }
        }
        public void moveGifts()
        {
            if (gifts.Count > 0)
            {
                for (int i = 0; i < gifts.Count; i++)
                {
                    if (gifts[i].location.Y >= Height - 45)
                    {
                        gifts.RemoveAt(i);
                    }
                    else
                        gifts[i].Move();
                }
            }
        }
        public void takeGift(Ship s)
        {
            if (gifts.Count > 0)
            {
                for (int i = 0; i < gifts.Count; i++)
                {
                    if (gifts[i].isHit(s))
                    {
                        if (gifts[i].type == UpgradeType.life)
                        {
                            lives = lives + gifts[i].amount;
                        }
                        else if (gifts[i].type == UpgradeType.max_bullets)
                        {
                            nbrBullets = nbrBullets + gifts[i].amount;
                        }
                        else if (gifts[i].type == UpgradeType.proj_speed)
                        {
                            speedProj = speedProj + gifts[i].amount;
                        }
                        gifts.RemoveAt(i);
                    }
                }
            }
        }

     
        

    }
}
