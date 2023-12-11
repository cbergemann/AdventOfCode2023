using Day11;

void PartOne()
{
    var map = new GalaxyMap(File.ReadAllLines("input.txt"), 2);
    var sum = map.SumShortestPaths();
    Console.WriteLine($"sum of shortest paths: {sum}");
}

void PartTwo()
{
    var map = new GalaxyMap(File.ReadAllLines("input.txt"), 1_000_000);
    var sum = map.SumShortestPaths();
    Console.WriteLine($"sum of shortest paths: {sum}");
}

PartOne();
PartTwo();
