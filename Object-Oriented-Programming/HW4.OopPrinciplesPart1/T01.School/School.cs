namespace T01.School
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class School
    {
        private List<Classes> classes;

        public School()
        {
            this.Classes = new List<Classes>();
        }

        public List<Classes> Classes
        {
            get
            {
                return this.classes;
            }

            set
            {
                this.classes = value;
            }
        }
    }
}
