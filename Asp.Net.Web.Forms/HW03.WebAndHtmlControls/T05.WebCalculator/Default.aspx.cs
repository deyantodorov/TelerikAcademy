using System;
using System.Globalization;
using System.Web.UI;

namespace T05.WebCalculator
{
    public partial class Default : Page
    {
        private const string SignPlus = "plus";
        private const string SignMinus = "minus";
        private const string SignMultiply = "multiply";
        private const string SignDivision = "division";
        private const string SignSqrt = "sqrt";
        private const string Zero = "0";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Num0_Click(object sender, EventArgs e)
        {
            this.tbNumber.Text += 0;
        }

        protected void Num1_Click(object sender, EventArgs e)
        {
            this.tbNumber.Text += 1;
        }

        protected void Num2_Click(object sender, EventArgs e)
        {
            this.tbNumber.Text += 2;
        }

        protected void Num3_Click(object sender, EventArgs e)
        {
            this.tbNumber.Text += 3;
        }

        protected void Num4_Click(object sender, EventArgs e)
        {
            this.tbNumber.Text += 4;
        }

        protected void Num5_Click(object sender, EventArgs e)
        {
            this.tbNumber.Text += 5;
        }

        protected void Num6_Click(object sender, EventArgs e)
        {
            this.tbNumber.Text += 6;
        }

        protected void Num7_Click(object sender, EventArgs e)
        {
            this.tbNumber.Text += 7;
        }

        protected void Num8_Click(object sender, EventArgs e)
        {
            this.tbNumber.Text += 8;
        }

        protected void Num9_Click(object sender, EventArgs e)
        {
            this.tbNumber.Text += 9;
        }

        protected void Plus_Click(object sender, EventArgs e)
        {
            this.operation.Value = SignPlus;
            AddValues();
        }
        
        protected void Minus_Click(object sender, EventArgs e)
        {
            this.operation.Value = SignMinus;
            AddValues();
        }

        protected void Multiply_Click(object sender, EventArgs e)
        {
            this.operation.Value = SignMultiply;
            AddValues();
        }

        protected void Divide_Click(object sender, EventArgs e)
        {
            this.operation.Value = SignDivision;
            AddValues();
        }

        protected void Root_Click(object sender, EventArgs e)
        {
            this.operation.Value = SignSqrt;
            this.tbNumber.Text = Math.Sqrt(double.Parse(this.tbNumber.Text)).ToString(CultureInfo.InvariantCulture);
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            this.prevValue.Value = Zero;
            this.operation.Value = string.Empty;
            this.tbNumber.Text = string.Empty;
        }

        protected void Equal_Click(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {
                var firstNumber = double.Parse(this.prevValue.Value);
                var secondNumber = double.Parse(this.tbNumber.Text);

                switch (this.operation.Value)
                {
                    case SignPlus:
                        this.tbNumber.Text = (firstNumber + secondNumber).ToString(CultureInfo.InvariantCulture);
                        break;
                    case SignMinus:
                        this.tbNumber.Text = (firstNumber - secondNumber).ToString(CultureInfo.InvariantCulture);
                        break;
                    case SignMultiply:
                        this.tbNumber.Text = (firstNumber * secondNumber).ToString(CultureInfo.InvariantCulture);
                        break;
                    case SignDivision:
                        this.tbNumber.Text = (firstNumber / secondNumber).ToString(CultureInfo.InvariantCulture);
                        break;
                    case SignSqrt:
                        this.tbNumber.Text = Math.Sqrt(firstNumber).ToString(CultureInfo.InvariantCulture);
                        break;
                }
            }
        }

        private void AddValues()
        {
            this.prevValue.Value = this.tbNumber.Text;
            this.tbNumber.Text = string.Empty;
        }
    }
}