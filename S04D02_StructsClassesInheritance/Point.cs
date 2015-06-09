using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S04D02_StructsClassesInheritance
{
    class Point
    {
        private double positionX;
        private double positionY;


        public Point(double positionX, double positionY)
        {
            this.positionX = positionX;
            this.positionY = positionY;
        }

        public double Distance(Point other)
        {
            double deltaX = this.positionX - other.positionX;
            double deltaY = this.positionY - other.positionY;

            deltaX *= deltaX;
            deltaY *= deltaY;

            double distance = Math.Sqrt((deltaX + deltaY));

            return distance;
        }

        public double GetPositionX()
        {
            return positionX;
        } 

        public double GetPositionY()
        {
            return positionY;
        }

        public void SetPositionX(double positionX)
        {
            this.positionX = positionX;
        }

        public void SetPositionY(double positionY)
        {
            this.positionY = positionY;
        }

        public override string ToString()
        {
            return String.Format("({0}, {1})", positionX, positionY);
        }

        public override bool Equals(object obj)
        {
            Point other = (Point)obj;
            return other.positionX == this.positionX
                && other.positionY == this.positionY;
        }

    }
}
