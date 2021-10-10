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
}