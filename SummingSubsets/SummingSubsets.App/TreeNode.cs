using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeEx.Lib
{
    internal class TreeNode
    {
        private int _value;
        private TreeNode _leftChild, _rightChild;
        public TreeNode(int v)
        {
            _value = v;
            _leftChild = null;
            _rightChild = null;
        }

        public int Value { get { return _value; } }

        internal void Insert(int v)
        {
            if (v < _value)
            {
                if (_leftChild != null)
                    _leftChild.Insert(v);
                else
                    _leftChild = new TreeNode(v);
            }
            else
            {
                if (_rightChild != null)
                    _rightChild.Insert(v);
                else
                    _rightChild = new TreeNode(v);
            }
        }

        internal TreeNode LCommonAncestor(int v1, int v2)
        {
            if (!(IsPreSent(v1) && IsPreSent(v2)))  //invalid values
                return null;
            if (_leftChild == null && _rightChild == null)
                return null;
            if (v1 == _value || v2 == _value)//when one of the value is reached, it must be the other's ancestor
                return this;
            else if (_leftChild == null)
                return _rightChild.LCommonAncestor(v1, v2);
            else if (_rightChild == null)
                return _leftChild.LCommonAncestor(v1, v2);
            else
            {
                if(_leftChild.IsPreSent(v1))
                {
                    if (_rightChild.IsPreSent(v2))    //when the smaller value is in the left tree and the greater value is in the right tree,
                        return this;                    //return itself
                    return _leftChild.LCommonAncestor(v1, v2);
                }
                return _rightChild.LCommonAncestor(v1, v2);  
            }
        }

        public override string ToString()
        {
            return Convert.ToString(_value);
        }

        internal bool IsPreSent(int v)
        {
            if (v == _value)
                return true;
            if (v >= _value)
                return (_rightChild == null) ? false : _rightChild.IsPreSent(v);
            else
                return (_leftChild == null) ? false : _leftChild.IsPreSent(v);
        }

        internal void InOrderTraversal()
        {
            if (_leftChild != null)
                _leftChild.InOrderTraversal();
            Console.WriteLine(this);
            if (_rightChild != null)
                _rightChild.InOrderTraversal();
        }

   

        internal int Sum
        {
            get
            {
                return ((_leftChild == null) ? 0 : _leftChild._value + _leftChild.Sum)
                    + ((_rightChild == null) ? 0 : _rightChild._value + _rightChild.Sum);
            }
        }

        internal int Count
        {
            get
            {
                return 1 + ((_leftChild == null) ? 0 : _leftChild.Count)
                    + ((_rightChild == null) ? 0 : _rightChild.Count);
            }
        }

        internal int Depth
        {
            get
            {
                if (_leftChild == null & _rightChild == null)
                    return 1;
                int leftDepth = (_leftChild == null) ? 0 : _leftChild.Depth;
                int rightDepth = (_rightChild == null) ? 0 : _rightChild.Depth;
                return 1 + Math.Max(leftDepth, rightDepth);
            }
        }
    }
}
