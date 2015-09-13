namespace SingletonPattern
{
    using System;

    /// <summary>
    /// Example of Singleton pattern with thread-safe implementation
    /// 
    /// This example work only on .NET 4 Lazy type
    /// </summary>
    public sealed class Singleton
    {
        private static readonly DateTime CreatedDateTime = DateTime.Now;
        private static readonly Lazy<Singleton> Lazy = new Lazy<Singleton>(() => new Singleton());

        private Singleton()
        {
        }

        public static Singleton GetInstance => Lazy.Value;
        public DateTime Date => CreatedDateTime;
    }
}
