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
        public Gift(Point loc)
        {
            location = loc;
            sprite = Properties.Resources.upgradebox;
            modifier = new Upgrade();
        }
        public void Draw(Graphics g)
        {
            g.DrawImage(sprite, location.X,location.Y,30,30);
        }
        public bool isHit(Ship s)
        {
            Rectangle b = new Rectangle(location, new Size(30, 30));
            return b.IntersectsWith(s.bounds);
        }
        public void Move()
        {
            location = new Point(location.X, location.Y + 10);
        }
    }
}
