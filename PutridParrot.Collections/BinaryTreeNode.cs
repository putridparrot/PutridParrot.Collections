namespace PutridParrot.Collections
{
    /// <summary>
    /// Implementation of a simple Binary Tree Node 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinaryTreeNode<T>
    {
        /// <summary>
        /// Creates a BinaryTreeNode
        /// </summary>
        public BinaryTreeNode()
        {
        }

        /// <summary>
        /// Creates a BinaryTreeNode with the supplied value
        /// </summary>
        /// <param name="value">The value associated with this node</param>
        public BinaryTreeNode(T value)
        {
            Value = value;
        }

        /// <summary>
        /// Get/Set the value associated with the BinaryTreeNode
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Operator overload to convert a BinaryTreeNode to the Value
        /// associated with it
        /// </summary>
        /// <param name="node">The node to get the value from</param>
        public static implicit operator T(BinaryTreeNode<T> node)
        {
            return node.Value;
        }

        /// <summary>
        /// Get/Set the left node from this BinaryTreeNode
        /// </summary>
        public BinaryTreeNode<T> Left { get; set; }
        /// <summary>
        /// Get/Set the right node from this BinaryTreeNode
        /// </summary>
        public BinaryTreeNode<T> Right { get; set; }
    }
}
