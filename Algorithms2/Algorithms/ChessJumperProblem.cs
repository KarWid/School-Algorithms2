using System.Drawing;
using System.Threading.Tasks;
using Algorithms2.Interfaces;
using Algorithms2.Algorithms.BaseClasses;

namespace Algorithms2.Algorithms
{
    public class ChessJumperProblem : ChessJumperBase, IAlgorithm
    {
        // constructor
        public ChessJumperProblem(int chessBoardSize, Point startField) : base(chessBoardSize, startField) { }

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
    }
}