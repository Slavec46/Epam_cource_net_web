using System;
using System.Collections.Generic;

namespace Task_3_1_1_Weakest_Text
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int _lenght = 0;
                int _coef = 0;
                List<int> _people = new List<int>();


                Console.WriteLine("Enter N:");

                int.TryParse(Console.ReadLine(), out _lenght);

                Console.WriteLine("Enter a people which became deleted on that step:");

                int.TryParse(Console.ReadLine(), out _coef);


                if (_lenght < 1 || _coef < 1)
                {
                    continue;
                }

                for (int i = 0; i < _lenght; i++)
                {
                    _people.Add(i);
                }

                Console.WriteLine($"Generate people: {_lenght}. Begin deleted {_coef}");


                for (int round = 0, index = 0, count = 0; _coef <= _people.Count; index++, count++)
                {
                    if (count == _coef - 1)
                    {
                        round++;

                        _people.RemoveAt(index);

                        count = -1;

                        Console.WriteLine($"Round {round}. Person was deleted. People staying: {_people.Count}");
                    }

                    if (index >= _people.Count - 1)
                    {
                        index = -1;
                    }
                }

                Console.WriteLine("Game over. Impossible to delete any person");
                Console.ReadKey();
            }
        }
    }
}