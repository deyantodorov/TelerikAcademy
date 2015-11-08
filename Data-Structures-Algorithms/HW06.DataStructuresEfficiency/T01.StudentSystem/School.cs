using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T01.StudentSystem
{
    public class School : IEnumerable<Student>
    {
        private readonly SortedDictionary<int, Student> students;

        public School()
        {
            this.students = new SortedDictionary<int, Student>();
        }

        public void Add(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("student", "Student can't be null");
            }

            this.students.Add(student.GetHashCode(), student);
        }

        public void Remove(int id)
        {
            this.students.Remove(id);
        }

        public string PrintOrderedStudentsByCourse()
        {
            var result = this.students
                .GroupBy(x => x.Value.Course)
                .OrderBy(x => x.Key)
                .Select(x => x.OrderBy(y => y.Value.LastName).ThenBy(z => z.Value.FirstName));

            var builder = new StringBuilder();
            var index = 0;
            var spacerIndex = 0;

            foreach (var group in result)
            {
                foreach (var pair in group)
                {
                    if (index == 0)
                    {
                        builder.Append(pair.Value.Course+": ");
                    }

                    if (spacerIndex == group.Count() - 1)
                    {
                        builder.Append(pair.Value.FirstName + " " + pair.Value.LastName);
                    }
                    else
                    {
                        builder.Append(pair.Value.FirstName + " " + pair.Value.LastName + ", ");
                    }

                    spacerIndex++;
                    index++;
                }

                builder.AppendLine();
                spacerIndex = 0;
                index = 0;
            }

            return builder.ToString();
        }

        public IEnumerator<Student> GetEnumerator()
        {
            return this.students.Select(student => student.Value).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
