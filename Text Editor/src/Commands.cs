using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Text_Editor
{
    internal class Commands
    {
        string path;

        Dictionary<string, string> commandsDic; //Command name - how to execute it (by the user)
        Dictionary<string, string> commandsDef; //Command name - defenition

        public Commands()
        {
            commandsDic = new Dictionary<string, string>();
            commandsDef = new Dictionary<string, string>();

            path = @"./Conf/commands";

            if(!File.Exists(path))
            {
                Create();
            }
        }

        Dictionary<string, string> SetsDefault() //Sets the defualt data of the commands file
        {
            var defualt = new Dictionary<string, string>(); //What should be wrriten by defult. Line by line

            defualt.Add("close", "close=close=closes the file");
            defualt.Add("changeLine", "changeLine=change=Change a specific line in the file");

            return defualt;
        }

        void Create()
        {
            var defualtDic = SetsDefault();

            var f = File.Create(path);
            f.Close();

            using (StreamWriter w = File.AppendText("myFile.txt"))
            {
                foreach(string key in defualtDic.Keys)
                {
                    w.WriteLine(defualtDic[key]);
                }
            }
        }

        public Dictionary<string, string> ReturnCommands()
        {
            var commands = new Dictionary<string, string>();
            if(!File.Exists(path))
            {
                Create();
            }

            var lines = File.ReadAllLines(path);

            // read each line from file
            foreach (var line in lines)
            {
                string[] splited = line.Split('=');
                commands.Add(splited[0], splited[1]);
            }

            return commands;
        }
    }
}
