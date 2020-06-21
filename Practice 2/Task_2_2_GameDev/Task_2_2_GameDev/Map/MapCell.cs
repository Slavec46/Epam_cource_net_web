using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2_2_GameDev.Units;

namespace Task_2_2_GameDev.Map
{
    public abstract class MapCell
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Gismo Gismo { get; set; }

        public virtual void StepIn(Unit unit)
        {
            if (Gismo != null)
            {
                // логика влияния предмета
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
