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

    public IEnumerable<long> EnumeratePartNumbers()
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

                var digits = new List<char> { c };

                var isPartNumber = IsAdjacentToSymbol(it_row, it_col);

                while (++it_col < _data.GetLength(1))
                {
                    c = _data[it_row, it_col];
                    if (!char.IsDigit(c))
                    {
                        break;
                    }

                    digits.Add(c);
                    isPartNumber = IsAdjacentToSymbol(it_row, it_col) || isPartNumber;
                }

                if (isPartNumber)
                {
                    yield return long.Parse(string.Concat(digits));
                }
            }
        }
    }

    public IEnumerable<long> EnumerateGearRatios()
    {
        var gears = EnumerateGears().GroupBy(k => k.Item2, v => v.Item1);
        foreach (var gearing in gears)
        {
            if (gearing.Count() != 2)
            {
                continue;
            }

            yield return gearing.Aggregate(1L, (a, b) => a * b);
        }
    }

    public IEnumerable<(long, (int, int))> EnumerateGears()
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

                var digits = new List<char> { c };

                var isPartNumber = IsAdjacentToGear(it_row, it_col, out var gearPosition);

                while (++it_col < _data.GetLength(1))
                {
                    c = _data[it_row, it_col];
                    if (!char.IsDigit(c))
                    {
                        break;
                    }

                    digits.Add(c);

                    if (IsAdjacentToGear(it_row, it_col, out var gearPosition2))
                    {
                        isPartNumber = true;
                        gearPosition = gearPosition2;
                    }
                }

                if (isPartNumber)
                {
                    yield return (long.Parse(string.Concat(digits)), gearPosition);
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

    private bool IsAdjacentToGear(int row, int col, out (int, int) gearPosition)
    {
        // check row above
        if (row > 0)
        {
            if (col > 0 && IsGear(_data[row - 1, col - 1]))
            {
                gearPosition = (row - 1, col - 1);
                return true;
            }

            if (IsGear(_data[row - 1, col]))
            {
                gearPosition = (row - 1, col);
                return true;
            }

            if (col < _data.GetLength(1) - 1 && IsGear(_data[row - 1, col + 1]))
            {
                gearPosition = (row - 1, col + 1);
                return true;
            }
        }

        // check same row
        if (col > 0 && IsGear(_data[row, col - 1]))
        {
            gearPosition = (row, col - 1);
            return true;
        }

        if (col < _data.GetLength(1) - 1 && IsGear(_data[row, col + 1]))
        {
            gearPosition = (row, col + 1);
            return true;
        }

        // check row below
        if (row < _data.GetLength(0) - 1)
        {
            if (col > 0 && IsGear(_data[row + 1, col - 1]))
            {
                gearPosition = (row + 1, col - 1);
                return true;
            }

            if (IsGear(_data[row + 1, col]))
            {
                gearPosition = (row + 1, col);
                return true;
            }

            if (col < _data.GetLength(1) - 1 && IsGear(_data[row + 1, col + 1]))
            {
                gearPosition = (row + 1, col + 1);
                return true;
            }
        }

        gearPosition = (-1, -1);
        return false;
    }

    private bool IsGear(char c) => c == '*';
}