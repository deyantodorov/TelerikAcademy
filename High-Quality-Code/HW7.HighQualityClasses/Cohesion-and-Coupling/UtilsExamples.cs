namespace CohesionAndCoupling
{
    using System;

    public class UtilsExamples
    {
        private static void Main()
        {
            Console.WriteLine(Utils.GetFileExtension("example.cs"));
            Console.WriteLine(Utils.GetFileExtension("example.pdf"));
            Console.WriteLine(Utils.GetFileExtension("example.new.pdf"));

            Console.WriteLine(Utils.GetFileNameWithoutExtension("example.cs"));
            Console.WriteLine(Utils.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(Utils.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("Distance in the 2D space = {0:f2}", Figure.CalculateDistance2D(1, 2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}", Figure.CalculateDistance3D(5, 2, 1, 3, 6, 4));

            Figure figure = new Figure();

            figure.Width = 3;
            figure.Height = 4;
            figure.Depth = 5;
            Console.WriteLine("Volume = {0:f2}", figure.CalculateVolume());
            Console.WriteLine("Diagonal XYZ = {0:f2}", figure.CalculateDiagonal3D());
            Console.WriteLine("Diagonal XY = {0:f2}", figure.CalculateDiagonalXY());
            Console.WriteLine("Diagonal XZ = {0:f2}", figure.CalculateDiagonalXZ());
            Console.WriteLine("Diagonal YZ = {0:f2}", figure.CalculateDiagonalYZ());
        }
    }
}
