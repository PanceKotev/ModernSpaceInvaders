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
        /// <summary>
        /// Constructor of the Star class which is used for the background of levels.
        /// Randomly chooses which type of star and its location.
        /// </summary>
        /// <param name="Width">Width of the form.</param>
        /// <param name="Height">Height of the form.</param>
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
        /// <summary>
        /// Draws the star depending on the type.
        /// </summary>
        /// <param name="g">Graphics object of the form.</param>
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
    }
}
