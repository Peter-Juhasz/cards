using System;
using System.Collections;
using System.Collections.Generic;

namespace Cards;

public partial class Pile<TCard>
{
    public TCard this[int index]
    {
        get => _inner[index];
        set => _inner[index] = value;
    }

    public TCard this[Index index]
    {
        get => _inner[index];
        set => _inner[index] = value;
    }

    public IList<TCard> this[Range range]
    {
        get
        {
            var (offset, length) = range.GetOffsetAndLength(Count);
            return _inner.GetRange(offset, length);
        }
        set
        {
            RemoveAt(range);
            _inner.InsertRange(range.Start.GetOffset(Count), value);
        }
    }

    public int Count => _inner.Count;

    public bool IsReadOnly => false;

    public void Add(TCard item) => _inner.Add(item);
    public void AddRange(IEnumerable<TCard> items) => _inner.AddRange(items);

    public void Clear() => _inner.Clear();

    public bool Contains(TCard item) => _inner.Contains(item);

    public void CopyTo(TCard[] array, int arrayIndex) => _inner.CopyTo(array, arrayIndex);

    public int IndexOf(TCard item) => _inner.IndexOf(item);

    public void Insert(int index, TCard item) => _inner.Insert(index, item);
    public void Insert(Index index, TCard item) => _inner.Insert(index.GetOffset(Count), item);
    public void InsertRange(int index, IEnumerable<TCard> items) => _inner.InsertRange(index, items);

    public bool Remove(TCard item) => _inner.Remove(item);

    public void RemoveAt(int index) => _inner.RemoveAt(index);
    public void RemoveAt(Index index) => _inner.RemoveAt(index.GetOffset(Count));
    public void RemoveAt(Range range)
    {
        var (offset, length) = range.GetOffsetAndLength(Count);
        _inner.RemoveRange(offset, length);
    }

    public IEnumerator<TCard> GetEnumerator() => _inner.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)_inner).GetEnumerator();
}
