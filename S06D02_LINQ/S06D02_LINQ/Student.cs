using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S06D02_LINQ
{
    /// <summary>
    /// Class represents a student
    /// </summary>
    class Student
    {

        private static int STUDENT_COUNT = 1;

        private string name;
        private string lastName;
        private int studentId;
        private List<TakenCourse> courses;

        /// <summary>
        /// Student's average grade
        /// </summary>
        public double AverageGrade { get { return GetAverageGrade(); } }
       
        /// <summary>
        /// Student's name
        /// </summary>
        public string Name { get { return name; } }

        public string LastName { get { return lastName; } }

        /// <summary>
        /// Student's ID
        /// </summary>
        public int StudentId { get { return studentId; } }

        /// <summary>
        /// Student constructor, the student ID is automathicaly generated
        /// </summary>
        /// <param name="name">name of the student</param>
        /// <param name="lastName">last name of the student</param>
        public Student(string name, string lastName)
        {
            this.name = name;
            this.lastName = lastName;
            this.studentId = STUDENT_COUNT++;
            this.courses = new List<TakenCourse>();
        }

        /// <summary>
        /// Adds a course with default grade to the
        /// list of courses the student has passed
        /// </summary>
        /// <param name="c">The course to add</param>
        /// <returns>true if the course is added, false otherwise</returns>
        public bool AddCourse(Course c)
        {
            return AddCourse(c, 0);
        }

        // <summary>
        /// Adds a course with the grade to the
        /// list of courses the student has passed
        /// </summary>
        /// <param name="c">The course to add</param>
        /// <param name="grade">The grade the student got</param>
        /// <returns>true if the course is added, false otherwise</returns>
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

        /// <summary>
        /// If the student has taken the course specified the grade
        /// is changed to the provided grade
        /// </summary>
        /// <param name="c">The course</param>
        /// <param name="grade">The grade</param>
        /// <exception cref="ArgumentException">If the course is not taken by the
        /// student</exception>
        public void ChangeGrade(Course c, int grade)
        {
            TakenCourse toChange = courses.Find(tc => tc.Course.Equals(c));
            if (toChange != null) {
                toChange.Grade = grade;
            } else {
                throw new ArgumentException("Can't change non existing grade");
            }
        }

        /// <summary>
        /// Calculates and returns the average grade for the student
        /// </summary>
        /// <returns>average grade</returns>
        private double GetAverageGrade()
        {
            return courses.Average(tc => tc.Grade);
        }

        /// <summary>
        /// Gets the grade the student got for a specific course
        /// </summary>
        /// <param name="courseName">the name of the course</param>
        /// <returns>the name the student got, -1 if the student
        /// did not take the course</returns>
         public int GetGrade(string courseName)
        {
            TakenCourse course = 
                courses.Find(x => x.Course.Name == courseName);
            if (course != null)
                return course.Grade;
            else
                return -1;
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
