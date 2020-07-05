using System;

namespace _3_2_1_Dynamic_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDynamicArray<int> array = new MyDynamicArray<int>(new int[] { 2, 3, 4 });



            foreach (var item in array)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}
