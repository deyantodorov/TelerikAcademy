namespace CoinChangeProblem
{
    using System;

    public class Program
    {
        private static long Count(int[] vehicles, int numberOfVehicles, int desiredSum)
        {
            var table = new long[desiredSum + 1];
            table[0] = 1;

            for (int i = 0; i < numberOfVehicles; i++)
            {
                for (int j = vehicles[i]; j <= desiredSum; j++)
                {
                    Console.WriteLine(table[j]);
                    table[j] += table[j - vehicles[i]];
                }
            }

            return table[desiredSum];
        }
        private static void Main()
        {
            var vehicles = new [] { 3, 4, 10 };
            int numberOfVehicles = vehicles.Length;
            int desiredSum = 40;
            Console.WriteLine(Count(vehicles, numberOfVehicles, desiredSum));  //242
        }
    }
}
