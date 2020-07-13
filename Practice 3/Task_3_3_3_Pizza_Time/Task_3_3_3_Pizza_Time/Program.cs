using System;

namespace Task_3_3_3_Pizza_Time
{
    public delegate void OrdersHandler(Menu order);

    internal class Program
    {
        static void Main(string[] args)
        {
            PizzaShop pizzaShop = new PizzaShop("Pizza Shop");

            User user01 = new User("01", "Andrea");
            BuildProcessing(user01, pizzaShop, Menu.Becon);

            User user02 = new User("02", "Bella");
            BuildProcessing(user02, pizzaShop, Menu.Fresh);

            User user03 = new User("03", "Monica");
            BuildProcessing(user03, pizzaShop, Menu.Havana);

            User user04 = new User("04", "Enzo");
            BuildProcessing(user04, pizzaShop, Menu.Italy);

            Console.ReadKey();
        }
        static void BuildProcessing(User user, PizzaShop pizzaShop, Menu order)
        {
            user.onMakeOrder += pizzaShop.CookOrder;
            user.onMakeOrder += pizzaShop.DisplayOnScoreboard;
            pizzaShop.onIssueOrder += user.PickUpOrder;
            user.MakeOrder(order);
            pizzaShop.onIssueOrder -= user.PickUpOrder;
        }
    }
}