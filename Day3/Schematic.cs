namespace Day3;

public class Schematic
{
    private char[,] _data;

    public Schematic(string[] input)
    {
        _data = new char[input.Length, input[0].Length];
        for (var it_row = 0; it_row < input.Length; it_row++)
        {
            var line = input[it_row];

            for (var it_col = 0; it_col < input[0].Length; it_col++)
            {
                _data[it_row, it_col] = line[it_col];
            }
        }
    }

    public IEnumerable<int> EnumeratePartNumbers()
    {
        for (var it_row = 0; it_row < _data.GetLength(0); it_row++)
        {
            for (var it_col = 0; it_col < _data.GetLength(1); it_col++)
            {
                var c = _data[it_row, it_col];
                if (!char.IsDigit(c))
                {
                    continue;
                }



            }
        }
    }

    private bool IsAdjacentToSymbol(int row, int col)
    {
        // check row above
        if (row > 0)
        {
            if (col > 0 && IsSymbol(_data[row - 1, col - 1]))
            {
                return true;
            }

            if (IsSymbol(_data[row - 1, col]))
            {
                return true;
            }

            if (col < _data.GetLength(1) - 1 && IsSymbol(_data[row - 1, col + 1]))
            {
                return true;
            }
        }

        // check same row
        if (col > 0 && IsSymbol(_data[row, col - 1]))
        {
            return true;
        }

        if (col < _data.GetLength(1) - 1 && IsSymbol(_data[row, col + 1]))
        {
            return true;
        }

        // check row below
        if (row < _data.GetLength(0) - 1)
        {
            if (col > 0 && IsSymbol(_data[row + 1, col - 1]))
            {
                return true;
            }

            if (IsSymbol(_data[row + 1, col]))
            {
                return true;
            }

            if (col < _data.GetLength(1) - 1 && IsSymbol(_data[row + 1, col + 1]))
            {
                return true;
            }
        }

        return false;
    }

    private bool IsSymbol(char c) => !char.IsDigit(c) && c != '.';
}