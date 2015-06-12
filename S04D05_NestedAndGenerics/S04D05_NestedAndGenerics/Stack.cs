using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S04D05_NestedAndGenerics
{
    class StackInt
    {
        private int[] array;
        private int index;

        public StackInt()
        {
            this.array = new int[10];
            this.index = 0;
        }

        public void Push(int value)
        {
            array[index++] = value;
        }

        public int Pop()
        {
            return array[--index];
        }

        public int Peek()
        {
            int last = index - 1;
            return array[last];
        }

    }

    class Stack<T>
    {
        private T[] array;
        private int index;

        public Stack()
        {
            this.array = new T[10];
            this.index = 0;
        }

        public void Push(T value)
        {
            this.array[index++] = value;
        }

        public T Pop()
        {
            return this.array[--index];
        }

        public T Peek()
        {
            int last = index - 1;
            return this.array[last];
        }

    }


}
