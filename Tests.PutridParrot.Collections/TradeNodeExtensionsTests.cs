using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PutridParrot.Collections;

namespace Tests.PutridParrot.Collections
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    public class TradeNodeExtensionsTests
    {
        private TreeNode<string> _root;
        private BinaryTreeNode<string> _binaryRoot;

        [SetUp]
        public void SetUp()
        {
            _root = new TreeNode<string>("F");
            // level 1
            _root.ChildNodes.Add(new TreeNode<string>("B"));
            _root.ChildNodes.Add(new TreeNode<string>("G"));

            // level 2
            _root.ChildNodes[0].ChildNodes.Add(new TreeNode<string>("A"));
            _root.ChildNodes[0].ChildNodes.Add(new TreeNode<string>("D"));

            _root.ChildNodes[1].ChildNodes.Add(new TreeNode<string>("I"));

            // level 3
            _root.ChildNodes[0].ChildNodes[1].ChildNodes.Add(new TreeNode<string>("C"));
            _root.ChildNodes[0].ChildNodes[1].ChildNodes.Add(new TreeNode<string>("E"));

            _root.ChildNodes[1].ChildNodes[0].ChildNodes.Add(new TreeNode<string>("H"));

            // binary tree

            _binaryRoot = new BinaryTreeNode<string>("F");
            // level 1
            _binaryRoot.Left = new BinaryTreeNode<string>("B");
            _binaryRoot.Right = new BinaryTreeNode<string>("G");

            // level 2
            _binaryRoot.Left.Left = new BinaryTreeNode<string>("A");
            _binaryRoot.Left.Right = new BinaryTreeNode<string>("D");

            _binaryRoot.Right.Right = new BinaryTreeNode<string>("I");

            // level 3
            _binaryRoot.Left.Right.Left = new BinaryTreeNode<string>("C");
            _binaryRoot.Left.Right.Right = new BinaryTreeNode<string>("E");

            _binaryRoot.Right.Right.Left = new BinaryTreeNode<string>("H");
        }

        [Test]
        public void PreOrderTraversal_TreeNode()
        {
            var result = new List<string>();

            _root.PreOrderTraversal(n => result.Add(n));

            Assert.That(result.Count, Is.EqualTo(9));
            Assert.That(result, Is.EqualTo(new [] {"F", "B", "A", "D", "C", "E", "G", "I", "H"}));
        }

        [Test]
        public void PreOrderTraversal_BinaryTreeNode()
        {
            var result = new List<string>();

            _binaryRoot.PreOrderTraversal(n => result.Add(n));

            Assert.That(result.Count, Is.EqualTo(9));
            Assert.That(result, Is.EqualTo(new[] { "F", "B", "A", "D", "C", "E", "G", "I", "H" }));
        }


        [Test]
        public void PostOrderTraversal_TreeNode()
        {
            var result = new List<string>();

            _root.PostOrderTraversal(n => result.Add(n));

            Assert.That(result.Count, Is.EqualTo(9));
            Assert.That(result, Is.EqualTo(new[] { "A", "C", "E", "D", "B", "H", "I", "G", "F" }));
        }

        [Test]
        public void PostOrderTraversal_BinaryTreeNode()
        {
            var result = new List<string>();

            _binaryRoot.PostOrderTraversal(n => result.Add(n));

            Assert.That(result.Count, Is.EqualTo(9));
            Assert.That(result, Is.EqualTo(new[] { "A", "C", "E", "D", "B", "H", "I", "G", "F" }));
        }

        [Test]
        public void BreathTraversal_TreeNode()
        {
            var result = new List<string>();

            _root.BreadthTraversal(n => result.Add(n));

            Assert.That(result.Count, Is.EqualTo(9));
            Assert.That(result, Is.EqualTo(new[] { "F", "B", "G", "A", "D", "I", "C", "E", "H" }));
        }

        [Test]
        public void BreathTraversal_BinaryTreeNode()
        {
            var result = new List<string>();

            _binaryRoot.BreadthTraversal(n => result.Add(n));

            Assert.That(result.Count, Is.EqualTo(9));
            Assert.That(result, Is.EqualTo(new[] { "F", "B", "G", "A", "D", "I", "C", "E", "H" }));
        }

        [Test]
        public void InOrderTraversal()
        {
            var result = new List<string>();

            _binaryRoot.InOrderTraversal(n => result.Add(n));

            Assert.That(result.Count, Is.EqualTo(9));
            Assert.That(result, Is.EqualTo(new[] { "A", "B", "C", "D", "E", "F", "G", "H", "I" }));
        }
    }
}
