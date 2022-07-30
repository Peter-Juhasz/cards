using System;

namespace Cards;

public static class Deck
{
    public static Pile<Card<TSuite, TNumber>> Create<TSuite, TNumber>()
        where TSuite : struct, Enum
        where TNumber : struct, Enum
    {
        var deck = new Pile<Card<TSuite, TNumber>>();

        foreach (var suite in Enum.GetValues<TSuite>())
        {
            foreach (var number in Enum.GetValues<TNumber>())
            {
                deck.Add(new Card<TSuite, TNumber>(suite, number));
            }
        }

        return deck;
    }
}
