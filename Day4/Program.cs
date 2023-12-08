// See https://aka.ms/new-console-template for more information

void PartOne()
{
    var sum = 0L;

    var lines = File.ReadAllLines("input.txt");
    foreach (var line in lines)
    {
        var split1 = line.Split(':');
        // var split2 = split1[0].Split(' ');
        // var cardId = int.Parse(split2[0]);

        var split2 = split1[1].Split('|');
        var winningNumbers = split2[0].Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToHashSet();
        var drawnNumbers = split2[1].Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
        winningNumbers.IntersectWith(drawnNumbers);

        if (winningNumbers.Count > 0)
        {
            var points = (long)Math.Pow(2, winningNumbers.Count - 1);
            // Console.WriteLine($"{split1[0]}: {points}");
            sum += points;
        }
    }

    Console.WriteLine($"Ticket points total: {sum}");
}

PartOne();


