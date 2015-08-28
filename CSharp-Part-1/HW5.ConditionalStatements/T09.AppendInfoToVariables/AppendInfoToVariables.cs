namespace T09.AppendInfoToVariables
{
    using System;
    using System.Globalization;
    using System.Threading;

    /// <summary>
    /// 9. Write a program that, depending on the user’s choice, inputs an int, double or string variable.
    /// If the variable is int or double, the program increases it by one.
    /// If the variable is a string, the program appends * at the end.
    /// Print the result at the console. Use switch statement.
    /// </summary>
    public class AppendInfoToVariables
    {
        private static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            int intVariable;
            double doubleVariable;
            string stringVariable;
            byte variableType = 0;

            Console.Write("Enter number or text: ");

            stringVariable = Console.ReadLine();
            bool isValidInt = int.TryParse(stringVariable, out intVariable);
            bool isValidDouble = double.TryParse(stringVariable.Replace(',', '.'), out doubleVariable);

            if (isValidInt == true)
            {
                variableType = 1;
            }

            if (isValidDouble == true && isValidInt == false)
            {
                variableType = 2;
            }

            switch (variableType)
            {
                case 1:
                    {
                        intVariable += 1;
                        Console.WriteLine("This is int variable with new value (variable + 1) = {0}", intVariable);
                        break;
                    }

                case 2:
                    {
                        doubleVariable += 1;
                        Console.WriteLine("This is double variable with new value (variable + 1) = {0}", doubleVariable);
                        break;
                    }

                default:
                    {
                        stringVariable += "*";
                        Console.WriteLine("This is string with new text (* appended) = {0}", stringVariable);
                        break;
                    }
            }
        }
    }
}