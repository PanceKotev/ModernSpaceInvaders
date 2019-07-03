using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSpaceInvaders
{
    public enum UpgradeType
    {
        max_bullets,
        proj_speed,
        life
    }
    public class Upgrade
    {
        public UpgradeType type { get; set; }
        public static Random random = new Random();
        public int amount;
        public Upgrade()
        {
            int dec = random.Next(0, 3);
            if (dec == 0)
            {
                type = UpgradeType.max_bullets;
                amount = 1;
            }
            else if (dec == 1)
            {
                type = UpgradeType.proj_speed;
                amount = 1;
            }
            else if (dec == 2)
            {
                type = UpgradeType.life;
                amount = 1;
            }
            
        }

    }
}
