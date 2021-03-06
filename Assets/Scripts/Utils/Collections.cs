using System;
using System.Collections.Generic;
using System.Linq;

namespace Utils
{
    public static class Collections
    {
        public static List<T> Flatten<T>(this IReadOnlyCollection<IReadOnlyCollection<T>> l)
        {
            return l.SelectMany(x => x).ToList();
        }

        public static List<R> Map<T,R>(this IReadOnlyCollection<T> l, Func<T, R> f)
        {
            var r = new List<R>();
            foreach (var a in l)
            {
                r.Add(f(a));
            }
            return r;
        }

        public static T Find<T>(this IReadOnlyCollection<T> l, Func<T, bool> f)
        {
            foreach (var a in l)
            {
                if (f(a)) return a;
            }

            return default(T);
        }
    }
}