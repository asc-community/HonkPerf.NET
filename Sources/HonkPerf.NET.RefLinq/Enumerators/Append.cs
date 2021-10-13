// Copyright (c) Angouri 2021.
// This file from HonkPerf.NET project is MIT-licensed.
// Read more: https://github.com/asc-community/HonkPerf.NET

namespace HonkPerf.NET.RefLinq.Enumerators;

public struct Append<T, TEnumerator>
    : IRefEnumerable<T>
    where TEnumerator : IRefEnumerable<T>
{
    private TEnumerator prev;
    private readonly T toAppend;
    private bool theLastAlreadyYielded;
    public Append(TEnumerator prev, T toAppend)
    {
        this.prev = prev;
        theLastAlreadyYielded = false;
        this.toAppend = toAppend;
        Current = default!;
    }

    public bool MoveNext()
    {
        if (theLastAlreadyYielded)
            return false;
        if (prev.MoveNext())
        {
            Current = prev.Current;
        }
        else
        {
            Current = toAppend;
            theLastAlreadyYielded = true;
        }
        return true;
    }

    public T Current { get; private set; }
}