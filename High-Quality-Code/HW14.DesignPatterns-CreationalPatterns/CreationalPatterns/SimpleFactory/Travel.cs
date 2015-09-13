namespace SimpleFactory
{
    public class Travel : CheckBook
    {
        public Travel()
        {
            this.amount = 10000;
        }

        public override string ToString()
        {
            return $"Your travel expenses: {this.amount}";
        }
    }
}
