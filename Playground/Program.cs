using HonkPerf.NET.RefLinq;


var z = new[] { 1, 2, 3, 10, 20, 30, 502, 2342, 23 }.It();
var seq = z
    .RefSelect(c => c.ToString())
    .RefWhere(c => c.Length > 1)
    .RefSelect(c => int.Parse(c) * 100);

foreach (var a in seq)
    Console.WriteLine(a);
