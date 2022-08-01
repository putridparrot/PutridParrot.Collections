using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PutridParrot.Collections
{
    /// <summary>
    /// A two-dimensional (non-jagged) collection class in the same vein as a T[,]
    /// </summary>
    /// <typeparam name="T">The type to be stored within the collection</typeparam>
    public class Matrix<T> : ICloneable, IEnumerable<T>
    {
        private T[,] _matrix;

        /// <summary>
        /// Creates a default empty matrix.
        /// </summary>
        public Matrix()
        {
        }
        /// <summary>
        /// Creates a matrix of a given size
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        public Matrix(int rows, int columns)
        {
            _matrix = Create(rows, columns);
        }
        /// <summary>
        /// Creates a matrix of given size with the supplied default value in each position
        /// </summary>
        /// <param name="rows">The number of rows in the matrix</param>
        /// <param name="columns">The number of columns in the matrix</param>
        /// <param name="defaultValue">The default value of type T to set the data to</param>
        public Matrix(int rows, int columns, T defaultValue)
        {
            _matrix = Create(rows, columns, defaultValue);
        }
        /// <summary>
        /// Creates a matrix from the supplied two dimensional array
        /// </summary>
        /// <param name="matrix">The two dimensional array to be copied</param>
        public Matrix(T[][] matrix)
        {
            Copy(matrix);
        }
        /// <summary>
        /// Creates a matrix from the supplied two dimensional array
        /// </summary>
        /// <param name="matrix">The two dimensional array to be copied</param>
        public Matrix(T[,] matrix)
        {
            Copy(matrix);
        }

        /// <summary>
        /// Creates a matrix from the supplied enumerable of enumerable
        /// </summary>
        /// <param name="matrix">The enumerable of enumerable to represent the matrix</param>
        public Matrix(IEnumerable<IEnumerable<T>> matrix)
        {
            Copy(matrix);
        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="matrix">The matrix to be copied</param>
        public Matrix(Matrix<T> matrix)
        {
            Copy(matrix);
        }
        /// <summary>
        /// Gets the number of rows within the matrix
        /// </summary>
        public int Rows => _matrix?.GetLength(0) ?? 0;

        /// <summary>
        /// Gets the number of columns within the matrix
        /// </summary>
        public int Columns => _matrix?.GetLength(1) ?? 0;

        /// <summary>
        /// Indexer used to get/set a value at a given row/column.
        /// </summary>
        /// <param name="row">The row to get the data from</param>
        /// <param name="column">The column to get the data from</param>
        /// <returns>The data at the given row/column</returns>
        public T this[int row, int column]
        {
            get => _matrix[row, column];
            set => _matrix[row, column] = value;
        }

        /// <summary>
        /// Redimensions the matrix to the given number of rows and columns and can 
        /// either preserve the current data or create an empty matrix depending upon
        /// the preserve flag.
        /// </summary>
        /// <param name="rows">The number of rows to resize to.</param>
        /// <param name="columns">The number of columns to resize to.</param>
        /// <param name="preserve">True to preserve the current data, False to create an empty matrix.</param>
        public void Resize(int rows, int columns, bool preserve = false)
        {
            if (!preserve)
            {
                _matrix = Create(rows, columns);
            }
            else
            {
                var tmp = Create(rows, columns);
                var minRows = Math.Min(Rows, rows);
                var minColumns = Math.Min(Columns, columns);
                for (var i = 0; i < minRows; i++)
                {
                    for (var j = 0; j < minColumns; j++)
                    {
                        tmp[i, j] = _matrix[i, j];
                    }
                }
                _matrix = tmp;
            }
        }
        /// <summary>
        /// Gets whether the matrix is empty or not.
        /// </summary>
        public bool IsEmpty => _matrix.IsNullOrEmpty();

        /// <summary>
        /// Creates a clone of the current matrix. This is the same as copy but
        /// adheres to the ICloneable pattern.
        /// </summary>
        /// <returns>A clone/copy of this matrix is returned. This is a shallow copy.</returns>
        public object Clone()
        {
            return new Matrix<T>(this);
        }

        /// <summary>
        /// Creates a copy of the supplied matrix
        /// </summary>
        /// <param name="data">The matrix to be copied</param>
		public void Copy(Matrix<T> data)
        {
            Copy(data._matrix);
        }
        /// <summary>
        /// Creates a copy of the supplied two dimensional array
        /// </summary>
        /// <param name="data">The two dimensional array to be copied</param>
        public void Copy(T[,] data)
        {
            _matrix = Create(data.GetLength(0), data.GetLength(1));
            for (var i = 0; i < Rows; i++)
            {
                for (var j = 0; j < Columns; j++)
                {
                    _matrix[i, j] = data[i, j];
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public void Copy(T[][] data)
        {
            var rowCount = data.Length;
            var columnCount = rowCount > 0 ? data.Max(e => e.Length) : 0;
            _matrix = Create(rowCount, columnCount);
            for (var i = 0; i < rowCount; i++)
            {
                var row = data[i];
                for (var j = 0; j < row.Length; j++)
                {
                    _matrix[i, j] = row[j];
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public void Copy(IEnumerable<IEnumerable<T>> data)
        {
            var rows = data.ToArray();
            var rowCount = rows.Length;
            var columnCount = rowCount > 0 ? rows.Max(e => e.Count()) : 0;
            _matrix = Create(rowCount, columnCount);
            for (var i = 0; i < rowCount; i++)
            {
                var row = rows[i].ToArray();
                for (var j = 0; j < row.Length; j++)
                {
                    _matrix[i, j] = row[j];
                }
            }
        }

        #region Private methods
        private static T[,] Create(int rows, int columns)
        {
            return rows > 0 && columns > 0 ? new T[rows, columns] : null;
        }
        private static T[,] Create(int rows, int columns, T defaultValue)
        {
            if (rows == 0 || columns == 0)
                return null;

            return Create(rows, columns).Fill(defaultValue);
        }
        #endregion

        /// <summary>
        /// Iterates over all data by row and column. In essence turns a two dimensional
        /// array into a one dimensional iteration by row and column.
        /// </summary>
        /// <returns>An IEnumerator&lt;T&gt;</returns>
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            for (var i = 0; i < Rows; i++)
            {
                for (var j = 0; j < Columns; j++)
                {
                    yield return this[i, j];
                }
            }
        }

        /// <summary>
        /// Iterates over all data by row and column. In essence turns a two dimensional
        /// array into a one dimensional iteration by row and column.
        /// </summary>
        /// <returns>An IEnumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }

        /// <summary>
        /// Transpose rows to columns and columns to rows
        /// </summary>
        public void Transpose()
        {
            _matrix = _matrix.Transpose();
        }
    }
}
