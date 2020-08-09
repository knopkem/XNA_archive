using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassicPacMan
{
    public static class CfExtensions
    {
        // Finds an item matching a predicate in the enumeration, much like List<T>.FindIndex()
        public static int FindIndex<T>(this IEnumerable<T> list, Predicate<T> finder)
        {
            int index = 0;
            foreach (T item in list)
            {
                if (finder(item))
                {
                    return index;
                }

                index++;
            }

            return -1;
        }

        // Finds an item matching a predicate in the enumeration, much like List<T>.Find()
        public static T Find<T>(this IEnumerable<T> list, Predicate<T> finder)
        {
            foreach (T item in list)
            {
                if (finder(item))
                {
                    return item;
                }
            }

            return list.First();
        }

        // Finds all items matching a predicate in the enumeration and removes them, much like List<T>.RemoveAll()
        public static void RemoveAll<T>(this List<T> list, Predicate<T> finder)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (finder(list[i]))
                {
                    list.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}