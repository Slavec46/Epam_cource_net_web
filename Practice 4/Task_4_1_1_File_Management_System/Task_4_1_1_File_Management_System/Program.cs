using System;
using System.IO;


namespace Task_4_1_1_File_Management_System
{
    class Program
    {
        private static bool flagForWrite = true;
        private static string pathToCatalog;

        static void Main() // Прежде чем запускать проверьте в режиме отладки верное ли значение Type в классе Restoration.cs
        {
            try
            {
                if (flagForWrite)
                {
                    flagForWrite = false;
                    Console.WriteLine("Введите путь к каталогу: ");
                    pathToCatalog = Console.ReadLine();
                }

                var tracker = new Tracker(@pathToCatalog);
                Console.ReadLine();
                tracker.Dispose();
            }
            #region catch
            catch
                (DirectoryNotFoundException
                exception)
            {
                Console.WriteLine(exception.Message);

                Console.WriteLine("Создать его? y/n");

                if (Console.ReadKey().Key == ConsoleKey.Y)
                {
                    try
                    {
                        Directory.CreateDirectory(exception.Message);
                        Console.Clear();

                        Main();
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    return;
                }
            }
            #endregion
        }
    }
}