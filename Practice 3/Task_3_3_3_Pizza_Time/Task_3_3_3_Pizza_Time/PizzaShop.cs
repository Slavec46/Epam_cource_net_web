using System;
using System.Threading;
using static System.Console;

namespace Task_3_3_3_Pizza_Time
{
    internal class PizzaShop
    {
        public event OrdersHandler onIssueOrder; // order availability event

        public string Name { get; set; }

        public PizzaShop(string name)
        {
            Name = name;
        }

        public void CookOrder(Menu order)
        {
            ForegroundColor = ConsoleColor.Blue;
            Thread.Sleep(1000);
            WriteLine($"{Name} -> Pizza cooking {order}...");
            Thread.Sleep(1500);
            ResetColor();
        }

        public void DisplayOnScoreboard(Menu order)
        {
            ForegroundColor = ConsoleColor.Green;
            WriteLine($"{Name} -> You're order is ready!");
            ResetColor();
            onIssueOrder?.Invoke(order);
        }
    }
}
