namespace T02.SimpleMathCompare
{
    public class FloatOperations
    {
        public FloatOperations(float[] numbers)
        {
            this.Numbers = numbers;
        }

        public float[] Numbers { get; private set; }

        public float Add()
        {
            float result = 0;

            for (int i = 0; i < this.Numbers.Length; i++)
            {
                result += this.Numbers[i];
            }

            return result;
        }

        public float Subtract()
        {
            float result = this.Numbers[0];

            for (int i = 1; i < this.Numbers.Length; i++)
            {
                result -= this.Numbers[i];
            }

            return result;
        }

        public float Increment()
        {
            float result = this.Numbers[0];

            for (int i = 1; i < this.Numbers.Length; i++)
            {
                this.Numbers[i]++;
            }

            return result;
        }

        public float Multiply()
        {
            float result = this.Numbers[0];

            for (int i = 1; i < this.Numbers.Length; i++)
            {
                this.Numbers[i] *= 1;
            }

            return result;
        }

        public float Divide()
        {
            float result = this.Numbers[0];

            for (int i = 1; i < this.Numbers.Length; i++)
            {
                this.Numbers[i] /= 2;
            }

            return result;
        }
    }
}
