namespace SimpleFactory
{
    public class Personal : CheckBook
    {
        public Personal()
        {
            this.amount = 15000;
        }

        public override string ToString()
        {
            return $"Your personal expenses: {this.amount}";
        }
    }
}