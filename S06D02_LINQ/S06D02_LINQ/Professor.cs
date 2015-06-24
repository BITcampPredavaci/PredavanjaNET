using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S06D02_LINQ
{
    class Professor : Person
    {

        private List<Course> coursesTaught;

        public List<Course> CoursesTaught { get { return coursesTaught; } }
        public Professor(string name, string lastName, int age)
            : base(name, lastName, age)
        {
            this.coursesTaught = new List<Course>();
        }


        public void AddCourse(Course c)
        {
            if (coursesTaught.Contains(c) == false)
                coursesTaught.Add(c);
        }

        public override string ToString()
        {
            string output = base.ToString();
            output += "===Courses===";
            foreach (Course c in coursesTaught)
                output += c.Name + " " + c.CourseCode + "\n";
            return output;
        }

    }
}
