namespace Day13;

public enum Terrain
{
    Ash = 0,
    Rock = 1,
}

public class Pattern
{
    private readonly List<Terrain[]> _pattern = new();

    public static Pattern? FromReader(TextReader reader)
    {
        var pattern = new List<Terrain[]>();
        var line = reader.ReadLine();
        while (!string.IsNullOrEmpty(line))
        {
            pattern.Add(line.Select(c => c switch
            {
                '.' => Terrain.Ash,
                '#' => Terrain.Rock,
                _ => throw new Exception(),
            }).ToArray());
            
            line = reader.ReadLine();
        }

        if (pattern.Count == 0)
        {
            return null;
        }

        return new Pattern(pattern);
    }

    public Pattern(List<Terrain[]> pattern)
    {
        _pattern = pattern;
    }

    public int? HorizontalSymmetry(int smudges = 0)
    {
        var cols = _pattern[0].Length;
        var rows = _pattern.Count;

        for (var idx = 0; idx < cols - 1; idx++)
        {
            var foundSmudges = 0;
            
            for (var col = 0; col <= idx; col++)
            {
                var anticol = idx + (idx - col) + 1;
                if (anticol >= cols)
                {
                    continue;
                }
                
                for (var row = 0; row < rows; row++)
                {
                    if (_pattern[row][col] != _pattern[row][anticol])
                    {
                        foundSmudges++;
                        if (foundSmudges > smudges)
                        {
                            goto not_equal;
                        }
                    }
                }
            }

            if (foundSmudges == smudges)
            {
                return idx;
            }
            
            not_equal: ;
        }

        return null;
    }

    public int? VerticalSymmetry(int smudges = 0)
    {
        var cols = _pattern[0].Length;
        var rows = _pattern.Count;

        for (var idx = 0; idx < rows - 1; idx++)
        {
            var foundSmudges = 0;
            
            for (var row = 0; row <= idx; row++)
            {
                var antirow = idx + (idx - row) + 1;
                if (antirow >= rows)
                {
                    continue;
                }
                
                for (var col = 0; col < cols; col++)
                {
                    if (_pattern[row][col] != _pattern[antirow][col])
                    {
                        foundSmudges++;
                        if (foundSmudges > smudges)
                        {
                            goto not_equal;
                        }
                    }
                }
            }


            if (foundSmudges == smudges)
            {
                return idx;
            }
            
            not_equal: ;
        }

        return null;
    }
}