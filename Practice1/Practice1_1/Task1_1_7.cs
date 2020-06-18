using System;

namespace Practice1_1
{
    class Task1_1_7
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Array Processing");
            Console.WriteLine(new string('-', 20));

            Random rand = new Random();

            int[] array = new int[]
            {
                rand.Next(100),
                rand.Next(100),
                rand.Next(100),
                rand.Next(100),
                rand.Next(100)
            };

            Console.WriteLine("Array:");

            foreach (var item in array)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(new string('-', 20));

            Console.WriteLine($"Min value: {GetMin(array)}\nMax value: {GetMax(array)}");

            Console.WriteLine(new string('-', 20));

            array = SelectionSortArray(array);

            Console.WriteLine("Sorted array:");

            foreach (var item in array)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }

        static int GetMax(int[] array)
        {
            int maxValue = 0;

            foreach (var item in array)
            {
                if (maxValue < item) maxValue = item;
            }

            return maxValue;
        }
        static int GetMin(int[] array)
        {
            int minValue = 2147483647;

            foreach (var item in array)
            {
                if (minValue > item) minValue = item;
            }

            return minValue;
        }

        static int[] SelectionSortArray(int[] array)
        {
            int min, temp;

            for (int i1 = 0; i1 < array.Length - 1; i1++)                       // Итерация текущего элемента
            {
                min = i1;

                for (int i2 = i1 + 1; i2 < array.Length; i2++)                  // выбор минимального значения
                {
                    if (array[i2] < array[min])
                    {
                        min = i2;
                    }
                }
                temp = array[i1];                                               
                array[i1] = array[min];
                array[min] = temp;
            }

            return array;
        }
    }
}
