namespace T10.EmployeeData
{
    using System;

    public class Employee
    {
        private const int MinAge = 0;
        private const int MaxAge = 100;
        private const int PersonalIdLength = 10;
        private const int MinEmployee = 27560000;
        private const int MaxEmployee = 27569999;

        private string firstName;
        private string lastName;
        private int age;
        private GenderType gender;
        private long personalId;
        private int employeeNumber;

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                TestString(value);
                this.lastName = value;
            }
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                TestString(value);
                this.firstName = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }

            set
            {
                if (value < MinAge || value > MaxAge)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Invalid value {0}", value));
                }

                this.age = value;
            }
        }

        public GenderType Gender
        {
            get
            {
                return this.gender;
            }

            set
            {
                this.gender = value;
            }
        }

        public long PersonalId
        {
            get
            {
                return this.personalId;
            }

            set
            {
                if (value.ToString().Length != PersonalIdLength)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Invalid value {0}", value));
                }

                this.personalId = value;
            }
        }

        public int EmployeeNumber
        {
            get
            {
                return this.employeeNumber;
            }

            set
            {
                if (value < MinEmployee || value > MaxEmployee)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Invalid value {0}", value));
                }

                this.employeeNumber = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4} {5}", this.FirstName, this.LastName, this.Age, this.Gender, this.PersonalId, this.EmployeeNumber);
        }

        private void TestString(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(string.Format("Incorrect value {0}", value));
            }
        }
    }
}
