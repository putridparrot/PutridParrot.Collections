using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PutridParrot.Collections;

namespace Tests.PutridParrot.Collections
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    public class BinaryTreeNodeTests
    {
        [Test]
        public void Constructor_Default_ExpectDefaultOfT()
        {
            var node = new BinaryTreeNode<string>();
            Assert.AreEqual(default(string), node.Value);
        }

        [Test]
        public void Constructor_WithValue_ExpectValue()
        {
            var node = new BinaryTreeNode<string>("Scooby");
            Assert.AreEqual("Scooby", node.Value);
        }

        [Test]
        public void ImplicitCast_ExpectValue()
        {
            var node = new BinaryTreeNode<string>("Scooby");
            string value = node;
            Assert.AreEqual("Scooby", value);
        }

        [Test]
        public void Left_Default_ExpectNull()
        {
            var node = new BinaryTreeNode<string>("Scooby");
            Assert.IsNull(node.Left);
        }

        [Test]
        public void Left_AddNonNull_ExpectSameValue()
        {
            var node = new BinaryTreeNode<string>("Scooby");
            var left = new BinaryTreeNode<string>("Doo");

            node.Left = left;
            Assert.AreEqual(left, node.Left);
            Assert.IsNull(node.Right);
        }

        [Test]
        public void Right_Default_ExpectNull()
        {
            var node = new BinaryTreeNode<string>("Scooby");
            Assert.IsNull(node.Right);
        }

        [Test]
        public void Right_AddNonNull_ExpectSameValue()
        {
            var node = new BinaryTreeNode<string>("Scooby");
            var right = new BinaryTreeNode<string>("Doo");

            node.Right = right;
            Assert.AreEqual(right, node.Right);
            Assert.IsNull(node.Left);
        }
    }
}
