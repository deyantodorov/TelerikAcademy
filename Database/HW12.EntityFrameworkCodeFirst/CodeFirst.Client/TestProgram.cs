namespace CodeFirst.Client
{
    using System;
    using System.Linq;
    using CodeFirst.Data;

    public class TestProgram
    {
        private static readonly StudentSystemContext Context = new StudentSystemContext();

        private static void Main()
        {
            ListAllStudents();

            ListAllCourses();

            LisAllCoursesAndStudents();

            Console.WriteLine("Informatin created in Sql Server");
        }

        private static void LisAllCoursesAndStudents()
        {
            var allCourses = Context.Courses.ToList();

            foreach (var course in allCourses)
            {
                Console.WriteLine("{0}-{1}", course.Name, course.Description);
                Console.WriteLine("Students in this course:");
                foreach (var student in course.Students)
                {
                    Console.WriteLine("-{0} - {1}", student.Name, student.FacultyNumber);
                }
            }
        }

        private static void ListAllStudents()
        {
            var allStudents = Context.Students.ToList();

            foreach (var student in allStudents)
            {
                Console.WriteLine("{0} - {1}", student.Name, student.FacultyNumber);
            }
        }

        private static void ListAllCourses()
        {
            var allCourses = Context.Courses.ToList();

            foreach (var course in allCourses)
            {
                Console.WriteLine("{0}-{1}", course.Name, course.Description);
            }
        }
    }
}
