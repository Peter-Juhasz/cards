using System;

namespace Cards;

public abstract record Card;

public record class Card<TSuite, TNumber>(
    TSuite Suite,
    TNumber Number
) : Card
    where TSuite : struct, Enum
    where TNumber : struct
;

public enum PokerSuite
{
    Spades,
    Hearts,
    Clubs,
    Diamonds,
}

public enum PokerNumber
{
    Two,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    Jack,
    Queen,
    King,
    Ace,
}