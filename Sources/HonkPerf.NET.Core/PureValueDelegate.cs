namespace HonkPerf.NET.Core;

public struct PureValueDelegate<TIn, TOut> : IValueDelegate<TIn, TOut>
{
    private readonly Func<TIn, TOut> deleg;

    public PureValueDelegate(Func<TIn, TOut> func)
        => deleg = func;

    public TOut Invoke(TIn arg) => deleg(arg);
}

public struct PureValueDelegate<TIn1, TIn2, TOut> : IValueDelegate<TIn1, TIn2, TOut>
{
    private readonly Func<TIn1, TIn2, TOut> deleg;

    public PureValueDelegate(Func<TIn1, TIn2, TOut> func)
        => deleg = func;

    public TOut Invoke(TIn1 arg1, TIn2 arg2) => deleg(arg1, arg2);
}