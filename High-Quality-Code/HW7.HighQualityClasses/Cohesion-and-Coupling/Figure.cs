namespace CohesionAndCoupling
{
    using System;

    public class Figure : IFigure
    {
        private double width;
        private double height;
        private double depth;

        public Figure()
        {
        }

        public Figure(double width, double height)
            : base()
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

            set
            {
                Validator.ValueNotEqualToZero(value, "Width");
                Validator.ValueNotLessThanZero(value, "Width");
                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                Validator.ValueNotEqualToZero(value, "Height");
                Validator.ValueNotLessThanZero(value, "Height");
                this.height = value;
            }
        }

        public double Depth
        {
            get
            {
                return this.depth;
            }

            set
            {
                Validator.ValueNotEqualToZero(value, "Depth");
                Validator.ValueNotLessThanZero(value, "Depth");
                this.depth = value;
            }
        }

        public static double CalculateDistance2D(double firstX, double firstY, double secondX, double secondY)
        {
            if (firstX < 0 || firstY < 0 || secondX < 0 || secondY < 0)
            {
                throw new ArgumentOutOfRangeException("Values can't be negative");
            }

            double distanceX = (secondX - firstX) * 2;
            double distanceY = (secondY - firstY) * 2;
            double distance = Math.Sqrt(distanceX + distanceY);

            return distance;
        }

        public static double CalculateDistance3D(double firstX, double firstY, double firstZ, double secondX, double secondY, double secondZ)
        {
            if (firstX < 0 || firstY < 0 || firstZ < 0 || secondX < 0 || secondY < 0 || secondZ < 0)
            {
                throw new ArgumentOutOfRangeException("Values can't be negative");
            }

            double distanceX = (secondX - firstX) * 2;
            double distanceY = (secondY - firstY) * 2;
            double distanceZ = (secondZ - firstZ) * 2;
            double distance = Math.Sqrt(distanceX + distanceY + distanceZ);

            return distance;
        }

        public double CalculateVolume()
        {
            double distance = this.Width * this.Height * this.Depth;
            return distance;
        }

        public double CalculateDiagonal3D()
        {
            double distance = CalculateDistance3D(0, 0, 0, this.Width, this.Height, this.Depth);
            return distance;
        }

        public double CalculateDiagonalXY()
        {
            double distance = CalculateDistance2D(0, 0, this.Width, this.Height);
            return distance;
        }

        public double CalculateDiagonalXZ()
        {
            double distance = CalculateDistance2D(0, 0, this.Width, this.Depth);
            return distance;
        }

        public double CalculateDiagonalYZ()
        {
            double distance = CalculateDistance2D(0, 0, this.Height, this.Depth);
            return distance;
        }
    }
}
