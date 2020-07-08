using System;

namespace Practice1_2
{
    class Task1_2_3
    {
        static void Main(string[] args)
        {
            string str = "Антон хорошо начал утро: послушал Стинга, выпил кофе и посмотрел Звёздные Войны";

            char[] simbols = { ' ', '.', ',', '!', '?', '"', '\'', ':', ';' };

            string[] strs = str.Split(simbols, StringSplitOptions.RemoveEmptyEntries);


            int Count = 0;
            for (int i = 0; i < strs.Length; i++)
            {
                foreach (var item in strs[i])
                {
                    if (char.IsLower(item))
                    {
                        Count++;
                    }

                    break;
                }
            }

            Console.WriteLine("Lowercase");
            Console.WriteLine(new string('-', 20));

            Console.WriteLine("Text: ");
            Console.WriteLine(str);

            Console.WriteLine(new string('-', 20));

            Console.WriteLine("Sum: " + Count);

            Console.ReadKey();
        }
    }
}
