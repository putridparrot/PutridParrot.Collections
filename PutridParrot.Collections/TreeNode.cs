using System.Collections;
using System.Collections.Generic;

namespace PutridParrot.Collections
{
    /// <summary>
    /// TreeNode acts as a node which may none or many child nodes
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TreeNode<T>
    {
        private TreeNodeCollection<T> _childNodes;

        /// <summary>
        /// 
        /// </summary>
        public TreeNode()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public TreeNode(T value)
        {
            Value = value;
        }

        /// <summary>
        /// A Value associated with this node
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        public static implicit operator T(TreeNode<T> node)
        {
            return node.Value;
        }

        /// <summary>
        /// Gets then child nodes or an empty collection of child nodes
        /// </summary>
        public TreeNodeCollection<T> ChildNodes => _childNodes ?? (_childNodes = new TreeNodeCollection<T>());
    }

    /// <summary>
    /// Implements a collection of TreeNodes
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TreeNodeCollection<T> : IList<TreeNode<T>>
    {
        private readonly List<TreeNode<T>> _nodes;

        /// <summary>
        /// 
        /// </summary>
        public TreeNodeCollection()
        {
            _nodes = new List<TreeNode<T>>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator<TreeNode<T>> GetEnumerator()
        {
            return _nodes.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Add a TreeNode to the collection
        /// </summary>
        /// <param name="item"></param>
        public void Add(TreeNode<T> item)
        {
            _nodes.Add(item);
        }

        /// <summary>
        /// Clear the TreeNode collection
        /// </summary>
        public void Clear()
        {
            _nodes.Clear();
        }

        /// <summary>
        /// Checks if the collection contains a supplied TreeNode
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(TreeNode<T> item)
        {
            return _nodes.Contains(item);
        }

        /// <summary>
        /// Copy TreeNodes starting at arrayIndex into the TreeNode
        /// collection
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(TreeNode<T>[] array, int arrayIndex)
        {
            _nodes.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Remove a TreeNode from the collection
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(TreeNode<T> item)
        {
            return _nodes.Remove(item);
        }

        /// <summary>
        /// Gets the collection count
        /// </summary>
        public int Count => _nodes.Count;

        /// <summary>
        /// Gets if the collection is read-only
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// Gets the index of a TreeNode in the collection
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int IndexOf(TreeNode<T> item)
        {
            return _nodes.IndexOf(item);
        }

        /// <summary>
        /// Inserts a TreeNode into the collection at the specified index
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        public void Insert(int index, TreeNode<T> item)
        {
            _nodes.Insert(index, item);
        }

        /// <summary>
        /// Remove a TreeNode from the collections at the specified index
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            _nodes.RemoveAt(index);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public TreeNode<T> this[int index]
        {
            get => _nodes[index];
            set => _nodes[index] = value;
        }
    }
}
