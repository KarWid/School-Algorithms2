using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Algorithms2.Forms;
using Algorithms2.Helpers;
using Algorithms2.Interfaces;

namespace Algorithms2.Algorithms
{
    public class NQueenPermutationsProblem : IAlgorithm
    {
        // private fields
        private const int _unvisitedField = -1;

        private int _chessBoardSize;

        private int[] _positionInColumns;
        private int[] _countHetmanInRow;
        private int[] _countHetmanToLeftDownDiagonal;
        private int[] _countHetmanToRightDownDiagonal;

        private Stopwatch _stopwatch;

        // public properties
        public TimeSpan LastActionTime { get; protected set; }
        public int[] Result { get; private set; }

        // constructors
        public NQueenPermutationsProblem(int chessBoardSize)
        {
            int diagonalCount = ((chessBoardSize * 2) - 1);

            _chessBoardSize = chessBoardSize;

            _stopwatch = new Stopwatch();

            _positionInColumns = new int[_chessBoardSize];
            _countHetmanInRow = new int[_chessBoardSize];
            _countHetmanToLeftDownDiagonal = new int[diagonalCount];
            _countHetmanToRightDownDiagonal = new int[diagonalCount];

            for (int i = 0; i < _chessBoardSize; i++)
            {
                _positionInColumns[i] = _unvisitedField;
                _countHetmanInRow[i] = 0;
                _countHetmanToLeftDownDiagonal[i] = 0;
                _countHetmanToRightDownDiagonal[i] = 0;
            }

            Result = new int[_chessBoardSize];
        }

        // public methods
        public async Task Start()
        {
            await Task.Run(() =>
            {
                _stopwatch.Start();

                SetUpChessBoardRandomly();

                Result = MainFunction((int[])_positionInColumns.Clone(), (int[])_countHetmanInRow.Clone(), (int[])_countHetmanToLeftDownDiagonal.Clone(),
                             (int[])_countHetmanToRightDownDiagonal.Clone(), 0);

                _stopwatch.Stop();
                LastActionTime = _stopwatch.Elapsed;
            });
        }

        public void ShowResult()
        {
            var form = new ChessBoardForm(Result, _chessBoardSize, LastActionTime);
            form.Show();
        }

        // private methods
        private int[] MainFunction(int[] positionInColumns, int[] countHetmanInRow, int[] countHetmanToLeftDownDiagonal,
                                  int[] countHetmanToRightDownDiagonal, int actualHetman)
        {
            if (actualHetman >= _chessBoardSize)
            {
                return positionInColumns;
            }

            var oldConflicts = GetConflictsOnBoard(positionInColumns, countHetmanInRow, countHetmanToLeftDownDiagonal, countHetmanToRightDownDiagonal);

            for (int iHetman = actualHetman + 1; iHetman < _chessBoardSize; iHetman++)
            {
                ChangeHetmansInChessBoard(positionInColumns, countHetmanInRow, countHetmanToLeftDownDiagonal, countHetmanToRightDownDiagonal, actualHetman, iHetman);

                var conflicts = GetConflictsOnBoard(positionInColumns, countHetmanInRow, countHetmanToLeftDownDiagonal, countHetmanToRightDownDiagonal);

                if (conflicts >= oldConflicts)
                {
                    ChangeHetmansInChessBoard(positionInColumns, countHetmanInRow, countHetmanToLeftDownDiagonal, countHetmanToRightDownDiagonal, iHetman, actualHetman);
                }
                else if (conflicts == 0)
                {
                    return positionInColumns;
                }
                else
                {
                    break;
                }
            }

            return MainFunction(positionInColumns, countHetmanInRow, countHetmanToLeftDownDiagonal, countHetmanToRightDownDiagonal, actualHetman + 1);
        }

        private void SetUpChessBoardRandomly()
        {
            Random rand = new Random();

            var randomRowsInColumns = new List<int>();

            randomRowsInColumns.AddRange(Enumerable.Range(0, _chessBoardSize)
                                                   .OrderBy(i => rand.Next())
                                                   .Take(_chessBoardSize));

            
            for (int i=0; i < randomRowsInColumns.Count; i++)
            {
                ChessBoardHelper.SetHetman(_positionInColumns, _countHetmanInRow, _countHetmanToLeftDownDiagonal, _countHetmanToRightDownDiagonal, i, 
                                           randomRowsInColumns[i], true, _unvisitedField, _chessBoardSize);
            }
        }

        private int GetConflictsOnBoard(int[] positionInColumns, int[] countHetmanInRow, int[] countHetmanToLeftDiagonal,
                                        int[] countHetmanToRightDownDiagonal)
        {
            var result = 0;

            for (int hetman = 0; hetman < _chessBoardSize; hetman++)
            {
                result += ChessBoardHelper.GetConflictsByHetman(positionInColumns, countHetmanInRow, countHetmanToLeftDiagonal,
                                                                countHetmanToRightDownDiagonal, hetman, _chessBoardSize);
            }

            return result;
        }

        private void ChangeHetmansInChessBoard(int[] positionInColumns, int[] countHetmanInRow, int[] countHetmanToLeftDownDiagonal,
                                               int[] countHetmanToRightDownDiagonal, int hetman1, int hetman2)
        {
            int row1 = positionInColumns[hetman1];
            int row2 = positionInColumns[hetman2];

            // remove hetmans
            ChessBoardHelper.SetHetman(positionInColumns, countHetmanInRow, countHetmanToLeftDownDiagonal, countHetmanToRightDownDiagonal,
                                       hetman1, row1, false, _unvisitedField, _chessBoardSize);

            ChessBoardHelper.SetHetman(positionInColumns, countHetmanInRow, countHetmanToLeftDownDiagonal, countHetmanToRightDownDiagonal, 
                      hetman2, row2, false, _unvisitedField, _chessBoardSize);

            // set hetmans on new positions
            ChessBoardHelper.SetHetman(positionInColumns, countHetmanInRow, countHetmanToLeftDownDiagonal, countHetmanToRightDownDiagonal, 
                      hetman1, row2, true, _unvisitedField, _chessBoardSize);

            ChessBoardHelper.SetHetman(positionInColumns, countHetmanInRow, countHetmanToLeftDownDiagonal, countHetmanToRightDownDiagonal, 
                      hetman2, row1, true, _unvisitedField, _chessBoardSize);
        }
    }
}