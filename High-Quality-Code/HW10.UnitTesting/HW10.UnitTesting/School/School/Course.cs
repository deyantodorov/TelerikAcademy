namespace School
{
    using System;
    using System.Collections.Generic;

    public class Course
    {
        private const int MaxStudentNumber = 30;

        private string name;
        private readonly List<Student> students;

        public Course(string name)
        {
            this.Name = name;
            this.students = new List<Student>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                Validator.IsNullOrWhiteSpace(value, "Course");
                this.name = value;
            }
        }

        public void AddStudent(Student student)
        {
            Validator.IsNull(student, "Student");

            if (this.students.Count == MaxStudentNumber)
            {
                throw new ArgumentOutOfRangeException("Can't add more than" + MaxStudentNumber + " students");
            }

            this.students.Add(student);
        }


        public void RemoveStudent(Student student)
        {
            Validator.IsNull(student, "Student");
            this.students.Remove(student);
        }

        public int NumberOfStudents()
        {
            return this.students.Count;
        }
    }
}