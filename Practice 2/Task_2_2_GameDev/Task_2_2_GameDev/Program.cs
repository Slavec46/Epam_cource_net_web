using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2_2_GameDev.Units;

namespace Task_2_2_GameDev
{
    class Program
    {
        static void Main(string[] args)
        {
            var gamer = new Player();
            var enemies = new List<Enemy>();

            // Инициализация карты
            // ... (тут)

            // Инициализация списка врагов - с созданием правил из движения!!
            // ... (тут)

            //запуск типа-FPS
            while (true)
            {
                var currentkey = Console.ReadKey();

                switch (currentkey.Key)
                {
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.RightArrow:
                        //Ход игрока
                        gamer.Move(currentkey);

                        //Ходы врагов
                        foreach (var enemy in enemies)
                        {
                         var enemyDirection = enemy.MovementRule.GetDirection();
                         enemy.Move(enemyDirection);
                        }
                        break;
                    case ConsoleKey.X:
                        break;
                    default:

                        break;
                }
            }
        }
    }
}
