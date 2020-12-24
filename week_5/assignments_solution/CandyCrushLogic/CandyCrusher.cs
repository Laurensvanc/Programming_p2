using System;
using System.Collections.Generic;
using System.Text;

namespace CandyCrushLogic
{
    public class CandyCrusher
    {
        public static bool ScoreRowPresent(RegularCandies[,] input)
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

        public static bool ScoreColumnPresent(RegularCandies[,] input)
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
}
