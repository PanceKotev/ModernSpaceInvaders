using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSpaceInvaders
{
    public enum Projectile_Type
    {
        NORMAL,
        DOUBLE
    }
    public class Projectile
    {
        public Point start { get; set; }
        public int speed { get; set; }
        public Size size { get; set; }
        public Projectile_Type Type { get; set; }
        public bool Friendly { get; set; }

        public Projectile(Point s,bool f)
        {
            Type = Projectile_Type.NORMAL;
            speed = 10;
            size = new Size(10,10);
            start = s;
            Friendly = f;
        }
        public void Draw(Graphics g)
        {
            Brush b;
            if (Friendly)
                b = new SolidBrush(Color.Blue);
            else
                b = new SolidBrush(Color.Red);
            if (Type==Projectile_Type.NORMAL)
            g.FillRectangle(b,start.X-size.Width/2,start.Y,size.Width,size.Height);
            else
            {
                g.FillRectangle(b, start.X - ((size.Width / 2)+10), start.Y, size.Width, size.Height);
                g.FillRectangle(b, start.X - ((size.Width / 2) - 10), start.Y, size.Width, size.Height);
            }
        }
        public void Move(bool up)
        {
            if (up)
            {
              start = new Point(start.X, start.Y - speed);
            }
            else {
                start = new Point(start.X, start.Y + speed);
            }
        }
    }
}
