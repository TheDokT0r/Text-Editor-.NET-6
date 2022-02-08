using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Text_Editor
{
    public class Files
    {
        string path;

        public Files()
        {

        }

        public void NewFile()
        {
            Console.Write("Dir name ('dif' for default dir): ");
            string dir = Console.ReadLine().ToLower();

            if (dir == "dif")
            {
                return; //Do it later plz
            }

            Console.Write("File name: ");
            string fileName = Console.ReadLine();

            path = Path.Combine(dir, fileName);

            if (File.Exists(path))
            {
                Console.WriteLine("File already exists, please try again!");
                Console.ReadKey();
                Console.Clear();
                NewFile();
            }

            var f = File.Create(path);
            f.Close();

            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;

            Console.WriteLine("Editing: {0}", fileName);
            Console.Clear();

            Commands commands = new Commands();

            while(true)
            {
                using (StreamWriter w = File.AppendText(path))
                {
                    string line = Console.ReadLine();
                    var commandsDic = commands.ReturnCommands(); //Checks for any commands

                    /*if(line == commandsDic["close"])
                    {
                        break;
                    }*/

                    w.WriteLine(line);
                }
            }
        }

        public void Open()
        {
            Console.Write("File path: ");

            path = Console.ReadLine();

            if (!File.Exists(path)) //In case that the file doesn't exists
            {
                Console.WriteLine("Error! This path doesn't exists, please try again");
                Console.ReadKey();
                Console.Clear();
                Open();
            }

            var allText = File.ReadAllLines(path);

            string[] delimiterChars = {
                            "/",
                            "//",
                            "\\",
                            @"\"
                          };
            
            string[] allDirs = path.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries); //Epic gamer moment

            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("Now reading the file: {0}", allDirs[allDirs.Length - 1]);
            Console.ResetColor();

            foreach (string line in allText)
            {
                Console.WriteLine(line);
            }
        }
    }
}
