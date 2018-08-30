using System;
using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PutridParrot.Collections;

namespace Tests.PutridParrot.Collections
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    public class CompareImplTests
    {
        [Test]
        public void Constructor_NullComparerFunc_ExpectException()
        {
            Func<string, string, int> compFunc = null;
            Assert.Throws<ArgumentNullException>(() => new ComparerImpl<string>(compFunc));
        }

        [Test]
        public void Constructor_NullHasFunc_ExpectException()
        {
            Func<string, int> hashFunc = null;
            Assert.Throws<ArgumentNullException>(() => new ComparerImpl<string>(
                (a, b) => String.Compare(a, b), hashFunc));
        }

        [Test]
        public void CompareStrings_ExpectSuppliedComparerToBeCalled()
        {
            var comparer = new ComparerImpl<string>((a, b) => 123);
            Assert.AreEqual(123, comparer.Compare("A", "B"));
        }

        [Test]
        public void CompareObjectWithBothStrings_ExpectSuppliedComparerToBeCalled()
        {
            var comparer = new ComparerImpl<string>((a, b) => 123);
            Assert.AreEqual(123, comparer.Compare((object)"A", (object)"B"));
        }

        [Test]
        public void CompareObjectWithNotStrings_ExpectInvalidCastException()
        {
            var comparer = new ComparerImpl<string>((a, b) => 123);
            Assert.Throws<InvalidCastException>(() => comparer.Compare((object)1, (object)2));
        }

        [Test]
        public void GetHashCode_UseDefault()
        {
            var s = "Scooby Doo";

            var comparer = new ComparerImpl<string>(String.CompareOrdinal);
            Assert.AreEqual(s.GetHashCode(), comparer.GetHashCode(s));
        }

        [Test]
        public void Equals_WhereEqual_ExpectTrue()
        {
            var comparer = new ComparerImpl<string>(String.CompareOrdinal);
            Assert.IsTrue(comparer.Equals("ABC", "ABC"));
        }

        [Test]
        public void Equals_WhereNotEqual_ExpectTrue()
        {
            var comparer = new ComparerImpl<string>(String.CompareOrdinal);
            Assert.IsFalse(comparer.Equals("ABC", "DEF"));
        }

    }
}
