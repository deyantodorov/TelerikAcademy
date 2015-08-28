namespace Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RandomData
    {
        private static readonly List<string> mailProviders = new List<string>() { "abv.bg", "mail.bg", "gmail.com", "yahoo.com", "hotmail.com" };
        private static readonly List<string> phonePrefix = new List<string>() { "02", "082", "046", "052", "0361", "042", "088", "098", "078" };
        private static readonly List<string> departments = new List<string>() { "Mathematics", "Architecture", "Art", "Music", "Philosophy", "Education", "Economics", "Law", "Criminology", "Economy" };

        public static List<Student> Students(int count, int firstNameLength, int lastNameLength, int fnStart, int fnEnd, int markStart, int markEnd, int groupNumberStart, int groupNumberEnd)
        {
            List<Student> students = new List<Student>();

            for (int i = 0; i < count; i++)
            {
                string firstName = GenerateRandom.Text(firstNameLength);
                string lastName = GenerateRandom.Text(lastNameLength);
                int fn = 0;

                // Hardcore atleast few 2006 students
                if (i % 5 == 0)
                {
                    fn = int.Parse(GenerateRandom.Number(1000, 9999).ToString() + "06");
                }
                else
                {
                    fn = GenerateRandom.Number(fnStart, fnEnd);
                }

                string tel = phonePrefix[GenerateRandom.Number(0, phonePrefix.Count)] + "/" + GenerateRandom.Number(100000, 999999).ToString();
                string email = firstName + "." + lastName + "@" + mailProviders[GenerateRandom.Number(0, mailProviders.Count)];
                int numberOfMarks = GenerateRandom.Number(2, 10);
                int groupNumber = GenerateRandom.Number(groupNumberStart, groupNumberEnd);

                Group group = new Group(groupNumber, departments[GenerateRandom.Number(0, departments.Count)]);

                Student student = new Student(firstName, lastName);
                student.Fn = fn;
                student.Tel = tel;
                student.Email = email;
                student.GroupNumber = groupNumber;
                student.Group = group;

                for (int j = 0; j < numberOfMarks; j++)
                {
                    student.Marks.Add(GenerateRandom.Number(markStart, markEnd));
                }

                students.Add(student);
            }

            return students;
        }
    }
}
