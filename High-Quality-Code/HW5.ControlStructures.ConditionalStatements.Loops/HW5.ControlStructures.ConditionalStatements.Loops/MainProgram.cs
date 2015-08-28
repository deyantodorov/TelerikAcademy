namespace HW5.ControlStructures.ConditionalStatements.Loops
{
    using System;

    public class MainProgram
    {
        private static void Main()
        {
            // 1. Refactor the following class using best practices for organizing straight-line code: 
            // This files: Chef.cs, Bowl.cs, Carrot.cs, Potato.cs, Vegetable.cs, IVegetable.cs

            // 2. Refactor the following if statements: See: Chef.cs and MainProgram.cs
            int x = 1;
            int y = 2;
            int minX = 0;
            int maxX = 9;
            int minY = 0;
            int maxY = 9;
            bool inRange = (minX <= x && minY <= y) && (x <= maxX && y <= maxY);

            if (inRange)
            {
                VisitCell();
            }

            // 3. Refactor the following loop: 
            int expectedValue = 123;
            int[] array = new int[1000];

            int i;
            for (i = 0; i < 100; i++)
            {
                if (i % 10 == 0)
                {
                    Console.WriteLine(array[i]);

                    if (array[i] == expectedValue)
                    {
                        i = 666;
                    }
                }
                else
                {
                    Console.WriteLine(array[i]);
                }
            }

            // More code here
            if (i == 666)
            {
                Console.WriteLine("Value Found");
            }
        }

        private static void VisitCell()
        {
            throw new NotImplementedException();
        }
    }
}
