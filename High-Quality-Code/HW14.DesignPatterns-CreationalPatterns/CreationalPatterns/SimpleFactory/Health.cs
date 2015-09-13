namespace SimpleFactory
{
    public class Health : CheckBook
    {
        public Health()
        {
            this.amount = 5000;
        }

        public override string ToString()
        {
            return $"Your health expense: {this.amount}";
        }
    }
}
