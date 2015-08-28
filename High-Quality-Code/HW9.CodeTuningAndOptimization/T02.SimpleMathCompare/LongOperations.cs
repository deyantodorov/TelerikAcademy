namespace T02.SimpleMathCompare
{
    public class LongOperations
    {
        public LongOperations(long[] numbers)
        {
            this.Numbers = numbers;
        }

        public long[] Numbers { get; private set; }

        public long Add()
        {
            long result = 0;

            for (int i = 0; i < this.Numbers.Length; i++)
            {
                result += this.Numbers[i];
            }

            return result;
        }

        public long Subtract()
        {
            long result = this.Numbers[0];

            for (int i = 1; i < this.Numbers.Length; i++)
            {
                result -= this.Numbers[i];
            }

            return result;
        }

        public long Increment()
        {
            long result = this.Numbers[0];

            for (int i = 1; i < this.Numbers.Length; i++)
            {
                this.Numbers[i]++;
            }

            return result;
        }

        public long Multiply()
        {
            long result = this.Numbers[0];

            for (int i = 1; i < this.Numbers.Length; i++)
            {
                this.Numbers[i] *= 1;
            }

            return result;
        }

        public long Divide()
        {
            long result = this.Numbers[0];

            for (int i = 1; i < this.Numbers.Length; i++)
            {
                this.Numbers[i] /= 2;
            }

            return result;
        }
    }
}
