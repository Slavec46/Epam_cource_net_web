using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_2_2_GameDev
{
    public class Rule
    {
        private int i;
        private List<ConsoleKey> moveSet = new List<ConsoleKey>();

        // заполнение Rule нужно делать отдельно

        public ConsoleKey GetDirection()
        {
            var direction = moveSet[i];
            i++;

            i = i >= moveSet.Count ? 0 : i;

            return direction;
        }
    }
}
