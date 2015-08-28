namespace SoftwareAcademy
{
    using System;
    using System.Linq;
    using SoftwareAcademy.Contracts;

    public class CourseFactory : ICourseFactory
    {
        public ITeacher CreateTeacher(string name)
        {
            ITeacher teacher = new Teacher(name);
            return teacher;
        }

        public ILocalCourse CreateLocalCourse(string name, ITeacher teacher, string lab)
        {
            ILocalCourse localCourse = new LocalCourse(name, teacher, lab);
            return localCourse;
        }

        public IOffsiteCourse CreateOffsiteCourse(string name, ITeacher teacher, string town)
        {
            IOffsiteCourse offsiteCouse = new OffsiteCourse(name, teacher, town);
            return offsiteCouse;
        }
    }
}
