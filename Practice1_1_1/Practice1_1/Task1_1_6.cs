using System;
using FontStyle;


namespace Practice1_1
{
    class Task1_1_6
    {
        static void Main(string[] args)
        {
            var Font = Style.None;
            byte Number;
            bool flag = true;

            while (flag)
            {
                Console.WriteLine("1: Bold" + Environment.NewLine +
                                  "2: Italic" + Environment.NewLine +
                                  "3: Underline" + Environment.NewLine +
                                  "4: None");
                Console.Write($"{Environment.NewLine}Choose font style {Environment.NewLine}==> ");
                byte.TryParse(Console.ReadLine(), out Number);

                Font = ChooseFont(Number, Font); //Call function

                Console.Write($"Choose other style? { Environment.NewLine }1: Yes 2: No {Environment.NewLine}==> ");

                byte.TryParse(Console.ReadLine(), out Number);

                switch (Number)
                {
                    case 1:
                        flag = true;
                        break;
                    case 2:
                        flag = false;
                        break;
                    default:
                        break;
                }

                if (!flag)
                {
                    break;
                }
            }
        }
        static Style ChooseFont(byte id, Style font)
        {

            switch (id)
            {
                case 1:
                    Console.WriteLine($"{ Environment.NewLine }Choose {Style.Bold} {Environment.NewLine}");
                    return Style.Bold;
                case 2:
                    Console.WriteLine($"{ Environment.NewLine }Choose {Style.Italic} {Environment.NewLine}");
                    return Style.Italic;
                case 3:
                    Console.WriteLine($"{ Environment.NewLine }Choose {Style.Underline} {Environment.NewLine}");
                    return Style.Underline;
                case 4:
                    Console.WriteLine($"{ Environment.NewLine }Choose {Style.None} {Environment.NewLine}");
                    return Style.None;
                default:
                    Console.WriteLine($"{Environment.NewLine}Style not found, style has not changed {Environment.NewLine}");
                    return font;
            }
        }
    }
}
