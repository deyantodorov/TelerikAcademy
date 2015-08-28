namespace GenericClass
{
    using System;

    public class TestGenericClass
    {
        private static void Main()
        {
            GenericList<int> testInt = new GenericList<int>(5);

            for (int i = 0; i < testInt.Length; i++)
            {
                testInt[i] = i + 1;
            }

            Console.WriteLine(testInt[3]);
            testInt.RemoveAt(1);
            Console.WriteLine(testInt);
            Console.WriteLine(testInt.Find(11));
            testInt.InsertAt(3, 12);
            Console.WriteLine(testInt);

            Console.WriteLine("Max: " + testInt.Max());
            Console.WriteLine("Min: " + testInt.Min());
            testInt.Clear();
            Console.WriteLine(testInt);

            var testString = new GenericList<string>(5);

            for (int i = 0; i < testString.Length; i++)
            {
                testString[i] = ((char)(65 + i)).ToString();
            }

            Console.WriteLine(testString);
            testString.RemoveAt(1);
            Console.WriteLine(testString);
            Console.WriteLine(testString.Find("C"));
            testString.InsertAt(3, "W");
            Console.WriteLine(testString);

            Console.WriteLine("Max: " + testString.Max());
            Console.WriteLine("Min: " + testString.Min());

            testString.Clear();
            Console.WriteLine(testString);
        }
    }
}