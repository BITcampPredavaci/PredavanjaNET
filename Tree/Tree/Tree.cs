using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class Tree<T>
    {
        private Node root;

        public Tree()
        {
            this.root = null;
        }

        public void Add(T value){
            if (root == null)
            {
                root = new Node(value);
                return;
            }
            Add(ref root, value);
        }

        private void Add(ref Node subRoot, T value)
        {
            if (subRoot.left == null)
            {
                subRoot.childCount++;
                subRoot.left = new Node(value);
                return;
            }
            if (subRoot.right == null)
            {
                subRoot.childCount++;
                subRoot.right = new Node(value);
                return;
            }
            if (subRoot.left.childCount <= subRoot.right.childCount)
            {
                Add(ref subRoot.left, value);
            }
            else
            {
                Add(ref subRoot.right, value);
            }
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
            public int childCount = 0;

            public Node(T value)
            {
                this.value = value;
                this.left = null;
                this.right = null;
            }
        }

    }
}
