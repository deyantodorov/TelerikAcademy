namespace Matrix
{
    using System;

    public class TestMatrix
    {
        private static void Main()
        {
            var matrix1 = new Matrix<int>(3, 3);
            int value = 1;

            for (int r = 0; r < matrix1.Row; r++)
            {
                for (int c = 0; c < matrix1.Col; c++)
                {
                    matrix1[r, c] = value;
                    value++;
                }
            }

            var matrix2 = new Matrix<int>(3, 3);

            for (int r = 0; r < matrix2.Row; r++)
            {
                for (int c = 0; c < matrix2.Col; c++)
                {
                    matrix2[r, c] = value;
                    value++;
                }
            }

            Console.WriteLine(matrix1);
            Console.WriteLine();
            Console.WriteLine(matrix2);
            Console.WriteLine();
            Console.WriteLine(matrix1 + matrix2);
            Console.WriteLine();
            Console.WriteLine(matrix2 - matrix1);

            if (matrix1)
            {
                Console.WriteLine("Empty");
            }

            if (matrix2)
            {
                Console.WriteLine("Empty");
            }

            var matrix3 = new Matrix<int>(1, 1);

            if (matrix3)
            {
                Console.WriteLine("Empty ");
                Console.WriteLine(matrix3);
            }

            // Boom exception, because of different rows and cols
            // Console.WriteLine(matrix1 * matrix3);
            Console.WriteLine(matrix1 * matrix2);
        }
    }
}