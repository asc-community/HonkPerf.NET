// Copyright (c) Angouri 2021.
// This file from HonkPerf.NET project is MIT-licensed.
// Read more: https://github.com/asc-community/HonkPerf.NET

using HonkPerf.NET.RefLinq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Xunit;

namespace Tests;

public class RefLinqTests
{
    [Fact]
    public void Test1()
    {
        var seq =
            new[] { 1, 2, 3, 10, 20, 30, 502, 2342, 23 }
            .ToRefLinq()
            .Select(c => c.ToString())
            .Where(c => c.Length > 1)
            .Select(c => int.Parse(c) * 100);

        TestUtils.EqualSequences(seq, new[] { 1000, 2000, 3000, 50200, 234200, 2300 });
    }

    [Fact]
    public void TestCapture()
    {
        var greaterThan = GetThing();
        var res = 0;
        var z = new[] { 1, 2, 3 }.ToRefLinq();
        foreach (var n in z.Select((a, greaterThan) => a + greaterThan, greaterThan))
            res += n;

        Assert.Equal(51, res);

        [MethodImpl(MethodImplOptions.NoInlining)]
        static int GetThing()
            => 15;
    }

    [Fact]
    public void NoMoreCallsThanNeeded()
    {
        var list = new List<int>();
        var z = new[] { 1, 2, 3, 10, 20, 30, 502, 2342, 23 }.ToRefLinq();
        var calls1 = 0;
        var calls2 = 0;
        var calls3 = 0;
        var log = new List<string>();
        var seq = z
            .Select(c => 
                {
                    calls1++;
                    log.Add(c.ToString());
                    return c.ToString();
                })
            .Where(c => 
                {
                    calls2++;
                    return c.Length > 1;
                })
            .Select(c =>
                {
                    calls3++;
                    return int.Parse(c) * 100;
                });

        foreach (var a in seq)
            list.Add(a);

        Assert.Equal(9, calls1);
        Assert.Equal(9, calls2);
        Assert.Equal(6, calls3);
    }
}