namespace School
{
    using System;

    public class Student
    {
        private const int MinNumber = 10000;
        private const int MaxNumber = 99999;

        private const string MessageNumberCanTBeLessThanOrGreaterThan = "Number can't be less than {0} or greater than {1}";

        private string name;
        private int number;

        public Student(string name)
        {
            this.Name = name;
        }

        public int Number
        {
            get
            {
                return this.number;
            }

            set
            {
                if (value < MinNumber || value > MaxNumber)
                {
                    throw new ArgumentOutOfRangeException(string.Format(MessageNumberCanTBeLessThanOrGreaterThan, MinNumber, MaxNumber));
                }

                this.number = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                Validator.IsNullOrWhiteSpace(value, "Student");
                this.name = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Name: {0}, number: {1}", this.Name, this.Number);
        }
    }
}