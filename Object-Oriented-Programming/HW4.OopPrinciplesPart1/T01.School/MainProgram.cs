namespace T01.School
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;

    /// <summary>
    /// Here is my logic if ClassDiagram is not' clear:
    /// 
    /// class School
    ///     contains class Classes
    ///         class Classes contains 
    ///             HashSet - Students - this way I guarantee uniquee students
    ///             HashSet - Teachers - this way I guarantee uniquee teachers
    /// 
    /// abstract People
    ///         class Teacher
    ///             HashSet - Disciplines - this way I guarantee uniquee disciplines
    ///         class Student
    /// 
    /// class Description
    /// 
    /// IPeople - interface for People
    ///     IPeople: inherits IComment, cause if I work by Interface property Comment isn't accessible.
    /// 
    /// IComment - interface for all comentable items
    /// 
    /// All properties and fields by task description are set ... I think :)
    /// </summary>
    public class MainProgram
    {
        private static void Main()
        {
            // Generate random students, teachers, disciplines
            List<Student> students = GenerateStudent(10);
            List<Teacher> teachers = GenerateTeacher(10);
            List<Discipline> disciplines = GenerateDiscriplines(10);

            // Add discriplines to teachers
            AddDisciplineToTeacher(teachers, disciplines);

            // Create two classes and add students and teachers 
            List<Classes> classes = new List<Classes>();
            AddStuentsAndTeachersToClasses(students, teachers, classes);

            // Create school and add classes to it
            School school = new School();

            foreach (var item in classes)
            {
                school.Classes.Add(item);
            }

            // See result in debug mode
            Console.ReadKey();
        }

        private static void AddStuentsAndTeachersToClasses(List<Student> students, List<Teacher> teachers, List<Classes> classes)
        {
            int numberInClass = 1;

            // Example for first class
            Classes myClass1 = new Classes();
            myClass1.TextIdentifier = TextIdentifier.A;

            for (int i = 0; i < teachers.Count / 2; i++)
            {
                myClass1.Teachers.Add(teachers[i]);

                students[i].ClassNumber = numberInClass;
                myClass1.Students.Add(students[i]);
                numberInClass++;
            }

            classes.Add(myClass1);
            numberInClass = 1;

            // Example for second class
            Classes myClass2 = new Classes();
            myClass1.TextIdentifier = TextIdentifier.B;

            for (int i = teachers.Count / 2; i < teachers.Count; i++)
            {
                myClass2.Teachers.Add(teachers[i]);

                students[i].ClassNumber = numberInClass;
                myClass2.Students.Add(students[i]);
                numberInClass++;
            }

            classes.Add(myClass2);
        }

        private static void AddDisciplineToTeacher(List<Teacher> teachers, List<Discipline> disciplines)
        {
            if (disciplines.Count < teachers.Count)
            {
                return;
            }
            else
            {
                for (int i = 0; i < teachers.Count; i++)
                {
                    teachers[i].Disciplines.Add(new Discipline(disciplines[i].Name, disciplines[i].NumberOfLectures, disciplines[i].NumberOfExercises));
                }
            }
        }

        private static List<Discipline> GenerateDiscriplines(int count)
        {
            List<Discipline> data = new List<Discipline>();

            for (int i = 0; i < count; i++)
            {
                string name = GenerateRandom.Text(GenerateRandom.Number(5, 15));
                int numberOfLectures = GenerateRandom.Number(10, 50);
                int numberOfExercises = GenerateRandom.Number(10, 30);

                Discipline discipline = new Discipline(name, numberOfLectures, numberOfExercises);
                data.Add(discipline);
            }

            return data;
        }

        private static List<Student> GenerateStudent(int count)
        {
            List<Student> data = new List<Student>();

            for (int i = 0; i < count; i++)
            {
                string firstName = GenerateRandom.Text(GenerateRandom.Number(3, 12));
                string middleName = GenerateRandom.Text(GenerateRandom.Number(3, 12));
                string lastName = GenerateRandom.Text(GenerateRandom.Number(3, 12));

                Student student = new Student(firstName, middleName, lastName);
                data.Add(student);
            }

            return data;
        }

        private static List<Teacher> GenerateTeacher(int count)
        {
            List<Teacher> data = new List<Teacher>();

            for (int i = 0; i < count; i++)
            {
                string firstName = GenerateRandom.Text(GenerateRandom.Number(3, 12));
                string middleName = GenerateRandom.Text(GenerateRandom.Number(3, 12));
                string lastName = GenerateRandom.Text(GenerateRandom.Number(3, 12));

                Teacher teacher = new Teacher(firstName, middleName, lastName);
                data.Add(teacher);
            }

            return data;
        }
    }
}