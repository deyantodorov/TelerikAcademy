namespace T01.School
{
    using System;
    using System.Linq;
    using Common;
    using T01.School.Contracts;

    public class Discipline : IComment
    {
        private string name;
        private int numberOfLectures;
        private int numberOfExercises;
        private string comment;

        public Discipline(string name)
        {
            this.Name = name;
        }

        public Discipline(string name, int numberOfLectures, int numberOfExercises)
            : this(name)
        {
            this.NumberOfLectures = numberOfLectures;
            this.NumberOfExercises = numberOfExercises;
        }

        public string Comment
        {
            get
            {
                return this.comment;
            }

            set
            {
                Validation.StringIsNullOrEmpty(value, "Comment");
                this.comment = value;
            }
        }

        public int NumberOfExercises
        {
            get
            {
                return this.numberOfExercises;
            }

            set
            {
                Validation.LessThanZero<int>(value, 0, "NumberOfExercises");
                this.numberOfExercises = value;
            }
        }

        public int NumberOfLectures
        {
            get
            {
                return this.numberOfLectures;
            }

            set
            {
                Validation.LessThanZero<int>(value, 0, "NumberOfLectures");
                this.numberOfLectures = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                Validation.StringIsNullOrEmpty(value, "Name");
                this.name = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Discipline: {0}", this.Name);
        }
    }
}