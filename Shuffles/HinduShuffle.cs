using System;

namespace Cards.Shuffles;

public class HinduShuffle<TCard> : IShuffle<TCard> where TCard : Card
{
    public HinduShuffle(HinduShuffleOptions options)
    {
        Options = options;
    }

    public HinduShuffleOptions Options { get; }

    public void Shuffle(Pile<TCard> pile)
    {
        var source = pile.Take(pile.Count);
        while (source.Count > 0)
        {
            var cardsToTake = Math.Min(Options.Random.Next(Options.MinimumCardsToTake, Options.MaximumCardsToTake + 1), source.Count);
            var cards = source.Take(cardsToTake);
            pile.AddRange(cards);
        }
    }
}
