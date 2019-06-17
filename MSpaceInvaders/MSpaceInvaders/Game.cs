using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSpaceInvaders
{
    public class Game
    {
        public List<Projectile> firedP { get; set; }
        public Ship sh { get; set; }
        public Enemy[,] enemies;

        public Game(int x,int y)
        {
            for (int i = 0; i < 5;i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    enemies[i, j] = new Enemy(new Point(i * 50, j * 50));
                }
                sh = new Ship(x, y);

            }

        }
    }
}
