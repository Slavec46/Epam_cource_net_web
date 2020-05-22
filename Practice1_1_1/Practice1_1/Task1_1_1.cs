using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1_1_1
{
    class Task1_1_1
    {
        static void Main()
        {
            int a, b;
            bool repeat = true;
            while (repeat)
            {
                do
                {
                    Console.Write("A = ");
                }
                while (!int.TryParse(Console.ReadLine(), out a));
                do
                {
                    Console.Write("B = ");
                }
                while (!int.TryParse(Console.ReadLine(), out b));
                if (a <= 0 || b <= 0)
                {
                    Console.WriteLine("Ошибка, попробовать еще раз? Да/Нет"); // возможно правильнее было бы Yes/No, 
                    var ki = Console.ReadKey(true); // но раз уж все в консоли на русском, то пусть будет
                    if (ki.Key != ConsoleKey.L)
                        repeat = false;
                    continue;
                }
                Console.WriteLine("Длина: {0}, Ширина: {1}, Площадь: {2}", a, b, a * b); 
                repeat = false;
                Console.ReadKey();
            }
        }
    }
 }
