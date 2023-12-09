using Day7;

void PartOne()
{
    var hands = new List<(Hand Hand, int Bet)>(); 
    
    var lines = File.ReadAllLines("input.txt");
    foreach (var line in lines)
    {
        var split = line.Split(' ');
        var hand = new Hand(split[0]);
        var bet = int.Parse(split[1]);

        hands.Add((hand, bet));
    }
    
    hands.Sort();
    hands.Reverse();

    var winnings = 0L;
    
    for (var it = 0; it < hands.Count; it++)
    {
        winnings += (it + 1) * hands[it].Bet;
    }

    Console.WriteLine($"total winnings: {winnings}");
}

PartOne();