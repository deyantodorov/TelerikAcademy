namespace Point3d
{
    using System;
    using System.Linq;

    public class TestingPoint3d
    {
        private static void Main()
        {
            Point3d firstPoint = new Point3d(1, 2, 3);
            Point3d secondPoint = new Point3d(4, 5, 6);

            Console.WriteLine("First point " + firstPoint);
            Console.WriteLine("Second point " + secondPoint);
            Console.WriteLine("Start point " + Point3d.StartPoint);
            Console.WriteLine("Distance between first and second point " + Calculate3d.Distance(firstPoint, secondPoint));

            Path paths = new Path();
            paths.Add(firstPoint);
            paths.Add(secondPoint);

            Console.WriteLine("All points: ");
            Console.Write(paths);

            PathStorage.Save(paths);

            Console.WriteLine("Loaded: ");
            Path loadedPaths = PathStorage.Load();
            Console.Write(loadedPaths);
        }
    }
}