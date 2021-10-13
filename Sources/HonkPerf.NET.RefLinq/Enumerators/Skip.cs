// Copyright (c) Angouri 2021.
// This file from HonkPerf.NET project is MIT-licensed.
// Read more: https://github.com/asc-community/HonkPerf.NET

namespace HonkPerf.NET.RefLinq.Enumerators;

public struct Skip<T, TEnumerator>
    : IRefEnumerable<T>
    where TEnumerator : IRefEnumerable<T>
{
    private TEnumerator en;
    private int toSkip;
    public Skip(TEnumerator en, int toSkip)
    {
        this.en = en;
        this.toSkip = toSkip;
        Current = default!;
    }
    public bool MoveNext()
    {
        if (toSkip is 0)
        {
            var res = en.MoveNext();
            if (res)
                Current = en.Current;
            return res;
        }
        bool theLastMovedNext;
        while ((theLastMovedNext = en.MoveNext()) && toSkip > 0)
        {
            toSkip--;
        }
        if (!theLastMovedNext)
            return false;
        Current = en.Current;
        return true;
    }

    public T Current { get; private set; }
}