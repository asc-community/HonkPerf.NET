namespace HonkPerf.NET.RefLinq;

static partial class LazyLinqExtensions
{
    public static RefLinqEnumerable<T, Skip<T, TPrevious>> RefSkip<T, TPrevious>(this RefLinqEnumerable<T, TPrevious> prev, int toSkip)
        where TPrevious : IRefEnumerable<T>
        => new(new(prev.enumerator, toSkip));
}