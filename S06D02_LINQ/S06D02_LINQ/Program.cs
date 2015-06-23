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
            Student[] students = new Student[4];
            students[0] = new Student("Hazim", "Begagic");
            students[1] = new Student("Tinka", "Milinovic");
            students[2] = new Student("Dejana", "Rosuljas");
            students[3] = new Student("Segmedina", "Srna");

            Course[] courses = new Course[8];
            courses[0] = new Course("Intro to Programming", "Tarik Filipovic");
            courses[1] = new Course("Algorithms", "Thomas");
            courses[2] = new Course("Data Structures", "Oliver Mlakar");
            courses[3] = new Course("Object Oriented Programming", "Emerik Gudelj");
            courses[4] = new Course("Intro to Databases", "Bruce Lee");
            courses[5] = new Course("Mathemathics", "Harry Miller");
            courses[6] = new Course("String theory", "Sheldon Cooper");
            courses[7] = new Course("Quantum Mechanics", "Stephen Hawking");

            Random rand = new Random();
            for (int i = 0; i < students.Length; i++) {
                int j = 0;
                while (j < 6) {
                    int grade = 5 + rand.Next(6);
                    int courseId = rand.Next(8);
                    if (students[i].AddCourse(courses[courseId], grade))
                        j++;
                }
            }

            foreach (Student s in students) {
                Console.WriteLine(s);
            }


            IEnumerable<string> filter = students
                .Where(x => x.GetGrade("Intro to Programming") > 7
                 || x.GetGrade("Mathemathics") > 6)
                .Select(x => x.Name)
                .OrderBy(x => x);

            PrintEnumerable(filter);

            List<string> best2 = students
                .OrderByDescending(x => x.AverageGrade)
                .Take(2)
                .Select(x => x.Name)
                .ToList();
            List<string> worst2 = students
                .OrderBy(x => x.AverageGrade)
                .Take(2)
                .Select(x => x.Name)
                .ToList();

            Console.WriteLine("Best 2: ");
            PrintEnumerable(best2);

            Console.WriteLine("Worst 2: ");
            PrintEnumerable(worst2);
        }

        static void InitData(Student[] students, Course[] courses)
        {
           
            students[0] = new Student("Hazim", "Begagic");
            students[1] = new Student("Tinka", "Milinovic");
            students[2] = new Student("Dejana", "Rosuljas");
            students[3] = new Student("Segmedina", "Srna");

           
            courses[0] = new Course("Intro to Programming", "Tarik Filipovic");
            courses[1] = new Course("Algorithms", "Thomas");
            courses[2] = new Course("Data Structures", "Oliver Mlakar");
            courses[3] = new Course("Object Oriented Programming", "Emerik Gudelj");
            courses[4] = new Course("Intro to Databases", "Bruce Lee");
            courses[5] = new Course("Mathemathics", "Harry Miller");
            courses[6] = new Course("String theory", "Sheldon Cooper");
            courses[7] = new Course("Quantum Mechanics", "Stephen Hawking");

            Random rand = new Random();
            for (int i = 0; i < students.Length; i++) {
                int j = 0;
                while (j < 6) {
                    int grade = 5 + rand.Next(6);
                    int courseId = rand.Next(8);
                    if (students[i].AddCourse(courses[courseId], grade))
                        j++;
                }
            }
        }

        static void Main(string[] args)
        {
            Student[] students = new Student[4];
            Course[] courses = new Course[8];

            InitData(students, courses);
            PrintEnumerable(students);

            PrintEnumerable(courses);
            Console.WriteLine("Pick a course: " );
            int coursePosition = Convert.ToInt16(Console.ReadLine());
           
            Course selected = courses[coursePosition-1];

            List<string> best2 = students
                .Where(x => x.GetGrade(selected.Name) > -1)
                .OrderByDescending(x => x.AverageGrade)
                .Take(2)
                .Select(x => x.Name).ToList();

            Console.WriteLine("Best 2 students taking " + selected.Name);
            PrintEnumerable(best2);

            List<string> bestGrade = students
                .Where(x => x.GetGrade(selected.Name) > -1)
                .OrderByDescending(x => x.GetGrade(selected.Name))
                .Take(1)
                .Select(x => x.Name).ToList();
            Console.WriteLine("Best grade in " + selected.Name);
            Console.WriteLine(bestGrade.First());





            

        }
    }
}
