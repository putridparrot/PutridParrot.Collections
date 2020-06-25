using System.Collections;
using System.Collections.Generic;

namespace PutridParrot.Collections
{
    public class TreeNode<T>
    {
        private TreeNodeCollection<T> _childNodes;

        public TreeNode()
        {
        }

        public TreeNode(T value)
        {
            Value = value;
        }

        public T Value { get; set; }

        public static implicit operator T(TreeNode<T> node)
        {
            return node.Value;
        }

        public TreeNodeCollection<T> ChildNodes => _childNodes ?? (_childNodes = new TreeNodeCollection<T>());
    }


    public class TreeNodeCollection<T> : IList<TreeNode<T>>
    {
        private readonly List<TreeNode<T>> _nodes;
        public TreeNodeCollection()
        {
            _nodes = new List<TreeNode<T>>();
        }

        public IEnumerator<TreeNode<T>> GetEnumerator()
        {
            return _nodes.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(TreeNode<T> item)
        {
            _nodes.Add(item);
        }

        public void Clear()
        {
            _nodes.Clear();
        }

        public bool Contains(TreeNode<T> item)
        {
            return _nodes.Contains(item);
        }

        public void CopyTo(TreeNode<T>[] array, int arrayIndex)
        {
            _nodes.CopyTo(array, arrayIndex);
        }

        public bool Remove(TreeNode<T> item)
        {
            return _nodes.Remove(item);
        }

        public int Count => _nodes.Count;

        public bool IsReadOnly => false;
        public int IndexOf(TreeNode<T> item)
        {
            return _nodes.IndexOf(item);
        }

        public void Insert(int index, TreeNode<T> item)
        {
            _nodes.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _nodes.RemoveAt(index);
        }

        public TreeNode<T> this[int index]
        {
            get => _nodes[index];
            set => _nodes[index] = value;
        }
    }
}
