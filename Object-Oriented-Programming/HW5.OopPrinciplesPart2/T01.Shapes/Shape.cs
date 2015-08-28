namespace T01.Shapes
{
    using System;
    using System.Linq;
    using Common;
    using T01.Shapes.Contracts;

    public abstract class Shape : IShape
    {
        private double width;
        private double height;

        public Shape(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            protected set
            {
                Validation.LessThanZero<double>(value, 0, "Width");
                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            protected set
            {
                Validation.LessThanZero<double>(value, 0, "Height");
                this.height = value;
            }
        }

        public abstract double CalculateSurface();

        public override string ToString()
        {
            return string.Format("Type: {0}, Width: {1:F2}, Height: {2:F2}, Surface: {3:F2}", this.GetType().Name, this.Width, this.Height, this.CalculateSurface());
        }
    }
}
