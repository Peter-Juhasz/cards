using System;

namespace Cards;

public static partial class PileExtensions
{
    public static void Reverse<TCard>(this Pile<TCard> pile)
        where TCard : Card
    {
        pile.AsSpan().Reverse();
    }
}
