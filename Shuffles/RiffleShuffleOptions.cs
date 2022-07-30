namespace Cards.Shuffles;

public record struct RiffleShuffleOptions(
    IRandom Random,
    double MaximumSplitError,
    int MaximumAdjacentCards
);