using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Algorithms2.Interfaces;
using Algorithms2.Helpers;
using Algorithms2.Forms;

namespace Algorithms2.Algorithms
{
    public class ChessJumperProblem : IAlgorithm
    {
        // private fields
        private const int _unvisitedField = -1;

        private Point _startField;

        private int _chessBoardSize;
        private int[,] _chessBoard; // [row, column]

        private Stopwatch _stopwatch;

        // public properties
        public TimeSpan LastActionTime { get; private set; }
        public List<int[,]> Results { get; private set; } = new List<int[,]>();

        // constructor
        public ChessJumperProblem(int chessBoardSize, Point startField)
        {
            if (chessBoardSize < 4 || !startField.IsValid(chessBoardSize))
            {
                throw new Exception("Bad chess board size or start field");
            }

            _startField = startField;

            _chessBoardSize = chessBoardSize;
            _chessBoard = new int[chessBoardSize, chessBoardSize];

            for (int i=0; i < chessBoardSize; i++)
            {
                for (int j=0; j < chessBoardSize; j++)
                {
                    _chessBoard[i, j] = _unvisitedField;
                }
            }

            _stopwatch = new Stopwatch();
        }

        // public methods
        public async Task Start()
        {
            await Task.Run(() =>
            {
                _stopwatch.Start();
                NextJumps(_chessBoard, _startField, 0);
                _stopwatch.Stop();
                LastActionTime = _stopwatch.Elapsed;
            });
        }

        public void ShowResult()
        {
            if (Results.Count == 0)
            {
                MessageBox.Show("Brak wyników");
                return;
            }

            var form = new ChessBoardForm(Results, _chessBoardSize, LastActionTime);
            form.Show();
        }

        // private methods
        private void NextJumps(int[,] chessBoard, Point actualPosition, int actualJumpNumber)
        {
            Jump(chessBoard, actualPosition, ref actualJumpNumber);

            var possibleMoves = GetActualPossibleMoves(chessBoard, actualPosition);

            if (actualJumpNumber == _chessBoardSize * _chessBoardSize
                && possibleMoves.Count == 0)
            {
                if (CanBackToStart(actualPosition))
                {
                    Results.Add((int[,])chessBoard.Clone());
                }
            }

            possibleMoves.ForEach(possibleMove =>
            {
                if (Results.Count == 0)
                {
                    NextJumps(chessBoard, possibleMove, actualJumpNumber);
                    chessBoard[possibleMove.X, possibleMove.Y] = _unvisitedField;
                }
            });
        }

        private void Jump(int[,] chessBoard, Point actualField, ref int actualJump)
        {
            chessBoard[actualField.X, actualField.Y] = actualJump++;
        }

        private List<Point> GetActualPossibleMoves(int[,] chessBoard, Point actualPosition)
        {
            var result = new List<Point>();

            var actualRow = actualPosition.X;
            var actualColumn = actualPosition.Y;

            AddIfMoveIsPossible(chessBoard, result, new Point(actualRow + 1, actualColumn + 2));
            AddIfMoveIsPossible(chessBoard, result, new Point(actualRow + 1, actualColumn - 2));
            AddIfMoveIsPossible(chessBoard, result, new Point(actualRow - 1, actualColumn + 2));
            AddIfMoveIsPossible(chessBoard, result, new Point(actualRow - 1, actualColumn - 2));
            AddIfMoveIsPossible(chessBoard, result, new Point(actualRow + 2, actualColumn + 1));
            AddIfMoveIsPossible(chessBoard, result, new Point(actualRow + 2, actualColumn - 1));
            AddIfMoveIsPossible(chessBoard, result, new Point(actualRow - 2, actualColumn + 1));
            AddIfMoveIsPossible(chessBoard, result, new Point(actualRow - 2, actualColumn - 1));

            return result;
        }

        private void AddIfMoveIsPossible(int[,] chessBoard, List<Point> list, Point point)
        {
            if (point.IsValid(_chessBoardSize) && chessBoard[point.X, point.Y] == _unvisitedField)
            {
                list.Add(point);
            }
        }

        private bool CanBackToStart(Point actualPosition)
        {
            var xDiff = Math.Abs(actualPosition.X - _startField.X);
            var yDiff = Math.Abs(actualPosition.Y - _startField.Y);

            if (xDiff == 1 && yDiff == 2 || xDiff == 2 && yDiff == 1)
            {
                return true;
            }

            return false;
        }
    }
}