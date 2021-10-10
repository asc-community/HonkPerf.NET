namespace HonkPerf.NET.RefLinq;

static partial class ActiveLinqExtensions
{
    public static TAccumulate Aggregate<T, TAccumulate, TDelegate, TPrevious>(this RefLinqEnumerable<T, TPrevious> prev, TAccumulate acc, TDelegate agg)
        where TPrevious : IRefEnumerable<T>
        where TDelegate : IValueDelegate<TAccumulate, T, TAccumulate>
    {
        var res = acc;
        foreach (var el in prev)
            res = agg.Invoke(res, el);
        return res;
    }

    public static TAccumulate Aggregate<T, TAccumulate, TPrevious>(this RefLinqEnumerable<T, TPrevious> prev, TAccumulate acc, Func<TAccumulate, T, TAccumulate> agg)
        where TPrevious : IRefEnumerable<T>
        => Aggregate(prev, acc, new PureValueDelegate<TAccumulate, T, TAccumulate>(agg));


    public static TAccumulate Aggregate<T, TAccumulate, TCapture, TPrevious>(this RefLinqEnumerable<T, TPrevious> prev, TAccumulate acc, Func<TAccumulate, T, TCapture, TAccumulate> agg, TCapture capture)
        where TPrevious : IRefEnumerable<T>
        => Aggregate(prev, acc, new CapturingValueDelegate<TAccumulate, T, TCapture, TAccumulate>(agg, capture));




    public static T Aggregate<T, TDelegate, TPrevious>(this RefLinqEnumerable<T, TPrevious> prev, TDelegate agg)
        where TPrevious : IRefEnumerable<T>
        where TDelegate : IValueDelegate<T, T, T>
    {
        if (!prev.enumerator.MoveNext())
            ThrowHelpers.ThrowSequenceContainsNoElements();
        var c = prev.enumerator.Current;

        while (prev.enumerator.MoveNext())
            c = agg.Invoke(c, prev.enumerator.Current);

        return c;
    }

    public static T Aggregate<T, TPrevious>(this RefLinqEnumerable<T, TPrevious> prev, Func<T, T, T> agg)
        where TPrevious : IRefEnumerable<T>
        => Aggregate(prev, new PureValueDelegate<T, T, T>(agg));


    public static T Aggregate<T, TCapture, TPrevious>(this RefLinqEnumerable<T, TPrevious> prev, Func<T, T, TCapture, T> agg, TCapture capture)
        where TPrevious : IRefEnumerable<T>
        => Aggregate(prev, new CapturingValueDelegate<T, T, TCapture, T>(agg, capture));
}