namespace T01.StudentSystem
{
    public class Student
    {
        public Student(string firstName, string lastName, string course)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Course = course;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Course { get; private set; }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", this.FirstName, this.LastName, this.Course);
        }
    }
}
