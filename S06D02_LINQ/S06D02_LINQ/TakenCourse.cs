using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S06D02_LINQ
{
    class TakenCourse
    {

        private Course course;
        private Student student;
        private int grade;


        public TakenCourse(Course course, Student student) : this(course, student, 0)
        {
        }

        public TakenCourse(Course course, Student student, int grade)
        {
            this.course = course;
            this.student = student;
            this.grade = grade;
        }

    }
}
