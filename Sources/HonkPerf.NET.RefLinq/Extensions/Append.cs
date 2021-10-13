namespace HonkPerf.NET.RefLinq;

public static partial class ActiveLinqExtensions
{
    public static RefLinqEnumerable<T, Append<T, TPrevious>> Append<T, TPrevious>(this RefLinqEnumerable<T, TPrevious> prev, T toAppend)
        where TPrevious : IRefEnumerable<T>
        => new(new(prev.enumerator, toAppend));
}