// Copyright (c) Angouri 2021.
// This file from HonkPerf.NET project is MIT-licensed.
// Read more: https://github.com/asc-community/HonkPerf.NET

namespace HonkPerf.NET.Core;

public struct PureValueAction<TIn> : IValueAction<TIn>
{
    private readonly Action<TIn> deleg;

    public PureValueAction(Action<TIn> func)
        => deleg = func;

    public void Invoke(TIn arg) => deleg(arg);
}

public struct PureValueDelegate<TIn, TOut> : IValueDelegate<TIn, TOut>
{
    private readonly Func<TIn, TOut> deleg;

    public PureValueDelegate(Func<TIn, TOut> func)
        => deleg = func;

    public TOut Invoke(TIn arg) => deleg(arg);
}

public struct PureValueAction<TIn1, TIn2> : IValueAction<TIn1, TIn2>
{
    private readonly Action<TIn1, TIn2> deleg;

    public PureValueAction(Action<TIn1, TIn2> func)
        => deleg = func;

    public void Invoke(TIn1 arg1, TIn2 arg2) => deleg(arg1, arg2);
}

public struct PureValueDelegate<TIn1, TIn2, TOut> : IValueDelegate<TIn1, TIn2, TOut>
{
    private readonly Func<TIn1, TIn2, TOut> deleg;

    public PureValueDelegate(Func<TIn1, TIn2, TOut> func)
        => deleg = func;

    public TOut Invoke(TIn1 arg1, TIn2 arg2) => deleg(arg1, arg2);
}

public struct PureValueAction<TIn1, TIn2, TIn3> : IValueAction<TIn1, TIn2, TIn3>
{
    private readonly Action<TIn1, TIn2, TIn3> deleg;

    public PureValueAction(Action<TIn1, TIn2, TIn3> func)
        => deleg = func;

    public void Invoke(TIn1 arg1, TIn2 arg2, TIn3 arg3) => deleg(arg1, arg2, arg3);
}

public struct PureValueDelegate<TIn1, TIn2, TIn3, TOut> : IValueDelegate<TIn1, TIn2, TIn3, TOut>
{
    private readonly Func<TIn1, TIn2, TIn3, TOut> deleg;

    public PureValueDelegate(Func<TIn1, TIn2, TIn3, TOut> func)
        => deleg = func;

    public TOut Invoke(TIn1 arg1, TIn2 arg2, TIn3 arg3) => deleg(arg1, arg2, arg3);
}

public struct PureValueAction<TIn1, TIn2, TIn3, TIn4> : IValueAction<TIn1, TIn2, TIn3, TIn4>
{
    private readonly Action<TIn1, TIn2, TIn3, TIn4> deleg;

    public PureValueAction(Action<TIn1, TIn2, TIn3, TIn4> func)
        => deleg = func;

    public void Invoke(TIn1 arg1, TIn2 arg2, TIn3 arg3, TIn4 arg4) => deleg(arg1, arg2, arg3, arg4);
}

public struct PureValueDelegate<TIn1, TIn2, TIn3, TIn4, TOut> : IValueDelegate<TIn1, TIn2, TIn3, TIn4, TOut>
{
    private readonly Func<TIn1, TIn2, TIn3, TIn4, TOut> deleg;

    public PureValueDelegate(Func<TIn1, TIn2, TIn3, TIn4, TOut> func)
        => deleg = func;

    public TOut Invoke(TIn1 arg1, TIn2 arg2, TIn3 arg3, TIn4 arg4) => deleg(arg1, arg2, arg3, arg4);
}

public struct PureValueAction<TIn1, TIn2, TIn3, TIn4, TIn5> : IValueAction<TIn1, TIn2, TIn3, TIn4, TIn5>
{
    private readonly Action<TIn1, TIn2, TIn3, TIn4, TIn5> deleg;

    public PureValueAction(Action<TIn1, TIn2, TIn3, TIn4, TIn5> func)
        => deleg = func;

    public void Invoke(TIn1 arg1, TIn2 arg2, TIn3 arg3, TIn4 arg4, TIn5 arg5) => deleg(arg1, arg2, arg3, arg4, arg5);
}

public struct PureValueDelegate<TIn1, TIn2, TIn3, TIn4, TIn5, TOut> : IValueDelegate<TIn1, TIn2, TIn3, TIn4, TIn5, TOut>
{
    private readonly Func<TIn1, TIn2, TIn3, TIn4, TIn5, TOut> deleg;

    public PureValueDelegate(Func<TIn1, TIn2, TIn3, TIn4, TIn5, TOut> func)
        => deleg = func;

    public TOut Invoke(TIn1 arg1, TIn2 arg2, TIn3 arg3, TIn4 arg4, TIn5 arg5) => deleg(arg1, arg2, arg3, arg4, arg5);
}
