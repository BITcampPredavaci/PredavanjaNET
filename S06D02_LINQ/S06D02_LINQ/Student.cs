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

        public int AverageGrade { get { return GetAverageGrade(); } }
        public string Name { get { return name; } }

        public int StudentId { get { return studentId; } }


        public Student(string name, string lastName)
        {
            this.name = name;
            this.lastName = lastName;
            this.studentId = STUDENT_COUNT++;
            this.courses = new List<TakenCourse>();
        }


       


        private int GetAverageGrade()
        {
            return 0;
        }

  

    }
}
