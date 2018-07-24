using System;
using System.Collections.Generic;

namespace PutridParrot.Collections
{
    /// <summary>
    /// Tree traversal functions, allowing traversal of 
    /// tree-like structures whereby no specific tree collection
    /// is expected.
    /// </summary>
    public static class TraverseTree
    {
        // https://en.wikipedia.org/wiki/Tree_traversal#Pre-order
        public static void PreOrderTraversal<T>(T node, Func<T, IEnumerable<T>> getChildNodes, Action<T> preOrderAction)
        {
            if (node != null)
            {
                preOrderAction(node);
                foreach (var child in getChildNodes(node))
                {
                    if (child != null)
                    {
                        PreOrderTraversal(child, getChildNodes, preOrderAction);
                    }
                }
            }
        }

        // https://en.wikipedia.org/wiki/Tree_traversal#Post-order
        public static void PostOrderTraversal<T>(T node, Func<T, IEnumerable<T>> getChildNodes, Action<T> postOrderAction)
        {
            if (node != null)
            {
                foreach (var child in getChildNodes(node))
                {
                    if (child != null)
                    {
                        PostOrderTraversal(child, getChildNodes, postOrderAction);
                    }
                }
                postOrderAction(node);
            }
        }

        // https://en.wikipedia.org/wiki/Tree_traversal#In-order
        public static void InOrderTraversal<T>(T node, Func<T, T[]> getChildNodes, Action<T> inOrderAction)
        {
            if (node != null)
            {
                var childNodes = getChildNodes(node);
                if (childNodes != null)
                {
                    // expects a binary tree
                    InOrderTraversal(childNodes[0], getChildNodes, inOrderAction);
                    inOrderAction(node);
                    InOrderTraversal(childNodes[1], getChildNodes, inOrderAction);
                }
            }
        }

        public static void BreadthTraversal<T>(T node, Func<T, IEnumerable<T>> getChildNodes, Action<T> breadthAction)
        {
            var d = new Dictionary<T, bool>();
            var q = new Queue<T>();

            q.Enqueue(node);
            breadthAction(node);
            d[node] = true;

            while (q.Count != 0)
            {
                var n = q.Dequeue();
                foreach (var child in getChildNodes(n))
                {
                    if (child != null)
                    {
                        if (!d.ContainsKey(child))
                        {
                            d[child] = true;
                            breadthAction(child);
                            q.Enqueue(child);
                        }
                    }
                }
            }
        }
    }
}
