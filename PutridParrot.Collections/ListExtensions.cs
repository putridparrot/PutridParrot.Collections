using System;
using System.Collections.Generic;

namespace PutridParrot.Collections
{
    /// <summary>
    /// Extension methods of IList
    /// </summary>
    public static class ListExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TSearchItem"></typeparam>
        /// <typeparam name="TListItem"></typeparam>
        /// <param name="searchItem"></param>
        /// <param name="listItem"></param>
        /// <returns></returns>
        public delegate int CompareValues<TSearchItem, TListItem>(TSearchItem searchItem, TListItem listItem);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TSearchItem"></typeparam>
        /// <typeparam name="TListItem"></typeparam>
        /// <param name="list"></param>
        /// <param name="searchItem"></param>
        /// <param name="matcher"></param>
        /// <returns></returns>
        public static int BinarySearch<TSearchItem, TListItem>(this IList<TListItem> list, TSearchItem searchItem,
            CompareValues<TSearchItem, TListItem> matcher)
        {
            return BinarySearch(list, 0, list.Count - 1, searchItem, matcher);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TSearchItem"></typeparam>
        /// <typeparam name="TListItem"></typeparam>
        /// <param name="list"></param>
        /// <param name="lowerBound"></param>
        /// <param name="upperBound"></param>
        /// <param name="searchItem"></param>
        /// <param name="matcher"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static int BinarySearch<TSearchItem, TListItem>(this IList<TListItem> list, int lowerBound,
            int upperBound, TSearchItem searchItem, CompareValues<TSearchItem, TListItem> matcher)
        {
            if (lowerBound > upperBound)
                throw new ArgumentOutOfRangeException(nameof(lowerBound),
                    "lowerBound must be less than or equal to upperBound");
            if (upperBound >= list.Count)
                throw new ArgumentOutOfRangeException(nameof(upperBound),
                    "upperBound must be less than the size of the collection");

            var start = lowerBound;
            var end = upperBound;
            while (start <= end)
            {
                var mid = start + (end - start) / 2;

                var match = matcher(searchItem, list[mid]);
                if (match == 0)
                    return mid;

                if (match < 0)
                {
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }
            }

            return -1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TSearchItem"></typeparam>
        /// <typeparam name="TListItem"></typeparam>
        /// <param name="list"></param>
        /// <param name="searchItem"></param>
        /// <param name="matcher"></param>
        /// <returns></returns>
        public static int BinarySearchInsertionPoint<TSearchItem, TListItem>(this IList<TListItem> list,
            TSearchItem searchItem, CompareValues<TSearchItem, TListItem> matcher)
        {
            return BinarySearchInsertionPoint(list, 0, list.Count - 1, searchItem, matcher);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TSearchItem"></typeparam>
        /// <typeparam name="TListItem"></typeparam>
        /// <param name="list"></param>
        /// <param name="lowerBound"></param>
        /// <param name="upperBound"></param>
        /// <param name="searchItem"></param>
        /// <param name="matcher"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static int BinarySearchInsertionPoint<TSearchItem, TListItem>(this IList<TListItem> list, int lowerBound,
            int upperBound, TSearchItem searchItem, CompareValues<TSearchItem, TListItem> matcher)
        {
            if (lowerBound > upperBound)
                throw new ArgumentOutOfRangeException(nameof(lowerBound),
                    "lowerBound must be less than or equal to upperBound");
            if (upperBound >= list.Count)
                throw new ArgumentOutOfRangeException(nameof(upperBound),
                    "upperBound must be less than the size of the collection");

            var highIndex = upperBound;
            var lowIndex = lowerBound;

            while (lowIndex <= highIndex)
            {
                var mid = lowIndex + (highIndex - lowIndex) / 2;
                var test = matcher(searchItem, list[mid]);
                if (test > 0)
                {
                    lowIndex = mid + 1;
                }
                else if (test < 0)
                {
                    highIndex = mid - 1;
                }
                else
                {
                    // found a match, now find first value greater than match
                    for (int i = mid; i < highIndex; i++)
                    {
                        if (matcher(searchItem, list[i]) < 0)
                        {
                            return i;
                        }
                    }

                    // if there's no value larger than return upperbound
                    return upperBound + 1;
                }
            }

            return highIndex < 0 ? 0 : lowIndex;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="item"></param>
        /// <param name="matcher"></param>
        /// <returns></returns>
        public static int BinarySearch<T>(this IList<T> list, T item, Comparison<T> matcher)
        {
            return BinarySearch(list, 0, list.Count - 1, item, matcher);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="lowerBound"></param>
        /// <param name="upperBound"></param>
        /// <param name="item"></param>
        /// <param name="matcher"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static int BinarySearch<T>(this IList<T> list, int lowerBound, int upperBound, T item,
            Comparison<T> matcher)
        {
            if (lowerBound > upperBound)
                throw new ArgumentOutOfRangeException(nameof(lowerBound),
                    "lowerBound must be less than or equal to upperBound");
            if (upperBound >= list.Count)
                throw new ArgumentOutOfRangeException(nameof(upperBound),
                    "upperBound must be less than the size of the collection");

            var start = lowerBound;
            var end = upperBound;
            while (start <= end)
            {
                var mid = start + (end - start) / 2;

                var match = matcher(item, list[mid]);
                if (match == 0)
                {
                    return mid;
                }

                if (match < 0)
                {
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }
            }

            return -1;
        }

        /// <summary>
        /// IndexOf using the supplied Predicate
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static int IndexOf<T>(this IList<T> list, Predicate<T> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            for (var i = 0; i < list.Count; i++)
            {
                if (predicate(list[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// Adds an item to a sorted list. It is expected the list is either sorted 
        /// or as items are added they're put in order
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="item"></param>
        /// <param name="comparison"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void Add<T>(this IList<T> list, T item, Comparison<T> comparison)
        {
            if (comparison == null)
                throw new ArgumentNullException(nameof(comparison));

            for (var i = 0; i < list.Count; i++)
            {
                if (comparison(item, list[i]) < 0)
                {
                    list.Insert(i, item);
                    return;
                }
            }

            list.Add(item);
        }

        /// <summary>
        /// Sort for all list implementations, using a quick sort along with a supplied comparison function
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="comparison"></param>
        public static void Sort<T>(this IList<T> list, Comparison<T> comparison)
        {
            if (comparison == null)
                throw new ArgumentNullException(nameof(comparison));

            if (list != null && list.Count > 0)
            {
                Sort(list, 0, list.Count - 1, comparison);
            }
        }

        // standard quick sort implementation
        private static void Sort<T>(IList<T> list, int left, int right, Comparison<T> comparison)
        {
            var i = left;
            var j = right;
            var x = list[(left + right) / 2];
            while (i <= j)
            {
                while (comparison(list[i], x) < 0)
                {
                    i++;
                }

                while (comparison(x, list[j]) < 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    var tmp = list[i];
                    list[i++] = list[j];
                    list[j--] = tmp;
                }
            }

            if (left < j)
            {
                Sort(list, left, j, comparison);
            }

            if (i < right)
            {
                Sort(list, i, right, comparison);
            }
        }
    }
}
