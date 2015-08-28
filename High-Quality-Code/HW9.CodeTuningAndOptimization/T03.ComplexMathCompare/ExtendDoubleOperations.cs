namespace T03.ComplexMathCompare
{
    using System;
    using System.Linq;
    using T02.SimpleMathCompare;

    public class ExtendDoubleOperations  : DoubleOperations
    {
        public ExtendDoubleOperations(double[] numbers)
            : base(numbers)
        {
            this.Numbers = numbers;
        }

        public double[] Numbers { get; private set; }

        public void SquareRoot()
        {
            for (int i = 1; i < this.Numbers.Length; i++)
            {
                this.Numbers[i] = (float)Math.Sqrt(this.Numbers[i]);
            }
        }

        public double[] NaturalLogarithm()
        {
            for (int i = 1; i < this.Numbers.Length; i++)
            {
                this.Numbers[i] = (float)Math.Log(this.Numbers[i]);
            }

            return this.Numbers;
        }

        public double[] Sinus()
        {
            for (int i = 1; i < this.Numbers.Length; i++)
            {
                this.Numbers[i] = (float)Math.Sin(this.Numbers[i]);
            }

            return this.Numbers;
        }
    }
}
