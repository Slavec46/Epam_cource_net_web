using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Practice1_1
{
    class Task1_1_3
    {
        static void Main(string[] args)
        {
            Console.Write("Enter N: ");


            if (ulong.TryParse(Console.ReadLine(), out var Number))
            {
                Console.WriteLine("");
                ShowTriangle(Number);
            }
            else
            {
                Console.WriteLine("Enter a positive number");
            }

            Console.ReadLine();
        }

        static void ShowTriangle(ulong number)
        {
            if (number != 0)
            {
                for (ulong j = 1; number > 0; j+=2, number--)
                {
                    Console.WriteLine(new String(' ',(int)number) + new String('*', (int)j));
                }
            }
            else
            {
                Console.WriteLine("is nothing to draw");
            }
        }
    }
}