using System;

namespace assignment1
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
            int[,] matrixA = new int[8, 8];

            InitMatrix2D(matrixA);

            //DisplayMatrix(matrixA);

            int[,] matrixB = new int[nrOfRows, nrOfColumns];

            InitMatrixLinear(matrixB);

            DisplayMatrixWithCross(matrixB);

            Console.ReadKey();
        }

        void InitMatrix2D(int[,] matrix)
        {
            int count = 1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    matrix[row, column] = count;
                    count++;
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

        void InitMatrixLinear(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0) * matrix.GetLength(1); row++)
            {
                matrix[row / matrix.GetLength(1), row % matrix.GetLength(1)] = row + 1;
            }
        }

        void DisplayMatrixWithCross(int[,] matrix)
        {
            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);

            int count = matrix.GetLength(0) - 1;

            for (int i = 0; i < row; i++)
            {
                for (int k = 0; k < col; k++)
                {
                    if (i == k)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        if (k == (count))
                        {
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            count -= 1;
                        }
                    }
                    else if (k == (count))
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        count -= 1;
                    }
                    else
                    {
                        Console.ResetColor();
                    }

                    Console.Write(string.Format("{0,3} ", matrix[i, k]));
                }
                Console.WriteLine();
            }
            Console.ResetColor();
        }
    }
}
