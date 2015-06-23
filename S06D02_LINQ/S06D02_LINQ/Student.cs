using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S06D02_LINQ
{
    class Student
    {

        private static int STUDENT_COUNT = 1;

        private string name;
        private string lastName;
        private int studentId;
        private List<TakenCourse> courses;

        public double AverageGrade { get { return GetAverageGrade(); } }
        public string Name { get { return name; } }

        public int StudentId { get { return studentId; } }


        public Student(string name, string lastName)
        {
            this.name = name;
            this.lastName = lastName;
            this.studentId = STUDENT_COUNT++;
            this.courses = new List<TakenCourse>();
        }

        public bool AddCourse(Course c)
        {
            return AddCourse(c, 0);
        }

        public bool AddCourse(Course c, int grade)
        {
            TakenCourse newCourse = new TakenCourse(c, this, grade);
            if (courses.Contains(newCourse) == false) {
                courses.Add(newCourse);
                return true;
            } else {
                return false;
            }
        }

        public void ChangeGrade(Course c, int grade)
        {
            TakenCourse toChange = courses.Find(tc => tc.Course.Equals(c));
            if (toChange != null) {
                toChange.Grade = grade;
            } else {
                throw new ArgumentException("Can't change non existing grade");
            }
        }


        private double GetAverageGrade()
        {
            return courses.Average(tc => tc.Grade);
        }


        public override bool Equals(object obj)
        {
            if (obj is Student) {
                Student other = (Student)obj;
                return this.studentId == other.studentId;
            } else {
                return false;
            }
        }

        public override string ToString()
        {
            string output = name + " " + lastName + " Avrg: " + GetAverageGrade();
            output += "\nGrades: \n";
            foreach (TakenCourse tc in courses) {
                output += tc + "\n";
            }
            return output;
        }

    }
}
