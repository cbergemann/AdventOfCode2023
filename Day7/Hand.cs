using System.Diagnostics;

namespace Day7;

[DebuggerDisplay("Hand({_hand})")]
public class Hand : IComparable<Hand>
{
    private readonly string _hand;
    private readonly bool _allowJokers;

    public Hand(string hand, bool allowJokers)
    {
        _hand = hand;
        _allowJokers = allowJokers;
        Cards = hand.Select(DetermineCard).ToArray();
        TypeOfHand = DetermineTypeOfHand(Cards);
    }

    private Card[] Cards { get; }
    
    private TypeOfHand TypeOfHand { get; }

    private Card DetermineCard(char c)
    {
        return c switch
        {
            'A' => Card.Ace,
            'K' => Card.King,
            'Q' => Card.Queen,
            'J' => _allowJokers ? Card.Joker : Card.Jack,
            'T' => Card.Ten,
            '9' => Card.Nine,
            '8' => Card.Eight,
            '7' => Card.Seven,
            '6' => Card.Six,
            '5' => Card.Five,
            '4' => Card.Four,
            '3' => Card.Three,
            '2' => Card.Two,
            _ => throw new Exception(),
        };
    }

    private TypeOfHand DetermineTypeOfHand(IEnumerable<Card> cards)
    {
        var jokerCount = 0;
        var cardCount = new Dictionary<Card, int>();
        foreach (var card in cards)
        {
            if (card == Card.Joker)
            {
                jokerCount++;
                continue;
            }
            
            if (!cardCount.TryAdd(card, 1))
            {
                cardCount[card] += 1;
            }
        }

        if (cardCount.Count <= 1)
        {
            return TypeOfHand.FiveOfAKind;
        }

        if (cardCount.Count == 2 && cardCount.Values.Any(v => v == 1))
        {
            return TypeOfHand.FourOfAKind;
        }

        if (cardCount.Count == 2 && cardCount.Values.Any(v => v == 2))
        {
            return TypeOfHand.FullHouse;
        }

        if (cardCount.Values.Any(v => v == 3))
        {
            return TypeOfHand.ThreeOfAKind;
        }

        var pairCount = cardCount.Values.Count(c => c == 2);
        return pairCount switch
        {
            2 => TypeOfHand.TwoPair,
            1 => TypeOfHand.OnePair,
            _ => TypeOfHand.HighCard,
        };
    }

    public int CompareTo(Hand? other)
    {
        if (other == null)
        {
            throw new ArgumentNullException(nameof(other));
        }

        var typeCompare = TypeOfHand.CompareTo(other.TypeOfHand);
        if (typeCompare != 0)
        {
            return typeCompare;
        }

        for (var it = 0; it < Cards.Length; it++)
        {
            var cardCompare = Cards[it].CompareTo(other.Cards[it]);
            if (cardCompare != 0)
            {
                return cardCompare;
            }
        }

        return 0;
    }
}