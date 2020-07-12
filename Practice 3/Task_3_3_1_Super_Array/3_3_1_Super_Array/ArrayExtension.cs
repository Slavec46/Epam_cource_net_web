using System;
using System.Collections.Generic;
using System.Text;

namespace _3_3_1_Super_Array
{
    public static class ArrayExtension
    {
        public delegate double ChangeElements(double element); // delegate perform action on elements
        public delegate double SearchValues(double[] array); // delegate for search values

        public static double[] ChangeArrayElements(this double[] array, ChangeElements changeEl)
        {
            double[] newArray = new double[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = changeEl.Invoke(array[i]);
            }
            return newArray;
        }
        public static double MultiplyByTwo(double n) // for extension method "ChangeArrayElements"
        {
            return n * 2;
        }
        public static double SquareIt(double n) // for extension method "ChangeArrayElements"
        {
            return n * n;
        }

        public static double SearchArrayValues(this double[] array, SearchValues searchVal)
        {
            return searchVal.Invoke(array);
        }
        public static double SumArrayElements(double[] array) // for extension method "SearchArrayValues" - search sum of values
        {
            double sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            return sum;
        }
        public static double AverageArrayElements(double[] array)  // for extension method "SearchArrayValues" - search everage value
        {
            double average = 0;
            for (int i = 0; i < array.Length; i++)
            {
                average += array[i];
            }
            return average / array.Length;
        }
        public static double CommonArrayElement(double[] array) // for extension method "SearchArrayValues" - search most common values
        {
            int count = 0;
            int index = -1;
            for (int i = 0; i < array.Length; ++i)
            {
                int k = 1;
                for (int j = i + 1; j < array.Length; ++j)
                {
                    if (array[i] == array[j]) k++;
                }
                if (k <= count) continue;
                count = k;
                index = i;
            }
            return array[index];
        }
    }
}