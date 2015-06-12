using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S04D05_NestedAndGenerics
{
    interface ICompareArea<T> where T : Body
    {
        /// <summary>
        /// Return true 
        /// if area of a is larger then area of b
        /// </summary>
        /// <param name="a">object of type body</param>
        /// <param name="b">object of type body</param>
        /// <returns></returns>
        bool CompareArea(T a, T b);
    }

    class Body : ICompareArea<Body>
    {
        public virtual double GetArea()
        {
            return 0;
        }

        public virtual bool CompareArea(Body a, Body b)
        {
            return false;
        }
    }

    class Square : Body
    {
        private int side;

        public Square(int side)
        {
            this.side = side;
        }

        public override double GetArea()
        {
            return side * side;
        }

        public override bool CompareArea(Body a, Body b)
        {
            if (a.GetArea() > b.GetArea())
                return true;
            else
                return false;
        }
    }

    class Circle : Body
    {
        private int radius;

        public Circle(int radius)
        {
            this.radius = radius;
        }

        public override double GetArea()
        {
            return Math.PI * radius * radius;
        }

        public override bool CompareArea(Body a, Body b)
        {
            if (a.GetArea() > b.GetArea())
                return true;
            else
                return false;
        }
    }
}
