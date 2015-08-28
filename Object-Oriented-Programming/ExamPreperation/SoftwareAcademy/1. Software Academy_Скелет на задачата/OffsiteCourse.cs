namespace SoftwareAcademy
{
    using System;
    using System.Linq;
    using SoftwareAcademy.Common;
    using SoftwareAcademy.Contracts;

    public class OffsiteCourse : Course, ICourse, IOffsiteCourse
    {
        private string town;

        public OffsiteCourse(string name, ITeacher teacher, string town)
            : base(name, teacher)
        {
            this.Town = town;
        }

        public string Town
        {
            get
            {
                return this.town;
            }

            set
            {
                Validate.StringIsNullOrEmpty(value, "Town");
                this.town = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("; Town={0}", this.Town);
        }
    }
}
