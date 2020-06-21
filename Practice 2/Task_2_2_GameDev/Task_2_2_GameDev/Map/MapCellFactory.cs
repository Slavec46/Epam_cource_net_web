using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_2_GameDev.Map
{
    public static class MapCellFactory
    {
        public static MapCell GerRandomCell()
        {
            var rnd = new Random();
            var cellTypeNumber = rnd.Next(3);

            switch (cellTypeNumber)
            {
                case 1:
                    return new Water();
                case 2:
                    return new Rock();
                case 0:
                default:
                    return new Ground();                    
            }
        }
    }
}
