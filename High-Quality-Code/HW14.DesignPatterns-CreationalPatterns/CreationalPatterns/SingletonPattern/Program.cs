namespace SingletonPattern
{
    using System;
    using System.Threading.Tasks;

    public class Program
    {
        internal static void Main()
        {
            var single = Singleton.GetInstance;

            // Start 20 operations on different threads
            Parallel.For(0, 20, index =>
            {
                Console.WriteLine(single.Date);
            });
        }
    }
}