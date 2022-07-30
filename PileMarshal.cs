using System;
using System.Runtime.InteropServices;

namespace Cards;

public static class PileMarshal
{
    public static Span<T> AsSpan<T>(this Pile<T> pile) where T : Card => CollectionsMarshal.AsSpan(pile._inner);
}