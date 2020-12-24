using System;

namespace assignment2
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
            int[,] matrixA = new int[nrOfRows, nrOfColumns];

            InitMatrixRandom(matrixA, 1, 99);

            DisplayMatrix(matrixA);

            Console.Write("\nEnter a number (to search for): ");
            int input = int.Parse(Console.ReadLine());

            Position outputFirst = SearchNumber(matrixA, input);
            Console.WriteLine($"Number {input} is found (first) at position [{outputFirst.row}, {outputFirst.column}]");

            Position outputLast = SearchNumberBackwards(matrixA, input);
            Console.WriteLine($"Number {input} is found (last) at position [{outputLast.row}, {outputLast.column}]");

            Console.ReadKey();
        }

        void InitMatrixRandom (int[,] matrix, int min, int max)
        {
            Random rnd = new Random();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    matrix[row, column] = rnd.Next(min, max);
                }
            }
        }

        void DisplayMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(0); column++)
                {
                    Console.Write(string.Format("{0,2} ", matrix[row, column]));
                }
                Console.WriteLine();
            }
        }

        Position SearchNumber(int[,] matrix, int number)
        {
            Position foundNumber = new Position();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    if (number == matrix[row, column])
                    {
                        foundNumber.row = row;
                        foundNumber.column = column;
                        return foundNumber;
                    }
                }
            }

            return foundNumber;
        }

        Position SearchNumberBackwards(int[,] matrix, int number)
        {
            Position foundNumber = new Position();

            for (int row = matrix.GetLength(0) - 1; row > 0; row--)
            {
                for (int column = matrix.GetLength(1) - 1; column > 0; column--)
                {
                    if (number == matrix[row, column])
                    {
                        foundNumber.row = row;
                        foundNumber.column = column;
                        return foundNumber;
                    }
                }
            }

            Console.WriteLine($"Number {number} is not found");
            return foundNumber;
        }
    }
}
