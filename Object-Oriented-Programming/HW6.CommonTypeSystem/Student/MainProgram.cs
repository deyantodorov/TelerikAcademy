namespace Student
{
    using System;

    /// <summary>
    /// Problem 1. Student class
    ///            Define a class Student, which contains data about a student – first, middle and last name, SSN, permanent address, mobile phone e-mail, course, 
    ///            specialty, university, faculty. Use an enumeration for the specialties, universities and faculties.
    ///            Override the standard methods, inherited by System.Object: Equals(), ToString(), GetHashCode() and operators == and !=.
    ///            
    /// Problem 2. IClonable
    ///            Add implementations of the ICloneable interface. The Clone() method should deeply copy all object's fields into a new object of type Student
    ///            
    /// Problem 3. IComparable
    ///            Implement the IComparable<Student> interface to compare students by names (as first criteria, in lexicographic order) and by social security number (as second criteria, 
    ///            in increasing order).
    /// </summary>
    public class MainProgram
    {
        private static void Main()
        {
            Student ivan = new Student
            {
                FirstName = "Ivan",
                MiddleName = "Ivanov",
                LastName = "Ivanov",
                Ssn = 1231231231,
                PermanentAddress = "Bulgaria, Sofia 1000, Minzuhar str. 123",
                MobilePhone = "+359887123123",
                Email = "ivancho@abv.bg",
                Course = 2,
                Faculty = FacultyType.Culture,
                University = UniversityType.Private,
                Specialty = SpecialtyType.Bachelor
            };

            Student pesho = new Student
            {
                FirstName = "Pesho",
                MiddleName = "Peshev",
                LastName = "Peshov",
                Ssn = 9999999999,
                PermanentAddress = "Bulgaria, Sofia 1000, Kokiche str. 321",
                MobilePhone = "+359889321321",
                Email = "pishko@abv.bg",
                Course = 2,
                Faculty = FacultyType.Economic,
                University = UniversityType.Public,
                Specialty = SpecialtyType.Doctor
            };

            Console.WriteLine(ivan);
            Console.WriteLine(pesho);

            Console.WriteLine("Equals: {0}", pesho.Equals(ivan));
            Console.WriteLine("GetHashCode() {0} {1}", "pesho", pesho.GetHashCode());
            Console.WriteLine("GetHashCode() {0} {1}", "ivan", ivan.GetHashCode());

            Console.WriteLine("pesho == ivan {0}", pesho == ivan);
            Console.WriteLine("pesho != ivan {0}", pesho != ivan);

            Student mircho = pesho.Clone();
            mircho.FirstName = "Mircho";
            mircho.MiddleName = "Mirchev";
            mircho.LastName = "Mirchev";
            mircho.Ssn = 9999999999;
            Console.WriteLine("GetHashCode() {0} {1}", "mircho", mircho.GetHashCode());

            Console.WriteLine("Compare: mircho and pesho = " + mircho.CompareTo(pesho));
            Console.WriteLine("Compare: mircho and mircho = " + mircho.CompareTo(mircho));
        }
    }
}