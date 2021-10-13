using Silk.NET.Maths;

namespace HonkPerf.NET.RefLinq;

public static partial class ActiveLinqExtensions
{
    private struct MultiplyDelegate<T> : IValueDelegate<T, T, T> where T : unmanaged
    {
        public T Invoke(T a, T b) => Scalar.Multiply(a, b);
    }
    public static T Multiply<T, TEnumerator>(this RefLinqEnumerable<T, TEnumerator> seq)
        where TEnumerator : IRefEnumerable<T>
        where T : unmanaged
        => seq.Aggregate(Scalar<T>.One, new MultiplyDelegate<T>());
}