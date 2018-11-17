using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Algorithms2.Forms;
using Algorithms2.Helpers;
using Algorithms2.Interfaces;

namespace Algorithms2.Algorithms
{
    public class NQueenWithReturnsProblem : IAlgorithm
    {
        // private fields
        private const int _unvisitedField = -1;

        private int _chessBoardSize;
        private int[,] _chessBoard; // [row, column]

        private int[] _positionInColums;
        private bool[] _isNotHetmanInRow;
        private bool[] _isNotHetmanOnToLeftDiagonal;
        private bool[] _isNotHetmanOnToRightDiagonal;

        private Stopwatch _stopwatch;

        // public properties
        public TimeSpan LastActionTime { get; protected set; }
        public List<int[,]> Results { get; protected set; } = new List<int[,]>();

        public NQueenWithReturnsProblem(int chessBoardSize)
        {
            int diagonalCount = ((chessBoardSize * 2) - 1);

            _chessBoardSize = chessBoardSize;
            _chessBoard = new int[chessBoardSize, chessBoardSize];

            for (int i = 0; i < chessBoardSize; i++)
            {
                for (int j = 0; j < chessBoardSize; j++)
                {
                    _chessBoard[i, j] = _unvisitedField;
                }
            }

            _stopwatch = new Stopwatch();

            _positionInColums = new int[_chessBoardSize];
            _isNotHetmanInRow = new bool[_chessBoardSize];
            _isNotHetmanOnToLeftDiagonal = new bool[diagonalCount];
            _isNotHetmanOnToRightDiagonal = new bool[diagonalCount];

            for (int i = 0; i < _chessBoardSize; i++)
            {
                _positionInColums[i] = _unvisitedField;
                _isNotHetmanInRow[i] = true;
            }

            for (int i = 0; i < diagonalCount; i++)
            {
                _isNotHetmanOnToLeftDiagonal[i] = _isNotHetmanOnToRightDiagonal[i] = true;
            }
        }

        // public methods
        public async Task Start()
        {
            bool q = false;

            await Task.Run(() =>
            {
                _stopwatch.Start();
                TrySetHetman(0, ref q);
                _stopwatch.Stop();
                LastActionTime = _stopwatch.Elapsed;
            });
        }

        public void ShowResult()
        {
            var form = new ChessBoardForm(_positionInColums, _chessBoardSize, LastActionTime);
            form.Show();
        }

        // private methods
        private void TrySetHetman(int hetman, ref bool q)
        {
            int row = -1;

            do
            {
                row++;
                q = false;

                if (!ChessBoardHelper.IsCheck(hetman, row, _isNotHetmanInRow, _isNotHetmanOnToLeftDiagonal,
                                             _isNotHetmanOnToRightDiagonal, _chessBoardSize))
                {
                    SetHetman(hetman, row, true);

                    if (hetman < (_chessBoardSize - 1))
                    {
                        TrySetHetman(hetman + 1, ref q);

                        if (!q)
                        {
                            SetHetman(hetman, row, false);
                        }
                    }
                    else
                    {
                        q = true;
                    }
                }
            } while (!q && (row != (_chessBoardSize - 1)));
        }

        private void SetHetman(int hetman, int row, bool set)
        {
            try
            {
                _positionInColums[hetman] = row;
                _isNotHetmanInRow[row] = !set;
                _isNotHetmanOnToLeftDiagonal[hetman + row] = !set;
                _isNotHetmanOnToRightDiagonal[hetman - row + (_chessBoardSize - 1)] = !set;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}