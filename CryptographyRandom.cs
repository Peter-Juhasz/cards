using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace Cards;

public sealed class CryptographyRandom : IRandom
{
    public CryptographyRandom(RandomNumberGenerator randomNumberGenerator)
    {
        _randomNumberGenerator = randomNumberGenerator;
    }

    private readonly RandomNumberGenerator _randomNumberGenerator;

    // based on https://github.com/dotnet/runtime/blob/main/src/libraries/System.Security.Cryptography/src/System/Security/Cryptography/RandomNumberGenerator.cs

    public int Next(int fromInclusive, int toExclusive)
    {
        // The total possible range is [0, 4,294,967,295).
        // Subtract one to account for zero being an actual possibility.
        uint range = (uint)toExclusive - (uint)fromInclusive - 1;

        // If there is only one possible choice, nothing random will actually happen, so return
        // the only possibility.
        if (range == 0)
        {
            return fromInclusive;
        }

        // Create a mask for the bits that we care about for the range. The other bits will be
        // masked away.
        uint mask = range;
        mask |= mask >> 1;
        mask |= mask >> 2;
        mask |= mask >> 4;
        mask |= mask >> 8;
        mask |= mask >> 16;

        Span<uint> resultSpan = stackalloc uint[1];
        uint result;

        do
        {
            _randomNumberGenerator.GetBytes(MemoryMarshal.AsBytes(resultSpan));
            result = mask & resultSpan[0];
        }
        while (result > range);

        return (int)result + fromInclusive;
    }
}
