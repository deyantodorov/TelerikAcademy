namespace Student
{
    using System;
    using System.Text;
    using Common;

    public class Student : ICloneable, IComparable<Student>
    {
        private const int MinCourse = 1;
        private const int MaxCourse = 6;
        private const int SsnLength = 10;

        private string firstName;
        private string middleName;
        private string lastName;
        private ulong ssn;
        private string permanentAddress;
        private string mobilePhone;
        private string email;
        private int course;

        public Student()
        {
        }

        public Student(string firstName, string middleName, string lastName)
            : this()
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
        }

        public SpecialtyType Specialty { get; set; }

        public UniversityType University { get; set; }

        public FacultyType Faculty { get; set; }

        public int Course
        {
            get
            {
                return this.course;
            }

            set
            {
                Validation.IsInRange(value, "Course", MinCourse, MaxCourse);
                this.course = value;
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }

            set
            {
                Validation.StringIsNullOrEmpty(value, "Email");
                this.email = value;
            }
        }

        public string MobilePhone
        {
            get
            {
                return this.mobilePhone;
            }

            set
            {
                Validation.StringIsNullOrEmpty(value, "Mobile Phone");
                this.mobilePhone = value;
            }
        }

        public string PermanentAddress
        {
            get
            {
                return this.permanentAddress;
            }

            set
            {
                Validation.StringIsNullOrEmpty(value, "Permanent Address");
                this.permanentAddress = value;
            }
        }

        public ulong Ssn
        {
            get
            {
                return this.ssn;
            }

            set
            {
                Validation.LessThan<ulong>(value, SsnLength, "Ssn");
                this.ssn = value;
            }
        }

        public string FullName
        {
            get
            {
                return string.Format("{0} {1} {2}", this.FirstName, this.MiddleName, this.LastName);
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                Validation.StringIsNullOrEmpty(value, "LastName");
                this.lastName = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return this.middleName;
            }

            set
            {
                Validation.StringIsNullOrEmpty(value, "MiddleName");
                this.middleName = value;
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
                Validation.StringIsNullOrEmpty(value, "FirstName");
                this.firstName = value;
            }
        }

        public static bool operator ==(Student first, Student second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(Student first, Student second)
        {
            return !first.Equals(second);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var property in this.GetType().GetProperties())
            {
                // Using Reflection I get property value
                var value = GetType().GetProperty(property.Name).GetValue(this, null);

                if (value != null && value.ToString() != "0")
                {
                    sb.AppendLine(string.Format("{0}: {1}", property.Name, GetType().GetProperty(property.Name).GetValue(this, null)));
                }
            }

            return sb.ToString();
        }

        public override bool Equals(object param)
        {
            Student student = param as Student;

            if (!object.Equals(this.FirstName, student.FirstName))
            {
                return false;
            }

            if (!object.Equals(this.MiddleName, student.MiddleName))
            {
                return false;
            }

            if (!object.Equals(this.LastName, student.LastName))
            {
                return false;
            }

            if (!object.Equals(this.Ssn, student.Ssn))
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return this.FullName.GetHashCode() ^ this.Ssn.GetHashCode();
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public Student Clone()
        {
            Student newStudent = new Student
            {
                FirstName = this.FirstName,
                MiddleName = this.MiddleName,
                LastName = this.LastName,
                Ssn = this.Ssn,
                PermanentAddress = this.PermanentAddress,
                MobilePhone = this.MobilePhone,
                Email = this.Email,
                Course = this.Course,
                Faculty = this.Faculty,
                University = this.University,
                Specialty = this.Specialty
            };

            return newStudent;
        }

        public int CompareTo(Student other)
        {
            int result = this.FirstName.CompareTo(other.FirstName);
            result = this.MiddleName.CompareTo(other.MiddleName);
            result = this.LastName.CompareTo(other.LastName);

            if (result == 0)
            {
                result = this.Ssn.CompareTo(other.Ssn);
            }

            return result;
        }
    }
}
