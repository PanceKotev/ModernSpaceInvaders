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
        public Image background { get; set; }
        public int Height { get; set; }
        public Direction enemyDirection { get; set; }
        public Level(int width,int height,int lvl)
        {
            Width = width;
            Height = height;
            if (lvl == 1)
            {
                background = Properties.Resources.Space;
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
                background = Properties.Resources.Space2;
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
            
        }
        public void Draw(Graphics g)
        {
            g.DrawImage(background, 0, 0, Width, Height);
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
            if (enemies[columns - 1, 0].location.X + enemies[columns - 1, 0].size.Width >= Width - enemies[0, 0].velocityX)
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

            else if (enemies[0, 0].location.X <= 0 + enemies[0, 0].velocityX)
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
