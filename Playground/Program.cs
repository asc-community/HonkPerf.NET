using HonkPerf.NET.RefLinq;

var z = new[] { 1, 2, 3, 10, 20, 30, 502, 2342, 23 }.It();
var seq = z
    .RefSelect((int c) => c.ToString())
    .RefWhere((string c) => c.Length > 1)
    .RefSelect((string c) => int.Parse(c) * 100);

foreach (var a in seq)
    Console.WriteLine(a);
