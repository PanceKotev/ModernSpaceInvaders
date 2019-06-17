using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSpaceInvaders
{
    public class Game
    {
        public List<Projectile> firedP { get; set; }
        public Ship player { get; set; }
        public void Shoot()
        {
            firedP.Add( new Projectile(new Point(player.X + player.Img.Size.Width / 2, player.Y - 20),true));
        }


    }
}
