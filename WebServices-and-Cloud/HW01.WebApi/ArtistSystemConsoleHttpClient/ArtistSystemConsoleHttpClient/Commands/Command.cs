namespace ArtistSystemConsoleHttpClient.Commands
{
    using System;
    using ArtistSystemConsoleHttpClient.HttpConsumers;

    public abstract class Command : ICommand
    {
        protected readonly IHttpConsumer Consumer;
        protected readonly RandomGenerator Generator;
        protected readonly string Uri;

        protected Command(IHttpConsumer consumer, string uri)
        {
            if (consumer == null)
            {
                throw new ArgumentNullException("consumer", "IHttpConsumer can't be null");
            }

            if (string.IsNullOrEmpty(uri))
            {
                throw new ArgumentNullException("uri", "Uri can't be null");
            }

            this.Consumer = consumer;
            this.Generator = new RandomGenerator();
            this.Uri = uri;
        }

        public abstract void Add();

        public abstract void Get(ContentType type);

        public abstract void GetById(ContentType type, int id);

        public abstract void Update(int id);

        public virtual void Delete(int id)
        {
            var result = this.Consumer.Delete(this.Uri + "/" + id);
            Console.WriteLine(result);
        }
    }
}