// Copyright (c) Angouri 2021.
// This file from HonkPerf.NET project is MIT-licensed.
// Read more: https://github.com/asc-community/HonkPerf.NET

using BenchmarkDotNet.Attributes;
using HonkPerf.NET.RefLinq;
using System.Runtime.CompilerServices;
using NoAlloq;
using JM.LinqFaster;
using NetFabric.Hyperlinq;
using StructLinq;

/*
 

|              Method | ArrayLength |          Mean |        Error |       StdDev |  Gen 0 | Allocated |
|-------------------- |------------ |--------------:|-------------:|-------------:|-------:|----------:|
|     RefLinqCombined |          10 |      88.83 ns |     1.517 ns |     1.806 ns |      - |         - |
| ClassicLinqCombined |          10 |     201.88 ns |     3.988 ns |     3.731 ns | 0.0331 |     104 B |
|     RefLinqCombined |         100 |     527.11 ns |     9.515 ns |     8.900 ns |      - |         - |
| ClassicLinqCombined |         100 |   1,321.29 ns |    25.839 ns |    51.604 ns | 0.0324 |     104 B |
|     RefLinqCombined |        1000 |   4,952.72 ns |    82.181 ns |    72.851 ns |      - |         - |
| ClassicLinqCombined |        1000 |  13,128.03 ns |   262.541 ns |   696.220 ns | 0.0305 |     104 B |
|     RefLinqCombined |       10000 |  59,863.10 ns |   937.781 ns |   877.201 ns |      - |         - |
| ClassicLinqCombined |       10000 | 121,760.98 ns | 2,388.575 ns | 2,345.900 ns |      - |     104 B |

 
 */

[MemoryDiagnoser]
public class DifferentLengths
{

    [Params(10, 100, 1000, 10000)]
    public int ArrayLength { get; set; }
    private int[] arr = default!;

    [GlobalSetup]
    public void Setup()
    {
        arr = System.Linq.Enumerable.Range(1, ArrayLength).ToArray();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    static int GetThing()
        => 15;


    [Benchmark]
    public double RefLinqCombined()
    {
        var res = 0.0;
        var local = GetThing();
        var seq = arr
            .ToRefLinq()
            .Select(c => c + 5)
            .Where(c => c % 2 == 0)
            ;
        foreach (var a in seq)
            res += a;
        return res;
    }

    [Benchmark]
    public double ClassicLinqCombined()
    {
        var res = 0.0;
        var local = GetThing();
        var seq = arr
            .Select(c => c + 5)
            .Where(c => c % 2 == 0)
            ;
        foreach (var a in seq)
            res += a;
        return res;
    }

}

