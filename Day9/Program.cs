using Day9;

void PartOne()
{
    var histories = File.ReadAllLines("input.txt").Select(line => new History(line)).ToArray();
    var sum = histories.Sum(h => h.ExtrapolateNextValue());

    Console.WriteLine($"Sum of extrapolated next values: {sum}");
}

void PartTwo()
{
    var histories = File.ReadAllLines("input.txt").Select(line => new History(line)).ToArray();
    var sum = histories.Sum(h => h.ExtrapolatePreviousValue());

    Console.WriteLine($"Sum of extrapolated previous values: {sum}");
}

PartOne();
PartTwo();