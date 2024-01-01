namespace Tetris
{
    class GameGrid
    {
        private readonly int[,] grid;
        public int Rows { get; }
        public int Columns { get; }

        public int this[int r, int c] 
        {
            get => grid[r, c];
            set => grid[r, c] = value;
        }

        public GameGrid(int _rows, int _columns) 
        {
            Rows = Rows;
            Columns = Columns;
            grid = new int[_rows, _columns];
        }

        public bool IsInside(int _row, int _column) 
        {
            return _row >= 0 && _row < Rows && _column >= 0 && _column < Columns;
        }

        public bool IsEmpty(int _row, int _column) 
        {
            return IsInside(_row, _column) && grid[_row, _column] == 0;
        }

        public bool IsRowFull(int _row) 
        {
            for(int column = 0; column < Columns; column++) 
                if(grid[_row, column] == 0) 
                    return false;
            
                return true;
        }

        public bool IsRowEmpty(int _row) 
        {
            for (int column = 0; column < Columns; column++)
                if (grid[_row, column] != 0)
                    return false;

            return true;
        }

        private void ClearRow(int _row) 
        {
            for(int column = 0; column < Columns; column++) 
            {
                grid[_row, column] = 0;
            }
        }

        private void MoveRowDown(int _row, int _numRows) 
        {
            for(int column = 0; column < Columns; column++) 
            {
                grid[_row + _numRows, column] = grid[_row, column];
                grid[_row, column] = 0;
            }
        }

        private int ClearFullRows()
        {
            int cleared = 0;

            for(int row = Rows - 1; row >= 0; row--)
            {
                if (IsRowFull(row))
                {
                    ClearRow(row);
                    cleared++;
                }
                else if (cleared > 0)
                {
                    MoveRowDown(row, cleared);
                }
            }

            return cleared;
        }
    }
}
