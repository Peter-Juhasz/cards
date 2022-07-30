using System;

namespace Cards;

public static partial class PileExtensions
{
    public static Pile<TCard> Take<TCard>(this Pile<TCard> pile, int count)
        where TCard : Card
    {
        var range = Range.StartAt(Index.FromEnd(count));
        var newPile = new Pile<TCard>(pile[range]);
        pile.RemoveAt(range);
        return newPile;
    }
}
