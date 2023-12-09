using Day9;

void PartOne()
{
    var histories = File.ReadAllLines("input.txt").Select(line => new History(line)).ToArray();
    var sum = histories.Sum(h => h.ExtrapolateNextValue());

    Console.WriteLine($"Sum of extrapolated values: {sum}");
}

PartOne();
