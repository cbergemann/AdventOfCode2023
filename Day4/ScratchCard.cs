namespace Day4;

public class ScratchCard
{
    public ScratchCard(string description)
    {
        var split1 = description.Split(':', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
        var split2 = split1[0].Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

        CardId = int.Parse(split2[1]);

        var split3 = split1[1].Split('|', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

        var winningNumbers = split3[0].Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToHashSet();
        var drawnNumbers = split3[1].Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);

        winningNumbers.IntersectWith(drawnNumbers);

        Count = winningNumbers.Count;
    }
    
    public int CardId { get; }
    
    public int Count { get; }

    public int Points => Count > 0 ? 1 << (Count - 1) : 0;
}
