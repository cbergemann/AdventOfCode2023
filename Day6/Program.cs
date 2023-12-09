
using Day6;

void PartOne()
{
    // var races = new Race[]
    // {
    //     new(7, 9),
    //     new(15, 40),
    //     new(30, 200),
    // };
    
    var races = new Race[]
    {
        new(44, 283),
        new(70, 1134),
        new(70, 1134),
        new(80, 1491),
    };

    var prod = races.Aggregate(1, (prod, race) => prod * race.NumberSolutions());

    Console.WriteLine($"number of ways to beat the race aggregated: {prod}");
}

void PartTwo()
{
    // var race = new Race(71530, 940200);
    var race = new Race(44707080, 283113411341491);
    
    Console.WriteLine($"number of ways to beat the race: {race.NumberSolutions()}");
}

PartOne();
PartTwo();