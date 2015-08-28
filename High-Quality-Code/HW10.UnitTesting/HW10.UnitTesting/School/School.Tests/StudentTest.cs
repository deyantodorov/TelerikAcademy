namespace School.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        public void Student_Create_Exist()
        {
            string name = "New School Name";
            var student = new Student(name);

            Assert.AreEqual(name, student.Name, "Student name doesn't exist. Something is wrong with Course creation");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Student_WrongName_Exception()
        {
            var student = new Student(" ");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Student_NumberBelowMin_Exception()
        {
            var student = new Student("Ivan Ivanov") { Number = 1 };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Student_NumberAboveMax_Exception()
        {
            var student = new Student("Ivan Ivanov") { Number = 123123123 };
        }

        [TestMethod]
        public void Student_GetNumber()
        {
            var number = 12345;

            var student = new Student("Ivan Ivanov");
            student.Number = number;

            Assert.AreEqual(number, student.Number, "Student number can not be taken");
        }

        [TestMethod]
        public void Student_ToString()
        {
            var number = 12345;
            var name = "Ivan Ivanov";

            var student = new Student(name)
            {
                Number = number
            };

            Assert.AreEqual(string.Format("Name: {0}, number: {1}", name, number), student.ToString(), "Student ToString doesn't work");
        }
    }
}