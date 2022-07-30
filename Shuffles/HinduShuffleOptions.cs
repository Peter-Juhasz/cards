namespace Cards.Shuffles;

public record struct HinduShuffleOptions(
    IRandom Random,
    int MinimumCardsToTake,
    int MaximumCardsToTake
);
