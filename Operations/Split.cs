using System;
using System.Collections;
using System.Collections.Generic;

namespace Cards;

public static partial class PileExtensions
{
    public static (Pile<TCard> top, Pile<TCard> bottom) Split<TCard>(this Pile<TCard> pile, int count)
        where TCard : Card
    {
        var top = pile.Take(count);
        var bottom = new Pile<TCard>(pile);
        return (top, bottom);
    }

    public static (Pile<TCard> top, Pile<TCard> bottom) Split<TCard>(this Pile<TCard> pile, IRandom random)
        where TCard : Card =>
        pile.Split(random.Next(1, pile.Count));

    public static IReadOnlyList<Pile<TCard>> Split<TCard>(this Pile<TCard> pile, int numberOfPiles, IRandom random)
    {
        if (pile.Count < numberOfPiles)
        {
            throw new InvalidOperationException($"The pile does not contain enough number of cards to split.");
        }

        var results = new Pile<TCard>[numberOfPiles];

        for (int i = 0; i < numberOfPiles; i++)
        {
            results[i] = pile.Take(random.Next(1, pile.Count - (numberOfPiles - i + 1) + 1));
        }

        return results;
    }
}
