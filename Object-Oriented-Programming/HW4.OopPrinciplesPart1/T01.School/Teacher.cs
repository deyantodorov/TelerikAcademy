namespace T01.School
{
    using System;
    using System.Collections.Generic;
    using T01.School.Contracts;

    public class Teacher : People, IPeople, IComment
    {
        public Teacher(string firstName, string middleName, string lastName)
            : base(firstName, middleName, lastName)
        {
            this.Disciplines = new HashSet<Discipline>();
        }

        public HashSet<Discipline> Disciplines { get; set; }
    }
}