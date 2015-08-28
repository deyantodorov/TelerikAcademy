namespace HW5.Variables.Data.Expressions.Constants
{
    using System;

    public class Size
    {
        private const string ToStringFormat = "width: {0}, height: {1}";
        private const string ValidationMessage = " can't be less or equal to zero.";

        private double width;
        private double height;

        public Size(double width, double height)
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
                ValidateSize(value, "Width");
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
                ValidateSize(value, "Height");
                this.height = value;
            }
        }

        public static Size GetRotatedSize(Size figure, double rotationAngle)
        {
            double newWidth = Math.Abs(Math.Cos(rotationAngle)) * figure.Width;
            double newHeight = Math.Abs(Math.Sin(rotationAngle)) * figure.Height;

            Size newFigure = new Size(newWidth + newHeight, newWidth + newHeight);

            return newFigure;
        }

        public override string ToString()
        {
            string print = string.Format(ToStringFormat, this.Width, this.Height);
            return print;
        }

        private static void ValidateSize(double value, string name)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(name + ValidationMessage);
            }
        }
    }
}