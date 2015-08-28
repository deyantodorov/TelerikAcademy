namespace T02.SimpleMathCompare
{
    public class DoubleOperations
    {
        public DoubleOperations(double[] numbers)
        {
            this.Numbers = numbers;
        }

        public double[] Numbers { get; private set; }

        public double Add()
        {
            double result = 0;

            for (int i = 0; i < this.Numbers.Length; i++)
            {
                result += this.Numbers[i];
            }

            return result;
        }

        public double Subtract()
        {
            double result = this.Numbers[0];

            for (int i = 1; i < this.Numbers.Length; i++)
            {
                result -= this.Numbers[i];
            }

            return result;
        }

        public double Increment()
        {
            double result = this.Numbers[0];

            for (int i = 1; i < this.Numbers.Length; i++)
            {
                this.Numbers[i]++;
            }

            return result;
        }

        public double Multiply()
        {
            double result = this.Numbers[0];

            for (int i = 1; i < this.Numbers.Length; i++)
            {
                this.Numbers[i] *= 1;
            }

            return result;
        }

        public double Divide()
        {
            double result = this.Numbers[0];

            for (int i = 1; i < this.Numbers.Length; i++)
            {
                this.Numbers[i] /= 2;
            }

            return result;
        }
    }
}
