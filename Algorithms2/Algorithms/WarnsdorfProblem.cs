using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using Algorithms2.Algorithms.BaseClasses;
using Algorithms2.Interfaces;

namespace Algorithms2.Algorithms
{
    public class WarnsdorfProblem : ChessJumperBase, IAlgorithm
    {
        private Point _defaultBadPoint = new Point(-1, -1);

        public WarnsdorfProblem(int chessBoardSize, Point startField) : base(chessBoardSize, startField) { }

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

        private void NextJumps(int[,] chessBoard, Point actualPosition, int actualJumpNumber)
        {
            Jump(chessBoard, actualPosition, ref actualJumpNumber);

            var possibleMoves = GetActualPossibleMoves(chessBoard, actualPosition);

            if (actualJumpNumber == _chessBoardSize * _chessBoardSize
                && possibleMoves.Count == 0)
            {
                Results.Add((int[,])chessBoard.Clone());
            }

            Dictionary<Point, List<Point>> possibleNextMoves = new Dictionary<Point, List<Point>>();

            possibleMoves.ForEach(possibleMove =>
            {
                var nextMoves = GetActualPossibleMoves(chessBoard, possibleMove);

                possibleNextMoves.Add(possibleMove, nextMoves);
            });

            var bestMove = GetKeyWithMiniumumValues(possibleNextMoves);

            if (Results.Count == 0)
            {
                NextJumps(chessBoard, bestMove, actualJumpNumber);
            }
        }

        private Point GetKeyWithMiniumumValues(Dictionary<Point, List<Point>> moves)
        {
            Point result = new Point(_defaultBadPoint.X, _defaultBadPoint.Y);

            if (moves == null || moves.Count == 0)
            {
                return result;
            }

            int minCountValues = int.MaxValue;

            foreach (var move in moves)
            {
                if (move.Value.Count < minCountValues)
                {
                    minCountValues = move.Value.Count;
                    result = move.Key;
                }
            }

            return result;
        }
    }
}