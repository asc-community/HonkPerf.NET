namespace HonkPerf.NET.RefLinq;

internal static class ThrowHelpers
{
    internal static void ThrowSequenceContainsNoElements()
    {
        throw new InvalidOperationException("Sequence contains no elements");
    }
}