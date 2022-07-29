using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using NUnit.Framework;
using PutridParrot.Collections;

namespace Tests.PutridParrot.Collections
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    public class MatrixTests
    {
        private Matrix<int> CreateData()
        {
            var matrix = new Matrix<int>(3, 2)
            {
                [0, 0] = 1,
                [0, 1] = 2,
                [1, 0] = 3,
                [1, 1] = 4,
                [2, 0] = 5,
                [2, 1] = 6
            };
            return matrix;
        }

        [Test]
        public void IsEmpty()
        {
            var matrix = new Matrix<int>();
            Assert.IsTrue(matrix.IsEmpty);
        }

        [Test]
        public void IsNotEmpty()
        {
            var matrix = new Matrix<int>(2, 3);
            Assert.IsFalse(matrix.IsEmpty);
        }

        [Test]
        public void CreateEmptyMatrix()
        {
            var matrix = new Matrix<int>();
            Assert.AreEqual(0, matrix.Rows);
            Assert.AreEqual(0, matrix.Columns);
        }

        [Test]
        public void CreateEmptyMatrixOfZeroSize()
        {
            var matrix = new Matrix<int>(0, 0);
            Assert.IsTrue(matrix.IsEmpty);
            Assert.AreEqual(0, matrix.Rows);
            Assert.AreEqual(0, matrix.Columns);
        }

        [Test]
        public void CreateMatrix()
        {
            var matrix = new Matrix<int>(2, 5);
            Assert.AreEqual(2, matrix.Rows);
            Assert.AreEqual(5, matrix.Columns);
        }

        [Test]
        public void CreateMatrixWithDefaultValue()
        {
            var matrix = new Matrix<int>(2, 5, 666);
            Assert.AreEqual(2, matrix.Rows);
            Assert.AreEqual(5, matrix.Columns);

            for (var i = 0; i < matrix.Rows; i++)
            {
                for (var j = 0; j < matrix.Columns; j++)
                {
                    Assert.AreEqual(666, matrix[i, j]);
                }
            }
        }

        [Test]
        public void CreateMatrixWithDefaultValueFailure()
        {
            var matrix = new Matrix<int>(0, 0, 666);
            Assert.IsTrue(matrix.IsEmpty);
        }

        [Test]
        public void CreateCopyMatrix()
        {
            var matrix = CreateData();

            var copy = new Matrix<int>(matrix);

            Assert.AreEqual(matrix.Rows, copy.Rows);
            Assert.AreEqual(matrix.Columns, copy.Columns);

            for (var i = 0; i < matrix.Rows; i++)
            {
                for (var j = 0; j < matrix.Columns; j++)
                {
                    Assert.AreEqual(matrix[i, j], copy[i, j]);
                }
            }
        }

        [Test]
        public void CreateMatrixFromTwoDimensionalArray()
        {
            var matrix = new int[2, 2];
            matrix[0, 0] = 1;
            matrix[0, 1] = 2;
            matrix[1, 0] = 3;
            matrix[1, 1] = 4;

            var copy = new Matrix<int>(matrix);

            Assert.AreEqual(matrix.GetLength(0), copy.Rows);
            Assert.AreEqual(matrix.GetLength(1), copy.Columns);

            for (var i = 0; i < copy.Rows; i++)
            {
                for (var j = 0; j < copy.Columns; j++)
                {
                    Assert.AreEqual(matrix[i, j], copy[i, j]);
                }
            }
        }

        [Test]
        public void CreateMatrixFromIEnumerableOfIEnumerable()
        {
            var matrix = new List<List<int>>
            {
                new List<int> { 1, 2, 3 },
                new List<int> { 4, 5, 6 }
            };

            var copy = new Matrix<int>(matrix);

            Assert.AreEqual(matrix.Count, copy.Rows);
            Assert.AreEqual(matrix[0].Count, copy.Columns);

            for (var i = 0; i < copy.Rows; i++)
            {
                for (var j = 0; j < copy.Columns; j++)
                {
                    Assert.AreEqual(matrix[i][j], copy[i, j]);
                }
            }
        }

        [Test]
        public void CreateMatrixFromArrayOfArray()
        {
            var matrix = new int[][]
            {
                new []{ 1, 2, 3, 4 },
                new []{ 5, 6, 7, 8 },
                new []{ 9, 10, 11, 12 }
            };

            var copy = new Matrix<int>(matrix);

            Assert.AreEqual(matrix.Length, copy.Rows);
            Assert.AreEqual(matrix[0].Length, copy.Columns);

            for (var i = 0; i < copy.Rows; i++)
            {
                for (var j = 0; j < copy.Columns; j++)
                {
                    Assert.AreEqual(matrix[i][j], copy[i, j]);
                }
            }
        }

        //[
        //RowTest,
        //Row(0, 0, 678),
        //Row(1, 4, 123)
        //]
        //public void SetViaIndexer(int row, int column, int value)
        //{
        //    Matrix<int> matrix = new Matrix<int>(2, 5);
        //    matrix[row, column] = value;
        //    Assert.AreEqual(value, matrix[row, column]);
        //}

        [Test]
        public void Resize()
        {
            var matrix = new Matrix<int>(2, 2);
            matrix.Resize(5, 7);
            Assert.AreEqual(5, matrix.Rows);
            Assert.AreEqual(7, matrix.Columns);
        }

        [Test]
        public void ResizePreserveFalse()
        {
            var matrix = new Matrix<int>(2, 2)
            {
                [0, 1] = 666
            };
            matrix.Resize(4, 5);
            Assert.AreEqual(0, matrix[0, 1]);
        }

        [Test]
        public void ResizePreserveTrue()
        {
            var matrix = new Matrix<int>(2, 2)
            {
                [0, 1] = 666
            };
            matrix.Resize(4, 5, true);
            Assert.AreEqual(666, matrix[0, 1]);
        }

        [Test]
        public void CopyMatrix()
        {
            var matrix = CreateData();

            var copy = new Matrix<int>();
            copy.Copy(matrix);

            Assert.AreEqual(matrix.Rows, copy.Rows);
            Assert.AreEqual(matrix.Columns, copy.Columns);

            for (var i = 0; i < matrix.Rows; i++)
            {
                for (var j = 0; j < matrix.Columns; j++)
                {
                    Assert.AreEqual(matrix[i, j], copy[i, j]);
                }
            }
        }

        [Test]
        public void CloneMatrix()
        {
            var matrix = CreateData();

            var copy = (Matrix<int>)matrix.Clone();

            Assert.AreEqual(matrix.Rows, copy.Rows);
            Assert.AreEqual(matrix.Columns, copy.Columns);

            for (var i = 0; i < matrix.Rows; i++)
            {
                for (var j = 0; j < matrix.Columns; j++)
                {
                    Assert.AreEqual(matrix[i, j], copy[i, j]);
                }
            }
        }

        [Test]
        public void Iterator()
        {
            var matrix = CreateData();

            var expected = 1;
            var count = 0;
            foreach (var value in matrix)
            {
                Assert.AreEqual(expected++, value);
                count++;
            }
            Assert.AreEqual(count, matrix.Rows * matrix.Columns);
        }

        [Test]
        public void ExplicitGenericIterator()
        {
            var matrix = CreateData();

            var expected = 1;
            int count = 0;
            var enumerable = (IEnumerable<int>) matrix;
            var enumerator = enumerable.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Assert.AreEqual(expected++, enumerator.Current);
                count++;
            }
            Assert.AreEqual(count, matrix.Rows * matrix.Columns);
        }

        [Test]
        public void ExplicitIterator()
        {
            var matrix = CreateData();

            var expected = 1;
            var count = 0;
            var enumerable = (IEnumerable) matrix;
            var enumerator = enumerable.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Assert.AreEqual(expected++, (int)enumerator.Current);
                count++;
            }
            Assert.AreEqual(count, matrix.Rows * matrix.Columns);
        }
    }

}
