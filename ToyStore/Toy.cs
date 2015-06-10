using System;


namespace ToyStore
{

    class Toy
    {

        private string name;
        private int ageRestriction;
        private string countryOfOrigin;
        private int yearManufacured;

        private int amount = 1;


        public Toy(string name, int ageRestriction, int yearManufactured) : this(name, ageRestriction, yearManufactured, "China") { }

        public Toy(string name, int ageRestriction, int yearManufactured, string countryOfOrigin)
        {
            this.name = name;
            this.ageRestriction = ageRestriction;
            this.countryOfOrigin = countryOfOrigin;
            this.yearManufacured = yearManufactured;
        }

        public string Name { get { return name; } set { name = value; } }
        public int AgeRestriction { get { return ageRestriction; } }

        public int Amount { get { return amount; } }

        ///<summary>
        /// Checks if the toy is safe for kids over the age sent
        /// as param
        ///</summary>
        ///<param name='age'>The age to check</param>
        ///<returns>True if the age id over the age limit, false otherwise</returns>
        public bool IsAllowedFor(int age)
        {
            if (age >= ageRestriction)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        ///<summary>
        ///Checks if the two objects are equal
        ///
        ///<param name='obj'>The other toy to check</param>
        ///<returns>True if they are equal, false otherwise</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            //check if object is a instance of toy
            if (obj is Toy)
            {
                Toy other = (Toy)obj;
                if (this.name == other.name && this.ageRestriction == other.ageRestriction
                && this.countryOfOrigin == other.countryOfOrigin && this.yearManufacured == other.yearManufacured)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                //if the object is not a toy return false
                return false;
            }
        }

        public override string ToString()
        {
            return String.Format("Name: {0}, Year manufactured: {1}, Age Restriction: {2} , Made in: {3}, Amount: {4}",
            name, yearManufacured, ageRestriction, countryOfOrigin, amount);
        }


        public void IncreaseAmount()
        {
            this.amount++;
        }

        public void DecereaseAmount()
        {
            this.amount--;
        }


    }


    class DynamicArrayToy
    {

        private Toy[] array;
        private int size;

        public DynamicArrayToy()
        {
            this.array = new Toy[1];
            this.size = 0;
        }

        public int Size { get { return size; } }

        public void AddToy(Toy toy)
        {
            if (array.Length >= size)
            {
                Resize();
            }

            int index = IndexOf(toy);
            if (index >= 0)
            {
                array[index].IncreaseAmount();
            }
            else
            {
                array[size++] = toy;
            }
        }

        private void Resize()
        {
            Toy[] temp = new Toy[array.Length * 2];
            for (int i = 0; i < array.Length; i++)
            {
                temp[i] = array[i];
            }
            array = temp;
        }

        private void RemoveElement(int index)
        {
            if (index < 0 || index >= size)
                return;
            for (int i = index; i < size; i++)
            {
                array[i] = array[i + 1];
            }
            array[size - 1] = null;
            size--;
        }

        public void RemoveToy(Toy toy)
        {
            int index = IndexOf(toy);
            if (index == -1)
                throw new ArgumentException("Can't remove a toy we don't have");

            if (array[index].Amount == 1)
            {
                RemoveElement(index);
            }
            else
            {
                array[index].DecereaseAmount();
            }
        }

        private int IndexOf(Toy toy)
        {
            for (int i = 0; i < size; i++)
            {
                if (array[i].Equals(toy))
                {
                    return i;
                }
            }
            return -1;
        }

        public Toy GetElement(int index)
        {
            if (index < 0 || index > size)
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }
            return array[index];
        }

        public bool Contains(Toy toy)
        {
            return IndexOf(toy) >= 0;
        }

    }



    class ToyStore
    {

        private string name;

        private DynamicArrayToy inventory;

        public ToyStore(string name)
        {
            this.name = name;
            this.inventory = new DynamicArrayToy();
        }

        public void PrintInventory()
        {
            for (int i = 0; i < inventory.Size; i++)
            {
                Console.WriteLine(inventory.GetElement(i));
            }
            Console.WriteLine("=====================");
        }

        public void SellToy(Toy toy)
        {
            if (inventory.Contains(toy))
                inventory.RemoveToy(toy);
        }

        public void BuyToy(Toy toy)
        {
            inventory.AddToy(toy);
        }

        public void PrintAllForAge(int age)
        {
            for (int i = 0; i < inventory.Size; i++)
            {
                Toy toy = inventory.GetElement(i);
                if (toy.IsAllowedFor(age))
                {
                    Console.WriteLine(toy);
                }
            }
        }
    }

}