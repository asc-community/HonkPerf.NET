namespace HonkPerf.NET.Core;

public interface IValueDelegate<TIn, TOut>
{
    public TOut Invoke(TIn arg);
}

public interface IValueDelegate<TIn1, TIn2, TOut>
{
    public TOut Invoke(TIn1 arg1, TIn2 arg2);
}

