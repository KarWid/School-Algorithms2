using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Algorithms2.Forms;
using Algorithms2.Helpers;

namespace Algorithms2.Algorithms.BaseClasses
{
    public class ChessJumperBase
    {
        protected const int _unvisitedField = -1;

        protected Point _startField;

        protected int _chessBoardSize;
        protected int[,] _chessBoard; // [row, column]

        protected Stopwatch _stopwatch;

        // public properties
        public TimeSpan LastActionTime { get; protected set; }
        public List<int[,]> Results { get; private set; } = new List<int[,]>();

        // constructor
        public ChessJumperBase(int chessBoardSize, Point startField)
        {
            if (chessBoardSize < 4 || !startField.IsValid(chessBoardSize))
            {
                throw new Exception("Bad chess board size or start field");
            }

            _startField = startField;

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
        }

        // public methods
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

        // protected methods
        protected bool CanBackToStart(Point actualPosition)
        {
            var xDiff = Math.Abs(actualPosition.X - _startField.X);
            var yDiff = Math.Abs(actualPosition.Y - _startField.Y);

            if (xDiff == 1 && yDiff == 2 || xDiff == 2 && yDiff == 1)
            {
                return true;
            }

            return false;
        }

        protected void AddIfMoveIsPossible(int[,] chessBoard, List<Point> list, Point point)
        {
            if (point.IsValid(_chessBoardSize) && chessBoard[point.X, point.Y] == _unvisitedField)
            {
                list.Add(point);
            }
        }

        protected List<Point> GetActualPossibleMoves(int[,] chessBoard, Point actualPosition)
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

        protected void Jump(int[,] chessBoard, Point actualField, ref int actualJump)
        {
            chessBoard[actualField.X, actualField.Y] = actualJump++;
        }
    }
}