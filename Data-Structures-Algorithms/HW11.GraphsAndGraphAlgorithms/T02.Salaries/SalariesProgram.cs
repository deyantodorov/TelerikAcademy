namespace T02.Salaries
{
    using System;
    using System.IO;

    public class SalariesProgram
    {
        private const int MaxN = 64;
        private static int numOfLines = 0;
        private static bool[,] adjecentMatrix = new bool[MaxN, MaxN];
        private static long[] cache = new long[MaxN];
        
        private static void Main()
        {
            // Hardcode input, be carefull with that sometimes work nasty
            if (Environment.CurrentDirectory.ToLower().EndsWith("bin\\debug"))
            {
                //Console.SetIn(new StreamReader("input.txt"));
                Console.SetIn(new StreamReader("input2.txt"));
            }

            ReadMatrix();
            SumOfSalaries();
        }

        private static void SumOfSalaries()
        {
            long sumOfSalaries = 0;
            for (int i = 0; i < numOfLines; i++)
            {
                sumOfSalaries += FindSalary(i);
            }

            Console.WriteLine(sumOfSalaries);
        }

        private static void ReadMatrix()
        {
            numOfLines = int.Parse(Console.ReadLine());

            var line = string.Empty;
            for (int i = 0; i < numOfLines; i++)
            {
                line = Console.ReadLine();

                for (int j = 0; j < numOfLines; j++)
                {
                    // fill with 1 or 0
                    adjecentMatrix[i, j] = (line[j] == 'Y');
                }
            }
        }

        private static long FindSalary(int employee)
        {
            if (cache[employee] > 0)
            {
                return cache[employee];
            }

            long salary = 0;

            for (int i = 0; i < numOfLines; i++)
            {
                if (adjecentMatrix[employee,i])
                {
                    salary += FindSalary(i);
                }
            }

            if (salary == 0)
            {
                salary = 1;
            }

            cache[employee] = salary;

            return salary;
        }
    }
}
