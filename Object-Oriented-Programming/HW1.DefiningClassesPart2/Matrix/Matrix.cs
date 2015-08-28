namespace Matrix
{
    using System;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Problem 8. Matrix
    ///            Define a class Matrix<T> to hold a matrix of numbers (e.g. integers, floats, decimals).
    /// 
    /// Problem 9. Matrix indexer
    ///            Implement an indexer this[row, col] to access the inner matrix cells.
    /// 
    /// Problem 10. Matrix operations
    ///             Implement the operators + and - (addition and subtraction of matrices of the same size) and * for matrix multiplication.
    ///             Throw an exception when the operation cannot be performed.
    ///             Implement the true operator (check for non-zero elements).
    /// </summary>
    public class Matrix<T> where T : IComparable
    {
        private readonly T[,] matrix;
        private int row;
        private int col;

        public Matrix(int row, int col)
        {
            this.Row = row;
            this.Col = col;
            this.matrix = new T[this.Row, this.Col];
        }

        public int Row
        {
            get
            {
                return this.row;
            }

            private set
            {
                this.ValidateForNegativeValue(value);
                this.row = value;
            }
        }

        public int Col
        {
            get
            {
                return this.col;
            }

            private set
            {
                this.ValidateForNegativeValue(value);
                this.col = value;
            }
        }

        public T this[int row, int col]
        {
            get
            {
                this.ValidateForOutOfRange(row, col);
                return this.matrix[row, col];
            }

            set
            {
                this.ValidateForOutOfRange(row, col);
                this.matrix[row, col] = value;
            }
        }

        public static Matrix<T> operator +(Matrix<T> first, Matrix<T> second)
        {
            if (first.Row != second.Row && first.Col != second.Col)
            {
                throw new ArithmeticException("Can't applay addition on different matrix");
            }

            Matrix<T> result = new Matrix<T>(first.Row, first.Col);

            for (int row = 0; row < first.Row; row++)
            {
                for (int col = 0; col < first.Col; col++)
                {
                    dynamic firstValue = first[row, col];
                    dynamic secondValue = second[row, col];
                    result[row, col] = firstValue + secondValue;
                }
            }

            return result;
        }

        public static Matrix<T> operator -(Matrix<T> first, Matrix<T> second)
        {
            if (first.Row != second.Row && first.Col != second.Col)
            {
                throw new ArithmeticException("Can't applay addition on different matrix");
            }

            Matrix<T> result = new Matrix<T>(first.Row, first.Col);

            for (int row = 0; row < first.Row; row++)
            {
                for (int col = 0; col < first.Col; col++)
                {
                    dynamic firstValue = first[row, col];
                    dynamic secondValue = second[row, col];
                    result[row, col] = firstValue - secondValue;
                }
            }

            return result;
        }

        /// <summary>
        /// Matrix multiplication. I used this example for "dot product" calculations - http://www.mathsisfun.com/algebra/matrix-multiplying.html.
        /// If there is something wrong in my way of calculations, please excuse me, but I'm not a math guy!
        /// </summary>
        public static Matrix<T> operator *(Matrix<T> first, Matrix<T> second)
        {
            if (first.Row != second.Col)
            {
                throw new ArgumentException("Matrix rows and cols should be equal!");
            }
            else
            {
                Matrix<T> result = new Matrix<T>(first.Row, first.Col);

                for (int r = 0; r < first.Row; r++)
                {
                    for (int c = 0; c < first.Col; c++)
                    {
                        dynamic firstValue = first[r, c];
                        dynamic secondValue = second[c, r];

                        result[r, c] = firstValue * secondValue;
                    }
                }

                return result;
            }
        }

        public static bool operator true(Matrix<T> matrix)
        {
            if (matrix == null || matrix.Row == 0 || matrix.Col == 0)
            {
                return false;
            }

            for (int row = 0; row < matrix.Row; row++)
            {
                for (int col = 0; col < matrix.Col; col++)
                {
                    if (matrix[row, col].Equals(default(T)))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool operator false(Matrix<T> matrix)
        {
            if (matrix == null || matrix.Row == 0 || matrix.Col == 0)
            {
                return true;
            }

            for (int row = 0; row < matrix.Row; row++)
            {
                for (int col = 0; col < matrix.Col; col++)
                {
                    if (matrix[row, col].Equals(default(T)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int row = 0; row < this.matrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.matrix.GetLength(1); col++)
                {
                    result.Append(this.matrix[row, col]);
                    result.Append(" ");
                }

                result.Append(Environment.NewLine);
            }

            if (this.Row != 0 && this.Col != 0)
            {
                result.Remove(result.Length - 1, 1);
            }

            return result.ToString();
        }

        private void ValidateForOutOfRange(int row, int col)
        {
            if (row < 0 || col < 0 || row >= this.matrix.GetLength(0) || col >= this.matrix.GetLength(1))
            {
                throw new ArgumentOutOfRangeException("Out of range");
            }
        }

        private void ValidateForNegativeValue(int value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Value for row can't be negative");
            }
        }
    }
}
