// Copyright (c) Angouri 2021.
// This file from HonkPerf.NET project is MIT-licensed.
// Read more: https://github.com/asc-community/HonkPerf.NET

namespace HonkPerf.NET.RefLinq.Enumerators;

public struct SelectMany<T, TEnumerator, TEnumeratorOfEnumerators>
    : IRefEnumerable<T>
    where TEnumerator : IRefEnumerable<T>
    where TEnumeratorOfEnumerators : IRefEnumerable<RefLinqEnumerable<T, TEnumerator>>
{
    private TEnumeratorOfEnumerators en;
    private TEnumerator currEn;
    private bool iterStarted;

    public SelectMany(TEnumeratorOfEnumerators en)
    {
        this.en = en;
        currEn = default!;
        iterStarted = false;
        Current = default!;
    }

    public bool MoveNext()
    {
        begin:
        if (!iterStarted)
        {
            iterStarted = true;
            if (en.MoveNext())
            {
                currEn = en.Current.enumerator;
                goto begin;
            }
            return false;
        }
        if (currEn.MoveNext())
        {
            Current = currEn.Current;
            return true;
        }
        iterStarted = false;
        goto begin;
    }

    public T Current { get; private set; }
}