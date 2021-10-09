using HonkPerf.NET.RefLinq;

/*
var z = new[] { 1, 2, 3, 10, 20, 30, 502, 2342, 23 }.It();
var seq = z
    .RefSelect((int c) => c.ToString())
    .RefWhere((string c) => c.Length > 1)
    .RefSelect((string c) => int.Parse(c) * 100);

foreach (var a in seq)
    Console.WriteLine(a);
*/

Aaa<int> a = default;
Bbb<string> b = default;

Do(a);

void Do<T1, TInterface1>(TInterface1 a)
    where TInterface1 : IInterface<T1>
    // where TInterface2 : IInterface<T2>
{
}

public interface IInterface<T> { }

public struct Aaa<T> : IInterface<T> { }
public struct Bbb<T> : IInterface<T> { }