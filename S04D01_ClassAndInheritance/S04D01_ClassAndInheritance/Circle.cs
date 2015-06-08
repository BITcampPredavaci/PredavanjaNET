using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S04D01_ClassAndInheritance
{
    /// <summary>
    /// A class representing a geomethric circle
    /// </summary>
    class Circle
    {

        private double radius;

        public double Radius
        {
            get
            {
                return radius;
            }
            set
            {
                    radius = value;
            }
        }

        public double Area
        {
            get
            {
                return radius * radius * Math.PI;
            }
        }

        public double Circomference
        {
            get
            {
                return 2 * Math.PI * radius;
            }
        }

        public double Diameter
        {
            get
            {
                return 2 * radius;
            }
        }

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public Circle(Circle other)
        {
            this.radius = other.radius;
        }

        public bool Equals(Circle other)
        {
            return this.radius == other.radius;
        }

        /// <summary>
        /// Returns the string representation of the circle
        /// </summary>
        /// <returns>a string containing all the circle data</returns>
        public override string ToString()
        {
            return String.Format(
                "Radius: {0} \nDiameter: {1} \nArea: {2} \nCircomference: {3}"
                , radius, Diameter, Area, Circomference
                );
        }

    }
}
