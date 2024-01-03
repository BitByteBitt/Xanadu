namespace Tetris
{
    public class Position
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public Position(int _row, int _column)
        {
            Row = _row;
            Column = _column;
        }
    }
}
