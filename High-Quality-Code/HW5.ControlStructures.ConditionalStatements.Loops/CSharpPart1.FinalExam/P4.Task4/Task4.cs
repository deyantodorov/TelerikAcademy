namespace P4.Task4
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Task4
    {
        private static List<string> middle = new List<string>();
        private static List<string> bottom = new List<string>();
        private static List<string> top = new List<string>();

        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int d = int.Parse(Console.ReadLine());
            int width = 2 * n + 1;

            MakeMiddle(width, d);
            MakeBottom(width, d);
            MakeTop();

            // Output result
            foreach (var item in top)
            {
                Console.WriteLine(item);
            }

            foreach (var item in middle)
            {
                Console.WriteLine(item);
            }

            foreach (var item in bottom)
            {
                Console.WriteLine(item);
            }
        }

        private static void MakeTop()
        {
            var temp = new List<string>();

            foreach (var item in bottom)
            {
                temp.Add(item);
            }

            temp.Reverse();

            foreach (var item in temp)
            {
                string replaced = MakeReplace(item);
                top.Add(replaced);
            }
        }

        private static void MakeBottom(int width, int d)
        {
            int tmp = middle.Count();

            if (tmp < 0)
            {
                tmp = 0;
            }

            int height = (width - middle.Count()) / 2;
            int spaceOut = (width - (d * 2 + 2)) / 2;

            if (spaceOut < 0)
            {
                spaceOut = 0;
            }

            string current = string.Empty;
            int newD = d;
            int dash = 1;
            int inDash = 1;
            int dots = 1;

            for (int i = 0; i < height; i++)
            {
                if (i == 0)
                {
                    if (spaceOut != width || spaceOut < width)
                    {
                        current = new string('.', spaceOut)
                                + new string('/', dash)
                                + new string('#', newD)
                                + new string('X', 1)
                                + new string('#', newD)
                                + new string('\\', dash)
                                + new string('.', spaceOut);

                        if (current.Length > width)
                        {
                            current = MakeSmaller(current, width);
                        }
                    }
                    else
                    {
                        current = new string('.', spaceOut)
                             + new string('/', inDash)
                             + new string('#', newD)
                             + new string('/', inDash)
                             + new string('.', dots)
                             + new string('\\', inDash)
                             + new string('#', newD)
                             + new string('\\', inDash)
                             + new string('.', spaceOut);

                        if (current.Length > width)
                        {
                            current = MakeSmaller(current, width);
                        }
                    }
                }
                else
                {
                    current = new string('.', spaceOut)
                            + new string('/', inDash)
                            + new string('#', newD)
                            + new string('/', inDash)
                            + new string('.', dots)
                            + new string('\\', inDash)
                            + new string('#', newD)
                            + new string('\\', inDash)
                            + new string('.', spaceOut);

                    if (current.Length > width)
                    {
                        current = MakeSmaller(current, width);
                    }
                }

                if (i != 0)
                {
                    dots += 2;
                }

                bottom.Add(current);
            }
        }

        private static string MakeSmaller(string current, int width)
        {
            var input = current;

            while (input.Length != width)
            {
                input = input.Substring(1, input.Length - 1); // cut first 
                input = input.Remove(input.Length - 1); // cut last
            }

            return input;
        }

        private static void MakeMiddle(int width, int d)
        {
            var middleTop = new List<string>();
            var middleMiddle = new List<string>();
            var middleBottom = new List<string>();

            int times = (d / 2) + 1;
            string current = string.Empty;
            int side = (width - d - 2) / 2;
            int newD = d;

            for (int i = 0; i < times; i++)
            {
                if (side < 0)
                {
                    side = 0;
                }

                if (i == 0)
                {
                    current = new string('.', side) + new string('X', 1) + new string('#', newD) + new string('X', 1) + new string('.', side);

                    if (current.Length > width)
                    {
                        current = MakeSmaller(current, width);
                    }

                    middleMiddle.Add(current);
                }
                else
                {
                    current = new string('.', side) + new string('/', 1) + new string('#', newD) + new string('\\', 1) + new string('.', side);

                    if (current.Length > width)
                    {
                        current = MakeSmaller(current, width);
                    }

                    middleBottom.Add(current);
                }

                side--;

                newD += 2;
            }

            foreach (var item in middleBottom)
            {
                middleTop.Add(item);
            }

            middleTop.Reverse();

            foreach (var item in middleTop)
            {
                string replaced = MakeReplace(item);
                middle.Add(replaced);
            }

            foreach (var item in middleMiddle)
            {
                middle.Add(item);
            }

            foreach (var item in middleBottom)
            {
                middle.Add(item);
            }
        }

        private static string MakeReplace(string item)
        {
            string result = string.Empty;

            for (int i = 0; i < item.Length; i++)
            {
                if (item[i] == '\\')
                {
                    result += '/';
                }
                else if (item[i] == '/')
                {
                    result += '\\';
                }
                else
                {
                    result += item[i];
                }
            }

            return result;
        }

        private static void MakeAllDies(int width)
        {
            for (int i = 0; i < width; i++)
            {
                Console.WriteLine(new string('#', width));
            }
        }
    }
}