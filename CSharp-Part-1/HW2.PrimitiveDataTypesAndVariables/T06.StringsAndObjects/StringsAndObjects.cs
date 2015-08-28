namespace T06.StringsAndObjects
{
    using System;

    /// <summary>
    /// 6. Declare two string variables and assign them with Hello and World. 
    ///    Declare an object variable and assign it with the concatenation of the first two variables (mind adding an interval between). 
    ///    Declare a third string variable and initialize it with the value of the object variable (you should perform type casting).
    /// </summary>
    public class StringsAndObjects
    {
        private static void Main()
        {
            string hello = "Hello";
            string world = "World";
            object objHelloWorld = hello + " " + world;
            string strHelloWorld = (string)objHelloWorld;

            Console.WriteLine("string = {0}", hello);
            Console.WriteLine("string = {0}", world);
            Console.WriteLine("object = {0}", objHelloWorld);
            Console.WriteLine("string = {0}", strHelloWorld);
        }
    }
}