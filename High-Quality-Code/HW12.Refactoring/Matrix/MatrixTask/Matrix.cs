namespace MatrixTask
{
    using System;
    using System.Text;

    public class Matrix
    {
        private const string WelcomeText = "Enter a positive number ";
        private const string WelcomeTextError = "You haven't entered a correct positive number";
        private const int MinMatrixSize = 1;
        private const int MaxMatrixSize = 100;
        private const int NumberOfDirections = 8;

        private readonly int matrixSize;
        private readonly int[,] matrix;

        private int matrixCurrentNumber;
        private int matrixRow;
        private int matrixCol;
        private int matrixDirectionX;
        private int matrixDirectionY;

        public Matrix(int matrixSize)
        {
            this.matrixSize = matrixSize;
            this.matrix = new int[this.matrixSize, this.matrixSize];
            this.matrixCurrentNumber = 1;
            this.matrixRow = 0;
            this.matrixCol = 0;
            this.matrixDirectionX = 1;
            this.matrixDirectionY = 1;
        }

        public static int ReadInputFromConsole()
        {
            int number;
            Console.WriteLine(WelcomeText);
            string input = Console.ReadLine();
            while (!int.TryParse(input, out number) || number < MinMatrixSize || number > MaxMatrixSize)
            {
                Console.WriteLine(WelcomeTextError);
                input = Console.ReadLine();
            }

            return number;
        }

        public string Walk()
        {
            this.WalkInMatrix();
            this.FindEmptyCell();

            if (this.matrixRow == 0 || this.matrixCol == 0)
            {
                return this.Print();
            }

            this.matrixDirectionX = 1;
            this.matrixDirectionY = 1;
            this.matrixCurrentNumber++;

            this.WalkInMatrix();

            return this.Print();
        }

        private void WalkInMatrix()
        {
            while (true)
            {
                this.matrix[this.matrixRow, this.matrixCol] = this.matrixCurrentNumber;

                if (!this.IsExit())
                {
                    break;
                }

                while (this.IsRowInMatrix() || this.IsColInMatrix() || this.IsFieldNotEqualToZero())
                {
                    this.ChangeDirection();
                }

                this.matrixRow += this.matrixDirectionX;
                this.matrixCol += this.matrixDirectionY;

                this.matrixCurrentNumber++;
            }
        }

        private bool IsFieldNotEqualToZero()
        {
            bool isFieldNotEqualToZero = this.matrix[this.matrixRow + this.matrixDirectionX, this.matrixCol + this.matrixDirectionY] != 0;
            return isFieldNotEqualToZero;
        }

        private bool IsRowInMatrix()
        {
            bool isRowInMatrix = this.matrixRow + this.matrixDirectionX >= this.matrixSize || this.matrixRow + this.matrixDirectionX < 0;
            return isRowInMatrix;
        }

        private bool IsColInMatrix()
        {
            bool isColInMatrix = this.matrixCol + this.matrixDirectionY >= this.matrixSize || this.matrixCol + this.matrixDirectionY < 0;
            return isColInMatrix;
        }

        private void ChangeDirection()
        {
            int[] directionsX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] directionsY = { 1, 0, -1, -1, -1, 0, 1, 1 };

            int changeDirection = 0;

            for (int count = 0; count < NumberOfDirections; count++)
            {
                if (directionsX[count] != this.matrixDirectionX || directionsY[count] != this.matrixDirectionY)
                {
                    continue;
                }

                changeDirection = count;
                break;
            }

            if (changeDirection == NumberOfDirections - 1)
            {
                this.matrixDirectionX = directionsX[0];
                this.matrixDirectionY = directionsY[0];

                return;
            }

            this.matrixDirectionX = directionsX[changeDirection + 1];
            this.matrixDirectionY = directionsY[changeDirection + 1];
        }

        private bool IsExit()
        {
            int positionX = this.matrixRow;
            int positionY = this.matrixCol;

            int[] directionsX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] directionsY = { 1, 0, -1, -1, -1, 0, 1, 1 };

            for (int i = 0; i < NumberOfDirections; i++)
            {
                if (positionX + directionsX[i] >= this.matrix.GetLength(0) || positionX + directionsX[i] < 0)
                {
                    directionsX[i] = 0;
                }

                if (positionY + directionsY[i] >= this.matrix.GetLength(0) || positionY + directionsY[i] < 0)
                {
                    directionsY[i] = 0;
                }
            }

            for (int i = 0; i < NumberOfDirections; i++)
            {
                if (this.matrix[positionX + directionsX[i], positionY + directionsY[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        private void FindEmptyCell()
        {
            this.matrixRow = 0;
            this.matrixCol = 0;

            for (int r = 0; r < this.matrix.GetLength(0); r++)
            {
                for (int c = 0; c < this.matrix.GetLength(0); c++)
                {
                    if (this.matrix[r, c] != 0)
                    {
                        continue;
                    }

                    this.matrixRow = r;
                    this.matrixCol = c;

                    return;
                }
            }
        }

        private string Print()
        {
            var builder = new StringBuilder();

            for (int row = 0; row < this.matrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.matrix.GetLength(1); col++)
                {
                    if (col == this.matrix.GetLength(1) - 1)
                    {
                        builder.AppendLine(string.Format("{0,3}", this.matrix[row, col]));
                    }
                    else
                    {
                        builder.Append(string.Format("{0,3}", this.matrix[row, col]));
                    }
                }
            }

            return builder.ToString();
        }
    }
}
