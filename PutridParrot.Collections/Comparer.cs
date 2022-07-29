using System;
using System.Collections;
using System.Collections.Generic;

namespace PutridParrot.Collections
{
    public class Comparer<T> : IComparer<T>, IEqualityComparer<T>, IComparer
    {
        private readonly Func<T, T, int> _objectComparer;
        private readonly Func<T, int> _objectHash;

        public Comparer(Func<T, T, int> objectComparer) :
            this(objectComparer, o => o.GetHashCode())
        {
        }

        public Comparer(Func<T, T, int> objectComparer, Func<T, int> objectHash)
        {
            _objectComparer = objectComparer ?? throw new ArgumentNullException(nameof(objectComparer));
            _objectHash = objectHash ?? throw new ArgumentNullException(nameof(objectHash)); ;
        }

        public int Compare(T x, T y)
        {
            return _objectComparer(x, y);
        }

        public bool Equals(T x, T y)
        {
            return Compare(x, y) == 0;
        }

        public int GetHashCode(T obj)
        {
            return _objectHash(obj);
        }

        #region IComparer Members

        public int Compare(object x, object y)
        {
            return Compare((T)x, (T)y);
        }

        #endregion
    }

}
