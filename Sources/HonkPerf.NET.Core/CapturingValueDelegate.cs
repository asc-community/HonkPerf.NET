// Copyright (c) Angouri 2021.
// This file from HonkPerf.NET project is MIT-licensed.
// Read more: https://github.com/asc-community/HonkPerf.NET

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

public struct CapturingValueDelegate<TIn1, TIn2, TIn3, TCapture, TOut> : IValueDelegate<TIn1, TIn2, TIn3, TOut>
{
    private readonly TCapture capture;
    private readonly Func<TIn1, TIn2, TIn3, TCapture, TOut> deleg;

    public CapturingValueDelegate(Func<TIn1, TIn2, TIn3, TCapture, TOut> func, TCapture capture)
    {
        deleg = func;
        this.capture = capture;
    }

    public TOut Invoke(TIn1 arg1, TIn2 arg2, TIn3 arg3)
        => deleg(arg1, arg2, arg3, capture);
}

public struct CapturingValueDelegate<TIn1, TIn2, TIn3, TIn4, TCapture, TOut> : IValueDelegate<TIn1, TIn2, TIn3, TIn4, TOut>
{
    private readonly TCapture capture;
    private readonly Func<TIn1, TIn2, TIn3, TIn4, TCapture, TOut> deleg;

    public CapturingValueDelegate(Func<TIn1, TIn2, TIn3, TIn4, TCapture, TOut> func, TCapture capture)
    {
        deleg = func;
        this.capture = capture;
    }

    public TOut Invoke(TIn1 arg1, TIn2 arg2, TIn3 arg3, TIn4 arg4)
        => deleg(arg1, arg2, arg3, arg4, capture);
}

public struct CapturingValueDelegate<TIn1, TIn2, TIn3, TIn4, TIn5, TCapture, TOut> : IValueDelegate<TIn1, TIn2, TIn3, TIn4, TIn5, TOut>
{
    private readonly TCapture capture;
    private readonly Func<TIn1, TIn2, TIn3, TIn4, TIn5, TCapture, TOut> deleg;

    public CapturingValueDelegate(Func<TIn1, TIn2, TIn3, TIn4, TIn5, TCapture, TOut> func, TCapture capture)
    {
        deleg = func;
        this.capture = capture;
    }

    public TOut Invoke(TIn1 arg1, TIn2 arg2, TIn3 arg3, TIn4 arg4, TIn5 arg5)
        => deleg(arg1, arg2, arg3, arg4, arg5, capture);
}