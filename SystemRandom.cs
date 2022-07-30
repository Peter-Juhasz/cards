using System;

namespace Cards;

public sealed class SystemRandom : IRandom
{
    public SystemRandom(Random random)
    {
        _random = random;
    }
    public SystemRandom(int seed)
        : this(new Random(seed))
    { }
    public SystemRandom()
        : this(new Random())
    { }

    private readonly Random _random;

    public int Next(int minimum, int maximum) => _random.Next(minimum, maximum);
}
