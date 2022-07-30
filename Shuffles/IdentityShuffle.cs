namespace Cards.Shuffles;

/// <summary>
/// Leaves the order of the <see cref="Card"/>s unchanged.
/// </summary>
public sealed class IdentityShuffle<TCard> : IShuffle<TCard>
    where TCard : Card
{
    public void Shuffle(Pile<TCard> pile) { }
}
