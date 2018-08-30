using System;

namespace PutridParrot.Collections
{
    public static class TreeNodeExtensions
    {
        public static void PreOrderTraversal<T>(this TreeNode<T> node, Action<TreeNode<T>> action)
        {
            TraverseTree.PreOrderTraversal(node, n => n.ChildNodes, action);
        }

        public static void PostOrderTraversal<T>(this TreeNode<T> node, Action<TreeNode<T>> action)
        {
            TraverseTree.PostOrderTraversal(node, n => n.ChildNodes, action);
        }

        public static void BreadthTraversal<T>(this TreeNode<T> node, Action<TreeNode<T>> action)
        {
            TraverseTree.BreadthTraversal(node, n => n.ChildNodes, action);
        }

        public static void PreOrderTraversal<T>(this BinaryTreeNode<T> node, Action<BinaryTreeNode<T>> action)
        {
            TraverseTree.PreOrderTraversal(node, n => new [] { n.Left, n.Right }, action);
        }

        public static void PostOrderTraversal<T>(this BinaryTreeNode<T> node, Action<BinaryTreeNode<T>> action)
        {
            TraverseTree.PostOrderTraversal(node, n => new[] { n.Left, n.Right }, action);
        }

        public static void InOrderTraversal<T>(this BinaryTreeNode<T> node, Action<BinaryTreeNode<T>> action)
        {
            TraverseTree.InOrderTraversal(node, n => new[] { n.Left, n.Right }, action);
        }

        public static void BreadthTraversal<T>(this BinaryTreeNode<T> node, Action<BinaryTreeNode<T>> action)
        {
            TraverseTree.BreadthTraversal(node, n => new[] { n.Left, n.Right }, action);
        }
    }
}
