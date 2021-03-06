﻿using System;
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
        public static Random random = new Random();
        public int difficulty = 1;
        public Enemy leftmost { get; set; }
        public Direction enemyDirection { get; set; }
        /// <summary>
        /// Constructor which generates a level with the variability of number of rows/columns/enemy projectile speed,
        /// and other stuff randomly depending on the difficulty variable.
        /// </summary>
        /// <param name="width">The width of the form.</param>
        /// <param name="height">The height of the form.</param>
        /// <param name="difficulty1">The difficulty by which the level is generated.</param>
        public Level(int width,int height,int difficulty1)
        {
            Width = width;
            Height = height;
            if (difficulty1 % 3 == 0 && difficulty1!=0)
            {
                difficulty++;
            }
            columns = random.Next(difficulty + 3, difficulty + 6);
            if (columns > 11)
                columns = 11;
            
            rows = random.Next(difficulty + 3, difficulty + 4);
            if (rows > 8)
                rows = 8;
            int velocityX = random.Next(difficulty + 9, difficulty + 12);
            int velocityY = random.Next(difficulty + 9, difficulty + 12);
            int speed = random.Next(9, 15);
            int r = random.Next(0, 2);
            if (r == 0)
                enemyDirection = Direction.LEFT;
            else if (r == 1)
                enemyDirection = Direction.RIGHT;
            enemies = new Enemy[columns, rows];
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    enemies[i, j] = new Enemy(new Point(i * 45 + ((Width - columns*45) / 2), j * 45),velocityX,velocityY,speed);
                }


            }
            rightmost = enemies[columns - 1, 0];
            leftmost = enemies[0, 0];
        }
        /// <summary>
        /// Draws the enemies if they are not dead.
        /// </summary>
        /// <param name="g">Graphics object from the form.</param>
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
        /// <summary>
        /// Moves the projectiles of the enemies.
        /// </summary>
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
        /// <summary>
        /// Updates the movement direction of the enemy matrix depending on whether they were moving right or left.
        /// </summary>
        public void updateDir()
        {
            if (rightmost.location.X + enemies[columns - 1, 0].size.Width >= Width-rightmost.size.Width)
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
        /// <summary>
        /// Moves the enemies depending on the variable enemyDirection.
        /// </summary>
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
        /// <summary>
        /// Decides which one of the enemies is the most right one or most left one to help with the updateDir function.
        /// </summary>
        public void decideMost()
        {
            Enemy right=rightmost;
            Enemy left = leftmost;
            int indexerR =0;
            int indexerL = columns - 1;
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
                    if(!en.isDead && i < indexerL)
                    {
                        left = en;
                        indexerL = i;
                    }
                }
            }
            rightmost = right;
            leftmost = left;
        }
        /// <summary>
        /// Checks whether all the enemies in the level are dead.
        /// </summary>
        /// <returns>Returns true if all the enemies are dead.</returns>
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
