namespace HonkPerf.NET.Core;

public interface IValueDelegate<TIn, TOut>
{
    public TOut Invoke(TIn arg);
}

public interface IValueDelegate<TIn1, TIn2, TOut>
{
    public TOut Invoke(TIn1 arg1, TIn2 arg2);
}

public interface IValueDelegate<TIn1, TIn2, TIn3, TOut>
{
    public TOut Invoke(TIn1 arg1, TIn2 arg2, TIn3 arg3);
}

public interface IValueDelegate<TIn1, TIn2, TIn3, TIn4, TOut>
{
    public TOut Invoke(TIn1 arg1, TIn2 arg2, TIn3 arg3, TIn4 arg4);
}

public interface IValueDelegate<TIn1, TIn2, TIn3, TIn4, TIn5, TOut>
{
    public TOut Invoke(TIn1 arg1, TIn2 arg2, TIn3 arg3, TIn4 arg4, TIn5 arg5);
}