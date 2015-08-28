namespace Methods
{
    using System;

    public class Methods
    {
        public static double CalculateTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("Triangle sides should be greater than zero");
            }

            double s = (a + b + c) / 2;
            double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));

            return area;
        }

        public static string NumberToText(int number)
        {
            if (number < 0)
            {
                throw new ArgumentOutOfRangeException("Number can't be less than zero");
            }

            if (number > 9)
            {
                throw new ArgumentOutOfRangeException("Number can't be greater than nine");
            }

            string text = string.Empty;

            switch (number)
            {
                case 0:
                    text = "zero";
                    break;
                case 1:
                    text = "one";
                    break;
                case 2:
                    text = "two";
                    break;
                case 3:
                    text = "three";
                    break;
                case 4:
                    text = "four";
                    break;
                case 5:
                    text = "five";
                    break;
                case 6:
                    text = "six";
                    break;
                case 7:
                    text = "seven";
                    break;
                case 8:
                    text = "eight";
                    break;
                case 9:
                    text = "nine";
                    break;
            }

            return text;
        }

        public static int FindMax(params int[] elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException("Argument can't be null");
            }
            
            if (elements.Length == 0)
            {
                throw new ArgumentNullException("Argument can't be empty");
            }

            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > elements[0])
                {
                    elements[0] = elements[i];
                }
            }

            return elements[0];
        }

        public static void StringFormat(object number, string format)
        {
            switch (format)
            {
                case "f":
                    Console.WriteLine("{0:f2}", number);
                    break;
                case "%":
                    Console.WriteLine("{0:p0}", number);
                    break;
                case "r":
                    Console.WriteLine("{0,8}", number);
                    break;
                default:
                    throw new ArgumentException("Invalid argument");
            }
        }

        public static double CalculateDistance(double firstX, double firstY, double secondX, double secondY, out bool isHorizontal, out bool isVertical)
        {
            isHorizontal = firstY == secondY;
            isVertical = firstX == secondX;

            double distanceX = (secondX - firstX) * 2;
            double distanceY = (secondY - firstY) * 2;
            double distance = Math.Sqrt(distanceX + distanceY);

            return distance;
        }

        private static void Main()
        {
            Console.WriteLine(CalculateTriangleArea(3, 4, 5));

            Console.WriteLine(NumberToText(5));

            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));

            StringFormat(1.3, "f");
            StringFormat(0.75, "%");
            StringFormat(2.30, "r");

            bool horizontal, vertical;
            Console.WriteLine(CalculateDistance(3, -1, 3, 2.5, out horizontal, out vertical));
            Console.WriteLine("Horizontal? " + horizontal);
            Console.WriteLine("Vertical? " + vertical);

            Student peter = new Student
            {
                FirstName = "Peter",
                LastName = "Ivanov",
                Description = "From Sofia, born at 17.03.1992",
                DateOfBirth = new DateTime(1992, 03, 17)
            };

            Student stella = new Student
            {
                FirstName = "Stella",
                LastName = "Markova",
                Description = "From Vidin, gamer, high results, born at 03.11.1993",
                DateOfBirth = new DateTime(1993, 11, 03)
            };

            Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlder(stella));
        }
    }
}
