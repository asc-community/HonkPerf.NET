// Copyright (c) Angouri 2021.
// This file from HonkPerf.NET project is MIT-licensed.
// Read more: https://github.com/asc-community/HonkPerf.NET

namespace HonkPerf.NET.RefLinq;

internal static class ThrowHelpers
{
    internal static void ThrowSequenceContainsNoElements()
    {
        throw new InvalidOperationException("Sequence contains no elements");
    }

    internal static void ThrowSequenceContainsMoreThanOneElement()
    {
        throw new InvalidOperationException("Sequence contains more than one element");
    }
}