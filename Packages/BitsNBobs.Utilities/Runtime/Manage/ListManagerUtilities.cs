using System.Collections.Generic;

namespace BitsNBobs.Manage
{
    public static class ListManagerUtilities
    {
        public static ListManager<T> ToListManager<T>(this List<T> list)
        {
            ListManager<T> d = new ListManager<T>();
            foreach (var l in list)
            {
                d.Add(l);
            }
            return d;
        }
    }
}