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
        /// <summary>
        /// Constructor for the game class.
        /// Sets all the variables to default values.
        /// </summary>
        /// <param name="width">Width of the form.</param>
        /// <param name="height">Height of the form.</param>
        public Game(int width,int height)
        {
            Score = 0;
            CurrentLevel = 1;
            speedProj = 10;
            lives = 3;
            Width = width;
            Height = height;
            gifts = new List<Gift>();
            level = new Level(Width, Height, CurrentLevel);
            stars = new List<Star>();
            GenerateStars();

            nbrBullets = 1;
            columns = level.columns;
            rows = level.rows;
            GameOver = false;
            firedP = new List<Projectile>();
            player = new Ship(Width / 2, Height-115);


        }
        /// <summary>
        /// This is a function that creates a new projectile if the maximum number of bullets hasnt been reached.
        /// </summary>
        public void Shoot()
        {
            if (firedP.Count < nbrBullets)
            {
                Projectile p = new Projectile(new Point(player.X + 17, player.Y - 10), true,speedProj);
                firedP.Add(p);
            }
                
        }
        /// <summary>
        /// This function checks whether the player has been hit by either the enemy projectiles or the actual enemies,
        ///  if it has been hit by an enemy projectile the players life total decreases by 1, if hit by an actual enemy
        ///  then the game is over.
        /// </summary>
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
                            GameOver = true;
                            flag = true;
                            break;
                        }
                        else if (level.enemies[i, j].projectile != null)
                        {
                            if (player.isHit(level.enemies[i, j].projectile) && !flag)
                            {
                                lives--;
                                player.isGettingHit = true;
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
       /// <summary>
       /// This function checks whether the enemies in the level are hit by the projectiles which are shot by the player,
       /// deletes the enemy if it has been hit,
       /// and has a 1 in 20 chance to generate a gift at the location at the enemy if the enemy has been hit.
       /// </summary>
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
        /// <summary>
        /// Draws the level background then the level, player , gifts if there are any and then the projectiles shot by the player.
        /// </summary>
        /// <param name="g">Graphics object from the form.</param>
        public void Draw(Graphics g)
        {

            foreach(Star s in stars)
            {
                s.Draw(g);
            }
            level.Draw(g);
            player.Draw(g);
            foreach (Gift gI in gifts)
            {
                gI.Draw(g);
            }
            
            foreach (Projectile p in firedP)
            {
                p.Draw(g);
            }
           




        }
        /// <summary>
        /// This function adds a gift with a point P to the list of gifts if the random number generated is hit(has a 1 in 20 chance)
        /// </summary>
        /// <param name="p">Position of the enemy</param>
        public void generateGift(Point p)
        {
            int b = random.Next(1, 20);
            if (b == 4)
            {
                gifts.Add(new Gift(new Point(p.X-level.enemies[0,0].size.Width/2,p.Y-10)));
            }
        }
        /// <summary>
        /// Moves the projectiles shot by the player.
        /// </summary>
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

        /// <summary>
        /// Checks whether all the enemies are dead via the all dead function and if they are dead generates a new level based on the difficulty,
        /// also adds to the total score if the level has been cleared.
        /// </summary>
        public void nextLevel()
        {

                if (level.allDead())
                {
                    Score += level.difficulty * 250;
                    GenerateStars();
                    CurrentLevel++;
                    firedP.Clear();
                    level = new Level(Width, Height, CurrentLevel);
                    columns = level.columns;
                    rows = level.rows;
                }
            
        }
        /// <summary>
        /// This is a function which bundles all the other detection and movement functions in this project.
        /// </summary>
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
        /// <summary>
        /// This function is responsible for generating the background of the level with the stars object.
        /// </summary>
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
        /// <summary>
        /// This function moves the gifts if there are any.
        /// </summary>
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
        /// <summary>
        /// This function checks whether the player has collected any of the gifts and if he has uses it,
        /// then it deletes the gift from the list.
        /// </summary>
        /// <param name="s">The ship which should take the gift.</param>
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
                        else if (gifts[i].type == UpgradeType.max_bullets && nbrBullets<=10)
                        {
                            nbrBullets = nbrBullets + gifts[i].amount;
                        }
                        else if (gifts[i].type == UpgradeType.proj_speed && speedProj<=18)
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
