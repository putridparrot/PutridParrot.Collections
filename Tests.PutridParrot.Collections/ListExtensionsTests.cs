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
        public void Sort_ExpectedArrayToBeSorted()
        {
            IList<int> array = new [] { 1, 5, 0, 2 };

            array.Sort((a, b) => a - b);

            Assert.That(array, Is.Ordered.Ascending);
        }

        [Test]
        public void Add_NullComparision_ExpectException()
        {
            IList<int> array = new[] { 0, 1, 2, 5 };
            Assert.Throws<ArgumentNullException>(() => array.Add(4, null));
        }

        [Test]
        public void Add_WithComparision_ExpectItemInCorrectSortedPlace()
        {
            IList<int> list = new List<int>{ 0, 1, 2, 5 };
            list.Add(4, (a, b) => a - b);
            Assert.AreEqual(4, list[3]);
        }
    }
}
