namespace School
{
    using System.Collections.Generic;

    public class School
    {
        private int studentUniqueNumber = 10000;

        private string name;

        private List<Student> students;

        public School(string name)
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
                Validator.IsNullOrWhiteSpace(value, "School");
                this.name = value;
            }
        }

        public void AddStudent(Student student)
        {
            Validator.IsNull(student, "Student");
            student.Number = ++this.studentUniqueNumber;
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