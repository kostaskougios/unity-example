using System.Collections.Generic;
using System.Linq;

namespace Utils
{
    public static class Collections
    {
        public static List<T> Flatten<T>(this List<List<T>> l)
        {
            return l.SelectMany(x => x).ToList();
        }
    }
}