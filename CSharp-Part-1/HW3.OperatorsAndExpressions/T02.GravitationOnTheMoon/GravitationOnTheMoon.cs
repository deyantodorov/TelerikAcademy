namespace T02.GravitationOnTheMoon
{
    using System;

    /// <summary>
    /// 2. The gravitational field of the Moon is approximately 17% of that on the Earth.
    ///    Write a program that calculates the weight of a man on the moon by a given weight on the Earth.
    /// </summary>
    public class GravitationOnTheMoon
    {
        private static void Main()
        {
            float[] weights = { 86f, 74.6f, 53.7f };
            CalculateMoonWeight(weights);
        }

        private static void CalculateMoonWeight(float[] weights)
        {
            int moonGravity = 17;
            float result;

            for (int i = 0; i < weights.Length; i++)
            {
                result = (weights[i] * moonGravity) / 100;
                Console.WriteLine("{0:F3}", result);
            }
        }
    }
}