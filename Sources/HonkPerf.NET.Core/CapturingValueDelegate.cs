namespace HonkPerf.NET.Core;

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

public struct CapturingValueDelegate<TIn1, TIn2, TCapture, TOut> : IValueDelegate<TIn1, TIn2, TOut>
{
    private readonly TCapture capture;
    private readonly Func<TIn1, TIn2, TCapture, TOut> deleg;

    public CapturingValueDelegate(Func<TIn1, TIn2, TCapture, TOut> func, TCapture capture)
    {
        deleg = func;
        this.capture = capture;
    }

    public TOut Invoke(TIn1 arg1, TIn2 arg2)
        => deleg(arg1, arg2, capture);
}