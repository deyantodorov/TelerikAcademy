namespace School.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CourseTest
    {
        [TestMethod]
        public void Course_Create_Exist()
        {
            string name = "New Course Name";
            var course = new Course(name);

            Assert.AreEqual(name, course.Name, "Course name doesn't exist. Something is wrong with Course creation");
        }

        [TestMethod]
        public void Course_Add_Student()
        {
            string courseName = "New course name";
            var studentName = "Ivan Ivanov";

            var course = new Course(courseName);
            var student = new Student(studentName);

            course.AddStudent(student);

            Assert.AreEqual(1, course.NumberOfStudents(), "Studen could not be added");
        }

        [TestMethod]
        public void Course_Remove_Student()
        {
            string courseName = "New course name";
            var studentName = "Ivan Ivanov";

            var course = new Course(courseName);
            var student = new Student(studentName);

            course.AddStudent(student);
            course.RemoveStudent(student);

            Assert.AreEqual(0, course.NumberOfStudents(), "Studen could not be removed");
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Course_AddFake_Student()
        {
            var course = new Course("New course");
            course.AddStudent(null);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Course_RemoveFake_Student()
        {
            var course = new Course("New course");
            course.RemoveStudent(null);
        }
    }
}
