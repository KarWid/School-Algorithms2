using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms2.Helpers;

namespace AlgorithmsTest
{
    [TestClass]
    public class ChessBoardHelperTest
    {
        [TestMethod]
        public void CountingConflictsByHetmanTest()
        {
            // prepare data
            int chessBoardSize = 5;
            int[] positionInColumns = new int[] { 2, 4, 1, 0, 3 };
            int[] countHetmanInRow = new int[] { 1, 1, 1, 1, 1 };
            int[] countHetmanInToLeftDownDiagonal = new int[] { 0, 0, 1, 2, 0, 1, 0, 1, 0 };
            int[] countHetmanInToRightDownDiagonal = new int[] { 0, 1, 1, 0, 0, 2, 0, 1, 0 };

            // make calculations
            var conflictsFirstHetman = ChessBoardHelper.GetConflictsByHetman(positionInColumns, countHetmanInRow, countHetmanInToLeftDownDiagonal, 
                                                                             countHetmanInToRightDownDiagonal, 0, chessBoardSize);

            var conflictsSecondHetman = ChessBoardHelper.GetConflictsByHetman(positionInColumns, countHetmanInRow, countHetmanInToLeftDownDiagonal,
                                                                             countHetmanInToRightDownDiagonal, 1, chessBoardSize);

            var conflictsThirdHetman = ChessBoardHelper.GetConflictsByHetman(positionInColumns, countHetmanInRow, countHetmanInToLeftDownDiagonal,
                                                                             countHetmanInToRightDownDiagonal, 2, chessBoardSize);

            var conflictsFourthHetman = ChessBoardHelper.GetConflictsByHetman(positionInColumns, countHetmanInRow, countHetmanInToLeftDownDiagonal,
                                                                             countHetmanInToRightDownDiagonal, 3, chessBoardSize);

            var conflictsFifthHetman = ChessBoardHelper.GetConflictsByHetman(positionInColumns, countHetmanInRow, countHetmanInToLeftDownDiagonal,
                                                                             countHetmanInToRightDownDiagonal, 4, chessBoardSize);

            // assert data
            Assert.AreEqual(0, conflictsFirstHetman);
            Assert.AreEqual(0, conflictsSecondHetman);
            Assert.AreEqual(2, conflictsThirdHetman);
            Assert.AreEqual(1, conflictsFourthHetman);
            Assert.AreEqual(1, conflictsFifthHetman);
        }

        [TestMethod]
        public void SetHetmanNQueenPermutationsTest()
        {
            // prepare data
            int[] positionInColumns = new int[] { 0, 2, 1, 3 };
            int[] countHetmanInRow = new int[] { 1, 1, 1, 1 };
            int[] countHetmanToLeftDownDiagonal = new int[] { 1, 0, 0, 2, 0, 0, 1 };
            int[] countHetmanToRightDownDiagonal = new int[] { 0, 0, 1, 2, 1, 0, 0 };
            int unvisitedField = -1;
            int chessBoardSize = 4;

            int hetman = 0;
            int row = positionInColumns[hetman];

            // make action
            ChessBoardHelper.SetHetman(positionInColumns, countHetmanInRow, countHetmanToLeftDownDiagonal, countHetmanToRightDownDiagonal,
                                       hetman, row, false, unvisitedField, chessBoardSize);

            // asserts
            Assert.AreEqual(positionInColumns[hetman], -1, "positionInColumns is bad");
            Assert.AreEqual(countHetmanInRow[0], 0, "CountHetmanInRow is bad");
            Assert.AreEqual(countHetmanToLeftDownDiagonal[0], 0, "LeftDownDiagonal is bad");
            Assert.AreEqual(countHetmanToRightDownDiagonal[4], 1, "RightDownDiagonal is bad");
        }

        [TestMethod]
        public void ChangeHetmansTest()
        {
            // prepare data
            int[] positionInColumns = new int[] { 0, 2, 1, 3 };
            int[] countHetmanInRow = new int[] { 1, 1, 1, 1 };
            int[] countHetmanToLeftDownDiagonal = new int[] { 1, 0, 0, 2, 0, 0, 1 };
            int[] countHetmanToRightDownDiagonal = new int[] { 0, 0, 1, 2, 1, 0, 0 };
            int unvisitedField = -1;
            int chessBoardSize = 4;

            int hetman1 = 1;
            int hetman2 = 3;
            int row1 = positionInColumns[hetman1];
            int row2 = positionInColumns[hetman2];

            // data to assert
            int[] expectedCountHetmanToLeftDownDiagonal = new int[] { 1, 0, 0, 1, 1, 1, 0 };
            int[] expectedCountHetmanToRightDownDiagonal = new int[] { 0, 1, 0, 1, 2, 0, 0 };

            // action
            // remove hetmans
            ChessBoardHelper.SetHetman(positionInColumns, countHetmanInRow, countHetmanToLeftDownDiagonal, countHetmanToRightDownDiagonal,
                                       hetman1, row1, false, unvisitedField, chessBoardSize);

            ChessBoardHelper.SetHetman(positionInColumns, countHetmanInRow, countHetmanToLeftDownDiagonal, countHetmanToRightDownDiagonal,
                      hetman2, row2, false, unvisitedField, chessBoardSize);

            // set hetmans on new positions
            ChessBoardHelper.SetHetman(positionInColumns, countHetmanInRow, countHetmanToLeftDownDiagonal, countHetmanToRightDownDiagonal,
                      hetman1, row2, true, unvisitedField, chessBoardSize);

            ChessBoardHelper.SetHetman(positionInColumns, countHetmanInRow, countHetmanToLeftDownDiagonal, countHetmanToRightDownDiagonal,
                      hetman2, row1, true, unvisitedField, chessBoardSize);

            // asserts
            // position in columns
            Assert.AreEqual(positionInColumns[hetman1], 3, "First hetman bad position");
            Assert.AreEqual(positionInColumns[hetman2], 2, "Second hetman bad position");

            // count hetman in row
            Assert.AreEqual(countHetmanInRow[2], 1, "Third row has not 1 hetman");
            Assert.AreEqual(countHetmanInRow[3], 1, "Fourth row has not 1 hetman");

            // position in diagonals
            for (int i=0; i < (chessBoardSize * 2) - 1; i++)
            {
                Assert.AreEqual(countHetmanToLeftDownDiagonal[i], expectedCountHetmanToLeftDownDiagonal[i], $"{i} left diagonal is wrong, values: " +
                                $"{countHetmanToLeftDownDiagonal[i]}, expected: {expectedCountHetmanToLeftDownDiagonal[i]}");
            }

            for (int i = 0; i < (chessBoardSize * 2) - 1; i++)
            {
                Assert.AreEqual(countHetmanToRightDownDiagonal[i], expectedCountHetmanToRightDownDiagonal[i], $"{i} right diagonal is wrong, values: " +
                                $"{countHetmanToRightDownDiagonal[i]}, expected: {expectedCountHetmanToRightDownDiagonal[i]}");
            }
        }
    }
}