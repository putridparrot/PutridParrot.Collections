using System;
using System.Collections.Generic;
using System.Linq;

namespace PutridParrot.Collections
{
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// For each item within the enumerable invoke the action with the supplied
        /// item and index
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="action"></param>
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T, int> action)
        {
            if(enumerable == null)
                throw new ArgumentNullException(nameof(enumerable));

            if (action == null)
            {
                return;
            }

            var i = 0;
            foreach (var item in enumerable)
            {
                action(item, i++);
            }
        }


        /// <summary>
        /// For each item within the enumerable invoke the action with the supplied
        /// item
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="action"></param>
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            ForEach(enumerable, (item, _) => action(item));
        }

        /// <summary>
        /// Concat enumerables
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="subsequent"></param>
        /// <returns></returns>
        public static IEnumerable<T> Concat<T>(this IEnumerable<T> enumerable, IEnumerable<T> first, IEnumerable<T> second,
            params IEnumerable<T>[] subsequent)
        {
            if (enumerable == null)
                throw new ArgumentNullException(nameof(enumerable));

            foreach (var item in enumerable.Concat(first).Concat(second))
            {
                yield return item;
            }

            foreach (var e in subsequent)
            {
                foreach (var item in e)
                {
                    yield return item;
                }   
            }
        }

        /// <summary>
        /// Enumerate the enumerable N number of times
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="numberOfTimes"></param>
        /// <returns></returns>
        public static IEnumerable<T> Repeat<T>(this IEnumerable<T> enumerable, int numberOfTimes)
        {
            if (enumerable == null)
                throw new ArgumentNullException(nameof(enumerable));
            if(numberOfTimes < 0)
                throw new ArgumentOutOfRangeException(nameof(numberOfTimes));

            for (var i = 0; i < numberOfTimes + 1; i++)
            {
                foreach (var item in enumerable)
                {
                    yield return item;
                }
            }
        }

        /// <summary>
        /// Get the index of the first matching value using a predicate
        /// to match against
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static int IndexOf<T>(this IEnumerable<T> enumerable, Predicate<T> predicate)
        {
            if (enumerable == null)
                throw new ArgumentNullException(nameof(enumerable));

            var found = enumerable.WithIndex().FirstOrDefault(item => predicate(item.Item));
            return !found.Equals(default) ? found.Index : -1;
        }

        /// <summary>
        /// Get the index of the first matching value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int IndexOf<T>(this IEnumerable<T> enumerable, T value)
        {
            return enumerable.IndexOf(item => Equals(item, value));
        }


        /// <summary>
        /// Get the numerable and it's index as named tuples
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static IEnumerable<(T Item, int Index)> WithIndex<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable == null)
                throw new ArgumentNullException(nameof(enumerable));

            return enumerable.Select((item, index) => (item, index));
        }

        /// <summary>
        /// Joins an enumerable as a string using the supplied
        /// separator to join on, null or empty strings are removed
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static string Join<T>(this IEnumerable<T> enumerable, string separator = ", ")
        {
            if (enumerable == null)
                throw new ArgumentNullException(nameof(enumerable));

            return String.Join(separator, enumerable
                .Where(i => i != null)
                .Select(i => i.ToString())
                .Where(i => !String.IsNullOrEmpty(i)));
        }

        /// <summary>
        /// Returns the enumerable if it's non-null, otherwise returns
        /// an empty enumerable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static IEnumerable<T> NullToEmpty<T>(this IEnumerable<T> enumerable)
        {
            return enumerable ?? System.Linq.Enumerable.Empty<T>();
        }

        /// <summary>
        /// Take values from startIndex until count items are taken
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="startIndex"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static IEnumerable<T> Take<T>(this IEnumerable<T> enumerable, int startIndex, int count)
        {
            if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex));

            foreach (var tuple in enumerable.WithIndex())
            {
                if (tuple.Index >= startIndex && tuple.Index < startIndex + count)
                {
                    yield return tuple.Item;
                }
            }
        }

        /// <summary>
        /// Is the enumerable null or empty
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            return enumerable == null || !enumerable.Any();
        }

        /// <summary>
        /// Flattens the enumerables into a single enumerable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<T> Flatten<T>(this IEnumerable<IEnumerable<T>> enumerable)
        {
            if (enumerable == null)
                throw new ArgumentNullException(nameof(enumerable));

            return enumerable.SelectMany(item => item);
        }

        /// <summary>
        /// Makes a single item into an enumerable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <returns></returns>
        public static IEnumerable<T> ToEnumerable<T>(this T item)
        {
            yield return item;
        }
    }
}
