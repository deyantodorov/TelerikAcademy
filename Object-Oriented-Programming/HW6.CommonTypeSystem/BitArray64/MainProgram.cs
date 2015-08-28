namespace BitArray64
{
    using System;
    using System.Linq;

    /// <summary>
    /// Problem 5. 64 Bit array
    ///            Define a class BitArray64 to hold 64 bit values inside an ulong value.
    ///            Implement IEnumerable<int> and Equals(…), GetHashCode(), [], == and !=.
    /// </summary>
    public class MainProgram
    {
        private static void Main()
        {
            BitArray64 firstNumber = new BitArray64(100);
            BitArray64 secondNumber = new BitArray64(20);

            foreach (var item in firstNumber)
            {
                Console.Write(item);
            }

            Console.WriteLine();

            Console.WriteLine(firstNumber[61]);

            Console.WriteLine(firstNumber == secondNumber);
            Console.WriteLine(firstNumber != secondNumber);
        }
    }
}