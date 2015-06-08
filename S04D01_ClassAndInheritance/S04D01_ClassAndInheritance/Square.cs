using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S04D01_ClassAndInheritance
{
    class Square
    {

        private int side;


        public Square(int side)
        {
            this.side = side;
        }

        public int GetSide()
        {
            return side;
        }

        public void SetSide(int side)
        {
            if (side < 0)
                throw new ArgumentOutOfRangeException("Side can't be less than 0");
            this.side = side;
        }

        public virtual int Area()
        {
            return side * side;
        }

        public virtual int Circomference()
        {
            return 4 * side;
        }

        public override string ToString()
        {
            return String.Format(
                "Area: {0}, Circomference: {1}"
                , Area(), Circomference()
                );
        }

    }


    class Rectangle : Square
    {
        private int sideB;

        public int SideB
        {
            get
            {
                return sideB;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Side can't be less than 0");
            }
        }


        public Rectangle(int sideA, int sideB) : base(sideA)
        {
            this.sideB = sideB;
        }

        public override int Area(){
            base.Area();   
            return base.GetSide() * this.sideB;
        }


        public override int Circomference()
        {
            return 2 * GetSide() + 2 * this.sideB;
        }
    }
}
