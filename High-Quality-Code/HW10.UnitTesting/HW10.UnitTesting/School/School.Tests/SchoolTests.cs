namespace School.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SchoolTests
    {
        private const string TestSchoolName = "New School Name";

        [TestMethod]
        public void School_Create_Exists()
        {

            var school = new School(TestSchoolName);

            Assert.AreEqual(TestSchoolName, school.Name, "School name doesn't exist. Something is wrong with School creation");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void School_WrongName_ArgumentNullException()
        {
            var school = new School(" ");
        }

        [TestMethod]
        public void School_Add_Student()
        {
            var school = new School(TestSchoolName);
            var student = new Student("Ivan Ivanov");

            school.AddStudent(student);

            Assert.AreEqual(1, school.NumberOfStudents(), "Can't add Student in School");
        }

        [TestMethod]
        public void School_Remove_Student()
        {
            var school = new School(TestSchoolName);
            var student = new Student("Ivan Ivanov");

            school.AddStudent(student);
            school.RemoveStudent(student);

            Assert.AreEqual(0, school.NumberOfStudents(), "Can't remove Student from School");
        }
    }
}
