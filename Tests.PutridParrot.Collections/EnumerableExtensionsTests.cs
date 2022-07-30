using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NUnit.Framework;
using PutridParrot.Collections;

namespace Tests.PutridParrot.Collections
{
    [ExcludeFromCodeCoverage]
    [TestFixture]

    internal class EnumerableExtensionsTests
    {
        [Test]
        public void ForEach_ExpectEachElementToBeSentToAction()
        {
            var enumerable = new int[] { 1, 2, 4, 8 };
            var total = 0;
            enumerable.ForEach(item => total += item);

            Assert.AreEqual(15, total);
        }

        [Test]
        public void ForEach_WithIndex_ExpectEachElementToBeSentToAction()
        {
            var actual = new List<int>();
            var enumerable = new int[] { 1, 2, 4, 8 };
            var total = 0;
            enumerable.ForEach((item, index) =>
            {
                total += item;
                actual.Add(index);
            });

            Assert.AreEqual(15, total);
            Assert.AreEqual(new List<int> { 0, 1, 2, 3}, actual);
        }

        [Test]
        public void NullToEmpty_NullEnumerable_ShouldReturnEmptyEnumerable()
        {
            IEnumerable<int> enumerable = null;
            Assert.NotNull(enumerable.NullToEmpty());
        }

        [Test]
        public void Concat_MoreThanTwoEnumerables()
        {
            var a = new List<int> { 1, 2 };
            var b = new List<int> { 3, 4 };
            var c = new List<int> { 5, 6 };
            var d = new List<int> { 7, 8 };

            Assert.AreEqual(new[] { 1, 2, 3, 4, 5, 6, 7, 8}, a.Concat(b, c, d));
        }

        [Test]
        public void Repeat_ZeroTimesExpectEmptyEnumerable()
        {
            var a = new List<int> { 1, 2 }.Repeat(0);
            Assert.AreEqual(Array.Empty<int>(), a);
        }

        [Test]
        public void Repeat_OneTimeExpectSameAsInput()
        {
            var a = new List<int> { 1, 2 }.Repeat(1);
            Assert.AreEqual(new[] { 1, 2 }, a);
        }

        [Test]
        public void Repeat_TwoTimesExpectSameAsInput()
        {
            var a = new List<int> { 1, 2 }.Repeat(2);
            Assert.AreEqual(new[] { 1, 2, 1, 2 }, a);
        }

        [Test]
        public void Repeat_MultipleTimesExpectSameAsInput()
        {
            var a = new List<int> { 1, 2 }.Repeat(3);
            Assert.AreEqual(new[] { 1, 2, 1, 2, 1, 2 }, a);
        }

        [Test]
        public void IndexOf_MissingValue_ExpectMinusOne()
        {
            IEnumerable<int> list = new [] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Assert.AreEqual(-1, list.IndexOf(i => i == 0));
        }

        [Test]
        public void IndexOf_ValidValue_ExpectCorrectIndex()
        {
            IEnumerable<int> list = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Assert.AreEqual(3, list.IndexOf(i => i == 4));
        }

        [Test]
        public void Join_WithCommaSpaceSeparator()
        {
            IEnumerable<int> list = new[] { 1, 2, 3 };
            Assert.AreEqual("1, 2, 3",list.Join());
        }

        [Test]
        public void Join_WithSuppliedSeparator()
        {
            IEnumerable<int> list = new[] { 1, 2, 3 };
            Assert.AreEqual("1|2|3", list.Join("|"));
        }

        [Test]
        public void Take_ValidIndexWithinLength()
        {
            IEnumerable<int> list = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Assert.AreEqual(new[] { 4, 5, 6, 7 }, list.Take(3, 4));
        }

        [Test]
        public void Take_ValidIndexInvalidLength()
        {
            IEnumerable<int> list = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Assert.AreEqual(new[] { 8, 9 }, list.Take(7, 4));
        }

        [Test]
        public void Take_InvalidIndexInvalidLength()
        {
            IEnumerable<int> list = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Assert.Throws<ArgumentOutOfRangeException>(() => list.Take(-1, 4).ToArray());
        }

        [Test]
        public void ToEnumerable()
        {
            var e = 123.ToEnumerable();
            Assert.AreEqual(new [] { 123 }, e.ToArray());
        }
    }
}
