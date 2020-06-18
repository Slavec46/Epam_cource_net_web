using System;

namespace Practice1_1
{
    class Task1_1_10
    {
        static void Main(string[] args)
        {
            Console.WriteLine("sum of even element numbers");
            Console.WriteLine(new string('-', 20));

            int[,] array = new int[5, 5];
            int sum = 0;

            Console.WriteLine($"x: {array.GetLength(0)}, y: {array.GetLength(1)}");

            Console.WriteLine(new string('-', 20));

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (((i + j) % 2) == 0)
                        sum += i + j;
                }
            }

            Console.WriteLine($"Sum: { sum }");

            Console.ReadKey();
        }
    }
}