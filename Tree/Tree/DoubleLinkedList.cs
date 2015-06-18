using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class DoubleLinkedList<T>
    {
        private Node head;

        public DoubleLinkedList()
        {
            this.head = null;
        }

        public void Add(T value)
        {
            if (head == null)
            {
                head = new Node(value);
                return;
            }
            Add(head, value);
        }

        private void Add(Node current, T value)
        {
            if (current.next == null)
            {
                //current.next = new Node(value);
                //current.next.previous = current;
                Node justAdded = new Node(value);

                current.next = justAdded;
                justAdded.previous = current;

                return;
            }
            Add(current.next, value);
        }


        public void Remove(T value)
        {
            if (head.value.Equals(value))
            {
                Node oldHead = head;
                head = head.next;
                head.previous = null;
                oldHead.next = null;
                return;
            }
            Remove(head, value);
        }

        private void Remove(Node current, T value)
        {
            if (current == null)
            {
                return;
            }
            if (current.value.Equals(value))
            {
                if (current.next == null)
                {
                    Node nodeBeforeLast = current.previous;
                    nodeBeforeLast.next = null;
                    current.previous = null;
                    return;
                }
                Node nodeBefore = current.previous;
                Node nodeAfter = current.next;

                nodeBefore.next = nodeAfter;
                nodeAfter.previous = nodeBefore;

                current.next = null;
                current.previous = null;
                return;
            }
            Remove(current.next, value);
        }


        public void PrintList()
        {
            PrintList(head);
        }

        private void PrintList(Node current)
        {
            if (current == null)
                return;
            Console.WriteLine(current.value);
            PrintList(current.next);
        }


        class Node
        {
            public T value;
            public Node next;
            public Node previous;

            public Node(T value)
            {
                this.value = value;
            }

        }
    }
}
