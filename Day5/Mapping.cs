namespace Day5;

public class Mapping
{
    private List<(long, long, long)> _entries;
    
    public Mapping(string description, Queue<string> lines)
    {
        var mappingName = description.Substring(0, description.Length - 5).Split("-to-");
        SourceName = mappingName[0];
        DestinationName = mappingName[1];

        _entries = new List<(long, long, long)>();
        var mappingEntry = lines.Dequeue();
        while (mappingEntry.Length > 0)
        {
            var mapNumbers = mappingEntry.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
            _entries.Add((mapNumbers[0], mapNumbers[1], mapNumbers[2]));

            if (!lines.TryDequeue(out mappingEntry))
            {
                break;
            }
        }
    }
    
    public string SourceName { get; }
    
    public string DestinationName { get; }

    public long this[long value]
    {
        get
        {
            foreach (var (destinationRageStart, sourceRangeStart, rangeSize) in _entries)
            {
                if (value >= sourceRangeStart && value < sourceRangeStart + rangeSize)
                {
                    return destinationRageStart + value - sourceRangeStart;
                }
            }

            return value;
        }
    }
}