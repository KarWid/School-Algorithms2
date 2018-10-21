using System;
using System.Drawing;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms2.Algorithms;

namespace AlgorithmsTest
{
    [TestClass]
    public class ChessJumperTest
    {
        // 6x6 position (1,1)
        [TestMethod]
        public async Task RoadWithRelapses6x6()
        {
            // prepare data
            var startField = new Point(1, 1);
            var lastField = new Point();
            var chessBoardSize = 6;
            var lastJumpNumber = chessBoardSize * chessBoardSize - 1;

            ChessJumperProblem chessJumperProblem = new ChessJumperProblem(chessBoardSize, startField);

            // do action
            await chessJumperProblem.Start();
            var results = chessJumperProblem.Results;

            // Asserts
            Assert.IsTrue(results.Count > 0);

            results.ForEach(x =>
            {
                for (int i=0; i < chessBoardSize; i++)
                {
                    for (int j=0; j < chessBoardSize; j++)
                    {
                        if (x[i,j] == lastJumpNumber)
                        {
                            lastField = new Point(i, j);
                            break;
                        }
                    }
                }

                Assert.IsTrue(CanBackToStart(startField, lastField));
            });
        }

        private bool CanBackToStart(Point startField, Point actualPosition)
        {
            var xDiff = Math.Abs(actualPosition.X - startField.X);
            var yDiff = Math.Abs(actualPosition.Y - startField.Y);

            if (xDiff == 1 && yDiff == 2 || xDiff == 2 && yDiff == 1)
            {
                return true;
            }

            return false;
        }
    }
}
