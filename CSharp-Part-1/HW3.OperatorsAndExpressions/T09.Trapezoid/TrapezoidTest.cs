namespace T09.Trapezoid
{
    using System;
    using System.Linq;

    /// <summary>
    /// 9. Write an expression that calculates trapezoid's area by given sides a and b and height h.
    /// </summary>
    public class TrapezoidTest
    {
        private static void Main()
        {
            Trapezoid trap = new Trapezoid();

            trap.SideA = 5;
            trap.SideB = 7;
            trap.Height = 12;
            Console.WriteLine("Area: {0}", trap.GetArea());

            trap.SideA = 2;
            trap.SideB = 1;
            trap.Height = 33;
            Console.WriteLine("Area: {0}", trap.GetArea());

            trap.SideA = 8.5;
            trap.SideB = 4.3;
            trap.Height = 2.7;
            Console.WriteLine("Area: {0}", trap.GetArea());

            trap.SideA = 100;
            trap.SideB = 200;
            trap.Height = 300;
            Console.WriteLine("Area: {0}", trap.GetArea());

            trap.SideA = 0.222;
            trap.SideB = 0.333;
            trap.Height = 0.555;
            Console.WriteLine("Area: {0}", trap.GetArea());
        }
    }
}