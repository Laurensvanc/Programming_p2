using System;
using System.Collections.Generic;

namespace assignment3
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("invalid number of arguments!");
                Console.WriteLine("usage: assignment[3-4] <filename>");
                return;
            }

            string filename = args[0];

            Program MyProgram = new Program();
            MyProgram.Start(filename);
        }

        void Start(string filename)
        {
            ReadWords("dictionary.csv");
        }

        Dictionary<string, string> ReadWords(string filename)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            try
            {
                dictionary.Add("txt", filename);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("And element with Key = \"txt\" already exists.");
            }
            

            return dictionary;
        }
    }
}
