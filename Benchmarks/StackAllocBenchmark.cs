// Copyright (c) Angouri 2021.
// This file from HonkPerf.NET project is MIT-licensed.
// Read more: https://github.com/asc-community/HonkPerf.NET

using System.Runtime.CompilerServices;

public static unsafe class StackAllocBenchmark
{
    [SkipLocalsInit]
    public static int Count(Action action)
    {
        MarkBytes(1000);
        action();
        return CountBytes(1000);
    }

    [SkipLocalsInit]
    private static void MarkBytes(int byteCount)
    {
        // Span<byte> bytes = stackalloc byte[byteCount];
        var a = 0;
        var bytes = &a + 132;
        for (int i = 0; i < byteCount - 2; i += 3)
        {
            bytes[i] = byte.MaxValue;
            bytes[i + 1] = byte.MaxValue - 1;
            bytes[i + 2] = byte.MaxValue - 2;
        }
    }

    [SkipLocalsInit]
    private static int CountBytes(int byteCount)
    {
        // Span<byte> bytes = stackalloc byte[byteCount];
        var a = 0;
        var bytes = &a + 132;
        var i = 0;
        while (i < byteCount - 4)
        {
            if (bytes[i] == byte.MaxValue && bytes[i + 1] == byte.MaxValue - 1 && bytes[i + 2] == byte.MaxValue - 2)
                return i;
            i++;
        }
        return -1;
    }
}