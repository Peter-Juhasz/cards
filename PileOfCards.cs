using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Cards.Shuffles;

namespace Cards;

public partial class Pile<TCard> : IList<TCard>
    where TCard : Card
{
    public Pile()
    {
        _inner = new List<TCard>(capacity: 52);
    }
    public Pile(IEnumerable<TCard> cards)
    {
        _inner = new List<TCard>(cards);
    }

    internal readonly List<TCard> _inner;

    public void Shuffle(IShuffle<TCard> shuffle) => shuffle.Shuffle(this);

    public TCard Peek() => this[^1];

    public TCard Peek(int index) => this[^(index + 1)];

    /// <summary>
    /// Deals a single <see cref="Card"/> from the top of the <see cref="Pile{T}"/>.
    /// </summary>
    public TCard Deal()
    {
        if (TryDeal(out var card))
        {
            return card;
        }

        throw new InvalidOperationException($"The pile is empty.");
    }

    public Pile<TCard> Deal(int count)
    {
        if (Count < count)
        {
            throw new InvalidOperationException($"The pile does not contain enough number of cards to deal.");
        }

        var pile = new Pile<TCard>();
        if (!TryDeal(count, pile))
        {
            throw new InvalidOperationException($"The pile does not contain enough number of cards to deal.");
        }

        return pile;
    }

    /// <summary>
    /// Tries to deal a single <see cref="Card"/> from the top of the <see cref="Pile{T}"/>.
    /// </summary>
    public bool TryDeal([NotNullWhen(true)] out TCard card)
    {
        if (Count == 0)
        {
            card = default!;
            return false;
        }

        card = Peek();
        RemoveAt(^1);
        return true;
    }

    /// <summary>
    /// Tries to deal a single <see cref="Card"/> from the top of the <see cref="Pile{T}"/>.
    /// </summary>
    public bool TryDeal(Pile<TCard> destination)
    {
        if (TryDeal(out var card))
        {
            destination.Add(card);
            return true;
        }

        return false;
    }

    public bool TryDeal(int count, Pile<TCard> destination)
    {
        if (Count < count)
        {
            return false;
        }

        for (int dealt = 0; dealt < count; dealt++)
        {
            destination.Add(Deal());
        }

        return true;
    }

    public bool TryDeal(int count, Span<TCard> destination)
    {
        if (Count < count)
        {
            return false;
        }

        if (destination.Length < count)
        {
            return false;
        }

        for (int dealt = 0; dealt < count; dealt++)
        {
            destination[dealt] = Deal();
        }

        return true;
    }
}
