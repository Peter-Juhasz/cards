namespace Cards.Shuffles;

public interface IShuffle<TCard> where TCard : Card
{
    void Shuffle(Pile<TCard> pile);
}
