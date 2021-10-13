// Copyright (c) Angouri 2021.
// This file from HonkPerf.NET project is MIT-licensed.
// Read more: https://github.com/asc-community/HonkPerf.NET

namespace HonkPerf.NET.RefLinq;

public unsafe struct FixedReadOnlySpan<T>
    where T : unmanaged
{
    private readonly T* pointer;
    public int Length { get; }
    public FixedReadOnlySpan(T* ptr, int length)
    {
        pointer = ptr;
        Length = length;
    }
    public T this[int index] => *(pointer + index);
}