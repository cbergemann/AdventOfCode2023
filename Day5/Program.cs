// See https://aka.ms/new-console-template for more information

using Day5;

long GetLocation(long seed, Dictionary<string, Mapping> mappings)
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
    
    var closestSeedLocation = initalSeeds.Min(s => GetLocation(s, mappings));
    
    Console.WriteLine($"the closest seed location is: {closestSeedLocation}");
}

void PartTwo()
{
    var initalSeeds = new List<(long, int)>();
    var mappings = new Dictionary<string, Mapping>();
    
    var lines = new Queue<string>(File.ReadAllLines("input.txt"));
    while (lines.TryDequeue(out var line))
    {
        if (line.StartsWith("seeds: "))
        {
            var seedRangeValues = line.Substring(7).Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse)
                .ToArray();

            initalSeeds.AddRange(seedRangeValues.Chunk(2).Select(seedRange => (seedRange[0], (int)seedRange[1])));
            // initalSeeds.AddRange(seedRangeValues.Chunk(2).Select(seedRange => (seedRange[0], 1000000)));

            continue;
        }

        if (line.EndsWith(" map:"))
        {
            var mapping = new Mapping(line, lines);
            mappings.Add(mapping.SourceName, mapping);
        }
    }

    var closestSeedLocation = long.MaxValue;

    foreach (var seedRange in initalSeeds)
    {
        Console.WriteLine($"looking at range {seedRange.Item1}...{seedRange.Item1+seedRange.Item2}...");
        
        var closestLocation = Enumerable.Range(0, seedRange.Item2).Min(s => GetLocation(seedRange.Item1 + s, mappings));
        if (closestLocation < closestSeedLocation)
        {
            closestSeedLocation = closestLocation;
        }
    }
    
    Console.WriteLine($"the closest seed location is: {closestSeedLocation}");
}

PartOne();
PartTwo();