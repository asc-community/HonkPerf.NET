namespace HonkPerf.NET.RefLinq;

public static class LinqExtensions
{
    public static IReadOnlyListEnumerator<T> It<T>(this IReadOnlyList<T> c)
        => new(c);

    public static Select<T, U, TPrevious> RefSelect<T, U, TPrevious>(this TPrevious prev, Func<T, U> map)
        where TPrevious : IRefEnumerable<T>
        => new(prev, map);

    public static Where<T, TPrevious> RefWhere<T, TPrevious>(this TPrevious prev, Func<T, bool> map)
        where TPrevious : IRefEnumerable<T>
        => new(prev, map);

    public struct RefZippedEnumerator<T1, T2, TList1, TList2>
        where TList1 : IReadOnlyList<T1>
        where TList2 : IReadOnlyList<T2>
    {
        private readonly TList1 list1;
        private readonly TList2 list2;
        private readonly int list1Length;
        private readonly int list2Length;
        private int curr;

        public RefZippedEnumerator(TList1 list1, TList2 list2)
        {
            this.list1 = list1;
            this.list2 = list2;
            list1Length = list1.Count;
            list2Length = list2.Count;
            curr = -1;
        }

        public (T1, T2) Current
            => (list1[curr], list2[curr]);

        public bool MoveNext()
        {
            curr++;
            if (curr == list1Length && curr == list2Length)
                return false;
            if (curr < list1Length && curr < list2Length)
                return true;
            throw new InvalidOperationException("Collections should have the same size");
        }

        public RefZippedEnumerator<T1, T2, TList1, TList2> GetEnumerator() => this;
    }

    public static RefZippedEnumerator<T1, T2, TList1, TList2> RefZip<T1, T2, TList1, TList2>(this TList1 seq1, TList2 seq2)
        where TList1 : IReadOnlyList<T1>
        where TList2 : IReadOnlyList<T2>
        => new(seq1, seq2);
}
