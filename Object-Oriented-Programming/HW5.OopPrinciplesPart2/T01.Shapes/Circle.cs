namespace T01.Shapes
{
    using System;
    using System.Linq;
    using T01.Shapes.Contracts;

    public class Circle : Shape, IShape
    {
        public Circle(double width)
            : base(width, width)
        {
        }    

        public override double CalculateSurface()
        {
            double surface = this.Width * Math.PI;
            return surface;
        }
    }
}
