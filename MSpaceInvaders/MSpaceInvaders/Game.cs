using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
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
        public Level level { get; set; }
        public int Score { get; set; }
        public static Random random = new Random();
        Direction enemyDirection { get; set; }
        public Game(int width,int height)
        {
            Score = 0;
            CurrentLevel = 1;
            speedProj = 10;
            lives = 3;
            Width = width;
            Height = height;
            gifts = new List<Gift>();
            level = new Level(Width, Height, CurrentLevel, 0);
            stars = new List<Star>();
            GenerateStars();

            nbrBullets = 1;
            columns = level.columns;
            rows = level.rows;
            GameOver = false;
            firedP = new List<Projectile>();
            player = new Ship(Width / 2, Height-115);


        }
        public void Shoot()
        {
            if (firedP.Count < nbrBullets)
            {
                Projectile p = new Projectile(new Point(player.X + 17, player.Y - 10), true,speedProj);
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
                        if (level.enemies[i, j].isHit(player) && !flag)
                        {
                            lives--;
                            if (lives == 0)
                            {
                                GameOver = true;
                            }
                            flag = true;
                            break;
                        }
                        else if (level.enemies[i, j].projectile != null)
                        {
                            if (player.isHit(level.enemies[i, j].projectile) && !flag)
                            {
                                lives--;
                                if (lives == 0)
                                {
                                    GameOver = true;
                                }
                                level.enemies[i, j].projectile = null;
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
            for (int i = 0; i < firedP.Count; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    bool flag = false;
                    for (int k = 0; k < rows; k++)
                    {
                        if (level.enemies[j, k].isHit(firedP[i]) && !level.enemies[j, k].isDead)
                        {
                            firedP.RemoveAt(i);
                            Score += 100;
                            level.enemies[j, k].isDead = true;
                            level.decideMost();
                            generateGift(level.enemies[j, k].location);

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
            level.Draw(g);
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
                gifts.Add(new Gift(new Point(p.X-level.enemies[0,0].size.Width/2,p.Y-10)));
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

                if (level.allDead())
                {
                    Score += level.difficulty * 250;
                    GenerateStars();
                    CurrentLevel++;
                    firedP.Clear();
                    level = new Level(Width, Height, CurrentLevel, 0);
                    columns = level.columns;
                    rows = level.rows;
                }
            
        }

        public void Update()
        {
            if (!GameOver)
            {
                nextLevel();
                moveProjectiles();
                level.enemyMoveProj();
                level.updateDir();
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
                        Score += 200;
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
