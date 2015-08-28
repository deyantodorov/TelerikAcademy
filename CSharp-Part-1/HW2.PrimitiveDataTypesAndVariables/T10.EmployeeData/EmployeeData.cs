namespace T10.EmployeeData
{
    using System;
    
    /// <summary>
    /// 10. A marketing company wants to keep record of its employees. Each record would have the following characteristics:
    ///     First name
    ///     Last name
    ///     Age (0...100)
    ///     Gender (m or f)
    ///     Personal ID number (e.g. 8306112507)
    ///     Unique employee number (27560000…27569999)
    /// </summary>
    public class EmployeeData
    {
        private static void Main()
        {
            // I'm using created object employee with properties
            var employee = new Employee();
            employee.FirstName = "Ivan";
            employee.LastName = "Goshov";
            employee.Age = 23;
            employee.Gender = GenderType.M;
            employee.PersonalId = 8306112507;
            employee.EmployeeNumber = 27560000;

            // overrided ToString() method print information correctly
            Console.WriteLine(employee);
        }
    }
}