// Copyright (c) Angouri 2021.
// This file from HonkPerf.NET project is MIT-licensed.
// Read more: https://github.com/asc-community/HonkPerf.NET

using HonkPerf.NET.RefLinq;


/*
unsafe
{

    var z = stackalloc [] { 1, 2, 3, 10, 20, 30, 502, 2342, 23 };

    var anotherSeq = stackalloc[] { 1, 2, 3, 4, 5, 6 };

    var fixedSpan = new FixedReadOnlySpan<int>(z, 9);
    var seq = fixedSpan
        .ToRefLinq()
        .Select(c => c % 10)
        .Where(c => c > 0)
        .Zip(
            new FixedReadOnlySpan<int>(anotherSeq, 6)
            .ToRefLinq())
        .Select(p => p.Item1 + p.Item2);

    foreach (var a in seq)
        Console.WriteLine(a);
    Console.WriteLine();
    Console.WriteLine(seq.Sum());
    Console.WriteLine(seq.Max());
    Console.WriteLine(seq.Min());
    Console.WriteLine(seq.Multiply());
}*/