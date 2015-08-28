namespace T06.Matrix
{
    using System;
    using System.Text;

    /// <summary>
    /// Matrix class with following features:
    ///  + adding
    ///  + subtracting
    ///  + multiplying of matrices using "dot product". I use this, because it's not defined "dot product" or matrix * some number.
    ///  + indexer for accessing the matrix content
    ///  + ToString()
    /// </summary>
    public class Matrix
    {
        private readonly int[,] matrix;
        private int row;
        private int col;
        
        public Matrix()
        {
        }

        public Matrix(int row, int col)
            : this()
        {
            this.Row = row;
            this.Col = col;
            this.matrix = new int[this.Row, this.Col];
        }

        public int Row
        {
            get
            {
                return this.row;
            }

            set
            {
                if (value < this.row)
                {
                    throw new Exception("Row size can't be less than current Row size!");
                }
                else
                {
                    this.row = value;
                }
            }
        }

        public int Col
        {
            get
            {
                return this.col;
            }

            set
            {
                if (value < this.col)
                {
                    throw new Exception("Col size can't be less than current Col size!");
                }
                else
                {
                    this.col = value;
                }
            }
        }

        /// <summary>
        /// Matrix indexer
        /// </summary>
        public int this[int row, int col]
        {
            get
            {
                return this.matrix[row, col];
            }

            set
            {
                this.matrix[row, col] = value;
            }
        }

        /// <summary>
        /// Adding two matrix
        /// </summary>
        /// <param name="first">first array information</param>
        /// <param name="second">second array information</param>
        /// <returns>new matrix with result of adding</returns>
        public static Matrix operator +(Matrix first, Matrix second)
        {
            if (first.Row != second.Row && first.Col != second.Col)
            {
                throw new ArgumentException("Both matrix rows and cols must be equal");
            }
            else
            {
                Matrix result = new Matrix(first.Row, first.Col);

                for (int r = 0; r < first.Row; r++)
                {
                    for (int c = 0; c < first.Col; c++)
                    {
                        result[r, c] = first[r, c] + second[r, c];
                    }
                }

                return result;
            }
        }

        /// <summary>
        /// Subtracting two matrix
        /// </summary>
        /// <param name="first">first array information</param>
        /// <param name="second">second array information</param>
        /// <returns>new matrix with result of subtracting</returns>
        public static Matrix operator -(Matrix first, Matrix second)
        {
            if (first.Row != second.Row && first.Col != second.Col)
            {
                throw new ArgumentException("Both matrix rows and cols must be equal");
            }
            else
            {
                Matrix result = new Matrix(first.Row, first.Col);

                for (int r = 0; r < first.Row; r++)
                {
                    for (int c = 0; c < first.Col; c++)
                    {
                        result[r, c] = first[r, c] - second[r, c];
                    }
                }

                return result;
            }
        }

        /// <summary>
        /// Matrix multiplication. I used this example for "dot product" calculations - http://www.mathsisfun.com/algebra/matrix-multiplying.html.
        /// If there is something wrong in my way of calculations, please excuse me, but I'm not a math guy!
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static Matrix operator *(Matrix first, Matrix second)
        {
            if (first.Row != second.Col)
            {
                throw new ArgumentException("Matrix rows and cols should be equal!");
            }
            else
            {
                Matrix result = new Matrix(first.Row, first.Col);

                for (int i = 0; i < first.Row; i++)
                {
                    for (int j = 0; j < first.Col; j++)
                    {
                        result[i, j] = first[i, j] * second[j, i];
                    }
                }

                return result;
            }
        }

        /// <summary>
        /// Override to string method
        /// </summary>
        /// <returns>StringBuilder converted ToString()</returns>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int r = 0; r < this.Row; r++)
            {
                for (int c = 0; c < this.Col; c++)
                {
                    result.Append(this.matrix[r, c]);

                    if (c != this.Col - 1)
                    {
                        result.Append(" ");
                    }

                    if (c == this.Col - 1 && !(r == this.Row - 1))
                    {
                        result.Append(Environment.NewLine);
                    }
                }
            }

            return result.ToString();
        }
    }
}
