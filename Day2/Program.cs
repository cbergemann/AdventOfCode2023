// See https://aka.ms/new-console-template for more information

void PartOne()
{
    var sum = 0L;
    var baseGame = new Game(13, 14, 12);
    foreach (var line in File.ReadAllLines("input.txt"))
    {
        var split1 = line.Split(':', 2);
        var split2 = split1[0].Split(' ');
        var gameId = int.Parse(split2[1]);

        var draws = split1[1].Split(';');
        foreach (var draw in draws)
        {
            var game = Game.FromString(draw);
            if (!baseGame.IsPossible(game))
            {
                goto not_possible;
            }
        }

        sum += gameId;

        not_possible: ;
    }

    Console.WriteLine($"Solution: {sum}");
}

void PartTwo()
{
    var sum = 0L;
    foreach (var line in File.ReadAllLines("input.txt"))
    {
        var split1 = line.Split(':', 2);
        var split2 = split1[0].Split(' ');
        var gameId = int.Parse(split2[1]);

        var draws = split1[1].Split(';');
        var game = new Game(0, 0, 0);
        foreach (var draw in draws)
        {
            var game2 = Game.FromString(draw);
            game.Merge(game2);
        }

        sum += game.Power;
    }

    Console.WriteLine($"Solution: {sum}");
}

PartOne();
PartTwo();