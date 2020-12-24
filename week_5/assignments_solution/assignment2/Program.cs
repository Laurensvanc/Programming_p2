using System;
using CandyCrushLogic;

namespace assignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            Program MyProgram = new Program();
            MyProgram.Start();
        }

        void Start()
        {
            RegularCandies[,] playingField = new RegularCandies[5, 5];

            InitCandies(playingField);

            DisplayCandies(playingField);

            bool scoreRow = CandyCrusher.ScoreRowPresent(playingField);
            bool scoreColumn = CandyCrusher.ScoreColumnPresent(playingField);

            if (scoreRow)
            {
                Console.WriteLine("row score");
            }
            else
            {
                Console.WriteLine("no row score");
            }

            if (scoreColumn)
            {
                Console.WriteLine("column score");
            }
            else
            {
                Console.WriteLine("no column score");
            }
        }

        void InitCandies(RegularCandies[,] input)
        {
            Random rnd = new Random();

            for (int i = 0; i < input.GetLength(0); i++)
            {
                for (int j = 0; j < input.GetLength(1); j++)
                {
                    input[i, j] = (RegularCandies)rnd.Next(0, 6);
                }
            }
        }

        void DisplayCandies(RegularCandies[,] input)
        {
            for (int i = 0; i < input.GetLength(0); i++)
            {
                for (int j = 0; j < input.GetLength(1); j++)
                {
                    switch (input[i, j])
                    {
                        case RegularCandies.Jellybean:
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        case RegularCandies.Lozenge:
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            break;
                        case RegularCandies.LemonDrop:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                        case RegularCandies.Gum_Square:
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;
                        case RegularCandies.LollipopHead:
                            Console.ForegroundColor = ConsoleColor.Blue;
                            break;
                        case RegularCandies.Jujube_Cluster:
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            break;
                        default:
                            Console.ResetColor();
                            break;
                    }

                    Console.Write("# ");
                }
                Console.WriteLine();
            }
            Console.ResetColor();
        }
    }
}

