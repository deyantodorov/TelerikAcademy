namespace Point3d
{
    using System;

    /// <summary>
    /// Problem 3. Static class
    ///            Write a static class with a static method to calculate the distance between two points in the 3D space.
    /// </summary>
    public static class Calculate3d
    {
        public static double Distance(Point3d p1, Point3d p2)
        {
            double x = Math.Pow(p1.X - p2.X, 2);
            double y = Math.Pow(p1.Y - p2.Y, 2);
            double z = Math.Pow(p1.Z - p2.Z, 2);
            double distance = Math.Sqrt(x + y + z);

            return distance;
        }
    }
}
