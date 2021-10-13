// Copyright (c) Angouri 2021.
// This file from HonkPerf.NET project is MIT-licensed.
// Read more: https://github.com/asc-community/HonkPerf.NET

namespace HonkPerf.NET.RefLinq.Enumerators;

public struct RangeEnumerator
    : IRefEnumerable<int>
{
    private readonly int end;
    private int current;

    public RangeEnumerator(int start, int count)
    {
        current = start - 1;
        end = start + count;
    }

    public bool MoveNext()
    {
        current++;
        return current < end;
    }

    public int Current => current;
}