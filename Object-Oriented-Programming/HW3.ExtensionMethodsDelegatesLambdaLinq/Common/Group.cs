namespace Common
{
    using System;
    using System.Linq;

    public class Group
    {
        private int groupNumber;
        private string departmentName;

        public Group(int groupNumber, string departmentName)
        {
            this.GroupNumber = groupNumber;
            this.DepartmentName = departmentName;
        }

        public string DepartmentName
        {
            get
            {
                return this.departmentName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Department name is required");
                }

                this.departmentName = value;
            }
        }

        public int GroupNumber
        {
            get
            {
                return this.groupNumber;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Group number can't be equal or less than zero");
                }

                this.groupNumber = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Department name: {0}, Group number: {1}", this.DepartmentName, this.GroupNumber);
        }
    }
}
