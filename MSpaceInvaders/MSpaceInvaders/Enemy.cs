using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace MSpaceInvaders
{
    public enum Direction
    {
        RIGHT,
        LEFT,
        DOWN
    }
    public class Enemy
    {
        public Image image { get; set; }
        public Point location{get;set;}
        public Projectile projectile { get; set; }
        public Size size { get; set; }
        public int speed { get; set; }
        private static Random rand = new Random();
        public int random { get; set; }
        public bool isDead { get; set; }
        public Rectangle bounds { get; set; }
        public int velocityX { get; set; }
        public int velocityY { get; set; }
        public Enemy()
        {
            isDead = false;
        }
        /// <summary>
        /// Constructor for the enemy class.
        /// </summary>
        /// <param name="loc">Location of the enemy.</param>
        /// <param name="velocityx">Horizontal velocity of enemy.</param>
        /// <param name="velocityy">Vertical velocity of enemy.</param>
        /// <param name="sp">Projectile speed of enemy.</param>
        public Enemy(Point loc,int velocityx=10,int velocityy=10,int sp=10)
        {
            size = new Size(35, 35);
            location = loc;
            speed = sp;
            velocityX = velocityx;
            velocityY = velocityy;
            bounds = new Rectangle(loc, size);
            image = Properties.Resources.enemy_ship;
            projectile = null;
            random = rand.Next(50, 200);
            isDead = false;

        }
        /// <summary>
        /// Draws the enemy and its projectile if the projectile is not null.
        /// </summary>
        /// <param name="g">Graphics object of the form.</param>
        public void Draw(Graphics g)
        {
            g.DrawImage(image, location.X, location.Y, size.Width,size.Height);
            if (projectile != null)
                projectile.Draw(g);
        }
        /// <summary>
        /// Checks whether the enemy is hit by projecile p.
        /// </summary>
        /// <param name="p">Projectile to check enemy hit with.</param>
        /// <returns>Returns true if the enemy is hit by the projectile p.</returns>
        public bool isHit(Projectile p)
        {
            
            return (bounds.IntersectsWith(p.bounds) && !isDead);
        }
        /// <summary>
        /// Moves the enemy depending on the direction.
        /// </summary>
        /// <param name="dir">Direction to determine movement.</param>
        public void Move(Direction dir)
        {
            if (dir == Direction.RIGHT)
            {
                location = new Point(location.X + velocityX, location.Y);
                bounds = new Rectangle(location, size);
            }
            else if (dir == Direction.LEFT)
            {
                location = new Point(location.X - velocityX, location.Y);
                bounds = new Rectangle(location, size);
            }
            else
            {
                location = new Point(location.X, location.Y + velocityY);
                bounds = new Rectangle(location, size);
            }
        }
        /// <summary>
        /// Checks whether the enemy is hit by the Ship s.
        /// </summary>
        /// <param name="s">Ship to check enemy hit with.</param>
        /// <returns>Returns true if the enemy hit the Ship s.</returns>
        public bool isHit(Ship s)
        {
            return (bounds.IntersectsWith(s.bounds) && !isDead);
        }
        /// <summary>
        /// Creates a projectile if the enemy is not dead.
        /// </summary>
        public void Fire()
        {
            if (!isDead)
            {
                projectile = new Projectile(new Point(location.X + size.Width / 2, location.Y + size.Height + size.Height / 3), false,speed);

            }
        }
        /// <summary>
        /// Moves the projectile of the enemy.
        /// </summary>
        /// <param name="height">Height of the form.</param>
        public void projMove(int height)
        {
            if (projectile != null)
            {
                if (projectile.start.Y + projectile.size.Height >= height-(projectile.speed+35))
                {
                    projectile = null;
                }
                else
                {
                    projectile.Move(false);
                }
            }

        }
        

    }
}
