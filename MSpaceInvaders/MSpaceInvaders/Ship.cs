using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSpaceInvaders
{
    public class Ship
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Size size { get; set; }
        public Rectangle bounds { get; set; }
        public Image Img = Properties.Resources.Space_Ship;

        public Ship(int x, int y)
        {
            X = x;
            Y = y;
            size = new Size(40, 40);
            bounds = new Rectangle(new Point(X, Y), size);
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(Img, X, Y,size.Width,size.Height);
        }

        public void Move(int State)
        {
            if (State == 0)
            {
                X = X - 20;
                bounds = new Rectangle(new Point(X, Y), size);
            }
            else
            {
                X = X + 20;
                bounds = new Rectangle(new Point(X, Y), size);
            }
        }

        public bool isHit(Projectile p)
        {
            return (bounds.IntersectsWith(p.bounds)&&p!=null);
        }
    }
}
