using Day7;

void Solution(bool allowJokers)
{
    var hands = new List<(Hand Hand, int Bet)>(); 
    
    var lines = File.ReadAllLines("input.txt");
    foreach (var line in lines)
    {
        var split = line.Split(' ');
        var hand = new Hand(split[0], allowJokers);
        var bet = int.Parse(split[1]);

        hands.Add((hand, bet));
    }
    
    hands.Sort();
    hands.Reverse();

    var winnings = 0L;
    
    for (var it = 0; it < hands.Count; it++)
    {
        var hand = hands[it];
        // if (hand.Hand.ToString().Contains("J"))
        // {
        //     Console.WriteLine($"Hand: {hand.Hand}: {hand.Hand.TypeOfHand}");
        // }
        
        winnings += (it + 1) * hand.Bet;
    }

    Console.WriteLine($"total winnings: {winnings} ({(allowJokers ? "with" : "without")} jokers)");
}

Solution(allowJokers: false);
Solution(allowJokers: true);
