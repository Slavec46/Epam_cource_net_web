using static System.Console;

namespace _3_3_1_Super_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            UseExtensionMethods();
        }
        private static void UseExtensionMethods()
        {
            double[] array = new double[] { 1, 2, 2, 3, 3, 3, 4, 5 };
            WriteLine("Исходный массив:");
            foreach (var item in array)
            {
                Write(item + "   ");
            }
            WriteLine();
            double[] array2 = array.ChangeArrayElements(ArrayExtension.MultiplyByTwo);
            WriteLine("Массив после обработки MultiplyByTwo:");
            foreach (var item in array2)
            {
                Write(item + "   ");
            }
            WriteLine();
            double[] array3 = array.ChangeArrayElements(ArrayExtension.SquareIt);
            WriteLine("Массив после обработки SquareIt:");
            foreach (var item in array3)
            {
                Write(item + "   ");
            }
            WriteLine();
            double sum = array.SearchArrayValues(ArrayExtension.SumArrayElements);
            WriteLine("Сумма элементов исходного массива равна " + sum);
            double average = array.SearchArrayValues(ArrayExtension.AverageArrayElements);
            WriteLine("Среднее значение элементов исходного массива равно " + average);
            double common = array.SearchArrayValues(ArrayExtension.CommonArrayElement);
            WriteLine("Наиболее часто повторяющееся значение элементов исходного массива равно " + common);
            ReadKey();
        }
    }
}