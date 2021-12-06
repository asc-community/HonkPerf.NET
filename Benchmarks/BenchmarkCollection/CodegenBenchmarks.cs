// Copyright (c) Angouri 2021.
// This file from HonkPerf.NET project is MIT-licensed.
// Read more: https://github.com/asc-community/HonkPerf.NET

using CodegenAnalysis.Benchmarks;
using HonkPerf.NET.RefLinq;
using System.Runtime.CompilerServices;

[CAColumn(CAColumn.StaticStackAllocations)]

[CAExport(Export.Html),
 CAExport(Export.Md)]
public class CodegenBenchmarks
{
    [CAAnalyze]
    public static double RefLinqManyAppends()
    {
        var seq = arr
             .ToRefLinq()
             .Append(3).Append(3)
             .Append(3).Append(3)
             .Append(3).Append(3)
             .Append(3).Append(3)
             .Append(3).Append(3)
             .Append(3).Append(3)
             ;
        return seq.Sum();
    }

    [CAAnalyze]
    public static double LinqAFManyAppends()
    {
        return LinqAF.RunLinqAFSSa.LinqAFManyAppends();
    }

    public static readonly int[] arr = new[] {
        1, 2, 3, 10, 20, 30, 502, 2342, 23, 234, 23, 2235, 32, 324322, 333,
        1, 2, 3, 10, 20, 30, 502, 2342, 23, 234, 23, 2235, 32, 324322, 333,
        1, 2, 3, 10, 20, 30, 502, 2342, 23, 234, 23, 2235, 32, 324322, 333,
        1, 2, 3, 10, 20, 30, 502, 2342, 23, 234, 23, 2235, 32, 324322, 333,
        1, 2, 3, 10, 20, 30, 502, 2342, 23, 234, 23, 2235, 32, 324322, 333,
        1, 2, 3, 10, 20, 30, 502, 2342, 23, 234, 23, 2235, 32, 324322, 333,
        };
}


namespace LinqAF
{
    public static class RunLinqAFSSa
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int LinqAFManyAppends()
        {
            var seq = CodegenBenchmarks.arr
                 .Append(3).Append(3)
                 .Append(3).Append(3)
                 .Append(3).Append(3)
                 .Append(3).Append(3)
                 .Append(3).Append(3)
                 .Append(3).Append(3)
                 ;
            return seq.Sum();
        }
    }
}