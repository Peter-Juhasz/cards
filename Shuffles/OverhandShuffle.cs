using System;

namespace Cards.Shuffles;

public class OverhandShuffle<TCard> : IShuffle<TCard> where TCard : Card
{
    public OverhandShuffle(OverhandShuffleOptions options)
    {
        Options = options;
    }

    public OverhandShuffleOptions Options { get; }

    public void Shuffle(Pile<TCard> pile)
    {
        var rounds = Options.Random.Next(1, Options.MaximumRounds + 1);
        for (int i = 0; i < rounds; i++)
        {
            var cardsToTake = Options.Random.Next(Options.MinimumCardsToTake, Options.MaximumCardsToTake + 1);
            var taken = pile.Take(cardsToTake);

            while (taken.Count > 0)
            {
                var cardsToFall = Math.Min(Options.Random.Next(Options.MinimumCardsToFall, Options.MaximumCardsToFall + 1), taken.Count);
                var falling = taken.Take(cardsToFall);
                pile.InsertRange(0, falling);
            }
        }
    }
}
