namespace T01.Shapes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;
    using T01.Shapes.Contracts;

    /// <summary>
    /// https://github.com/TelerikAcademy/Object-Oriented-Programming/blob/master/05.%20OOP%20Principles%20-%20Part%202/README.md#problem-1-shapes
    /// </summary>
    public class MainProgram
    {
        private static void Main()
        {
            // Generate random data to test functionality
            List<IShape> shapes = new List<IShape>();

            for (int i = 0; i < 12; i++)
            {
                if (i < 4)
                {
                    // Make Triangle
                    IShape shape = GetShape(typeof(Triangle));
                    shapes.Add((Triangle)shape);
                }
                else if (i < 8)
                {
                    // Make Rectangle
                    IShape shape = GetShape(typeof(Rectangle));
                    shapes.Add((Rectangle)shape);
                }
                else
                {
                    // Make Circle
                    IShape shape = GetShape(typeof(Circle));
                    shapes.Add((Circle)shape);
                }
            }

            // Print result
            shapes.ForEach(x => Console.WriteLine(x));
        }

        private static IShape GetShape(Type shapeType)
        {
            double width = GenerateRandom.Number(1, 100);
            double height = GenerateRandom.Number(1, 100);

            IShape shape;

            if (typeof(Triangle) == shapeType)
            {
                shape = new Triangle(width, height);
            }
            else if (typeof(Rectangle) == shapeType)
            {
                shape = new Rectangle(width, height);
            }
            else if (typeof(Circle) == shapeType)
            {
                shape = new Circle(width);
            }
            else
            {
                throw new ArgumentException("Unsupported type of shapes");
            }

            return shape;
        }
    }
}