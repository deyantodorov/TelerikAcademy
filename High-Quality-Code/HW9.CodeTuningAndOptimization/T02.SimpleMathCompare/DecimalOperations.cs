namespace T02.SimpleMathCompare
{
    public class DecimalOperations
    {
        public DecimalOperations(decimal[] numbers)
        {
            this.Numbers = numbers;
        }

        public decimal[] Numbers { get; private set; }

        public decimal Add()
        {
            decimal result = 0;

            for (int i = 0; i < this.Numbers.Length; i++)
            {
                result += this.Numbers[i];
            }

            return result;
        }

        public decimal Subtract()
        {
            decimal result = this.Numbers[0];

            for (int i = 1; i < this.Numbers.Length; i++)
            {
                result -= this.Numbers[i];
            }

            return result;
        }

        public decimal Increment()
        {
            decimal result = this.Numbers[0];

            for (int i = 1; i < this.Numbers.Length; i++)
            {
                this.Numbers[i]++;
            }

            return result;
        }

        public decimal Multiply()
        {
            decimal result = this.Numbers[0];

            for (int i = 1; i < this.Numbers.Length; i++)
            {
                this.Numbers[i] *= 1;
            }

            return result;
        }

        public decimal Divide()
        {
            decimal result = this.Numbers[0];

            for (int i = 1; i < this.Numbers.Length; i++)
            {
                this.Numbers[i] /= 2;
            }

            return result;
        }
    }
}
