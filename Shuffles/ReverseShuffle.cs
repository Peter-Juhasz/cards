namespace Cards.Shuffles;

/// <summary>
/// Reverses the order of <see cref="Card"/>s in a <see cref="Pile{TCard}"/>.
/// </summary>
public sealed class ReverseShuffle<TCard> : IShuffle<TCard> where TCard : Card
{
    public void Shuffle(Pile<TCard> pile) => pile.Reverse();
}
