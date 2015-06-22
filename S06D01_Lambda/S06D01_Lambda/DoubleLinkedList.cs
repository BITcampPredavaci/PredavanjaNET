using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S06D01_Lambda
{
    class DoubleLinkedList<T>
    {
        private Node head;
        private Node tail;
        private int size;

        public DoubleLinkedList()
        {
            this.head = null;
            this.size = 0;
        }

        public void Add(T value)
        {
            if (head == null)
            {
                head = new Node(value);
                tail = head;
                size++;
                return;
            }
            Add(head, value);
        }
        private void Add(Node current, T value)
        {
            if (current.next == null)
            {
                current.next = new Node(value);
                Node newNode = current.next;
                tail = newNode;
                newNode.previous = current;
                size++;
                return;
            }
            Add(current.next, value);
        }
        public void Add(T value, int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException();
            }
            if (index == 0)
            {
                Node temp = new Node(value);
                temp.next = head;
                head.previous = temp;
                head = temp;
                size++;
                return;
            }
            Add(head, value, index, 0);
        }
        private void Add(Node current, T value, int index, int count)
        {
            if (count == index - 1)
            {
                Node newNode = new Node(value);
                newNode.next = current.next;
                newNode.previous = current;
                current.next.previous = newNode;
                current.next = newNode;
                size++;
                return;
            }
            Add(current.next, value, index, ++count);
        }
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException();
            }
            if (index == 0)
            {
                Node toRemove = head;
                head = head.next;
                head.previous = null;
                toRemove.next = null;
                size--;
                return;
            }
            Remove(head, index, 0);
        }
        private void Remove(Node current, int index, int count)
        {
            if (count == index)
            {
                throw new ArgumentNullException();
            }
            if (count == index - 1)
            {
                if (current.next.next == null)
                {
                    Node toRemove1 = current.next;
                    tail = current;
                    toRemove1.previous = null;
                    current.next = null;
                    size--;
                    return;
                }
                Node toRemove = current.next;
                current.next = toRemove.next;
                toRemove.next.previous = current;
                toRemove.next = null;
                toRemove.previous = null;
                size--;
                return;
            }
            Remove(current.next, index, ++count);
        }
        public void Remove(T value)
        {
            if (head == null)
            {
                throw new ArgumentNullException();
            }
            if (head.value.Equals(value))
            {
                Node toRemove = head;
                head = head.next;
                head.previous = null;
                toRemove.next = null;
                size--;
                return;
            }
            Remove(head, value);
        }
        private void Remove(Node current, T value)
        {
            if (current.value.Equals(value))
            {
                if (current.next == null)
                {
                    Node toRemove1 = current;
                    tail = current.previous;
                    current.previous.next = null;
                    toRemove1.previous = null;
                    size--;
                    return;
                }
                Node toRemove = current;
                toRemove.previous.next = current.next;
                toRemove.next.previous = current.previous;
                toRemove.next = null;
                toRemove.previous = null;
                size--;
                return;
            }
            Remove(current.next, value);
        }
        class Node
        {
            public Node next;
            public Node previous;
            public T value;

            public Node(T value)
            {
                this.value = value;
                this.previous = null;
                this.next = null;
            }
        }
        public void Reverse()
        {
            if (head == null)
            {
                throw new ArgumentNullException();
            }
            Reverse(head);
        }
        private void Reverse(Node current)
        {
            if (current == null)
            {
                return;
            }
            Reverse(current.next);
            Add(current.value);
            Remove(current.value);
        }

        public void PrintList()
        {
            if (head == null)
            {
                throw new ArgumentNullException();
            }
            PrintList(head);
            Console.WriteLine();
        }
        private void PrintList(Node current)
        {
            if (current == null)
            {

                return;
            }
            Console.Write(current.value + " ");
            PrintList(current.next);
        }
    }
}
