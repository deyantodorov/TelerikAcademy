namespace T02.SimpleMathCompare
{
    public class IntOperations
    {
        public IntOperations(int[] numbers)
        {
            this.Numbers = numbers;
        }

        public int[] Numbers { get; private set; }

        public int Add()
        {
            int result = 0;

            for (int i = 0; i < this.Numbers.Length; i++)
            {
                result += this.Numbers[i];
            }

            return result;
        }

        public int Subtract()
        {
            int result = this.Numbers[0];

            for (int i = 1; i < this.Numbers.Length; i++)
            {
                result -= this.Numbers[i];
            }

            return result;
        }

        public int Increment()
        {
            int result = this.Numbers[0];

            for (int i = 1; i < this.Numbers.Length; i++)
            {
                this.Numbers[i]++;
            }

            return result;
        }

        public int Multiply()
        {
            int result = this.Numbers[0];

            for (int i = 1; i < this.Numbers.Length; i++)
            {
                this.Numbers[i] *= 1;
            }

            return result;
        }

        public int Divide()
        {
            int result = this.Numbers[0];

            for (int i = 1; i < this.Numbers.Length; i++)
            {
                this.Numbers[i] /= 2;
            }

            return result;
        }
    }
}
