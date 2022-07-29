using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NUnit.Framework;
using PutridParrot.Collections;

namespace Tests.PutridParrot.Collections
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    public class ArrayExtensionsTests
    {
        [Test]
        public void IsNullOrEmpty_WhenArrayIsNull()
        {
            int[] array = null;
            Assert.IsTrue(array.IsNullOrEmpty());
        }

        [Test]
        public void IsNullOrEmpty_WhenArrayIsEmpty()
        {
            var array = Array.Empty<int>();
            Assert.IsTrue(array.IsNullOrEmpty());
        }

        [Test]
        public void GetRow_WhenNoRowsExist()
        {
            var array = new int[0, 0];
            Assert.Throws<ArgumentOutOfRangeException>(() => array.GetRow(1).ToArray());
        }

        [Test]
        public void GetRow_WhenNoRowsRequestedDoesNotExist()
        {
            var array = new [,]
            {
                {1, 2},
                {3, 4}
            };
            Assert.Throws<ArgumentOutOfRangeException>(() => array.GetRow(-1).ToArray());
        }

        [Test]
        public void GetRow_WithCorrectIndex()
        {
            var array = new[,]
            {
                {1, 2},
                {3, 4}
            };
            Assert.AreEqual(new[]{ 3, 4 }, array.GetRow(1));
        }

    }
}
