using System;
using System.Collections.Generic;
using System.Text;

namespace MyTools
{
    public class ReadTools
    {
        static public int ReadInt(string question)
        {
            int input;

            Console.Write(question);
            input = int.Parse(Console.ReadLine());

            return input;
        }

        static public int ReadInt(string question, int min, int max)
        {
            int input;

            Console.Write(question);
            input = int.Parse(Console.ReadLine());

            while (input <= min || input >= max)
            {
                Console.Write(question);
                input = int.Parse(Console.ReadLine());
            }
            
            return input;
        }

        static public string ReadString(string question)
        {
            string input;

            Console.Write(question);
            input = Console.ReadLine();

            return input;
        }
    }
}
