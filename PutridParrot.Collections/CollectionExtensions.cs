using System;
using System.Collections.Generic;
using System.Linq;

namespace PutridParrot.Collections
{
    /// <summary>
    /// Extension methods of ICollection
    /// </summary>
    public static class CollectionExtensions
    {
        /// <summary>
        /// A simple AddRange which allows the user to include an item if the Predicate
        /// returns true.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="items"></param>
        /// <param name="function"></param>
        public static void AddRange<T>(this ICollection<T> list, IEnumerable<T> items, Predicate<T> function = null)
        {
            if (list != null)
            {
                if (function == null)
                {
                    foreach (var item in items)
                    {
                        list.Add(item);
                    }
                }
                else
                {
                    foreach (var item in items)
                    {
                        if (function(item))
                        {
                            list.Add(item);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Creates a new list with the distinct items from the supplied list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ICollection<T> Distinct<T>(this ICollection<T> list, Func<T, T, int> comparer)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            if (comparer == null)
                throw new ArgumentNullException(nameof(comparer));

            return list.Distinct(new Comparer<T>(comparer)).ToList();
        }
       

        /// <summary>
        /// Rotate the collection by rotateBy 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="rotateBy"></param>
        /// <returns></returns>
        public static ICollection<T> Rotate<T>(this ICollection<T> list, int rotateBy)
        {
            if (rotateBy <= 0)
            {
                return list;
            }

            if (rotateBy > list.Count)
            {
                rotateBy %= list.Count;
            }

            return list.Take(rotateBy, list.Count - rotateBy)
                .Concat(list.Take(0, rotateBy).ToArray())
                .ToList();
        }
    }
}
