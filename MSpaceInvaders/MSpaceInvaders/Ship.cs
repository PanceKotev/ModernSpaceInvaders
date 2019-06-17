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
        public Image Img = Properties.Resources.Space_Ship;

        public Ship(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(Img, X, Y);
        }

        public void Move(int State)
        {
            if (State == 0)
                X =X- 20;
            else
                X = X+20;
        }

        public bool isHit(Projectile p)
        {
            return (p.start.X - p.size.Width / 2 >= X && p.start.X - p.size.Width / 2 <= X + 40 && p.start.Y >= Y + 10 && p.start.Y <=Y + 30 - 17);
        }
    }
}
