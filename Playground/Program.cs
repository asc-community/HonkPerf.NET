using HonkPerf.NET.RefLinq;

var z = new[] { 1, 2, 3, 10, 20, 30, 502, 2342, 23 }.It();
var seq = z
    .RefSelect<int, string, IReadOnlyListEnumerator<int>>(c => c.ToString())
    .RefWhere<string, Select<int, string, IReadOnlyListEnumerator<int>>>(c => c.Length > 1)
    .RefSelect<string, int, Where<string, Select<int, string, IReadOnlyListEnumerator<int>>>>(c => int.Parse(c) * 100);

foreach (var a in seq)
    Console.WriteLine(a);
