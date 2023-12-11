namespace Day11;

public class Galaxy
{
    public Galaxy(int row, int col)
    {
        Row = row;
        Col = col;
    }
    
    public int Row { get; set; }

    public int Col { get; set; } 
}

public class GalaxyMap
{
    private readonly List<Galaxy> _galaxies;

    public GalaxyMap(string[] lines, int expansionConstant)
    {
        _galaxies = new List<Galaxy>();
        var emptyCols = new HashSet<int>(Enumerable.Range(0, lines[0].Length));
        var emptyRows = new HashSet<int>(Enumerable.Range(0, lines.Length));
        
        for (var row = 0; row < lines.Length; row++)
        {
            for (var col = 0; col < lines[0].Length; col++)
            {
                var c = lines[row][col];
                if (c == '#')
                {
                    _galaxies.Add(new Galaxy(row, col));
                    emptyCols.Remove(col);
                    emptyRows.Remove(row);
                }
            }
        }

        foreach (var galaxy in _galaxies)
        {
            var noEmptyCols = emptyCols.Count(c => c < galaxy.Col);
            var noEmptyRows = emptyRows.Count(c => c < galaxy.Row);

            checked
            {
                galaxy.Col += noEmptyCols * (expansionConstant - 1);
                galaxy.Row += noEmptyRows * (expansionConstant - 1);
            }
        }
    }

    public long SumShortestPaths()
    {
        var sum = 0L;
        
        for (var it1 = 0; it1 < _galaxies.Count; it1++)
        {
            for (var it2 = it1 + 1; it2 < _galaxies.Count; it2++)
            {
                var path = ShortestPath(_galaxies[it1], _galaxies[it2]);
                sum += path;
            }
        }

        return sum;
    }

    public int ShortestPath(Galaxy a, Galaxy b)
    {
        return Math.Abs(a.Col - b.Col) + Math.Abs(a.Row - b.Row);
    }
}
