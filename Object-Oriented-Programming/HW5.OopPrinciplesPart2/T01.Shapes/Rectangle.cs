namespace T01.Shapes
{
    using System;
    using System.Linq;
    using T01.Shapes.Contracts;

    public class Rectangle : Shape, IShape
    {
        public Rectangle(double width, double height)
            : base(width, height)
        {
        }

        public override double CalculateSurface()
        {
            double surface = (this.Width * this.Height) / 2;
            return surface;
        }
    }
}
