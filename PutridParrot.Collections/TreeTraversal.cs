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
        /// <summary>
        /// Executes a pre-order traversal of the supplied nodes invoking
        /// the supplied action on each node
        /// </summary>
        /// <seealso href="https://en.wikipedia.org/wiki/Tree_traversal#Pre-order"/>
        /// <typeparam name="T"></typeparam>
        /// <param name="node"></param>
        /// <param name="getChildNodes"></param>
        /// <param name="preOrderAction"></param>
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

        /// <summary>
        /// Executes a post-order traversal of the supplied nodes invoking
        /// the supplied action on each node
        /// </summary>
        /// <seealso href="https://en.wikipedia.org/wiki/Tree_traversal#Post-order"/>
        /// <typeparam name="T"></typeparam>
        /// <param name="node"></param>
        /// <param name="getChildNodes"></param>
        /// <param name="postOrderAction"></param>
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

        /// <summary>
        /// Executes an in-order traversal of the supplied nodes invoking
        /// the supplied action on each node
        /// </summary>
        /// <seealso href="https://en.wikipedia.org/wiki/Tree_traversal#In-order"/>
        /// <typeparam name="T"></typeparam>
        /// <param name="node"></param>
        /// <param name="getChildNodes"></param>
        /// <param name="inOrderAction"></param>
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

        /// <summary>
        /// Executes an breadth traversal of the supplied nodes invoking
        /// the supplied action on each node
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="node"></param>
        /// <param name="getChildNodes"></param>
        /// <param name="breadthAction"></param>
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
