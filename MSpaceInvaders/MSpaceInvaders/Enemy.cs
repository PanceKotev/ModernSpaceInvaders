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

        public Enemy(Point loc)
        {
            size = new Size(40, 40);
            location = loc;
            image = Properties.Resources.enemy_ship;
            projectile = null;
            random = rand.Next(50, 200);

        }
        public void Draw(Graphics g)
        {
            g.DrawImage(image, location.X, location.Y, size.Width,size.Height);
            if (projectile != null)
                projectile.Draw(g);
        }
        public bool isHit(Projectile p)
        {
            return (p.start.X-p.size.Width/2 >= location.X && p.start.X-p.size.Width / 2 <= location.X + size.Width && p.start.Y >= location.Y+10 && p.start.Y <= location.Y + size.Height-17);
        }
        public void Move(Direction dir)
        {
            if (dir == Direction.RIGHT)
                location = new Point(location.X + size.Width / 2, location.Y);
            else if (dir == Direction.LEFT)
                location = new Point(location.X - size.Width / 2, location.Y);
            else
                location = new Point(location.X, location.Y - size.Height);
        }
        public bool isHit(Ship s)
        {
            return (s.X -20 >= location.X && s.X - 20 <= location.X + size.Width && s.Y >= location.Y + 10 && s.Y <= location.Y + size.Height - 17);
        }
        public void Fire()
        {
            projectile = new Projectile(new Point(location.X + size.Width / 2, location.Y + size.Height + 20));
        }
        public void projMove(int height)
        {
            if (projectile != null)
            {
                if (projectile.start.Y + projectile.size.Height >= height)
                {
                    projectile = null;
                }
                else
                {
                    projectile.Move(height, false);
                }
            }

        }
        

    }
}
