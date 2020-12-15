using System;
using System.IO;
using System.Text.RegularExpressions;

namespace assignment3
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Invalid number of arguments!");
                Console.WriteLine("usage: assignment[2-3] <filename>");
                return;
            }

            string filename = args[0];

            Program mainProgram = new Program();
            mainProgram.Start();
        }

        void Start()
        {
            string query = ReadString("Enter a word (to search): ");

            int result = SearchWordInFile("tweets-donaldtrump-2018.txt", query);
            Console.WriteLine($"Number of tweets containing the word: {result}");

            Console.ReadKey();
        }

        bool WordInLine(string line, string word)
        {
            foreach (string split in line.Split(' '))
            {
                if (word.ToLower() == split.ToLower())
                {
                    return true;
                }
            }
            return false;
        }

        int SearchWordInFile(string filename, string word)
        {
            StreamReader sr = new StreamReader(filename);
            int lines = 0;

            while (!sr.EndOfStream)
            {
                string currentLines = sr.ReadLine();

                if (WordInLine(currentLines, word))
                {
                    DisplayWordInLine(currentLines, word);
                    lines++;
                }
            }

            sr.Close();
            return lines;

        }

        void DisplayWordInLine(string line, string word)
        {
            string pattern = @"(?i)(?<= |^)" + word + "(?= |$)";
            MatchCollection matches = Regex.Matches(line, pattern);

            if (matches.Count > 0)
            {
                int startIndex = 0;
                int endIndex = matches[0].Index;

                string startString = line.Substring(startIndex, endIndex);

                Console.Write(startString);

                for (int i = 0; i < matches.Count; i++)
                {
                    int wordIndex = matches[i].Index;
                    int wordLength = matches[i].Value.Length;
                    int wordEnd = wordIndex + wordLength;
                    int sentenceRemaining = 0;

                    startString = line.Substring(wordIndex, wordLength);

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"[{startString}]");

                    if (i > matches.Count - 2)
                    {
                        int sentenceEnd = line.Length;
                        sentenceRemaining = sentenceEnd - wordEnd;
                    }
                    else
                    {
                        int sentenceEnd = matches[i + 1].Index;
                        sentenceRemaining = sentenceEnd - wordEnd;
                    }

                    string endString = line.Substring(wordEnd, sentenceRemaining);
                    Console.ResetColor();
                    Console.Write(endString);
                    
                }

                Console.WriteLine("\n");
            }
        }

        string ReadString(string question)
        {
            Console.Write(question);
            string input = Console.ReadLine();

            return input;
        }
    }
}
