namespace Cards.Shuffles;

public record class OverhandShuffleOptions(
    IRandom Random,
    int MinimumRounds,
    int MaximumRounds,
    int MinimumCardsToTake,
    int MaximumCardsToTake,
    int MinimumCardsToFall,
    int MaximumCardsToFall
);
