using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_2_Stack
{
    class Queue<T>
    {

        private T[] array;
        private int length;

        public int Length { get { return length; } }

        public Queue()
        {
            this.array = new T[1];
            this.length = 0;
        }


        /// <summary>
        /// Adds element to queue
        /// </summary>
        /// <param name="element">the element to add</param>
        public void Push(T element)
        {
            if (array.Length == length)
            {
                Resize();
            }

            array[length++] = element;
        }

        /// <summary>
        /// Returns the value of the first element
        /// </summary>
        /// <returns>the first element</returns>
        public T Peek()
        {
            if (length < 1)
                throw new ArgumentOutOfRangeException("Queue is empty");
            return array[0];
        }


        /// <summary>
        /// Returns the first element and removes it from the queue
        /// </summary>
        /// <returns>the first element</returns>
        public T Pop()
        {
            if (length < 1)
                throw new ArgumentOutOfRangeException("Queue is empty");
            T element = array[0];
            ShiftLeft();
            length--;
            return element;
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
        /// Moves all array elements one place to the left
        /// </summary>
        private void ShiftLeft()
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                array[i] = array[i + 1];
            }
            array[length - 1] = default(T);
        }

    }
}
