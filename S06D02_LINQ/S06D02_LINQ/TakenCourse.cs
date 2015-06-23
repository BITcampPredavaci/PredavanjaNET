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


        public TakenCourse(Course course, Student student)
            : this(course, student, 0)
        {
        }

        public TakenCourse(Course course, Student student, int grade)
        {
            this.course = course;
            this.student = student;
            this.grade = grade;
        }

        public Course Course { get { return course; } }
        public int Grade
        {
            get { return grade; }
            set
            {
                if (value > 4 && value < 11)
                    grade = value;
            }
        }

        public override string ToString()
        {
            return String.Format("Course: {0}, Grade: {1}", course, grade);
        }

        public override bool Equals(object obj)
        {
            if (obj is TakenCourse) {
                TakenCourse other = (TakenCourse)obj;
                if (this.student.Equals(other.student)
                    && this.course.Equals(other.course))
                    return true;
                else
                    return false;
            } else {
                return false;
            }
        }

    }
}
