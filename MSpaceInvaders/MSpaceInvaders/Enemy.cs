using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
        public Enemy(Point loc)
        {
            size = new Size(40, 40);
            location = loc;
            bounds = new Rectangle(loc, size);
            velocityX = size.Width / 3;
            velocityY = size.Height / 3;
            image = Properties.Resources.enemy_ship;
            projectile = null;
            random = rand.Next(50, 200);
            isDead = false;

        }
        public void Draw(Graphics g)
        {
            g.DrawImage(image, location.X, location.Y, size.Width,size.Height);
            if (projectile != null)
                projectile.Draw(g);
        }
        public bool isHit(Projectile p)
        {
            
            return (bounds.IntersectsWith(p.bounds) && !isDead);
        }
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
        public bool isHit(Ship s)
        {
            return (bounds.IntersectsWith(s.bounds) && !isDead);
        }
        public void Fire()
        {
            if(!isDead)
            projectile = new Projectile(new Point(location.X + size.Width / 2, location.Y + size.Height + size.Height/3),false);
        }
        public void projMove(int height)
        {
            if (projectile != null)
            {
                if (projectile.start.Y + projectile.size.Height >= height-projectile.speed)
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
