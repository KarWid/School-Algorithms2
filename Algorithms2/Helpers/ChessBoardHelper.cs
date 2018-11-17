using System;
using System.Drawing;

namespace Algorithms2.Helpers
{
    public static class ChessBoardHelper
    {
        public static bool IsValid(this Point point, int chessBoardSize)
        {
            return point.X >= 0 && point.X < chessBoardSize && point.Y >= 0 && point.Y < chessBoardSize;
        }

        // hetman - hetman number
        // columns[i] - hetman position in i column
        // isHetmanInRow[j] - if true, hetman doesnt exist in j row
        // isHetmanOnToLeftDiagonal[j] - if true, hetman doesnt exist in j Diagonal (right to left)
        // isHetmanOnToRightDiagonal[j] - if true, hetman doesnt exist in j Diagonal (left to right)
        public static bool IsCheck(int hetman, int row, bool[] isNotHetmanInRow, bool[] isNotHetmanOnToLeftDiagonal, 
                                   bool[] isNotHetmanOnToRightDiagonal, int chessBoardSize)
        {
            if (hetman >= chessBoardSize)
            {
                throw new Exception("Too many hetmans");
            }

            if (hetman + row >= ((chessBoardSize * 2) - 1))
            {
                throw new Exception("Bad row or hetman compare to diagonal");
            }

            return !(isNotHetmanInRow[row] && isNotHetmanOnToLeftDiagonal[row + hetman]
                   && isNotHetmanOnToRightDiagonal[hetman - row + (chessBoardSize - 1)]);
        }

        public static int GetConflictsByHetman(int[] positionInColumns, int[] countHetmanInRow, int[] countHetmanToLeftDownDiagonal,
                                               int[] countHetmanToRightDownDiagonal, int hetman, int chessBoardSize)
        {
            var result = 0;

            var hetmanPositionInRow = positionInColumns[hetman];

            result = (countHetmanInRow[hetmanPositionInRow] - 1) + (countHetmanToLeftDownDiagonal[hetmanPositionInRow + hetman] - 1)
                     + (countHetmanToRightDownDiagonal[hetman - hetmanPositionInRow + (chessBoardSize - 1)] - 1);

            if (result < 0)
            {
                throw new Exception("Bad counting elements in row and diagonals");
            }

            return result;
        }

        public static void SetHetman(int[] positionInColumns, int[] countHetmanInRow, int[] countHetmanToLeftDownDiagonal,
                                     int[] countHetmanToRightDownDiagonal, int hetman, int row, bool set, int unvisitedField, 
                                     int chessBoardSize)
        {
            try
            {
                int value = set ? 1 : -1;

                positionInColumns[hetman] = set ? row : unvisitedField;

                countHetmanInRow[row] += value;
                countHetmanToLeftDownDiagonal[hetman + row] += value;
                countHetmanToRightDownDiagonal[hetman - row + (chessBoardSize - 1)] += value;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}