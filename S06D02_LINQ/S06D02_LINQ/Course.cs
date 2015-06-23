using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S06D02_LINQ
{
    class Course
    {

        private string name;
        private string professor;

        public Course(string name, string professor)
        {
            this.name = name;
            this.professor = professor;
        }


        public override bool Equals(object obj)
        {
            if (obj is Course) {
                Course other = (Course)obj;
                return this.name == other.name;
            } else {
                return false;
            }
        }


        public override string ToString()
        {
            return String.Format("{0}, {1}", name, professor);
        }



    }
}
