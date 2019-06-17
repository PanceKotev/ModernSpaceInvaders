﻿using System;
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
                X -= 20;
            else
                X += 20;
        }
    }
}
