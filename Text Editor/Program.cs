using System;
using System.Windows;

namespace Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to text editor .NET! What would you like to do?");
            Console.WriteLine("1 = Browse files. 2 = Create file. 3 = Settings");
            int answer = 100;

            try
            {
                answer = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Answer format was unsupported. Please try again.");
                Console.ReadKey();
                Console.Clear();
                Main(args);
            }

            Files files = new Files();

            switch (answer)
            {
                case 1:
                    files.Open();
                    break;

                case 2:
                    Console.Clear();
                    files.NewFile();
                    break;

                case 3:
                    break;

                default:
                    Console.WriteLine("Answer wasnt supported. Please try again");
                    Console.ReadKey();
                    Console.Clear();
                    Main(args);
                    break;
            }

            //Source: https://stackoverflow.com/questions/8962691/console-readlinedefault-text-editable-text-on-line#comment45853612_8962845
            /*Console.Write("Your editable text:");
            SendKeys.SendWait("hello"); //hello text will be editable :)
            Console.ReadLine();*/
        }
    }
}