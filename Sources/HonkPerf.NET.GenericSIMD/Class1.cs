// Copyright (c) Angouri 2021.
// This file from HonkPerf.NET project is MIT-licensed.
// Read more: https://github.com/asc-community/HonkPerf.NET

using System;
using System.Runtime.Intrinsics.X86;

namespace HonkPerf.NET.GenericSIMD;

public static unsafe partial class GenericSimd
{
    public static void NaiveAdd<T>(Span<T> a, Span<T> b, Span<T> destination) where T : unmanaged
    {
        fixed (T* afPtr = a)
        fixed (T* bfPtr = b)
        {
            for (int i = 0; i < destination.Length; i++)
                destination[i] = afPtr[i] + bfPtr[i];
        }
    }

    public static void Add128<T>(Span<T> a, Span<T> b, Span<T> destination) where T : unmanaged
    {
        fixed (T* afPtr = a)
        fixed (T* bfPtr = b)
        fixed (T* cfPtr = destination)
        {
            var aPtr = afPtr;
            var bPtr = bfPtr;
            var cPtr = cfPtr;
            var extra = destination.Length % 32;
            if (extra != 0)
            {
                // naive
                aPtr += (32 - extra);
                bPtr += (32 - extra);
                cPtr += (32 - extra);
            }
            for (int i = 0; i < destination.Length / 32 * 4; i++)
            {
                Avx.Load
            }
        }
    }
}