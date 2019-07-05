using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSpaceInvaders
{
    public class Projectile
    {
        public Point start { get; set; }
        public int speed { get; set; }
        public Size size { get; set; }
        public bool Friendly { get; set; }
        public Rectangle bounds { get; set; }
        /// <summary>
        /// Constructor for projectile class.
        /// </summary>
        /// <param name="s">Point it should appear at.</param>
        /// <param name="f">If it is friendly.</param>
        /// <param name="sp">Speed of the projectile.</param>
        public Projectile(Point s,bool f,int sp=10)
        {
            speed = sp;
            size = new Size(5,9);
            start = s;
            bounds = new Rectangle(start, size);
            Friendly = f;
        }
        /// <summary>
        /// Draws the projectile green if it is friendly,red if it is not.
        /// </summary>
        /// <param name="g">Graphics object from the form.</param>
        public void Draw(Graphics g)
        {
            Brush b;
            if (Friendly)
                b = new SolidBrush(Color.Green);
            else
                b = new SolidBrush(Color.Red);
            g.FillRectangle(b,start.X,start.Y,size.Width,size.Height);
        }
        /// <summary>
        /// Moves the projectile up or down depending on the parameter up.
        /// </summary>
        /// <param name="up">True for down, False for up.</param>
        public void Move(bool up)
        {
            if (up)
            {
              start = new Point(start.X, start.Y - speed);
                bounds = new Rectangle(start, size);
            }
            else {
                start = new Point(start.X, start.Y + speed);
                bounds = new Rectangle(start, size);
            }
        }
    }
}
