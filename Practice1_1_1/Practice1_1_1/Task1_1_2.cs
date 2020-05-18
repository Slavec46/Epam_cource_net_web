using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1_1_1
{
    class Task1_1_2
    {
        static void Main()
        {
            int i = 0;
            int n = 0;
            while (i < 10)
            {
                while (n < 10)
                {
                    if (i > n)
                    {
                        Console.Write("*");
                    }
                    n++;
                }
                Console.WriteLine();
                n = 0;
                i++;
            }
            Console.ReadKey();
        }
    }
}
