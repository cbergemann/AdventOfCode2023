// See https://aka.ms/new-console-template for more information

using Day5;

void PartOne()
{
    var initalSeeds = new List<long>();
    var mappings = new Dictionary<string, Mapping>();
    
    var lines = new Queue<string>(File.ReadAllLines("input.txt"));
    while (lines.TryDequeue(out var line))
    {
        if (line.StartsWith("seeds: "))
        {
            initalSeeds = line.Substring(7).Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse)
                .ToList();
            continue;
        }

        if (line.EndsWith(" map:"))
        {
            var mapping = new Mapping(line, lines);
            mappings.Add(mapping.SourceName, mapping);
        }
    }

    long GetLocation(long seed)
    {
        var currentType = "seed";
        var value = seed;
        while (currentType != "location")
        {
            var map = mappings[currentType];
            currentType = map.DestinationName;
            value = map[value];
        }

        return value;
    }

    var closestSeedLocation = initalSeeds.Min(GetLocation);
    
    Console.WriteLine($"the closest seed location is: {closestSeedLocation}");
}

PartOne();
