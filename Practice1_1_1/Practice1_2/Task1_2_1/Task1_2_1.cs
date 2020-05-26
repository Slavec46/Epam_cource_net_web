using System;
using System.Collections.Generic;
using System.Text;

namespace Practice1_2
{
    class Task1_2_1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Averages");
            Console.WriteLine(new string('-', 20));

            Console.WriteLine("Enter text:");

            string str = Console.ReadLine();

            Console.WriteLine(new string('-', 20));

            char[] simbols = { ' ', '.', ',', '!', '?', '"', '\'', ':', ';' };
            List<StringBuilder> list = new List<StringBuilder>();

            // Деление на слова
            int Count = 0;
            foreach (var item in str.Split(simbols, StringSplitOptions.RemoveEmptyEntries))
            {
                if (string.IsNullOrWhiteSpace(item)) continue;

                list.Add(new StringBuilder());

                // Устранение знаков припинаний
                foreach (char simbol in item)
                {
                    if (char.IsSeparator(simbol)) break;

                    list[Count].Append(simbol);
                }

                Count++;
            }

            Count = 0;
            foreach (var item in list)
            {
                Count += item.Length;
            }
            // был выбран подсчет с округлением
            Count /= list.Count;


            Console.WriteLine($"Average long of word: {Count}");

            Console.ReadKey();
        }


    }
}