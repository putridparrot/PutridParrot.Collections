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
    public class TradeNodeExtensionsTests
    {
        private TreeNode<string> _root;

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
        }

        [Test]
        public void PreOrderTraversal()
        {
            var result = new List<string>();

            _root.PreOrderTraversal(n => result.Add(n));

            Assert.That(result.Count, Is.EqualTo(9));
            Assert.That(result, Is.EqualTo(new [] {"F", "B", "A", "D", "C", "E", "G", "I", "H"}));
        }

        [Test]
        public void PostOrderTraversal()
        {
            var result = new List<string>();

            _root.PostOrderTraversal(n => result.Add(n));

            Assert.That(result.Count, Is.EqualTo(9));
            Assert.That(result, Is.EqualTo(new[] { "A", "C", "E", "D", "B", "H", "I", "G", "F" }));
        }

        [Test]
        public void BreathTraversal()
        {
            var result = new List<string>();

            _root.BreadthTraversal(n => result.Add(n));

            Assert.That(result.Count, Is.EqualTo(9));
            Assert.That(result, Is.EqualTo(new[] { "F", "B", "G", "A", "D", "I", "C", "E", "H" }));
        }

    }
}
