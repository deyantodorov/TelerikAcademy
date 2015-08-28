namespace T06.Matrix
{
    using System;

    /// <summary>
    /// 6. * Write a class Matrix, to holds a matrix of integers. Overload the operators for adding, subtracting and multiplying of matrices, indexer for accessing the matrix content and ToString().
    /// </summary>
    public class MatrixTest
    {
        private static void Main()
        {
            // Create first matrix and add values with indexer
            Matrix myMatrix1 = new Matrix(2, 2);
            myMatrix1[0, 0] = 1;
            myMatrix1[0, 1] = 2;
            myMatrix1[1, 0] = 3;
            myMatrix1[1, 1] = 4;

            // Create second matrix and add values with indexer
            Matrix myMatrix2 = new Matrix(2, 2);
            myMatrix2[0, 0] = 5;
            myMatrix2[0, 1] = 6;
            myMatrix2[1, 0] = 7;
            myMatrix2[1, 1] = 8;

            // Testing ToString(), adding, subtracting and multiplying of matrices 
            Console.WriteLine(myMatrix1);
            Console.WriteLine(myMatrix2);
            Console.WriteLine("Adding: ");
            Console.WriteLine(new string('-', 4));
            Console.WriteLine(myMatrix1 + myMatrix2);
            Console.WriteLine("Subtracting: ");
            Console.WriteLine(myMatrix1 - myMatrix2);
            Console.WriteLine("Multiplying: ");
            Console.WriteLine(myMatrix1 * myMatrix2);
        }
    }
}
