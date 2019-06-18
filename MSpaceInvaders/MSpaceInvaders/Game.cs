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

        public Game(int width,int height)
        {
            firedP = new List<Projectile>();
            for (int i = 0; i < 5;i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    enemies[i, j] = new Enemy(new Point(i * 50, j * 50));
                }
                player = new Ship(width / 2, height);

            }

        }
        public void Shoot()
        {
            firedP.Add(new Projectile(new Point(player.X, player.Y), true));
        }
        public void shipHit()
        {
            
            for (int i = 0; i < 5; i++)
            {
                bool flag = false;
                for(int j = 0; j < 3; j++)
                {
                    if (enemies[i, j].isHit(player))
                    {
                        GameOver = true;
                        flag = true;
                        break;
                    }
                    else if (player.isHit(enemies[i, j].projectile)){
                        GameOver = true;
                        MessageBox.Show("Game Over");
                        flag = true;
                        break;
                    }
                }
                if (flag)
                    break;
            }
        }
        public void enemyHit()
        {
            for(int i = 0; i < firedP.Count; i++)
            {
                for(int j = 0; i < 5; i++)
                {
                    bool flag = false;
                    for(int k = 0; i < 3; i++)
                    {
                        if (enemies[j, k].isHit(firedP[i]))
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





        }
        

    }
}
