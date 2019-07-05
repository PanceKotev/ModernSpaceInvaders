using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSpaceInvaders
{
    public class Gift
    {
        public Image sprite { get; set; }
        public Point location { get; set; }
        public Upgrade modifier { get; set; }
        public UpgradeType type
        {
            get
            {
                return modifier.type;
            }
        }
        public int amount { get
            {
                return modifier.amount;
            } }
        public static Random random = new Random();
        /// <summary>
        /// Constructor for the class Gift.
        /// </summary>
        /// <param name="loc">Location of the Gift.</param>
        public Gift(Point loc)
        {
            location = loc;
            sprite = Properties.Resources.upgradebox;
            modifier = new Upgrade();
        }
        /// <summary>
        /// Draws the gift.
        /// </summary>
        /// <param name="g">Graphics object from the form.</param>
        public void Draw(Graphics g)
        {
            g.DrawImage(sprite, location.X,location.Y,25,25);
        }
        /// <summary>
        /// Checks whether the gift collides with the ship s.
        /// </summary>
        /// <param name="s">Ship object(player).</param>
        /// <returns>Returns true if the gift colldies with the player.</returns>
        public bool isHit(Ship s)
        {
            Rectangle b = new Rectangle(location, new Size(25, 25));
            return b.IntersectsWith(s.bounds);
        }
        /// <summary>
        /// Moves the gift down.
        /// </summary>
        public void Move()
        {
            location = new Point(location.X, location.Y + 10);
        }
    }
}
