namespace T4.Mines
{
    using System;
    using System.Collections.Generic;

    public class MainProgram
    {
        private static readonly Random Random = new Random();

        private static void Main()
        {
            string command;
            char[,] field = CreateField();
            char[,] bombs = PlaceBombs();
            int counter = 0;
            bool shoot = false;
            List<Point> winners = new List<Point>(6);
            int row = 0;
            int col = 0;
            bool startGame = true;
            bool finishGame = false;

            do
            {
                if (startGame)
                {
                    Console.WriteLine(Constants.MessageWelcome);
                    DrawBoard(field);
                    startGame = false;
                }

                Console.Write(Constants.MessageSetRowCol);

                string readLine = Console.ReadLine();
                command = readLine != null ? readLine.Trim() : string.Empty;

                if (command.Length >= 3)
                {
                    if (IsValidRowCol(command, field, ref row, ref col))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        Rating(winners);
                        break;
                    case "restart":
                        field = CreateField();
                        bombs = PlaceBombs();
                        DrawBoard(field);
                        break;
                    case "exit":
                        Console.WriteLine(Constants.MessageBye);
                        break;
                    case "turn":
                        if (bombs[row, col] != Constants.BombSymbol)
                        {
                            if (bombs[row, col] == Constants.BlankCell)
                            {
                                NextTurn(field, bombs, row, col);
                                counter++;
                            }

                            if (Constants.Max == counter)
                            {
                                finishGame = true;
                            }
                            else
                            {
                                DrawBoard(field);
                            }
                        }
                        else
                        {
                            shoot = true;
                        }

                        break;
                    default:
                        Console.WriteLine(Constants.MessageInvalidCommand);
                        break;
                }

                if (shoot)
                {
                    DrawBoard(bombs);
                    Console.Write(Constants.MessageYouAreDead, counter);
                    string niknejm = Console.ReadLine();
                    Point t = new Point(niknejm, counter);

                    if (winners.Count < 5)
                    {
                        winners.Add(t);
                    }
                    else
                    {
                        for (int i = 0; i < winners.Count; i++)
                        {
                            if (winners[i].Points < t.Points)
                            {
                                winners.Insert(i, t);
                                winners.RemoveAt(winners.Count - 1);
                                break;
                            }
                        }
                    }

                    winners.Sort((r1, r2) => r2.Name.CompareTo(r1.Name));
                    winners.Sort((r1, r2) => r2.Points.CompareTo(r1.Points));

                    Rating(winners);

                    field = CreateField();
                    bombs = PlaceBombs();
                    counter = 0;
                    shoot = false;
                    startGame = true;
                }

                if (finishGame)
                {
                    Console.WriteLine(Constants.MessageYouWin);
                    DrawBoard(bombs);

                    Console.WriteLine(Constants.MessageEnterName);
                    string name = Console.ReadLine();
                    Point point = new Point(name, counter);

                    winners.Add(point);
                    Rating(winners);
                    field = CreateField();
                    bombs = PlaceBombs();
                    counter = 0;
                    finishGame = false;
                    startGame = true;
                }
            }
            while (command != "exit");

            Console.WriteLine(Constants.MessageEndGameLine1);
            Console.WriteLine(Constants.MessageGameEndLine2);
            Console.Read();
        }

        private static bool IsValidRowCol(string command, char[,] field, ref int row, ref int col)
        {
            bool isValid = int.TryParse(command[0].ToString(), out row) && int.TryParse(command[2].ToString(), out col) && row <= field.GetLength(0) && col <= field.GetLength(1);
            return isValid;
        }

        private static void Rating(List<Point> points)
        {
            Console.WriteLine("\nTo4KI:");

            if (points.Count > 0)
            {
                for (int i = 0; i < points.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} kutii", i + 1, points[i].Name, points[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("prazna klasaciq!\n");
            }
        }

        private static void NextTurn(char[,] field, char[,] bombs, int red, int col)
        {
            char howMuchBombs = Find(bombs, red, col);

            bombs[red, col] = howMuchBombs;
            field[red, col] = howMuchBombs;
        }

        private static void DrawBoard(char[,] board)
        {
            int row = board.GetLength(0);
            int col = board.GetLength(1);

            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");

            for (int r = 0; r < row; r++)
            {
                Console.Write("{0} | ", r);

                for (int c = 0; c < col; c++)
                {
                    Console.Write("{0} ", board[r, c]);
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreateField()
        {
            char[,] board = new char[Constants.Rows, Constants.Cols];

            for (int r = 0; r < Constants.Rows; r++)
            {
                for (int c = 0; c < Constants.Cols; c++)
                {
                    board[r, c] = Constants.EmptyCell;
                }
            }

            return board;
        }

        private static char[,] PlaceBombs()
        {
            char[,] field = new char[Constants.Rows, Constants.Cols];

            for (int r = 0; r < Constants.Rows; r++)
            {
                for (int c = 0; c < Constants.Cols; c++)
                {
                    field[r, c] = Constants.BlankCell;
                }
            }

            List<int> bombs = new List<int>();

            while (bombs.Count < 15)
            {
                int randomValue = Random.Next(50);

                if (!bombs.Contains(randomValue))
                {
                    bombs.Add(randomValue);
                }
            }

            foreach (int value in bombs)
            {
                int row = value %Constants.Cols;
                int col = value /Constants.Cols;

                if (row == 0 && value != 0)
                {
                    col--;
                    row = Constants.Cols;
                }
                else
                {
                    row++;
                }

                field[col, row - 1] = Constants.BombSymbol;
            }

            return field;
        }

        private static char Find(char[,] fild, int col, int row)
        {
            int count = 0;
            int rows = fild.GetLength(0);
            int cols = fild.GetLength(1);

            if (col - 1 >= 0)
            {
                if (fild[col - 1, row] == Constants.BombSymbol)
                {
                    count++;
                }
            }

            if (col + 1 < rows)
            {
                if (fild[col + 1, row] == Constants.BombSymbol)
                {
                    count++;
                }
            }

            if (row - 1 >= 0)
            {
                if (fild[col, row - 1] == Constants.BombSymbol)
                {
                    count++;
                }
            }

            if (row + 1 < cols)
            {
                if (fild[col, row + 1] == Constants.BombSymbol)
                {
                    count++;
                }
            }

            if ((col - 1 >= 0) && (row - 1 >= 0))
            {
                if (fild[col - 1, row - 1] == Constants.BombSymbol)
                {
                    count++;
                }
            }

            if ((col - 1 >= 0) && (row + 1 < cols))
            {
                if (fild[col - 1, row + 1] == Constants.BombSymbol)
                {
                    count++;
                }
            }

            if ((col + 1 < rows) && (row - 1 >= 0))
            {
                if (fild[col + 1, row - 1] == Constants.BombSymbol)
                {
                    count++;
                }
            }

            if ((col + 1 < rows) && (row + 1 < cols))
            {
                if (fild[col + 1, row + 1] == Constants.BombSymbol)
                {
                    count++;
                }
            }

            return char.Parse(count.ToString());
        }

        private static void Calculations(char[,] field)
        {
            int row = field.GetLength(1);
            int col = field.GetLength(0);

            for (int c = 0; c < col; c++)
            {
                for (int r = 0; r < row; r++)
                {
                    if (field[c, r] != Constants.BombSymbol)
                    {
                        char howMuch = Find(field, c, r);
                        field[c, r] = howMuch;
                    }
                }
            }
        }
    }
}
