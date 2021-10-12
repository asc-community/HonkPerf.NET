# HonkPerf.NET

Collection of performant (but limited in usage) replacements for BCL's types and methods;

## RefLinq

## Summary

RefLinq is like Linq, but it must be only used within a method, so behaves more limited than `ref` structs. Its benefit - it does not make allocations for enumerators and captured variables (given that you use it properly). Its API does not differ *much* from that of Linq.

So, basically given that you have some sequence, you do `.ToRefLinq()` on it, and the rest of API is the same. All API which does not make heap allocations is available.

Example:

```cs
var arr = new [] { 1, 2, 3, 4 };

...

var localVar = 5;
var seq =
    arr
    .ToRefLinq()                // magic method
    .Select(c => c + 5)
    .Where(c => c % 2 == 0)
    .Select((c, localVar) => c - 6.0 / localVar, localVar) // capture-less capture
    .Append(3)                  // alloc-less append
    .Append(5)
    .Prepend(3)
    .Concat(arr.ToRefLinq().Select(c => c / 1d))  // concatenation
    ;
return seq.Sum() + seq.Max();
```

In the example above, no heap allocation happens aside from the one to allocate `arr` in the first line. Though even that may be optimized if you make stack allocation (and use HonkPerf.NET's `FixedReadOnlySpan<T>`), but that's on your side.

## Benchmarks

That's yet another linq library. Why use it? Here's a few benchmarks.


#### Select & Where
```
|              Method |       Mean |    Error |   StdDev |     Median | Code Size |  Gen 0 | Allocated |
|-------------------- |-----------:|---------:|---------:|-----------:|----------:|-------:|----------:|
|     RefLinqCombined |   782.3 ns |  9.78 ns |  9.15 ns |   782.0 ns |   1,246 B |      - |         - |
| ClassicLinqCombined | 1,337.9 ns | 26.57 ns | 72.73 ns | 1,318.1 ns |   2,112 B | 0.0801 |     256 B |
|     NoAlloqCombined | 1,370.4 ns | 27.32 ns | 46.39 ns | 1,364.9 ns |   2,114 B | 0.0267 |      88 B |
|  LinqFasterCombined |   789.3 ns | 15.74 ns | 34.54 ns |   793.1 ns |   1,971 B | 0.4253 |   1,336 B |
|   HyperlinqCombined |   701.8 ns | 13.51 ns | 16.60 ns |   696.8 ns |   1,506 B | 0.0277 |      88 B |
|   ValueLinqCombined |   795.3 ns | 15.84 ns | 37.03 ns |   782.2 ns |   1,364 B | 0.0172 |      56 B |
|      LinqAFCombined |   656.9 ns | 13.01 ns | 23.13 ns |   650.3 ns |   1,807 B | 0.0277 |      88 B |
|  StructLinqCombined |   752.9 ns | 14.93 ns | 18.88 ns |   751.4 ns |     933 B | 0.0582 |     184 B |
```

#### Append & Prepend
```
|         Method |      Mean |    Error |    StdDev |  Gen 0 | Allocated |
|--------------- |----------:|---------:|----------:|-------:|----------:|
|   RefLinqBench |  96.51 ns | 1.968 ns |  3.931 ns |      - |         - |
|      LinqBench | 248.80 ns | 4.945 ns | 11.263 ns | 0.1938 |     608 B |
| HyperLinqBench | 293.72 ns | 6.392 ns | 18.746 ns | 0.2165 |     680 B |
|    LinqAFBench | 253.92 ns | 5.094 ns | 13.509 ns |      - |         - |
```

#### Select, Where, Zip, Sum
```
|         Method |     Mean |     Error |    StdDev |   Median | Code Size |  Gen 0 | Allocated |
|--------------- |---------:|----------:|----------:|---------:|----------:|-------:|----------:|
|     RefLinqSum | 2.017 us | 0.0394 us | 0.0701 us | 2.014 us |   2,714 B |      - |         - |
|     RefLinqAgg | 2.032 us | 0.0405 us | 0.0827 us | 2.007 us |   2,706 B |      - |         - |
| ClassicLinqSum | 2.756 us | 0.0551 us | 0.1607 us | 2.705 us |   3,436 B | 0.1831 |     584 B |
```

#### Select, Where, Append, Prepend, Concat, Sum, Max
```
|              Method |     Mean |     Error |    StdDev | Code Size |  Gen 0 | Allocated |
|-------------------- |---------:|----------:|----------:|----------:|-------:|----------:|
|     RefLinqCombined | 4.193 us | 0.0835 us | 0.2125 us |   2,679 B |      - |         - |
| ClassicLinqCombined | 8.053 us | 0.1582 us | 0.2971 us |   3,173 B | 0.3204 |   1,032 B |
|   HyperlinqCombined | 7.555 us | 0.1397 us | 0.2410 us |   2,491 B | 0.2975 |     944 B |
|   ValueLinqCombined | 5.142 us | 0.1021 us | 0.1967 us |   3,903 B | 0.2823 |     888 B |
|      LinqAFCombined | 5.938 us | 0.1128 us | 0.1299 us |   5,431 B | 0.0381 |     120 B |
```
