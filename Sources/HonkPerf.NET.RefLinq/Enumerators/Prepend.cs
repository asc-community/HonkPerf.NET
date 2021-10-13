// Copyright (c) Angouri 2021.
// This file from HonkPerf.NET project is MIT-licensed.
// Read more: https://github.com/asc-community/HonkPerf.NET

namespace HonkPerf.NET.RefLinq.Enumerators;

public struct Prepend<T, TEnumerator>
    : IRefEnumerable<T>
    where TEnumerator : IRefEnumerable<T>
{
    private TEnumerator prev;
    private readonly T toPrepend;
    private bool theFirstAlreadyYielded;
    public Prepend(TEnumerator prev, T toPrepend)
    {
        this.prev = prev;
        theFirstAlreadyYielded = false;
        this.toPrepend = toPrepend;
        Current = default!;
    }

    public bool MoveNext()
    {
        if (theFirstAlreadyYielded)
        {
            if (prev.MoveNext())
            {
                Current = prev.Current;
                return true;
            }
            return false;
        }
        Current = toPrepend;
        theFirstAlreadyYielded = true;
        return true;
    }

    public T Current { get; private set; }
}