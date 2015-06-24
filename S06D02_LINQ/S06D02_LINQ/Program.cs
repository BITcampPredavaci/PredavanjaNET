using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S06D02_LINQ
{
    class Program
    {

        static void PrintEnumerable<T>(IEnumerable<T> result)
        {
            foreach (T el in result)
            {
                Console.WriteLine(el + " ");
            }
            Console.WriteLine();
        }

        static void LINQSample()
        {
            int[] array = new int[] { 8, 4, 3, 5, 2, 1, 7, 8, 4, 3, 5, 2, 1, 7 };
            IEnumerable<int> lessThan = array.Where(x => x < 5);
            PrintEnumerable(lessThan);
            IEnumerable<int> sortedLess = lessThan.OrderBy(x => x);
            PrintEnumerable(sortedLess);
            IEnumerable<int> sortedDesc = sortedLess.OrderByDescending(x => x);
            PrintEnumerable(sortedDesc);

            IEnumerable<int> sortedSmallNumbers = array.Where(x => x < 5)
                                                        .OrderBy(x => x);

            IEnumerable<int> firstSorted2 = array.OrderBy(x => x).Take(2);
            IEnumerable<int> first2 = array.Take(2).OrderBy(x => x);

            PrintEnumerable(firstSorted2);
            PrintEnumerable(first2);

            List<int> list = new List<int>(array);

            int count = list.Where(x => x < 5).Count();
            Console.WriteLine("Count: " + count);

            IEnumerable<int> smallNumbers = list.Where(x => x < 5).Select(x => x * 2);

            list.Add(3);
            PrintEnumerable(smallNumbers);

            list.Add(2);
            PrintEnumerable(smallNumbers);

            IEnumerable<int> unique = list.Distinct();
            PrintEnumerable(unique);
            PrintEnumerable(array);
        }

        static void LINQSamplePartTwo()
        {
            Random rand = new Random();
            Student[] students = new Student[4];
            students[0] = new Student("Hazim", "Begagic", rand.Next(18, 50));
            students[1] = new Student("Tinka", "Milinovic", rand.Next(18, 50));
            students[2] = new Student("Dejana", "Rosuljas", rand.Next(18, 50));
            students[3] = new Student("Segmedina", "Srna", rand.Next(18, 50));

            Professor[] professors = new Professor[4];
            professors[0] = new Professor("Tarik", "Filipovic", rand.Next(22, 60));
            professors[1] = new Professor("Thomas", "Cormmen", rand.Next(22, 60));
            professors[2] = new Professor("Sheldon", "Cooper", rand.Next(22, 60));
            professors[3] = new Professor("Stephen", "Hawking", rand.Next(22, 60));

            Course[] courses = new Course[9];
            courses[0] = new Course("Intro to Programming", professors[0], "CS101");
            courses[1] = new Course("Algorithms", professors[1], "CS302");
            courses[2] = new Course("Data Structures", professors[1], "CS202");
            courses[3] = new Course("Object Oriented Programming", professors[2], "CS105");
            courses[4] = new Course("Intro to Databases", professors[2], "CS200");
            courses[5] = new Course("Mathemathics", professors[3], "MATH101");
            courses[6] = new Course("Mathemathics", professors[3], "MATH102");
            courses[7] = new Course("String theory", professors[2], "PH101");
            courses[8] = new Course("Quantum Mechanics", professors[3], "PH101");

            
            for (int i = 0; i < students.Length; i++) {
                int j = 0;
                while (j < 6) {
                    int grade = 5 + rand.Next(6);
                    int courseId = rand.Next(9);
                    if (students[i].AddCourse(courses[courseId], grade))
                        j++;
                }
            }

            foreach (Student s in students) {
                Console.WriteLine(s);
            }


        }

        static void InitData(Student[] students, Course[] courses, Professor[] professors)
        {

            Random rand = new Random();
           
            students[0] = new Student("Hazim", "Begagic", rand.Next(18, 50));
            students[1] = new Student("Tinka", "Milinovic", rand.Next(18, 50));
            students[2] = new Student("Dejana", "Rosuljas", rand.Next(18, 50));
            students[3] = new Student("Segmedina", "Srna", rand.Next(18, 50));

            
            professors[0] = new Professor("Tarik", "Filipovic", rand.Next(22, 60));
            professors[1] = new Professor("Thomas", "Cormmen", rand.Next(22, 60));
            professors[2] = new Professor("Sheldon", "Cooper", rand.Next(22, 60));
            professors[3] = new Professor("Stephen", "Hawking", rand.Next(22, 60));

           
            courses[0] = new Course("Intro to Programming", professors[0], "CS101");
            courses[1] = new Course("Algorithms", professors[1], "CS302");
            courses[2] = new Course("Data Structures", professors[1], "CS202");
            courses[3] = new Course("Object Oriented Programming", professors[2], "CS105");
            courses[4] = new Course("Intro to Databases", professors[2], "CS200");
            courses[5] = new Course("Mathemathics", professors[3], "MATH101");
            courses[6] = new Course("Mathemathics", professors[3], "MATH102");
            courses[7] = new Course("String theory", professors[2], "PH101");
            courses[8] = new Course("Quantum Mechanics", professors[3], "PH101");


            for (int i = 0; i < students.Length; i++) {
                int j = 0;
                while (j < 6) {
                    int grade = 5 + rand.Next(6);
                    int courseId = rand.Next(9);
                    if (students[i].AddCourse(courses[courseId], grade))
                        j++;
                }
            }
        }

        static void Main(string[] args)
        {
            Student[] students = new Student[4];
            Course[] courses = new Course[9];
            Professor[] professors = new Professor[4];

            InitData(students, courses, professors);
            
            
            Console.WriteLine("Unique course names: ");
            IEnumerable<string> names = courses.Select(x => x.Name).Distinct();
            PrintEnumerable(names);

            Console.WriteLine("Students and averages: ");
            IEnumerable<string> studentAndAverage = students.Select(x => String.Format("{0}: {1:0.0}",x.Name, x.AverageGrade));
            PrintEnumerable(studentAndAverage);

            Console.WriteLine("Best student name and id: ");
            Student bestStudent = students.First(x => x.AverageGrade == students.Max(y => y.AverageGrade));
            Console.WriteLine(bestStudent.Name + " " + bestStudent.StudentId);

            Console.WriteLine("Worst student name and id: ");
            Student worstStudent = students.First(x => x.AverageGrade == students.Min(y => y.AverageGrade));
            Console.WriteLine(worstStudent.Name + " " + worstStudent.StudentId);

            


        }
    }
}
