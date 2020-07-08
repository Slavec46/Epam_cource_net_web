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
            int f = 0;
            Console.Write("N = ");
            int.TryParse(Console.ReadLine(), out int n);
            while (i <= n)
            {
                while (f < n)
                {
                    if (i > f)
                    {
                        Console.Write("*");
                    }
                    f++;
                }
                Console.WriteLine();
                f = 0;
                i++;
            }
            Console.ReadKey();
        }
    }
}
