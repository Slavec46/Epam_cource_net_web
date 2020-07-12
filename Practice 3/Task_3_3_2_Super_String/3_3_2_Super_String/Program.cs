using static System.Console;

namespace _3_3_2_Super_String
{
    class Program
    {
        static void Main(string[] args)
        {
            OutputToConsole();
        }
        static void OutputToConsole()
        {
            string phrase1 = "абвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
            string phrase2 = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string phrase3 = "0123456789";
            string phrase4 = "v w";
            Languages check = phrase1.CheckLanguage();
            WriteLine("Phrase: " + phrase1);
            WriteLine("Language: " + check);
            WriteLine();
            check = phrase2.CheckLanguage();
            WriteLine("Phrase: " + phrase2);
            WriteLine("Language: " + check);
            WriteLine();
            check = phrase3.CheckLanguage();
            WriteLine("Phrase: " + phrase3);
            WriteLine("Language: " + check);
            WriteLine();
            check = phrase4.CheckLanguage();
            WriteLine("Phrase: " + phrase4);
            WriteLine("Language: " + check);
            ReadKey();
        }
    }
}