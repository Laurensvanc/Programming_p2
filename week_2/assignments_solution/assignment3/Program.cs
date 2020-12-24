using System;

namespace assignment3
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("invalid number of arguments!");
                Console.WriteLine("usage: assignment[1-3] <nrOfColomns>");
                return;
            }

            int nrOfRows = int.Parse(args[0]);
            int nrOfColumns = int.Parse(args[1]);

            Program myProgram = new Program();
            myProgram.Start(nrOfRows, nrOfColumns);
        }

        void Start(int nrOfRows, int nrOfColumns)
        {
            RegularCandies[,] playingField = new RegularCandies[nrOfRows, nrOfColumns];

            InitCandies(playingField);

            DisplayCandies(playingField);

            bool scoreRow = ScoreRowPresent(playingField);
            bool scoreColumn = ScoreColumnPresent(playingField);

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

        bool ScoreRowPresent(RegularCandies[,] input)
        {
            for (int column = 0; column < input.GetLength(0); column++)
            {
                for (int row = 1; row < input.GetLength(1) - 1; row++)
                {
                    if (input[column, row - 1] == input[column, row] &&
                        input[column, row + 1] == input[column, row])
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        bool ScoreColumnPresent(RegularCandies[,] input)
        {
            for (int column = 1; column < input.GetLength(1) - 1; column++)
            {
                for (int row = 0; row < input.GetLength(0); row++)
                {
                    if (input[column - 1, row] == input[column, row] &&
                        input[column + 1, row] == input[column, row])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }

    enum RegularCandies
    {
        Jellybean,
        Lozenge,
        LemonDrop,
        Gum_Square,
        LollipopHead,
        Jujube_Cluster
    }
}
