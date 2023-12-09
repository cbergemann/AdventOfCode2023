namespace Day5;

public class Mapping
{
    private List<(long, long, long)> _entries;
    private List<long> _entryLookup;

    public Mapping(string description, Queue<string> lines)
    {
        var mappingName = description.Substring(0, description.Length - 5).Split("-to-");
        SourceName = mappingName[0];
        DestinationName = mappingName[1];

        _entries = new List<(long, long, long)>();
        _entryLookup = new List<long>();
        var mappingEntry = lines.Dequeue();
        while (mappingEntry.Length > 0)
        {
            var mapNumbers = mappingEntry.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
            _entries.Add((mapNumbers[0], mapNumbers[1], mapNumbers[2]));
            _entryLookup.Add(mapNumbers[1]);

            if (!lines.TryDequeue(out mappingEntry))
            {
                break;
            }
        }
        
        _entries.Sort((a, b) => a.Item2.CompareTo(b.Item2));
        _entryLookup.Sort((a, b) => a.CompareTo(b));
    }
    
    public string SourceName { get; }
    
    public string DestinationName { get; }

    public long this[long value]
    {
        get
        {
            var idx = _entryLookup.BinarySearch(value);
            if (idx < 0)
            {
                idx = -idx - 2;
            }

            if (idx < 0)
            {
                return value;
            }

            var (destinationRageStart, sourceRangeStart, rangeSize) = _entries[idx];
            if (sourceRangeStart + rangeSize < value)
            {
                return value;
            }
            
            return destinationRageStart + value - sourceRangeStart;
            
            // foreach (var (destinationRageStart, sourceRangeStart, rangeSize) in _entries)
            // {
            //     if (value >= sourceRangeStart && value < sourceRangeStart + rangeSize)
            //     {
            //         return destinationRageStart + value - sourceRangeStart;
            //     }
            // }

            // return value;
        }
    }
}