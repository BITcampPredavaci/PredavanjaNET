using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S04D05_NestedAndGenerics
{
    class DynamicArray<T>
    {

        protected T[] array;
        protected int size;

        public DynamicArray()
        {
            this.array = new T[1];
            this.size = 0;
        }

        public int Size { get { return size; } }


        public void Add(T element)
        {
            if (size == array.Length)
            {
                Resize();
            }

            array[size++] = element;
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException("Index out of bounds");
            }

            for (int i = index; i < size-1; i++)
            {
                array[i] = array[i + 1];
            }
            array[--size] = default(T);
        }

        public T Get(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException("Index out of bounds");
            }

            return array[index];
        }


        public bool Contains(T element)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Equals(element))
                {
                    return true;
                }
            }

            return false;
        }

        protected void Resize()
        {
            T[] temp = new T[array.Length * 2];
            for (int i = 0; i < array.Length; i++)
            {
                temp[i] = array[i];
            }

            array = temp;
        }


    }


    class DynamicSortedArray<T>
        : DynamicArray<T> where T : IComparable<T>
    {

        public DynamicSortedArray() : base()
        {
        }

        public new void Add(T element)
        {
            for (int i = 0; i < size; i++)
            {
                if (array[i].CompareTo(element) == 1)
                {
                    ShiftRight(i);
                    array[i] = element;
                    size++;
                    return;
                }
            }

            if (array.Length == size)
                Resize();

            array[size++] = element;
        }

        private void ShiftRight(int index)
        {
            if (size >= array.Length - 1)
            {
                Resize();
            }

            for (int i = size; i > index; i--)
            {
                array[i] = array[i - 1];
            }
        }


    }

  
}
