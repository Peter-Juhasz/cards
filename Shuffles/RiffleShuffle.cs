using System;

namespace Cards.Shuffles;

public class RiffleShuffle<TCard> : IShuffle<TCard> where TCard : Card
{
    public RiffleShuffle(RiffleShuffleOptions options)
    {
        Options = options;
    }

    public RiffleShuffleOptions Options { get; }

    public void Shuffle(Pile<TCard> pile)
    {
        var count = pile.Count;
        var random = Options.Random;
        var (first, second) = pile.Split(count / 2);

        var span = pile.AsSpan();
        for (int i = 0; i < count;)
        {
            var number = Math.Min(random.Next(1, Options.MaximumAdjacentCards + 1), first.Count);
            if (first.TryDeal(number, span.Slice(count - i - number, number)))
            {
                i += number;
            }

            number = Math.Min(random.Next(1, Options.MaximumAdjacentCards + 1), second.Count);
            if (second.TryDeal(number, span.Slice(count - i - number, number)))
            {
                i += number;
            }
        }
    }
}
