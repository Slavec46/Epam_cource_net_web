using System;

namespace CustomString2_1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            MyString myString1 = new MyString("zi");
            MyString myString2 = new MyString("z");

            Console.WriteLine($"MyString.Compare(): \t{MyString.Compare(myString1, myString2)}");
            Console.WriteLine($"myString1.CompareTo(): \t{myString1.CompareTo(myString2)}");

            Console.WriteLine($"myString1.Equals(): \t{myString1.Equals(myString2)}");

            MyString myString3 = myString1 + myString2;
            Console.WriteLine($"myString3.Remove(): \t{myString3.ToString()}");

            myString3.Remove('i');
            Console.WriteLine($"myString3.Remove(): \t{myString3.ToString()}");

            myString3[0] = 'z';
            Console.WriteLine($"myString3[0]: \t\t{myString3.ToString()}");

            Console.ReadKey();
        }
    }
}