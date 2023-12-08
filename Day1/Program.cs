// See https://aka.ms/new-console-template for more information

using System.Text.RegularExpressions;

void PartOne()
{
    var sum = 0L;

    foreach (var line in File.ReadAllLines("input.txt"))
    {
        var digits = line.Where(char.IsDigit).ToArray();
        if (digits.Length < 1)
        {
            continue;
        }

        sum += long.Parse(string.Concat(digits[0], digits[^1]));
    }

    Console.WriteLine($"The sum of the calibration values is: {sum}");
}

void PartTwo()
{
    var digitsWithLetters = new Regex("(\\d|one|two|three|four|five|six|seven|eight|nine)");
    var values = new Dictionary<string, int>
    {
        { "one", 1 },
        { "two", 2 },
        { "three", 3 },
        { "four", 4 },
        { "five", 5 },
        { "six", 6 },
        { "seven", 7 },
        { "eight", 8 },
        { "nine", 9 },
    };

    var sum = 0L;

    foreach (var line in File.ReadAllLines("input.txt"))
    {
        var digits = new List<int>();

        var pos = 0;
        var match = digitsWithLetters.Match(line);
        while (match.Success)
        {
            if (!int.TryParse(match.Value, out var digit))
            {
                digit = values[match.Value];
            }

            digits.Add(digit);

            pos += match.Length;
            match = digitsWithLetters.Match(line, pos);
        }

        if (digits.Count < 1)
        {
            continue;
        }

        sum += long.Parse(string.Concat(digits[0], digits[^1]));
    }

    Console.WriteLine($"The sum of the calibration values is: {sum}");
}

PartOne();
PartTwo();

