namespace Cards.Shuffles;

public class FaroShuffle<TCard> : IShuffle<TCard> where TCard : Card
{
    public FaroShuffle(FaroShuffleOptions options)
    {
        Options = options;
    }

    public FaroShuffleOptions Options { get; }

    public void Shuffle(Pile<TCard> pile)
    {
        var count = pile.Count;
        var (first, second) = pile.Split(count / 2);

        if (Options.Mode is FaroShuffleMode.In)
        {
            (first, second) = (second, first);
        }

        var span = pile.AsSpan();
        for (int i = 0; i < count;)
        {
            if (first.TryDeal(out var card))
            {
                span[count - i - 1] = card;
                i++;
            }

            if (second.TryDeal(out card))
            {
                span[count - i - 1] = card;
                i++;
            }
        }
    }
}
