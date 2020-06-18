using System;

namespace Practice1_1
{
    class Task1_1_8
    {
        static void Main(string[] args)
        {
            int[][][] array;

            GetArray(out array, 2, 2, 10, new int[] { -9, 9, 0, 1, -1, 1, -2, 4, -1, 4 });

            Console.WriteLine("Negative and zero");
            Console.WriteLine(new string('-', 20));

            OutArray(array);

            Console.WriteLine(new string('-', 20));

            SetElementsIn0(ref array);

            OutArray(array);

            Console.ReadKey();
        }

        /// Инициализирует массив
        private static void GetArray(out int[][][] array, int LenghtArray1, int LenghtArray2, int LenghtArray3, params int[] elements)
        {
            if (LenghtArray3 != elements.Length)
                throw new ArgumentException($"Argument lenght must be ({LenghtArray3})!");

            array = new int[LenghtArray1][][];

            for (int i1 = 0; i1 < LenghtArray1; i1++)
            {
                array[i1] = new int[LenghtArray2][];

                for (int i2 = 0; i2 < LenghtArray2; i2++)
                {
                    array[i1][i2] = new int[LenghtArray3];

                    for (int i3 = 0; i3 < LenghtArray3; i3++)
                    {
                        array[i1][i2][i3] = elements[i3];
                    }
                }
            }
        }

        /// Вывод массива в консоль
        static void OutArray(int[][][] array)
        {
            for (int i1 = 0; i1 < array.Length; i1++)
            {
                for (int i2 = 0; i2 < array[i1].Length; i2++)
                {
                    for (int i3 = 0; i3 < array[i1][i2].Length; i3++)
                    {
                        Console.Write(array[i1][i2][i3] + " ");
                    }
                    Console.WriteLine();
                }
            }
        }

        /// Устанавливает значение 0 всем положительным элементам массива
        private static void SetElementsIn0(ref int[][][] array)
        {
            for (int i1 = 0; i1 < array.Length; i1++)
            {
                for (int i2 = 0; i2 < array[i1].Length; i2++)
                {
                    for (int i3 = 0; i3 < array[i1][i2].Length; i3++)
                    {
                        if (array[i1][i2][i3] > 0)
                            array[i1][i2][i3] = 0;
                    }
                }
            }
        }
    }
}