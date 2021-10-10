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
}