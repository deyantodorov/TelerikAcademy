namespace Exceptions_Homework
{
    public class CSharpExam : Exam
    {
        private const int MinValue = 0;
        private const int MaxValue = 100;
        private int score;

        public CSharpExam(int score)
        {
            this.Score = score;
        }

        public int Score
        {
            get { return this.score; }

            private set
            {
                Validator.IsValueSmaller(value, MinValue, "Value");
                Validator.IsValueBigger(value, MaxValue, "Value");
                this.score = value;
            }
        }

        public override ExamResult Check()
        {
            var result = new ExamResult(this.Score, MinValue, MaxValue, "Exam results calculated by score.");
            return result;
        }
    }
}