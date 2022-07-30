using System;

namespace PutridParrot.Collections
{
    /// <summary>
    /// TreeNode extension methods
    /// </summary>
    public static class TreeNodeExtensions
    {
        /// <summary>
        /// Executes a pre-order traversal of the tree nodes invoking
        /// the supplied action on each node
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="node"></param>
        /// <param name="action"></param>
        public static void PreOrderTraversal<T>(this TreeNode<T> node, Action<TreeNode<T>> action)
        {
            TraverseTree.PreOrderTraversal(node, n => n.ChildNodes, action);
        }

        /// <summary>
        /// Executes a post-order traversal of the tree nodes invoking
        /// the supplied action on each node
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="node"></param>
        /// <param name="action"></param>
        public static void PostOrderTraversal<T>(this TreeNode<T> node, Action<TreeNode<T>> action)
        {
            TraverseTree.PostOrderTraversal(node, n => n.ChildNodes, action);
        }

        /// <summary>
        /// Executes a breadth traversal of the tree nodes invoking
        /// the supplied action on each node
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="node"></param>
        /// <param name="action"></param>
        public static void BreadthTraversal<T>(this TreeNode<T> node, Action<TreeNode<T>> action)
        {
            TraverseTree.BreadthTraversal(node, n => n.ChildNodes, action);
        }

        /// <summary>
        /// Executes a pre-order traversal of the binary tree nodes invoking
        /// the supplied action on each node
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="node"></param>
        /// <param name="action"></param>
        public static void PreOrderTraversal<T>(this BinaryTreeNode<T> node, Action<BinaryTreeNode<T>> action)
        {
            TraverseTree.PreOrderTraversal(node, n => new [] { n.Left, n.Right }, action);
        }

        /// <summary>
        /// Executes a post-order traversal of the binary tree nodes invoking
        /// the supplied action on each node
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="node"></param>
        /// <param name="action"></param>
        public static void PostOrderTraversal<T>(this BinaryTreeNode<T> node, Action<BinaryTreeNode<T>> action)
        {
            TraverseTree.PostOrderTraversal(node, n => new[] { n.Left, n.Right }, action);
        }

        /// <summary>
        /// Executes a in-order traversal of the binary tree nodes invoking
        /// the supplied action on each node
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="node"></param>
        /// <param name="action"></param>
        public static void InOrderTraversal<T>(this BinaryTreeNode<T> node, Action<BinaryTreeNode<T>> action)
        {
            TraverseTree.InOrderTraversal(node, n => new[] { n.Left, n.Right }, action);
        }

        /// <summary>
        /// Executes a breadth traversal of the binary tree nodes invoking
        /// the supplied action on each node
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="node"></param>
        /// <param name="action"></param>
        public static void BreadthTraversal<T>(this BinaryTreeNode<T> node, Action<BinaryTreeNode<T>> action)
        {
            TraverseTree.BreadthTraversal(node, n => new[] { n.Left, n.Right }, action);
        }
    }
}
