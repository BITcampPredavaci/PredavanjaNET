using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class BinarySearchTree<T> where T : IComparable
    {

        private Node root;

        public BinarySearchTree()
        {
            this.root = null;
        }
         
        public void Add(T value)
        {
            if (root == null)
            {
                root = new Node(value);
                return;
            }
            Add(ref root, value);
        }

        private void Add(ref Node subRoot, T value)
        {
            if (subRoot == null)
            {
                subRoot = new Node(value);
                return;
            }
            if (value.CompareTo(subRoot.value) < 1)
            {
                Add(ref subRoot.left, value);
            }
            else
            {
                Add(ref subRoot.right, value);
            }
        }

        public int CountNodes()
        {
            int count = 0;
            CountNodes(root, ref count);
            return count;
        }

        private void CountNodes(Node subRoot, ref int count)
        {
            if (subRoot == null)
                return;

            count++;
            CountNodes(subRoot.left, ref count);
            CountNodes(subRoot.right, ref count);
        }

        public bool Contains(T value)
        {
            return Contains(root, value);
        }


        private bool Contains(Node subRoot, T value)
        {
            if (subRoot == null)
                return false;
            if (subRoot.value.Equals(value))
                return true;

            return Contains(subRoot.left, value) ||
            Contains(subRoot.right, value);
        }

        private bool ContainsBetter(Node subRoot, T value)
        {
            if (subRoot == null)
                return false;
            if (subRoot.value.Equals(value))
                return true;

            if (value.CompareTo(subRoot.value) < 1)
            {
                return ContainsBetter(subRoot.left, value);
            }
            else
            {
                return ContainsBetter(subRoot.right, value);
            }
        }

        public void Remove(T value)
        {
            Remove(ref root, value);
        }


        private T RemoveMax(ref Node subRoot)
        {
           
            if (subRoot.right == null)
            {
                T max = subRoot.value;
                subRoot = subRoot.left;
                return max;
            }

            return RemoveMax(ref subRoot.right);
        }

        private void Remove(ref Node subRoot, T value)
        {
            if (subRoot == null)
                return;

            if (subRoot.value.Equals(value))
            {
                if (subRoot.left == null && subRoot.right == null)
                    subRoot = null;
                else if (subRoot.left == null)
                {
                    subRoot = subRoot.right;
                }
                else
                {
                    subRoot.value = RemoveMax(ref subRoot.left);
                }
                return;
            }

            if (subRoot.value.CompareTo(value) == -1)
                Remove(ref subRoot.right, value);
            else
                Remove(ref subRoot.left, value);
        }

        public void PrintTree()
        {
            PrintTree(root);
        }

        private void PrintTree(Node subRoot, int level = 0)
        {
            if (subRoot == null)
            {
                return;
            }

            PrintTree(subRoot.left, level + 1);
            Console.WriteLine("Level: " + level + " Current subRoot: " + subRoot.value);
            PrintTree(subRoot.right, level + 1);
        }


        class Node
        {
            public T value;
            public Node left;
            public Node right;


            public Node(T value)
            {
                this.value = value;
                this.left = null;
                this.right = null;
            }
        }
    }
}
