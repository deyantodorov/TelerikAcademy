namespace T14.Labyrinth
{
    using System;
    using System.Text;

    public static class Extensions
    {
        public static Position GetIndex<T>(this T[,] matrix, T element)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col].Equals(element))
                    {
                        return new Position(row, col);
                    }
                }
            }

            throw new ArgumentException("Invalid element.");
        }

        public static bool IsInRange<T>(this T[,] matrix, Position coordinates)
        {
            return (0 <= coordinates.Row) && (coordinates.Row < matrix.GetLength(0)) &&
                   (0 <= coordinates.Col) && (coordinates.Col < matrix.GetLength(1));
        }

        public static T[,] Replace<T>(this T[,] matrix, T oldValue, T newValue)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col].Equals(oldValue))
                    {
                        matrix[row, col] = newValue;
                    }
                }
            }

            return matrix;
        }

        public static string AsString<T>(this T[,] matrix)
        {
            var result = new StringBuilder();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    result.Append(matrix[row, col] + (col != matrix.GetUpperBound(1) ? " " : Environment.NewLine));
                }
            }

            return result.ToString().TrimEnd();
        }
    }
}
