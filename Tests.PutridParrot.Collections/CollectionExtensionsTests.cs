using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PutridParrot.Collections;

namespace Tests.PutridParrot.Collections
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    public class CollectionExtensionsTests
    {
        [Test]
        public void AddRangeToList_ExpectIncreasedSize()
        {
            ICollection<string> list = new List<string>();
            list.AddRange(new[] { "Hello", "World" });

            Assert.That(list.Count, Is.EqualTo(2));
        }

        [Test]
        public void AddRangeToListWithPredicate_ExpectCorrectSize()
        {
            ICollection<string> list = new List<string>();
            list.AddRange(new[] { "Hello", "W" }, s => s.Length == 1);

            Assert.That(list.Count, Is.EqualTo(1));
        }

        [Test]
        public void Distinct_WhenNoDuplicatesExpectUnchanged()
        {
            ICollection<string> list = new List<string>
            {
                "One", "Two"
            };

            var distinctList = list.Distinct((a, b) => String.Compare(a, b, StringComparison.Ordinal));

            Assert.That(distinctList.Count, Is.EqualTo(2));
        }

        [Test]
        public void Distinct_WhenDuplicatesExistExpectChanged()
        {
            ICollection<string> list = new List<string>
            {
                "One", "Two", "Two", "One"
            };

            var distinctList = list.Distinct((a, b) => String.Compare(a, b, StringComparison.Ordinal));

            Assert.That(distinctList.Count, Is.EqualTo(2));
        }

        [Test]
        public void Rotate_WithinRange()
        {
            var list = new List<int> { 0, 1, 2, 5 };
            var rotated = list.Rotate(1);
            Assert.AreEqual(new[] { 1, 2, 5, 0 }, list.Rotate(1));
        }

        [Test]
        public void Rotate_OutsideRange_ExpectModulo()
        {
            ICollection<int> list = new List<int> { 0, 1, 2, 5 };
            Assert.AreEqual(new[] { 5, 0, 1, 2 }, list.Rotate(7));
        }
    }
}
