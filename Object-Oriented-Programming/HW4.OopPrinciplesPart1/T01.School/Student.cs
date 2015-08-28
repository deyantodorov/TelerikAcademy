namespace T01.School
{
    using System;
    using System.Linq;
    using Common;
    using T01.School.Contracts;

    public class Student : People, IPeople, IComment
    {
        private int classNumber;

        public Student(string firstName, string middleName, string lastName)
            : base(firstName, middleName, lastName)
        {
        }

        public int ClassNumber
        {
            get
            {
                return this.classNumber;
            }

            set
            {
                Validation.LessThanZero<int>(value, 0, "ClassNumber");
                this.classNumber = value;
            }
        }
    }
}
