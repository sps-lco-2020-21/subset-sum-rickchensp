using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeEx.Lib
{
    public class BinaryTree
    {
        private TreeNode _root;

        public BinaryTree(int v)
        {
            _root = new TreeNode(v);
        }

        public void Insert(int v)
        {
            _root.Insert(v);
        }

        public void InsertRange(List<int> list)
        {
            foreach(int v in list)
            {
                _root.Insert(v);
            }
        }

        public bool IsPresent(int v) { return _root.IsPreSent(v); }
        public int Depth { get { return _root.Depth; } }
        public int Count { get { return _root.Count; } }
        public int Sum { get { return _root.Value + _root.Sum; } }
       
        public int LCommonAncestor(int v1, int v2)
        {
            return _root.LCommonAncestor(Math.Min(v1, v2), Math.Max(v1, v2)).Value;
        }
        public void InOrderOutput() { _root.InOrderTraversal(); }
        public override string ToString()
        {
            return "Count = " + Convert.ToString(Count);
        }
    }
}
