using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_2_2_GameDev.Units
{
    public abstract class Unit
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Speed { get; set; }

        public virtual void Move(ConsoleKey keyCodeDirection)
        {
            switch (keyCodeDirection)
            {
                case ConsoleKey.UpArrow:
                    Y += Speed;
                    break;

                case ConsoleKey.DownArrow:
                    Y -= Speed;
                    break;

                case ConsoleKey.RightArrow:
                    X += Speed;
                    break;

                case ConsoleKey.LeftArrow:
                    X -= Speed;
                    break;
                default:
                    break;
            }
        }
    }
}

