﻿namespace PutridParrot.Collections
{
    public class BinaryTreeNode<T>
    {
        public BinaryTreeNode()
        {
        }

        public BinaryTreeNode(T value)
        {
            Value = value;
        }

        public T Value { get; set; }

        public static implicit operator T(BinaryTreeNode<T> node)
        {
            return node.Value;
        }

        public BinaryTreeNode<T> Left { get; set; }
        public BinaryTreeNode<T> Right { get; set; }
    }


}
