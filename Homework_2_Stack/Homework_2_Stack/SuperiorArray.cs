using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_2_Stack
{
    class SuperiorArray<T> where T : IComparable<T>
    {
        private T[] array;
        private int length;

        public int Length { get { return length; } }

        public SuperiorArray()
        {
            this.array = new T[1];
            this.length = 0;
        }


        public static SuperiorArray<T> operator +(SuperiorArray<T> left, SuperiorArray<T> right) {
            SuperiorArray<T> result = new SuperiorArray<T>();
            for (int i = 0; i < left.length; i++)
            {
                result.Add(left[i]);
            }
            for (int i = 0; i < right.length; i++)
            {
                result.Add(right[i]);
            }
            return result;
        }

        public static SuperiorArray<T> operator -(SuperiorArray<T> left, SuperiorArray<T> right)
        {
            SuperiorArray<T> result = new SuperiorArray<T>();
            for (int i = 0; i < left.length; i++)
            {
                if (right.Contains(left[i]) == false)
                    result.Add(left[i]);
            }

            return result;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= length)
                    throw new IndexOutOfRangeException(index + " index out of bounds");
                return array[index];
            }
            set
            {
                if (index < 0 || index >= length)
                    throw new IndexOutOfRangeException(index + " index out of bounds");
                array[index] = value;
            }
        }

        /// <summary>
        /// Adds element to the end of the array
        /// </summary>
        /// <param name="element"></param>
        public void Add(T element)
        {
            ShouldResize();

            array[length++] = element;
        }


        /// <summary>
        /// Adds an element to the array at a specified index
        /// </summary>
        /// <param name="element">the element to add</param>
        /// <param name="index">the index at which to add</param>
        public void Add(T element, int index)
        {
            if (index < 0 || index >= length)
                throw new IndexOutOfRangeException(index + " is out of range");
            ShouldResize();
            ShiftRight(index);
            array[index] = element;
            length++;
        }

        /// <summary>
        /// Removes the element at the specified index
        /// </summary>
        /// <param name="index">index of the element which should be removed</param>
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= length)
                throw new IndexOutOfRangeException(index + " is out of range");

            ShiftLeft(index);
            length--;
        }


        /// <summary>
        /// Finds element with the value passed as paramether and removes it
        /// </summary>
        /// <param name="element">the value of the element which should be removed</param>
        public void Remove(T element)
        {
            int index = IndexOf(element);
            if (index != -1)
            {
                RemoveAt(index);
            }
        }
        /// <summary>
        /// Removes all elements with the value element from the array
        /// </summary>
        /// <param name="element">the value whic should be removed</param>
        public void RemoveAll(T element)
        {
            int index = -1;
            do
            {
                index = IndexOf(element);
                if (index != -1)
                    RemoveAt(index);
            } while (index != -1);
        }


        /// <summary>
        /// Checks if the element is in the array
        /// </summary>
        /// <param name="element">element to check for</param>
        /// <returns>true if the element is in the array</returns>
        public bool Contains(T element)
        {
            return IndexOf(element) != -1;
        }


        /// <summary>
        /// Clears the array
        /// </summary>
        public void Clear()
        {
            this.array = new T[length];
            this.length = 0;
        }


        /// <summary>
        /// Finds the largest element in the array
        /// </summary>
        /// <returns>the largest element in the arrau</returns>
        public T GetMax()
        {
            T max = array[0];
            for (int i = 1; i < length; i++)
            {
                if (max.CompareTo(array[i]) == -1)
                    max = array[i];
            }
            return max;
        }


        /// <summary>
        /// Finds the smallest element in the array
        /// </summary>
        /// <returns>the smallest element</returns>
        public T GetMin()
        {
            T min = array[0];
            for (int i = 1; i < length; i++)
            {
                if (min.CompareTo(array[i]) == 1)
                    min = array[i];
            }
            return min;
        }

        /// <summary>
        /// Removes the largest element from the array
        /// </summary>
        public void RemoveMax()
        {
            T max = GetMax();
            Remove(max);
        }

        /// <summary>
        /// Removes the smallest element from the array
        /// </summary>
        public void RemoveMin()
        {
            T min = GetMin();
            Remove(min);
        }

        /// <summary>
        /// Searches the array for a certain value, returns the first index at which the value is found
        /// </summary>
        /// <param name="element">the element which should be found</param>
        /// <returns>index of the element</returns>
        private int IndexOf(T element)
        {
            for (int i = 0; i < length; i++)
            {
                if (array[i].Equals(element))
                    return i;
            }
            return -1;
        }




        /// <summary>
        /// Checks if the array needs resizing, if it does it will resize
        /// </summary>
        private void ShouldResize()
        {
            if (length == array.Length)
            {
                Resize();
            }
        }

        /// <summary>
        /// Resizes the underlying array
        /// </summary>
        private void Resize()
        {
            T[] temp = new T[array.Length * 2];
            for (int i = 0; i < array.Length; i++)
            {
                temp[i] = array[i];
            }
            array = temp;
        }


        /// <summary>
        /// Moves all array elements one place to the left after a certain index
        /// </summary>
        /// <param name="after">the index after which the shift occures</param>
        private void ShiftLeft(int after)
        {
            for (int i = after; i < array.Length - 1; i++)
            {
                array[i] = array[i + 1];
            }
            array[length - 1] = default(T);
        }

        /// <summary>
        /// Shifts all the elements of the array after a certain index to the right
        /// </summary>
        /// <param name="after">the index after which the shift should happen</param>
        private void ShiftRight(int after)
        {
            for (int i = length; i > after; i--)
            {
                array[i] = array[i - 1];
            }
            array[after] = default(T);
        }
    }
}
