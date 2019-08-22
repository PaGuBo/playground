using System;
using System.Collections.Generic;
using System.Text;

namespace Lib
{
    public class TreeNode<T>
    {
        private T _value { get; }

        public TreeNode()
        {

        }
        public TreeNode(T value)
        {
            _value = value;
        }
        public T Value => _value;
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }
    }
}
