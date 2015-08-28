namespace T02.StudentsAndWorkers
{
    using System;
    using T02.StudentsAndWorkers.Contracts;

    public class Student : Human, IHuman
    {
        public Student(string firstName, string lastName)
            : base(firstName, lastName)
        {
        }

        public Grade Grade { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, grade: {1}", base.ToString(), this.Grade);
        }
    }
}