namespace T09.Trapezoid
{
    using System;

    public class Trapezoid
    {
        public double SideA { get; set; }

        public double SideB { get; set; }

        public double Height { get; set; }

        public double GetArea()
        {
            double result = 0;

            if (this.SideA == 0 || this.SideB == 0 || this.Height == 0)
            {
                return result;
            }

            result = ((this.SideA + this.SideB) / 2) * this.Height;

            return result;
        }
    }
}
