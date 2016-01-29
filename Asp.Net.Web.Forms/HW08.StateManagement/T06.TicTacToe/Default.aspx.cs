using System;
using System.Collections.Generic;
using System.Web.UI;

namespace T04.TicTacToe
{
    public partial class Default : Page
    {
        private const string UserSymbol = "X";
        private const string ComputerSymbol = "O";
        private const string UserWin = "You win and computer loose. Congratulations!";
        private const string ComputerWin = "Computer win and you loose. Try again and don't cry!";

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void C1_Click(object sender, EventArgs e)
        {
            SetUserValue("c1");
        }

        protected void C2_Click(object sender, EventArgs e)
        {
            SetUserValue("c2");
        }

        protected void C3_Click(object sender, EventArgs e)
        {
            SetUserValue("c3");
        }

        protected void C4_Click(object sender, EventArgs e)
        {
            SetUserValue("c4");
        }

        protected void C5_Click(object sender, EventArgs e)
        {
            SetUserValue("c5");
        }

        protected void C6_Click(object sender, EventArgs e)
        {
            SetUserValue("c6");
        }

        protected void C7_Click(object sender, EventArgs e)
        {
            SetUserValue("c7");
        }

        protected void C8_Click(object sender, EventArgs e)
        {
            SetUserValue("c8");
        }

        protected void C9_Click(object sender, EventArgs e)
        {
            SetUserValue("c9");
        }

        private void SetUserValue(string cell)
        {
            switch (cell)
            {
                case "c1":
                    if (string.IsNullOrEmpty(this.c1.InnerText))
                    {
                        this.c1.InnerText = UserSymbol;
                        CheckWinner();
                        SetComputerValue();
                        CheckWinner();
                    }

                    break;
                case "c2":
                    if (string.IsNullOrEmpty(this.c2.InnerText))
                    {
                        this.c2.InnerText = UserSymbol;
                        CheckWinner();
                        SetComputerValue();
                        CheckWinner();
                    }

                    break;
                case "c3":
                    if (string.IsNullOrEmpty(this.c3.InnerText))
                    {
                        this.c3.InnerText = UserSymbol;
                        CheckWinner();
                        SetComputerValue();
                        CheckWinner();
                    }

                    break;
                case "c4":
                    if (string.IsNullOrEmpty(this.c4.InnerText))
                    {
                        this.c4.InnerText = UserSymbol;
                        CheckWinner();
                        SetComputerValue();
                        CheckWinner();
                    }

                    break;
                case "c5":
                    if (string.IsNullOrEmpty(this.c5.InnerText))
                    {
                        this.c5.InnerText = UserSymbol;
                        CheckWinner();
                        SetComputerValue();
                        CheckWinner();
                    }

                    break;
                case "c6":
                    if (string.IsNullOrEmpty(this.c6.InnerText))
                    {
                        this.c6.InnerText = UserSymbol;
                        CheckWinner();
                        SetComputerValue();
                        CheckWinner();
                    }

                    break;
                case "c7":
                    if (string.IsNullOrEmpty(this.c7.InnerText))
                    {
                        this.c7.InnerText = UserSymbol;
                        CheckWinner();
                        SetComputerValue();
                        CheckWinner();
                    }

                    break;
                case "c8":
                    if (string.IsNullOrEmpty(this.c8.InnerText))
                    {
                        this.c8.InnerText = UserSymbol;
                        CheckWinner();
                        SetComputerValue();
                        CheckWinner();
                    }

                    break;
                case "c9":
                    if (string.IsNullOrEmpty(this.c9.InnerText))
                    {
                        this.c9.InnerText = UserSymbol;
                        CheckWinner();
                        SetComputerValue();
                        CheckWinner();
                    }

                    break;
                default:
                    throw new ArgumentException("Unsupported cell");
            }
        }

        private void CheckWinner()
        {
            var cells = new string[3, 3];

            cells[0, 0] = this.c1.InnerText;
            cells[0, 1] = this.c2.InnerText;
            cells[0, 2] = this.c3.InnerText;
            cells[1, 0] = this.c4.InnerText;
            cells[1, 1] = this.c5.InnerText;
            cells[1, 2] = this.c6.InnerText;
            cells[2, 0] = this.c7.InnerText;
            cells[2, 1] = this.c8.InnerText;
            cells[2, 2] = this.c9.InnerText;

            CheckColumns(cells);
            CheckRows(cells);
            CheckDiagonals(cells);
        }

        private void CheckDiagonals(string[,] cells)
        {
            if (cells[0, 0] == UserSymbol && cells[1, 1] == UserSymbol && cells[2, 2] == UserSymbol)
            {
                this.result.Visible = true;
                this.result.InnerText = UserWin;
                return;
            }

            if (cells[0, 0] == ComputerSymbol && cells[1, 1] == ComputerSymbol && cells[2, 2] == ComputerSymbol)
            {
                this.result.Visible = true;
                this.result.InnerText = ComputerWin;
                return;
            }

            if (cells[0, 2] == UserSymbol && cells[1, 1] == UserSymbol && cells[2, 0] == UserSymbol)
            {
                this.result.Visible = true;
                this.result.InnerText = UserWin;
                return;
            }

            if (cells[0, 2] == ComputerSymbol && cells[1, 1] == ComputerSymbol && cells[2, 0] == ComputerSymbol)
            {
                this.result.Visible = true;
                this.result.InnerText = ComputerWin;
                return;
            }
        }

        private void CheckRows(string[,] cells)
        {
            var userCount = 0;
            var computerCount = 0;

            for (int r = 0; r < cells.GetLength(0); r++)
            {
                for (int c = 0; c < cells.GetLength(1); c++)
                {
                    if (cells[r, c] == UserSymbol)
                    {
                        userCount++;
                    }

                    if (cells[r, c] == ComputerSymbol)
                    {
                        computerCount++;
                    }
                }

                if (userCount == 3 || computerCount == 3)
                {
                    break;
                }

                userCount = 0;
                computerCount = 0;
            }

            if (userCount == 3)
            {
                this.result.Visible = true;
                this.result.InnerText = UserWin;
                return;
            }

            if (computerCount == 3)
            {
                this.result.Visible = true;
                this.result.InnerText = ComputerWin;
                return;
            }
        }

        private void CheckColumns(string[,] cells)
        {
            var userCount = 0;
            var computerCount = 0;

            for (int c = 0; c < cells.GetLength(0); c++)
            {
                for (int r = 0; r < cells.GetLength(1); r++)
                {
                    if (cells[r, c] == UserSymbol)
                    {
                        userCount++;
                    }

                    if (cells[r, c] == ComputerSymbol)
                    {
                        computerCount++;
                    }
                }

                if (userCount == 3 || computerCount == 3)
                {
                    break;
                }

                userCount = 0;
                computerCount = 0;
            }

            if (userCount == 3)
            {
                this.result.Visible = true;
                this.result.InnerText = UserWin;
                return;
            }

            if (computerCount == 3)
            {
                this.result.Visible = true;
                this.result.InnerText = ComputerWin;
                return;
            }
        }

        private void SetComputerValue()
        {
            var rand = new Random();
            var freeCells = GetFreeCells();

            var computerCell = 0;

            if (freeCells.Count == 0)
            {
                computerCell = -1;
            }
            else
            {
                computerCell = freeCells.Count > 0 ? freeCells[rand.Next(0, freeCells.Count)] : freeCells[0];
            }


            switch (computerCell)
            {
                case 1:
                    this.c1.InnerText = ComputerSymbol;
                    break;
                case 2:
                    this.c2.InnerText = ComputerSymbol;
                    break;
                case 3:
                    this.c3.InnerText = ComputerSymbol;
                    break;
                case 4:
                    this.c4.InnerText = ComputerSymbol;
                    break;
                case 5:
                    this.c5.InnerText = ComputerSymbol;
                    break;
                case 6:
                    this.c6.InnerText = ComputerSymbol;
                    break;
                case 7:
                    this.c7.InnerText = ComputerSymbol;
                    break;
                case 8:
                    this.c8.InnerText = ComputerSymbol;
                    break;
                case 9:
                    this.c9.InnerText = ComputerSymbol;
                    break;
                default:
                    return;
            }
        }

        private List<int> GetFreeCells()
        {
            var freeCells = new List<int>();

            if (string.IsNullOrEmpty(this.c1.InnerText))
            {
                freeCells.Add(1);
            }

            if (string.IsNullOrEmpty(this.c2.InnerText))
            {
                freeCells.Add(2);
            }

            if (string.IsNullOrEmpty(this.c3.InnerText))
            {
                freeCells.Add(3);
            }

            if (string.IsNullOrEmpty(this.c4.InnerText))
            {
                freeCells.Add(4);
            }

            if (string.IsNullOrEmpty(this.c5.InnerText))
            {
                freeCells.Add(5);
            }

            if (string.IsNullOrEmpty(this.c6.InnerText))
            {
                freeCells.Add(6);
            }

            if (string.IsNullOrEmpty(this.c7.InnerText))
            {
                freeCells.Add(7);
            }

            if (string.IsNullOrEmpty(this.c8.InnerText))
            {
                freeCells.Add(8);
            }

            if (string.IsNullOrEmpty(this.c9.InnerText))
            {
                freeCells.Add(9);
            }

            return freeCells;
        }
    }
}