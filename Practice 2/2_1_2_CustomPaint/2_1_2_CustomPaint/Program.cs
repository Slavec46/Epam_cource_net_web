using _2_1_2_CustomPaint.Figures;
using _2_1_2_CustomPaint.Figures.Circle;
using _2_1_2_CustomPaint.Figures.Side;
using System;
using System.Collections.Generic;

namespace _2_1_2_CustomPaint
{
    class Program
    {
        static void Main(string[] args)
        {
            List<AbstractFigure> figure = new List<AbstractFigure>();

            while (true)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine(
                    "1. Добавить фигуру \n" +
                    "2. Вывести фигуры \n" +
                    "3. Отчистить холст \n" +
                    "4. Выход \n"
                    );

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:

                        Console.WriteLine("Выберите фигуру:");
                        Console.WriteLine(
                    "1. Круг \n" +
                    "2. Кольцо \n" +
                    "3. Треугольник \n" +
                    "4. Четырехугольник \n"
                    );

                        int enter1 = 0;
                        int enter2 = 0;

                        switch (Console.ReadKey(true).Key)
                        {
                            case ConsoleKey.NumPad1:
                            case ConsoleKey.D1:

                                while (true)
                                {
                                    Console.WriteLine("Фигура Круг");
                                    Console.WriteLine("Введите радиус: ");

                                    if (int.TryParse(Console.ReadLine(), out enter1))
                                    {
                                        figure.Add(new Circle(enter1));
                                        break;
                                    }
                                }

                                break;

                            case ConsoleKey.NumPad2:
                            case ConsoleKey.D2:

                                while (true)
                                {
                                    Console.WriteLine("Фигура Кольцо");
                                    Console.WriteLine("Введите внешний радиус: ");

                                    if (int.TryParse(Console.ReadLine(), out enter1))
                                    {

                                    }

                                    Console.WriteLine("Введите внутренний радиус: ");

                                    if (int.TryParse(Console.ReadLine(), out enter2))
                                    {
                                        figure.Add(new Ring(new Circle(enter1), new Circle(enter2)));
                                        break;
                                    }

                                }

                                break;

                            case ConsoleKey.NumPad3:
                            case ConsoleKey.D3:

                                while (true)
                                {
                                    Console.WriteLine("Фигура Трехугольник");
                                    Console.WriteLine("Введите колличество длинн сторон через запятую (1-2): ");

                                    string[] str = Console.ReadLine().Split(',');

                                    if (str.Length > 0 && int.TryParse(str[0], out enter1))
                                    {
                                        if (str.Length > 1 && int.TryParse(str[1], out enter2))
                                        {
                                            figure.Add(new Poligon(TypeFigure.Triangle, new Side(enter1), new Side(enter2)));
                                        }
                                        else
                                        {
                                            figure.Add(new Poligon(TypeFigure.Triangle, new Side(enter1)));
                                        }
                                        break;
                                    }
                                }

                                break;

                            case ConsoleKey.NumPad4:
                            case ConsoleKey.D4:

                                while (true)
                                {
                                    Console.WriteLine("Фигура Четырехугольник");
                                    Console.WriteLine("Введите колличество длинн сторон через запятую (1-2): ");

                                    string[] str = Console.ReadLine().Split(',');

                                    if (str.Length > 0 && int.TryParse(str[0], out enter1))
                                    {
                                        if (str.Length > 1 && int.TryParse(str[1], out enter2))
                                        {
                                            figure.Add(new Poligon(TypeFigure.Quadrangle, new Side(enter1), new Side(enter2)));
                                        }
                                        else
                                        {
                                            figure.Add(new Poligon(TypeFigure.Quadrangle, new Side(enter1)));
                                        }
                                        break;
                                    }
                                }

                                break;

                            default:
                                break;
                        }

                        break;
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:

                        Console.Clear();
                        foreach (var item in figure)
                        {
                            Console.WriteLine(item.ToString());
                            Console.WriteLine($"Aria: {item.Aria}, Circumference: {item.Circumference} \n");
                        }

                        break;
                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:

                        Console.Clear();
                        figure.Clear();

                        break;
                    case ConsoleKey.NumPad4:
                    case ConsoleKey.D4:

                        return;

                    default:
                        break;
                }
            }
        }
    }
}