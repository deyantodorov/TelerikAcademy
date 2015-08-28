namespace Exceptions_Homework
{
    using System;

    public class ExamResult
    {
        private int grade;
        private int minGrade;
        private int maxGrade;
        private string comments;

        public ExamResult(int grade, int minGrade, int maxGrade, string comments)
        {
            this.Grade = grade;
            this.MinGrade = minGrade;
            this.MaxGrade = maxGrade;
            this.Comments = comments;
        }

        public int Grade
        {
            get
            {
                return this.grade;
            }

            private set
            {
                Validator.IsValueSmaller(value, 0, "Grade");
                this.grade = value;
            }
        }

        public int MinGrade
        {
            get
            {
                return this.minGrade;
            }

            private set
            {
                Validator.IsValueSmaller(value, 0, "Minimal Grade");
                this.minGrade = value;
            }
        }

        public int MaxGrade
        {
            get { return this.maxGrade; }

            private set
            {
                if (value <= this.MinGrade)
                {
                    throw new ArgumentOutOfRangeException("Value of minGrade can't be equal or greater to maxGrade");
                }

                this.maxGrade = value;
            }
        }

        public string Comments
        {
            get
            {
                return this.comments; 
            }

            private set
            {
                Validator.IsStringNullOrEmpty(value, "Comments");
                this.comments = value;
            }
        }
    }
}