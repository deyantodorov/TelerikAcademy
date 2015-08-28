namespace T03.ComplexMathCompare
{
    using System;
    using System.Linq;
    using T02.SimpleMathCompare;

    public class ExtendDecimalOperations : DecimalOperations
    {
        public ExtendDecimalOperations(decimal[] numbers)
            : base(numbers)
        {
            this.Numbers = numbers;
        }

        public decimal[] Numbers { get; private set; }

        public void SquareRoot()
        {
            for (int i = 1; i < this.Numbers.Length; i++)
            {
                this.Numbers[i] = (decimal)Math.Sqrt((double)this.Numbers[i]);
            }
        }

        public decimal[] NaturalLogarithm()
        {
            for (int i = 1; i < this.Numbers.Length; i++)
            {
                this.Numbers[i] = (decimal)Math.Log((double)this.Numbers[i]);
            }

            return this.Numbers;
        }

        public decimal[] Sinus()
        {
            for (int i = 1; i < this.Numbers.Length; i++)
            {
                this.Numbers[i] = (decimal)Math.Sin((double)this.Numbers[i]);
            }

            return this.Numbers;
        }
    }
}
