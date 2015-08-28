namespace T04.SurfaceOfTriangle
{
    using System;

    /// <summary>
    /// 4. Write methods that calculate the surface of a triangle by given:
    ///    Side and an altitude to it; 
    ///    Three sides; 
    ///    Two sides and an angle between them. 
    ///    Use System.Math.
    /// </summary>
    public class SurfaceOfTriangle
    {
        public static double GetAreaWithAltitude(double sideC, double height)
        {
            double area = (sideC * height) / 2;
            return area;
        }

        public static double GetAreaWithThreeSides(double sideA, double sideB, double sideC)
        {
            double semiperimeter = (sideA + sideB + sideC) / 2;
            double area = Math.Sqrt(semiperimeter * ((semiperimeter - sideA) * (semiperimeter - sideB) * (semiperimeter - sideC)));
            return area;
        }

        public static double GetAreaWithTwoSidesAndAngle(double sideA, double sideB, int angle)
        {
            double area = ((sideA * sideB) / 2) * Math.Sin((Math.PI * angle) / 180);
            return area;
        }

        private static void Main()
        {
            Console.WriteLine("Surface is {0} cm2", GetAreaWithAltitude(5, 3));
            Console.WriteLine("Surface is {0} cm2", GetAreaWithThreeSides(3, 4, 5));
            Console.WriteLine("Surface is {0} cm2", GetAreaWithTwoSidesAndAngle(150, 231, 123));
        }
    }
}
