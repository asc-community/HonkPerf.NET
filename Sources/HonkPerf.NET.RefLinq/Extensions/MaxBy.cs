using Silk.NET.Maths;

namespace HonkPerf.NET.RefLinq;

public static partial class ActiveLinqExtensions
{
    private struct MaxByDelegate<T, TBy, TDelegate>
        : IValueDelegate<T, T, T>
        where TBy : unmanaged
        where TDelegate : IValueDelegate<T, TBy>
    {
        private TDelegate func;
        public MaxByDelegate(TDelegate func)
        {
            this.func = func;
        }
        public T Invoke(T a, T b)
            => Scalar.GreaterThan(func.Invoke(b), func.Invoke(a)) ? b : a;
    }

    public static T MaxBy<T, TBy, TDelegate, TEnumerator>(this RefLinqEnumerable<T, TEnumerator> seq, TDelegate func)
        where TEnumerator : IRefEnumerable<T>
        where TBy : unmanaged
        where TDelegate : IValueDelegate<T, TBy>
        => seq.Aggregate(new MaxByDelegate<T, TBy, TDelegate>(func));

    public static T MaxBy<T, TBy, TEnumerator>(this RefLinqEnumerable<T, TEnumerator> seq, Func<T, TBy> func)
        where TEnumerator : IRefEnumerable<T>
        where TBy : unmanaged
        => seq.Aggregate(new MaxByDelegate<T, TBy, PureValueDelegate<T, TBy>>(new(func)));

    public static T MaxBy<T, TBy, TCapture, TEnumerator>(this RefLinqEnumerable<T, TEnumerator> seq, Func<T, TCapture, TBy> func, TCapture capture)
        where TEnumerator : IRefEnumerable<T>
        where TBy : unmanaged
        => seq.Aggregate(new MaxByDelegate<T, TBy, CapturingValueDelegate<T, TCapture, TBy>>(new(func, capture)));
}