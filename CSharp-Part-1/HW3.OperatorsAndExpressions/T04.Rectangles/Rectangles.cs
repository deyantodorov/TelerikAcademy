namespace T04.Rectangles
{
    using System;
    using System.Linq;

    /// <summary>
    /// 4. Write an expression that calculates rectangle’s perimeter and area by given width and height.
    /// </summary>
    public class Rectangles
    {
        private static void Main()
        {
            Rectangle rect = new Rectangle();

            rect.Width = 3f;
            rect.Height = 4f;
            Console.WriteLine("Perimeter " + rect.GetPerimeter());
            Console.WriteLine("Area " + rect.GetArea());

            rect.Width = 2.5f;
            rect.Height = 3f;
            Console.WriteLine("Perimeter " + rect.GetPerimeter());
            Console.WriteLine("Area " + rect.GetArea());

            rect.Width = 5f;
            rect.Height = 5f;
            Console.WriteLine("Perimeter " + rect.GetPerimeter());
            Console.WriteLine("Area " + rect.GetArea());
        }
    }
}