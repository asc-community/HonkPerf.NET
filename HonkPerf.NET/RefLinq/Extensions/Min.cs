using Silk.NET.Maths;

namespace HonkPerf.NET.RefLinq;

public static partial class ActiveLinqExtensions
{
    private struct MinDelegate<T> : IValueDelegate<T, T, T> where T : unmanaged
    {
        public T Invoke(T a, T b) => Scalar.Min(a, b);
    }
    public static T Min<T, TEnumerator>(this RefLinqEnumerable<T, TEnumerator> seq)
        where TEnumerator : IRefEnumerable<T>
        where T : unmanaged
        => seq.Aggregate(new MinDelegate<T>());
}