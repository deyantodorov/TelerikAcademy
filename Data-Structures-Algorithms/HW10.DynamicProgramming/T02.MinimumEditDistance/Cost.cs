namespace T02.MinimumEditDistance
{
    using System;

    public struct Cost
    {
        public double Replace { get; set; }

        public double Delete { get; set; }

        public double Insert { get; set; }
    }
}
