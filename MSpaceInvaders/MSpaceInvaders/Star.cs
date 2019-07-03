using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSpaceInvaders
{
   public class Star
    {
        public Image sprite { get; set; }
        public Point location { get; set; }
        public static Random random = new Random();
        public Star(int Width, int Height)
        {
            int dec = random.Next(0, 2);
            if (dec == 0)
            {
                sprite = Properties.Resources.New_Piskel;
            }
            else
            {
                sprite = null;
            }
           int X = random.Next(10, Width - 10);
            int Y = random.Next(10, Height - 10);
            location = new Point(X, Y);
        }
        public void Draw(Graphics g)
        {
           
            if (sprite!=null)
            {
                g.DrawImage(sprite, location.X, location.Y, 15, 15);
            }
            else
            {
                g.FillRectangle(new SolidBrush(Color.Blue), location.X, location.Y, 4, 4);
            }

        }
        public void Move()
        {
            location = new Point(location.X, location.Y + 10);
        }
    }
}
