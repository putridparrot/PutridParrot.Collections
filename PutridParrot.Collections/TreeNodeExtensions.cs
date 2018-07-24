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
    }
}
