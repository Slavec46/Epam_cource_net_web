using System;
using System.Text;

namespace Practice1_2.Task1_2_4
{
    class Task1_2_4
    {
        static void Main(string[] args)
        {
            string str = "я плохо учил русский язык. забываю начинать предложения с заглавной. хорошо, что можно написать программу!";


            StringBuilder newStr = new StringBuilder();

            bool firstSimbol = true;
            foreach (var item in str)
            {
                if (firstSimbol == true)
                {
                    switch (item)
                    {
                        case ' ':
                        case '.':
                        case '!':
                        case '?':
                            newStr.Append(item);
                            break;

                        default:
                            newStr.Append(char.ToUpper(item));
                            firstSimbol = false;
                            break;
                    }
                }
                else
                {
                    switch (item)
                    {
                        case '.':
                        case '!':
                        case '?':
                            newStr.Append(item);
                            firstSimbol = true;
                            break;

                        default:
                            newStr.Append(item);
                            break;
                    }
                }
            }

            // Вывод
            Console.WriteLine("Validator");
            Console.WriteLine(new string('-', 105));

            Console.WriteLine("Text: ");
            Console.WriteLine(str);

            Console.WriteLine(new string('-', 105));

            Console.WriteLine("New text: ");
            Console.WriteLine(newStr);

            Console.ReadKey();
        }
    }
}
