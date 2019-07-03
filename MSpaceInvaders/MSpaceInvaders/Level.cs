using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSpaceInvaders
{
   public class Level
    {
        public Enemy[,] enemies { get; set; }
        public int columns { get; set; }
        public int rows { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Enemy rightmost { get; set; }
        public Enemy leftmost { get; set; }
        public Direction enemyDirection { get; set; }
        public Level(int width,int height,int lvl)
        {
            Width = width;
            Height = height;
            
            if (lvl == 1)
            {
                columns = 5;
                rows = 3;
                enemyDirection = Direction.RIGHT;
                enemies = new Enemy[columns, rows];
                for (int i = 0; i < columns; i++)
                {
                    for (int j = 0; j < rows; j++)
                    {
                        enemies[i, j] = new Enemy(new Point(i * 50 + ((Width - 200) / 2), j * 50));
                    }


                }

            }
            else if (lvl == 2)
            {
                columns = 6;
                rows = 4;
                enemyDirection = Direction.RIGHT;
                enemies = new Enemy[columns, rows];
                for (int i = 0; i < columns; i++)
                {
                    for (int j = 0; j < rows; j++)
                    {
                        enemies[i, j] = new Enemy(new Point(i * 50 + ((Width - 200) / 2), j * 50));
                    }


                }
            }
            else if (lvl == 3)
            {
                columns = 6;
                rows = 5;
                enemyDirection = Direction.LEFT;
                enemies = new Enemy[columns, rows];
                for (int i = 0; i < columns; i++)
                {
                    for (int j = 0; j < rows; j++)
                    {
                        enemies[i, j] = new Enemy(new Point(i * 50 + ((Width - 200) / 2), j * 50));
                    }


                }
            }
            rightmost = enemies[columns - 1, 0];
            leftmost = enemies[0, 0];

        }
        public void Draw(Graphics g)
        {
      
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    if (!enemies[i, j].isDead)
                        enemies[i, j].Draw(g);
                }
            }

        }
        public void enemyMoveProj()
        {
            for (int i = 0; i < columns; i++)
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
        public void updateDir()
        {
            if (rightmost.location.X + enemies[columns - 1, 0].size.Width >= Width - rightmost.velocityX)
            {
                for (int i = 0; i < columns; i++)
                {
                    for (int j = 0; j < rows; j++)
                    {
                        enemies[i, j].Move(Direction.DOWN);
                    }
                }
                enemyDirection = Direction.LEFT;
            }

            else if (leftmost.location.X <= 0 + leftmost.velocityX)
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
        public void moveEnemies()
        {
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    enemies[i, j].Move(enemyDirection);
                }
            }
        }
        public void decideMost()
        {
            Enemy right=rightmost;
            Enemy left = leftmost;
            int indexerR =0;
            int indexerL = rows-1;
            for (int i = 0; i < columns; i++)
            {
                for(int j = 0; j < rows; j++)
                {
                    Enemy en = enemies[i, j];
                    if (!en.isDead && i>indexerR)
                    {
                        right = en;
                        indexerR = i;
                    }
                    if(!en.isDead && j < indexerL)
                    {
                        left = en;
                        indexerL = j;
                    }
                }
            }
            rightmost = right;
            leftmost = left;
        }
        public bool allDead()
        {
            int umreni = 0;
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    if (enemies[i, j].isDead)
                        umreni++;
                }
            }
            return (umreni == columns * rows);
        }

    }
}
