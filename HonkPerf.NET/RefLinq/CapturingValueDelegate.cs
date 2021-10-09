namespace HonkPerf.NET.RefLinq;

public interface IValueDelegate<TIn, TOut>
{
    public TOut Invoke(TIn arg);
}

public struct PureValueDelegate<TIn, TOut> : IValueDelegate<TIn, TOut>
{
    private readonly Func<TIn, TOut> deleg;

    public PureValueDelegate(Func<TIn, TOut> func)
        => deleg = func;

    public TOut Invoke(TIn arg) => deleg(arg);
}

public struct CapturingValueDelegate<TIn, TCapture, TOut> : IValueDelegate<TIn, TOut>
{
    private readonly TCapture capture;
    private readonly Func<TIn, TCapture, TOut> deleg;

    public CapturingValueDelegate(Func<TIn, TCapture, TOut> func, TCapture capture)
    {
        deleg = func;
        this.capture = capture;
    }

    public TOut Invoke(TIn arg)
        => deleg(arg, capture);
}

public struct NoCapture { }