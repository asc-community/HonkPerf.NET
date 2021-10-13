using Silk.NET.Maths;

namespace HonkPerf.NET.RefLinq;

public static partial class ActiveLinqExtensions
{
    public static T Average<T, TEnumerator>(this RefLinqEnumerable<T, TEnumerator> seq)
        where TEnumerator : IRefEnumerable<T>
        where T : unmanaged
    {
        var sum = Scalar<T>.Zero;
        var count = 0;
        foreach (var el in seq)
        {
            sum = Scalar.Add(sum, el);
            count++;
        }
        return Scalar.Divide(sum, Scalar.As<int, T>(count));
    }
}