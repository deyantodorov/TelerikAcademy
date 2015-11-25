namespace T01.KnapsackProblem
{
    using System;

    public class Item
    {
        public string Name { get; set; }

        public int Weight { get; set; }

        public int Value { get; set; }

        public int ResultWeightValue
        {
            get
            {
                return this.Weight - this.Value;
            }
        }

        public override string ToString()
        {
            return string.Format("Name: {0}, Weight: {1}, Value: {2}, Result (Weight-Value): {3}", this.Name, this.Weight, this.Value, this.ResultWeightValue);
        }
    }
}
