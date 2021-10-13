namespace HonkPerf.NET.RefLinq;

public static partial class ActiveLinqExtensions
{
    public static RefLinqEnumerable<T, Prepend<T, TPrevious>> Prepend<T, TPrevious>(this RefLinqEnumerable<T, TPrevious> prev, T toPrepend)
        where TPrevious : IRefEnumerable<T>
        => new(new(prev.enumerator, toPrepend));
}