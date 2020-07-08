using System;

namespace Task_3_1_2_Text_Analysis
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine(new string('=', 20));
                Console.WriteLine("Text_Analysis");
                Console.WriteLine(new string('=', 20));

                Console.WriteLine("Enter text:");

                AnalizeMachie analyzer = new AnalizeMachie(Console.ReadLine());

                Console.WriteLine(new string('=', 20));

                Console.Write(analyzer.ToString());

                Console.WriteLine(new string('=', 20));

                Console.WriteLine("To exit press \"e\"");

                if (Console.ReadKey().Key == ConsoleKey.E)
                {
                    Environment.Exit(0);
                }

                Console.Clear();
            }
        }
    }
}