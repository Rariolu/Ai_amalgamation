using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ai_amalgamation;

namespace Demo
{
    class Program
    {
        static string[] commands = new string[]
        {
            "exit",
            "aiml",
            "help",
            "words",
            "d_aiml"
        };
        static void Main(string[] args)
        {
            
            while(true)
            {
                Console.WriteLine("Enter command:");
                string command = Console.ReadLine().ToLower();
                switch(command)
                {
                    case "exit":
                        Console.WriteLine("You are going to die one day.");
                        return;
                    case "aiml":
                        SpeakToAIML();
                        break;
                    case "help":
                        Console.Write("The available commands are: ");
                        foreach(string cmd in commands)
                        {
                            Console.Write(cmd + "; ");
                        }
                        Console.WriteLine();
                        break;
                    case "words":
                        foreach(string word in Words)
                        {
                            Console.WriteLine(word);
                        }
                        break;
                    case "d_aiml":
                        DoubleAIML();
                        break;
                }
            }

        }
        static void SpeakToAIML()
        {
            Console.WriteLine("Type \"exit\" to stop chatting to this pleb.");
            string path = Path.GetFullPath(@"..\..\..\config\Settings.xml");
            CuteRobot cr = new CuteRobot(path);
            while(true)
            {
                Console.Write("You: ");
                string command = Console.ReadLine().ToLower();
                if (command == "exit")
                {
                    Console.WriteLine("AIML: Goodbye.");
                    return;
                }
                Console.WriteLine("AIML: " + cr.GetOutput(command));
            }//g
        }
        static void DoubleAIML()
        {
            string path = Path.GetFullPath(@"..\..\..\config\Settings.xml");
            CuteRobot botA = new CuteRobot(path);
            CuteRobot botB = new CuteRobot(path);
            string textB = new Random().Next().ToString();
            Console.WriteLine("botB: {0}",textB);
            for (int i = 0; i < 10; i++)
            {
                string textA = botA.GetOutput(textB);
                Console.WriteLine("botA: {0}", textA);
                textB = botB.GetOutput(textA);
                Console.WriteLine("botB: {0}", textB);
            }
        }
        const string wordsfile = "..\\..\\..\\words.txt";
        static string[] _words = new string[0];
        static string[] Words
        {
            get
            {
                if (_words.Length < 1)
                {
                    return _words = File.ReadAllLines(wordsfile);
                }
                return _words;
            }
        }
    }
}