using System;
using System.Threading;
using static System.Console;

namespace Task_3_3_3_Pizza_Time
{
    internal class User // class describes a user making order
    {
        public event OrdersHandler onMakeOrder; // order receipt event

        public string ID { get; }
        public string Name { get; }

        public User(string iD, string name)
        {
            ID = iD;
            Name = name;
        }

        public void MakeOrder(Menu order)
        {
            ForegroundColor = ConsoleColor.Red;
            WriteLine($"ID: {ID} Name: {Name} -> order pizza {order}");
            ResetColor();
            onMakeOrder?.Invoke(order);
        }

        public void PickUpOrder(Menu pizza)
        {
            ForegroundColor = ConsoleColor.Yellow;
            Thread.Sleep(1000);
            WriteLine($"ID: {ID} Name: {Name} -> get pizza {pizza}. Thanks!");
            ResetColor();
            WriteLine();
        }
    }
}
