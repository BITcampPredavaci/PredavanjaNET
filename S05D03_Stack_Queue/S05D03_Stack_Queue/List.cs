using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S05D03_Stack_Queue
{
    class BitList<T>
    {

        private Node head;
        private int size;


        public BitList()
        {
            this.head = null;
            this.size = 0;
        }

        public void Add(T value)
        {
            if (head == null)
            {
                head = new Node(value);
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
                size++;
                return;
            }
            Add(current.next, value);
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException();
            }
            if (index == 0)
            {
                head = head.next;
                size--;
                return;
            }
            Remove(head, index);
        }

        private void Remove(Node current, int index)
        {
            if (index == 1)
            {
                Node toDelete = current.next;
                current.next = toDelete.next;
                toDelete.next = null;
                size--;
                return;
            }
            Remove(current.next, --index);
        }

        public bool Contains(T value)
        {
            return Contains(head, value);
        }

        private bool Contains(Node current, T value)
        {
            if (current == null)
                return false;
            if (current.value.Equals(value))
                return true;
            return Contains(current.next, value);
        }

        public int IndexOf(T value)
        {
            return IndexOf(head, value);
        }

        public int GetLength()
        {
            return GetLength(head);
        }

        private int GetLength(Node current, int count = 0)
        {
            if (current == null)
                return count;

           return GetLength(current.next, ++count);
        }


        public void Add(T value, int index)
        {
            if (index < 0 || index >= size)
                throw new IndexOutOfRangeException();

            if (index == 0)
            {
                Node oldHead = head;
                head = new Node(value);
                head.next = oldHead;
                size++;
                return;
            }

            Add(head, value, index);
        }

        private void Add(Node current, T value, int index)
        {
            if (index == 1)
            {
                Node toAdd = new Node(value);
                Node toMove = current.next;
                current.next = toAdd;
                toAdd.next = toMove;
                size++;
                return;
            }
            Add(current.next, value, --index);
        }


        private int IndexOf(Node current, 
            T value, int count = 0)
        {
            if (current == null)
                return -1;
            if (current.value.Equals(value))
                return count;
            return IndexOf(current.next, value, ++count);
        }
        
        public void PrintList()
        {
            PrintList(head);
        }

        private void PrintList(Node current)
        {
            if (current == null)
            {
                return;
            }
            Console.WriteLine(current.value);
            PrintList(current.next);
        }

        class Node
        {
            public T value;
            public Node next;
            public Node(T value)
            {
                this.value = value;
                this.next = null;
            }
        }

    }
}
