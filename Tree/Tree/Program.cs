using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class Program
    {
        static void Main(string[] args)
        {

            DoubleLinkedList<int> dl = new DoubleLinkedList<int>();
            dl.Add(1);
            dl.Add(2);
            dl.Add(3);
            dl.Add(4);
            dl.Add(5);
            dl.Remove(5);
            dl.PrintList();





            //BinarySearchTree<int> bst = new BinarySearchTree<int>();
            //bst.Add(1);
            //bst.Add(2);
            //bst.Add(3);
            //bst.Add(4);
            //bst.Add(5);
            //bst.Add(6);
            //bst.Add(7);
            //bst.Add(8);


            //bst.Add(15);
            //bst.Add(10);
            //bst.Add(7);
            //bst.Add(13);
            //bst.Add(5);
            //bst.Add(20);
            //bst.Add(17);
            //bst.Add(23);


            ////bst.Add(8);
            ////bst.Add(7);
            ////bst.Add(6);
            ////bst.Add(5);
            ////bst.Add(4);
            ////bst.Add(3);
            ////bst.Add(2);
            ////bst.Add(1);

            //bst.PrintTree();
            //Console.WriteLine("================");
            //bst.Remove(13);
            //bst.PrintTree();
            //Console.WriteLine();



        }
    }
}
