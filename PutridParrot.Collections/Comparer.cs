using System;
using System.Collections;
using System.Collections.Generic;

namespace PutridParrot.Collections
{
    /// <summary>
    /// The Comparer class allows us to create code that conforms
    /// to IComparer and IEqualityComparer using a Func
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Comparer<T> : IComparer<T>, IEqualityComparer<T>, IComparer
    {
        private readonly Func<T, T, int> _objectComparer;
        private readonly Func<T, int> _objectHash;

        /// <summary>
        /// Create a Comparer from a comparison Func, generating the hashcode function
        /// itself
        /// </summary>
        /// <param name="objectComparer">The compare function</param>
        public Comparer(Func<T, T, int> objectComparer) :
            this(objectComparer, o => o.GetHashCode())
        {
        }

        /// <summary>
        /// Creates a Comparer from a comparision Func as well as a hashcode
        /// generation Func
        /// </summary>
        /// <param name="objectComparer">The compare function</param>
        /// <param name="objectHash">The hash code generator function</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Comparer(Func<T, T, int> objectComparer, Func<T, int> objectHash)
        {
            _objectComparer = objectComparer ?? throw new ArgumentNullException(nameof(objectComparer));
            _objectHash = objectHash ?? throw new ArgumentNullException(nameof(objectHash)); ;
        }

        /// <summary>
        /// Compares two types of T for equality, returning &lt; 0 if the first item
        /// comes before the second, 0 if they're the same and &gt; 0 if the first item
        /// comes after the second
        /// </summary>
        /// <param name="first">The first item  to compare against</param>
        /// <param name="second">The second item to compare against</param>
        /// <returns>Less than zero if the first parameter comes before second. Zero if they match. Otherwise
        /// greater than zero when the first parameter comes after the second</returns>
        public int Compare(T first, T second)
        {
            return _objectComparer(first, second);
        }

        /// <summary>
        /// Checks if the two items are Equal
        /// </summary>
        /// <param name="first">The first item  to compare against</param>
        /// <param name="second">The second item  to compare against</param>
        /// <returns>True if they equate to the same item else False</returns>
        public bool Equals(T first, T second)
        {
            return Compare(first, second) == 0;
        }

        /// <summary>
        /// Gets the hashcode for the supplied item using the default or
        /// supplied hashcode generation function
        /// </summary>
        /// <param name="obj">The object to get a hashcode for</param>
        /// <returns>The hashcode created by the supplied function (or by the default function)</returns>
        public int GetHashCode(T obj)
        {
            return _objectHash(obj);
        }

        /// <summary>
        /// Compares two types of object for equality, returning &lt; 0 if the first item
        /// comes before the second, 0 if they're the same and &gt; 0 if the first item
        /// comes after the second. This expects assumes both items can be cast to T
        /// </summary>
        /// <param name="first">The first item  to compare against</param>
        /// <param name="second">The second item  to compare against</param>
        /// <returns>Less than zero if the first parameter comes before second. Zero if they match. Otherwise
        /// greater than zero when the first parameter comes after the second</returns>
        public int Compare(object first, object second)
        {
            return Compare((T)first, (T)second);
        }
    }
}
