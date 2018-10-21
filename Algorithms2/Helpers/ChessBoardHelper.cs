using System.Drawing;

namespace Algorithms2.Helpers
{
    public static class ChessBoardHelper
    {
        public static bool IsValid(this Point point, int chessBoardSize)
        {
            return point.X >= 0 && point.X < chessBoardSize && point.Y >= 0 && point.Y < chessBoardSize;
        }
    }
}
