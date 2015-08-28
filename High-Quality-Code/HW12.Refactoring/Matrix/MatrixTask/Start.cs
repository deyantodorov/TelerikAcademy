namespace MatrixTask
{
    using System;

    public class Start
    {
        internal static void Main()
        {
            int size = Matrix.ReadInputFromConsole();
            var matrix = new Matrix(size);
            var output = matrix.Walk();
            Console.Write(output);
        }
    }
}
