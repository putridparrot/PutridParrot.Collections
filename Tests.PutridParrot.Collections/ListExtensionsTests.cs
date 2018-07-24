using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PutridParrot.Collections;

namespace Tests.PutridParrot.Collections
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    public class ListExtensionsTests
    {
        [Test]
        public void AddRangeToList_ExpectIncreasedSize()
        {
            IList<string> list = new List<string>();
            list.AddRange(new[] {"Hello", "World"});

            Assert.That(list.Count, Is.EqualTo(2));
        }

        [Test]
        public void AddRangeToListWithPredicate_ExpectCorrectSize()
        {
            IList<string> list = new List<string>();
            list.AddRange(new[] { "Hello", "W" }, s => s.Length == 1);

            Assert.That(list.Count, Is.EqualTo(1));
        }

        [Test]
        public void IndexOf_WithoutPredicate_ExpectException()
        {
            IList<string> list = new List<string>
            {
                "One", "Two"                
            };
            Assert.Throws<ArgumentNullException>(() => list.IndexOf((Predicate<string>) null));
        }

        [Test]
        public void IndexOf_WithNoPredicate_ExpectException()
        {
            IList<string> list = new List<string>
            {
                "One", "Two"
            };
            Assert.Throws<ArgumentNullException>(() => list.IndexOf((Predicate<string>) null));
        }

        [Test]
        public void IndexOf_WithPredicate_ExpectFailureIfItemDoesNotExist()
        {
            IList<string> list = new List<string>
            {
                "One", "Two"
            };
            Assert.That(list.IndexOf(s => s == "Three"), Is.EqualTo(-1));
        }

        [Test]
        public void IndexOf_WithPredicate_ExpectSuccessIfItemExists()
        {
            IList<string> list = new List<string>
            {
                "One", "Two"
            };
            Assert.That(list.IndexOf(s => s == "Two"), Is.EqualTo(1));
        }

        [Test]
        public void Distinct_WhenNoDuplicatesExpectUnchanged()
        {
            IList<string> list = new List<string>
            {
                "One", "Two"
            };

            list.Distinct((a, b) => String.Compare(a, b, StringComparison.Ordinal));

            Assert.That(list.Count, Is.EqualTo(2));
        }

        [Test]
        public void Distinct_WhenDuplicatesExistExpectChanged()
        {
            IList<string> list = new List<string>
            {
                "One", "Two", "Two", "One"
            };

            list.Distinct((a, b) => String.Compare(a, b, StringComparison.Ordinal));

            Assert.That(list.Count, Is.EqualTo(2));
        }

        [Test]
        public void Sort_ExpectedArrayToBeSorted()
        {
            IList<int> array = new [] { 1, 5, 0, 2 };

            array.Sort((a, b) => a - b);

            Assert.That(array, Is.Ordered.Ascending);
        }
    }
}
