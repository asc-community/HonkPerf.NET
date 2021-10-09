using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace HonkPerf.NET.RefLinq;

public interface IRefEnumerable<T>
{
    bool MoveNext();
    T Current { get; }
}

public struct IReadOnlyListEnumerator<T> : IRefEnumerable<T>
{
    private readonly IReadOnlyList<T> list;
    private int curr;

    public IReadOnlyListEnumerator(IReadOnlyList<T> list)
    {
        this.list = list;
        this.curr = -1;
    }

    public bool MoveNext()
    {
        curr++;
        return curr < list.Count;
    }

    public T Current => list[curr];
}

public struct Select<T, U, TEnumerator>
    : IRefEnumerable<U>
    where TEnumerator : IRefEnumerable<T>
{
    public Select(TEnumerator prev, Func<T, U> map)
    {
        this.prev = prev;
        this.map = map;
        Current = default!;
    }
    private TEnumerator prev;
    private readonly Func<T, U> map;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool MoveNext()
    {
        var res = prev.MoveNext();
        if (res)
            Current = map(prev.Current);
        return res;
    }
    public U Current { get; private set;}

    public Select<T, U, TEnumerator> GetEnumerator() => this;
}

public struct Where<T, TEnumerator>
    : IRefEnumerable<T>
    where TEnumerator : IRefEnumerable<T>
{
    public Where(TEnumerator prev, Func<T, bool> map)
    {
        this.prev = prev;
        this.map = map;
    }
    private TEnumerator prev;
    private readonly Func<T, bool> map;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool MoveNext()
    {
        tryAgain:
        if (!prev.MoveNext())
            return false;
        if (!map(prev.Current))
            goto tryAgain;
        return true;
    }
    public T Current => prev.Current;

    public Where<T, TEnumerator> GetEnumerator() => this;
}

public struct Zip<T1, T2, TEnumerator1, TEnumerator2>
        where TEnumerator1 : IRefEnumerable<T1>
        where TEnumerator2 : IRefEnumerable<T2>
{
    private TEnumerator1 en1;
    private TEnumerator2 en2;

    public Zip(TEnumerator1 en1, TEnumerator2 en2)
    {
        this.en1 = en1;
        this.en2 = en2;
        Current = default;
    }

    public (T1, T2) Current { get; private set; }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool MoveNext()
    {
        var res1 = en1.MoveNext();
        var res2 = en2.MoveNext();
        if (!res1 && !res2)
            return false;
        if (res1 && res2)
        {
            Current = (en1.Current, en2.Current);
            return true;
        }
        ThrowInvalid();
        return default;
    }

    [MethodImpl(MethodImplOptions.NoInlining), DoesNotReturn]
    private static void ThrowInvalid()
        => throw new InvalidOperationException("Collections should have the same size");

    public Zip<T1, T2, TEnumerator1, TEnumerator2> GetEnumerator() => this;
}

public struct TypeArg<T> { }
