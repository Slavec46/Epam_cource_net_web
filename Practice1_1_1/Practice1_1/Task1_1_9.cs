using System;

namespace Practice1_1
{
    class Task1_1_9
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { -9, 4, -11, 0, 0, 1, -2, 2, -6, 1 };

            Console.WriteLine("Negative sum");
            Console.WriteLine(new string('-', 20));

            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.WriteLine(new string('-', 20));

            Console.WriteLine($"Sum: { SumPositiveElements(array) }");

            Console.ReadKey();
        }

        /// Возвращает сумму положительных элементов массива       
        static int SumPositiveElements(int[] array)
        {
            int sum = 0;

            foreach (int item in array)
            {
                if (item > 0)
                    sum += item;
            }

            return sum;
        }
    }
}
