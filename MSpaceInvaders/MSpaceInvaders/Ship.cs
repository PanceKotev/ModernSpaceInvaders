using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
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

        public Image Img = Properties.Resources.ship5;
        public Ship(int x, int y)
        {
            X = x;
            Y = y;
            size = new Size(35, 35);
            bounds = new Rectangle(new Point(X, Y), size);
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(Img, X, Y,size.Width,size.Height);
        }

        public void Move(int State, int Width)
        {
            if (State == 0 && !(X - size.Width <= 0 - size.Width / 2))
            {
                X = X - size.Width/2;
                bounds = new Rectangle(new Point(X, Y), size);
            }
            else if(State == 1 && !(X + size.Width >= Width - size.Width / 2))
            {
                X = X + size.Width/2;
                bounds = new Rectangle(new Point(X, Y), size);
            }
        }

        public bool isHit(Projectile p)
        {
            return (bounds.IntersectsWith(p.bounds)&&p!=null);
        }
    }
}
