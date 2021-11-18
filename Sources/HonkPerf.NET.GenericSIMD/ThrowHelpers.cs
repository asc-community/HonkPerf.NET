// Copyright (c) Angouri 2021.
// This file from HonkPerf.NET project is MIT-licensed.
// Read more: https://github.com/asc-community/HonkPerf.NET

using System.Runtime.CompilerServices;

namespace HonkPerf.NET.GenericSIMD;

internal static class ThrowHelpers
{
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void TypeNotSupported()
    {
        throw new NotSupportedException();
    }
}