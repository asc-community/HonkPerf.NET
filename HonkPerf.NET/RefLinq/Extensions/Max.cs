using Silk.NET.Maths;

namespace HonkPerf.NET.RefLinq;

public static partial class ActiveLinqExtensions
{
    private struct MaxDelegate<T> : IValueDelegate<T, T, T> where T : unmanaged
    {
        public T Invoke(T a, T b) => Scalar.Max(a, b);
    }
    public static T Max<T, TEnumerator>(this RefLinqEnumerable<T, TEnumerator> seq)
        where TEnumerator : IRefEnumerable<T>
        where T : unmanaged
        => seq.Aggregate(Scalar<T>.MinValue, new MaxDelegate<T>());
}