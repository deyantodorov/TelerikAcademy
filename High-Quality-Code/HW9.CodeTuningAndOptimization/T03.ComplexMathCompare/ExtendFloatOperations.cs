namespace T03.ComplexMathCompare
{
    using System;
    using System.Linq;
    using T02.SimpleMathCompare;

    public class ExtendFloatOperations : FloatOperations
    {
        public ExtendFloatOperations(float[] numbers)
            : base(numbers)
        {
            this.Numbers = numbers;
        }

        public float[] Numbers { get; private set; }

        public void SquareRoot()
        {
            for (int i = 1; i < this.Numbers.Length; i++)
            {
                this.Numbers[i] = (float)Math.Sqrt(this.Numbers[i]);
            }
        }

        public float[] NaturalLogarithm()
        {
            for (int i = 1; i < this.Numbers.Length; i++)
            {
                this.Numbers[i] = (float)Math.Log(this.Numbers[i]);
            }

            return this.Numbers;
        }

        public float[] Sinus()
        {
            for (int i = 1; i < this.Numbers.Length; i++)
            {
                this.Numbers[i] = (float)Math.Sin(this.Numbers[i]);
            }

            return this.Numbers;
        }
    }
}
