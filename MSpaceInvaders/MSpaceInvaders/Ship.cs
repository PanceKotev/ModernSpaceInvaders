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
        public int animationTime { get; set; }
        public Image Img = Properties.Resources.ship5;
        public bool isGettingHit { get; set; }
        /// <summary>
        /// Constructor for the ship class.
        /// </summary>
        /// <param name="x">X coordinate of the ship.</param>
        /// <param name="y">Y coordinate of the ship.</param>
        public Ship(int x, int y)
        {
            animationTime = 0;
            X = x;
            Y = y;
            isGettingHit = false;
            size = new Size(35, 35);
            bounds = new Rectangle(new Point(X, Y), size);
        }

        /// <summary>
        /// Draws the ship normally if isGettingHit is false,
        /// if isGettingHit is true then draws the red version of the ship.
        /// </summary>
        /// <param name="g">Takes the Graphics object of the form.</param>
        public void Draw(Graphics g)
        {
            if (isGettingHit == true && animationTime <= 2)
            {
                g.DrawImage(Properties.Resources.ship5_hit, X, Y, size.Width, size.Height);
                animationTime++;
                if (animationTime == 3)
                {
                    animationTime = 0;
                    isGettingHit = false;
                }
            }
            else
            {
                g.DrawImage(Img, X, Y, size.Width, size.Height);
            }
           
        }
        /// <summary>
        /// Moves the ship depending on the variable state and if the ship is not at the most right or left point of the form.
        /// </summary>
        /// <param name="State">Whether it should move right(1) or left(0)</param>
        /// <param name="Width">The width of the form.</param>
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
        /// <summary>
        /// Checks whether the ship is hit by a projectile.
        /// </summary>
        /// <param name="p">Projectile object.</param>
        /// <returns>Returns true if hit by the projectile p.</returns>
        public bool isHit(Projectile p)
        {
            return (bounds.IntersectsWith(p.bounds)&&p!=null);
        }
    }
}
