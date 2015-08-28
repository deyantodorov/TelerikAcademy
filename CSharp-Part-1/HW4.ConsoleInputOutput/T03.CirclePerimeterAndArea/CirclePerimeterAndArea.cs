namespace T03.CirclePerimeterAndArea
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading;

    /// <summary>
    /// 3. Write a program that reads the radius r of a circle and prints its perimeter and area formatted with 2 digits after the decimal point.
    /// </summary>
    public class CirclePerimeterAndArea
    {
        private static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            float r = ReadAndValidateInput("Please, enter value for radius \"r\" = ");
            float perimeter = (float)(2 * Math.PI * r);
            float area = (float)(Math.PI * r * r);
            Console.WriteLine("Circle perimeter is: {0:F2}", perimeter);
            Console.WriteLine("Circle area is: {0:F2}", area);
        }

        private static float ReadAndValidateInput(string msg)
        {
            float number;

            Console.Write(msg);

            bool isValid = float.TryParse(Console.ReadLine().ToString().Replace(',', '.'), out number);
            while (isValid == false)
            {
                Console.Write("Invalid number! {0}", msg);
                isValid = float.TryParse(Console.ReadLine().ToString().Replace(',', '.'), out number);
            }

            return number;
        }
    }
}