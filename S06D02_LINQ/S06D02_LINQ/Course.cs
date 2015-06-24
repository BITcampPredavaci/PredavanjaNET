using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S06D02_LINQ
{
    /// <summary>
    /// Represents a single course
    /// </summary>
    class Course
    {

        private string name;
        private Professor professor;
        private string courseCode;

        /// <summary>
        /// Name of the course
        /// </summary>
        public string Name { get { return name; } }
        public string CourseCode { get { return courseCode; } }

        public Course(string name, Professor professor, string courseCode)
        {
            this.name = name;
            this.courseCode = courseCode;
            this.professor = professor;
            this.professor.AddCourse(this);
        }


        public override bool Equals(object obj)
        {
            if (obj is Course) {
                Course other = (Course)obj;
                return this.courseCode == other.courseCode;
            } else {
                return false;
            }
        }

       


        public override string ToString()
        {
            return String.Format("Name: {0}, Code: {1} ", name, courseCode );
        }



    }
}
