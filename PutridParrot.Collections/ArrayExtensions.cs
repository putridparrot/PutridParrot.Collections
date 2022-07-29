using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PutridParrot.Collections
{
    /// <summary>
    /// Useful extensions to array like structures, T[], T[,]
    /// and IEnumerable&lt;IEnumerable&lt;T&gt;&gt;
    /// </summary>
    public static partial class ArrayExtensions
    {
        /// <summary>
        /// Gets a column by it's index. It's assumed that our 2D array
        /// is in the form [row, column]
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public static IEnumerable<T> GetColumn<T>(this T[,] array, int column)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            var columnCount = array.GetLength(1);
            if (column < 0 || column >= columnCount)
                throw new ArgumentOutOfRangeException(nameof(column));

            for (var row = 0; row < array.GetLength(0); row++)
            {
                yield return array[row, column];
            }
        }

        /// <summary>
        /// Gets a row by it's index. It's assumed that our 2D array
        /// is in the form [row, column]
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        public static IEnumerable<T> GetRow<T>(this T[,] array, int row)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            var rowCount = array.GetLength(0);
            if (row < 0 || row >= rowCount)
                throw new ArgumentOutOfRangeException(nameof(row));

            for (var column = 0; column < array.GetLength(1); column++)
            {
                yield return array[row, column];
            }
        }

        /// <summary>
        /// Gets all rows as an IEnumerable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <returns></returns>
        public static IEnumerable<IEnumerable<T>> GetRows<T>(this T[,] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            for (var row = 0; row < array.Length; row++)
            {
                yield return array.GetRow(row);
            }
        }

        /// <summary>
        /// Flattens a two dimensional array into a single IEnumerable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <returns></returns>
        public static IEnumerable<T> Flatten<T>(this T[,] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            for (var row = 0; row < array.GetLength(0); row++)
            {
                for (var column = 0; column < array.GetLength(1); column++)
                {
                    yield return array[row, column];
                }
            }
        }

        /// <summary>
        /// Is the supplied array null or empty
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty<T>(this T[] array) => array == null || array.Length == 0;
        /// <summary>
        /// Is the supplied 2D array null or empty
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty<T>(this T[,] array) => array == null || array.GetLength(0) == 0 && array.GetLength(1) == 0;

        /// <summary>
        /// Converts an IEnumerable&lt;IEnumerable&lt;T&gt;&gt; into a two dimensional
        /// array of max row size
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static T[,] To2dArray<T>(this IEnumerable<IEnumerable<T>> enumerable)
        {
            if (enumerable == null)
                throw new ArgumentNullException(nameof(enumerable));

            var rows = enumerable.ToArray();
            var rowCount = rows.Length;
            var columnCount = rowCount > 0 ? rows.Max(r => r.Count()) : 0;

            var result = new T[rowCount, columnCount];
            for (var column = 0; column < rowCount; column++)
            {
                var r = rows[column].ToArray();
                for (var row = 0; row < r.Length; row++)
                {
                    result[row, column] = r[column];
                }
            }

            return result;
        }
    }
}
