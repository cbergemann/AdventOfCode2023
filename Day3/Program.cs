// See https://aka.ms/new-console-template for more information

using Day3;

void PartOne()
{
    var lines = File.ReadAllLines("input.txt");
    var schematic = new Schematic(lines);
    var sum = schematic.EnumeratePartNumbers().Sum();

    Console.WriteLine($"Sum of all part numbers: {sum}");
}

void PartTwo()
{
    var lines = File.ReadAllLines("input.txt");
    var schematic = new Schematic(lines);
    var sum = schematic.EnumerateGearRatios().Sum();

    Console.WriteLine($"Sum of all gear ratios: {sum}");
}

PartOne();
PartTwo();