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
    public class TreeNodeTests
    {
        [Test]
        public void TreeNode_CreateDefaultInstance_ShouldHaveDefaultValue()
        {
            var treeNode = new TreeNode<string>();
            Assert.That(treeNode.Value, Is.EqualTo(default(string)));
        }

        [Test]
        public void TreeNode_CreateDefaultInstance_ShouldHaveNoChildNodes()
        {
            var treeNode = new TreeNode<string>();
            Assert.That(treeNode.ChildNodes.Count, Is.Zero);
        }

        [Test]
        public void TreeNode_AddChildNode_ExpectChildNodeCountToIncrease()
        {
            var treeNode = new TreeNode<string>();
            treeNode.ChildNodes.Add(new TreeNode<string>("Hello World"));

            Assert.That(treeNode.ChildNodes.Count, Is.EqualTo(1));
            Assert.That(treeNode.ChildNodes[0].Value, Is.EqualTo("Hello World"));
        }

        [Test]
        public void TreeNode_CreateInstanceWithValue_ExpectValueToBeStored()
        {
            var treeNode = new TreeNode<string>("Hello");
            Assert.That(treeNode.Value, Is.EqualTo("Hello"));
        }

        [Test]
        public void ImplicitOperator_ExpectValueToBeReturned()
        {
            var treeNode = new TreeNode<string>("Hello");
            Assert.That((string)treeNode, Is.EqualTo("Hello"));
        }
    }
}
