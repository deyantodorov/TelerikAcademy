namespace SimpleFactory
{
    using System;

    public class CheckBook
    {
        protected decimal amount;

        public decimal GetExpense()
        {
            return this.amount;
        }

        public CheckBook ChooseExpense(int type)
        {
            switch (type)
            {
                case 1:
                    return new Health();
                case 2:
                    return new Travel();
                case 3:
                    return new Personal();
                default:
                    throw new ArgumentException("Unsupported CheckBook type");
            }
        }
    }
}
