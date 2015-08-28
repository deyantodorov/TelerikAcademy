namespace Exceptions_Homework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Student
    {
        private string firstName;
        private string lastName;
        private IList<Exam> exams;

        public Student(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public Student(string firstName, string lastName, IList<Exam> exams)
            : this(firstName, lastName)
        {
            this.Exams = exams;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                Validator.IsStringNullOrEmpty(value, "First name");
                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                Validator.IsStringNullOrEmpty(value, "Last name");
                this.lastName = value;
            }
        }

        public IList<Exam> Exams
        {
            get { return this.exams; }

            set
            {
                if (value == null || value.Count == 0)
                {
                    throw new NullReferenceException("Exams can't be null or empty");
                }

                this.exams = value;
            }
        }

        public IList<ExamResult> CheckExams()
        {
            IList<ExamResult> results = new List<ExamResult>();

            for (int i = 0; i < this.Exams.Count; i++)
            {
                results.Add(this.Exams[i].Check());
            }

            return results;
        }

        public double CalcAverageExamResultInPercents()
        {
            double[] examScore = new double[this.Exams.Count];
            IList<ExamResult> examResults = this.CheckExams();

            for (int i = 0; i < examResults.Count; i++)
            {
                var currentScore = ((double)examResults[i].Grade - examResults[i].MinGrade) /
                                   (examResults[i].MaxGrade - examResults[i].MinGrade);
                examScore[i] = currentScore;
            }

            return examScore.Average();
        }
    }
}