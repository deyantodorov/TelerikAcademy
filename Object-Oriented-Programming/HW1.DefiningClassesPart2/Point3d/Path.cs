namespace Point3d
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Problem 4. Path
    ///            Create a class Path to hold a sequence of points in the 3D space.
    ///            Create a static class PathStorage with static methods to save and load paths from a text file.
    ///            Use a file format of your choice.
    /// </summary>
    public class Path
    {
        public Path()
        {
            this.Points = new List<Point3d>();
        }

        public List<Point3d> Points { get; private set; }

        public void Add(Point3d point)
        {
            this.Points.Add(point);
        }

        public void Delete(Point3d point)
        {
            this.Points.Add(point);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var point in this.Points)
            {
                sb.AppendLine(point.ToString());
            }

            return sb.ToString();
        }
    }
}
