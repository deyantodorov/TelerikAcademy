namespace T10.PointInCircleOutOfRectangle
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading;

    /// <summary>
    /// 10. Write an expression that checks for given point (x, y) if it is within the circle K({1, 1}, 1.5) and out of the rectangle R(top=1, left=-1, width=6, height=2).
    /// </summary>
    public class PointInCircleOutOfRectangle
    {
        private static void Main()
        {
            // Input data
            float inputX = ReadAndValidateInput("Please, enter value for x = ");
            float inputY = ReadAndValidateInput("Please, enter value for y = ");

            const double CircleR = 1.5;
            const double CircleX = 1;
            const double CircleY = 1;
            const double RactangleX = -1;
            const double RactangleY = 1;
            const double RactangleWidth = 6;
            const double RactangleHeight = 2;

            bool inRactangle = (inputX > RactangleX || inputX > RactangleWidth + RactangleX) && (inputY > RactangleY || inputY > RactangleY - RactangleHeight);

            /*
             * The equation of a circle is (x − a)2 + (y − b)2 = r2 where a and b are the coordinates of the center (a, b) and r is the radius.
             * Verify given point is in circle = (x - a) * (x - a) + (y - b) * (y - b) = r * r;
             */
            bool inCircle = ((inputX - CircleX) * (inputX - CircleX)) + ((inputY - CircleY) * (inputY - CircleY)) <= (CircleR * CircleR);

            if (inRactangle && inCircle)
            {
                Console.WriteLine("True. Your points x = {0} and y = {1} are in circle and out of ractangle", inputX, inputY);
            }
            else
            {
                Console.WriteLine("False. Your points x = {0} and y = {1} are not in circle or not out of ractangle", inputX, inputY);
            }
        }

        private static float ReadAndValidateInput(string msg)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            float number;

            Console.Write(msg);

            bool isValid = float.TryParse(Console.ReadLine(), out number);
            while (isValid == false || number == 0)
            {
                Console.Write("Invalid number! {0}", msg);
                isValid = float.TryParse(Console.ReadLine(), out number);
            }

            return number;
        }
    }
}