using HonkPerf.NET.RefLinq;
using System.Collections.Generic;
using Xunit;

namespace Tests;

public class RefLinqTests
{
    [Fact]
    public void Test1()
    {
        var list = new List<int>();
        var z = new[] { 1, 2, 3, 10, 20, 30, 502, 2342, 23 }.It();
        var seq = z
            .RefSelect(c => c.ToString())
            .RefWhere(c => c.Length > 1)
            .RefSelect(c => int.Parse(c) * 100);

        foreach (var a in seq)
            list.Add(a);

        Assert.Equal(list, new [] { 1000, 2000, 3000, 50200, 234200, 2300 });
    }

    [Fact]
    public void Test2()
    {
        var list = new List<(int, double)>();
        var z = new[] { 1, 2, 3, 10, 20, 30, 502, 2342, 23 }.It();
        var w1 = z
            .RefWhere(c => c > 5)
            .RefSelect(c => c * 100.0);
        var w2 = z
            .RefWhere(c => c > 5);
        foreach (var (b, a) in w1.RefZip(w2))
            list.Add((a, b));
        Assert.Equal(list, new[] { 
            (10, 1000d), 
            (20, 2000d),
            (30, 3000d),
            (502, 50200d), 
            (2342, 234200d),
            (23, 2300d)
            });
    }

    [Fact]
    public void NoMoreCallsThanNeeded()
    {
        var list = new List<int>();
        var z = new[] { 1, 2, 3, 10, 20, 30, 502, 2342, 23 }.It();
        var calls1 = 0;
        var calls2 = 0;
        var calls3 = 0;
        var log = new List<string>();
        var seq = z
            .RefSelect(c => 
                {
                    calls1++;
                    log.Add(c.ToString());
                    return c.ToString();
                })
            .RefWhere(c => 
                {
                    calls2++;
                    return c.Length > 1;
                })
            .RefSelect(c =>
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