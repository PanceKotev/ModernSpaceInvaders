using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSpaceInvaders
{
    public class Enemy
    {
        public Image image { get; set; }
        public Point location{get;set;}
        public Projectile projectile { get; set; }
        public Size size { get; set; }
        public int speed { get; set; }
        public Enemy(Point loc)
        {
            location = loc;
            image = Properties.Resources.enemy_ship;
            projectile = null;
        }
        public void Draw(Graphics g)
        {
            g.DrawImage(image, location.X, location.Y, 40, 40);
        }
    }
}
