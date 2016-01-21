using System;
using System.Globalization;
using System.Web.UI;

namespace WebFormsSumApp
{
    public partial class _Default : Page
    {
        protected void SumNumbers_Click(object sernder, EventArgs e)
        {
            try
            {
                this.ErrorField.Style.Add("display", "none");

                var firstNumber = decimal.Parse(this.FirstNumberInput.Text.ToString(CultureInfo.InvariantCulture));
                var secondNumber = decimal.Parse(this.SecondNumberInput.Text.ToString(CultureInfo.InvariantCulture));
                var result = firstNumber + secondNumber;

                this.ResultInput.Text = result.ToString(CultureInfo.InvariantCulture);
            }
            catch (FormatException ex)
            {
                this.ErrorField.Style.Add("display", "block");
                this.ErrorField.Style.Add("font-weight", "bold");
                this.ErrorField.Style.Add("color", "red");

                this.ErrorField.InnerText = "Error: " + ex.Message;
            }

        }
    }
}