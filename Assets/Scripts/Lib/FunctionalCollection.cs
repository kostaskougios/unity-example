using System;

namespace Lib
{
    public static class FunctionalCollection
    {
        public static B[] Map<A, B>(this A[] a, Func<A, B> f)
        {
            var ra = new B[a.Length];
            for (var i = 0; i < a.Length; i++)
            {
                ra[i] = f(a[i]);
            }

            return ra;
        }

        public static A[] Flatten<A>(this A[][] a)
        {
            int length = 0;
            foreach (var ai in a) length += ai.Length;
            var ra = new A[length];
            int idx = 0;
            foreach (var ai in a)
            foreach (var aii in ai)
                ra[idx++] = aii;

            return ra;
        }
    }
}