using HonkPerf.NET.RefLinq;

unsafe
{

    var z = stackalloc [] { 1, 2, 3, 10, 20, 30, 502, 2342, 23 };

    var anotherSeq = stackalloc[] { 1, 2, 3, 4, 5, 6 };

    var fixedSpan = new FixedReadOnlySpan<int>(z, 9);
    var seq = fixedSpan
        .ToRefLinq()
        .RefSelect(c => c % 10)
        .RefWhere(c => c > 0)
        .RefZip(
            new FixedReadOnlySpan<int>(anotherSeq, 6)
            .ToRefLinq())
        .RefSelect(p => p.Item1 + p.Item2);

    foreach (var a in seq)
        Console.WriteLine(a);
    Console.WriteLine();
    Console.WriteLine(seq.Sum());
    Console.WriteLine(seq.Max());
    Console.WriteLine(seq.Min());
    Console.WriteLine(seq.Multiply());
}