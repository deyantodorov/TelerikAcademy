namespace T1.ClassRefactored
{
    using System;

    public class TestClass
    {
        public void PrintBoolean(bool value)
        {
            string valueAsString = value.ToString();
            Console.WriteLine(valueAsString);
        }
    }
}
