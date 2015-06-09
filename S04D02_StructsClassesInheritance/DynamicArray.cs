using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S04D02_StructsClassesInheritance
{
    class DynamicArray
    {
        private Body[] array;
        private int size;

        public int Size { 
            get { return size; }
        }

        public bool IsEmpty
        {
            get { return size == 0;  }
        }

        public DynamicArray()
        {
            this.size = 0;
            this.array = new int[4];
        }

        public void AddElement(int element)
        {
            if (array.Length == size)
            {
                Resize();
            }
            array[size] = element;
            size++;
        }

        public bool RemoveElement(int index)
        {
            if (index < 0 || index > size-1)
                return false;

            //move all elements > index to the left
            for (int i = index; i < size; i++)
            {
                array[i] = array[i + 1];
            }
            array[size - 1] = 0;
            size--;
            return true;
        }

        public override string ToString()
        {
            string arrayAsString = "";
            for (int i = 0; i < size; i++)
            {
                arrayAsString += array[i];
                if(i < size-1)
                    arrayAsString += ", ";
            }
            return arrayAsString;
        }

        public bool Equals(DynamicArray other)
        {
            if (this.size != other.size)
                return false;
            for (int i = 0; i < size; i++)
            {
                if (this.array[i] != other.array[i])
                {
                    return false;
                }
            }
            return true;
        }

        public int Get(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new ArgumentOutOfRangeException("Index out of range");
            }
            return array[index];
        }

        private void Resize()
        {
            int[] temp = new int[2 * array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                temp[i] = array[i];
            }
            array = temp;
        }

    }
}
