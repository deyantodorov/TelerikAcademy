namespace T01.Shapes
{
    using System;
    using System.Linq;
    using T01.Shapes.Contracts;

    public class Triangle : Shape, IShape
    {
        public Triangle(double width, double height)
            : base(width, height)
        {
        }

        public override double CalculateSurface()
        {
            double surface = this.Width * this.Height;
            return surface;
        }
    }
}
