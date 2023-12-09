// See https://aka.ms/new-console-template for more information

using Day4;

void PartOne()
{
    var cards = File.ReadAllLines("input.txt").Select(line => new ScratchCard(line));
    var sum = cards.Sum(c => c.Points);

    Console.WriteLine($"Ticket points total: {sum}");
}

void PartTwo()
{
    var sum = 0L;

    var cards = File.ReadAllLines("input.txt").Select(line => new ScratchCard(line)).ToArray();

    var cardStack = new Queue<ScratchCard>(cards);
    while (cardStack.TryDequeue(out var card))
    {
        sum++;
        
        for (var it = 0; it < card.Count; it++)
        {
            cardStack.Enqueue(cards[card.CardId + it]);
        }
    }

    Console.WriteLine($"Total number of cards: {sum}");
}

PartOne();
PartTwo();

