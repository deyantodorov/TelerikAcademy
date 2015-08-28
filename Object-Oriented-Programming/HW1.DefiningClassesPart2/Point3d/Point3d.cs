namespace Point3d
{
    using System;

    /// <summary>
    /// Problem 1. Structure
    ///            Create a structure Point3D to hold a 3D-coordinate {X, Y, Z} in the Euclidian 3D space.
    ///            Implement the ToString() to enable printing a 3D point.
    ///            
    /// Problem 2. Static read-only field
    ///            Add a private static read-only field to hold the start of the coordinate system – the point O{0, 0, 0}.
    ///            Add a static property to return the point O.
    /// </summary>
    public struct Point3d
    {
        private static readonly Point3d startPoint = new Point3d(0, 0, 0);

        public Point3d(double x, double y, double z)
            : this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public static Point3d StartPoint
        {
            get
            {
                return startPoint;
            }
        }

        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }

        public override string ToString()
        {
            return string.Format("X: {0}, Y: {1}, Z: {2}", this.X, this.Y, this.Z);
        }
    }
}
