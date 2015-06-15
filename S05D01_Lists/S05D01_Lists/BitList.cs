using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S05D01_Lists
{
    class BitListInt
    {

        private Node head;
        private int size;

        public BitListInt()
        {
            this.size = 0;
            this.head = null;
        }

        public void Add(int el)
        {
            if (head == null)
            {
                head = new Node(el);
                size++;
                return;
            }

            Node current = head;

            while (current.next != null)
            {
                current = current.next;
            }

            Node newNode = new Node(el);
            current.next = newNode;
            size++;
        }

        public int Get(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException(index + " is out of bounds");
            }
            Node current = head;
            int count = 0;

            while (count != index)
            {
                current = current.next;
                count++;
            }

            return current.value;
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException(index + " out of bounds");
            }
            if (index == 0)
            {
                Node tmp = head;
                head = head.next;
                tmp.next = null;
                size--;
                return;
            }

            Node previous = head;
            Node current = head.next;
            int count = 1;

            while (count < index)
            {
                previous = previous.next;
                current = current.next;
                count++;
            }

            previous.next = current.next;
            current.next = null;
            size--;
        }

        public int GetR(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException(index + " is out of bounds");
            }
            return GetR(index, head);
        }

        private int GetR(int index, Node current){
            if (index == 0)
            {
                return current.value;
            }
            return GetR(--index, current.next);
        }


        public void PrintList()
        {
            Node current = head;

            while (current != null)
            {
                Console.WriteLine(current.value);
                current = current.next;
            }
        }

        public void PrintListR()
        {
            PrintListR(head);
        }

        private void PrintListR(Node current)
        {
            if (current == null)
            {
                return;
            }
            Console.WriteLine(current.value);
            PrintListR(current.next);
        }


        private class Node
        {
            public int value;
            public Node next;

            public Node(int value)
            {
                this.value = value;
                this.next = null;
            }
        }

    }
}
