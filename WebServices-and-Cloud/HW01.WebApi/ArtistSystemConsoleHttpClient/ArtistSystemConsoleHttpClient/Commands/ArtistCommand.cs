namespace ArtistSystemConsoleHttpClient.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Linq;
    using ArtistSystemConsoleHttpClient.HttpConsumers;
    using ArtistSystemConsoleHttpClient.Models.Artists;
    using Newtonsoft.Json;

    public class ArtistCommand
        : Command, ICommand
    {
        public ArtistCommand(IHttpConsumer consumer, string uri)
            : base(consumer, uri)
        {
        }

        public override void Add()
        {
            for (int i = 0; i < 10; i++)
            {
                var model = new ArtistAddModel()
                {
                    Name = this.Generator.GetRandomString(5, 25),
                    Country = this.Generator.GetRandomString(10, 50),
                    BirthDate = this.Generator.GetRandomDate(before: DateTime.Now, after: new DateTime(1990, 2, 2))
                };

                var json = JsonConvert.SerializeObject(model);
                this.Consumer.Post(this.Uri, json);
            }
        }

        public override void Get(ContentType type)
        {
            var result = string.Empty;
            var items = new List<ArtistShowModel>();

            switch (type)
            {
                case ContentType.Json:
                    result = this.Consumer.Get(this.Uri);
                    items = JsonConvert.DeserializeObject<List<ArtistShowModel>>(result);
                    break;
                case ContentType.Xml:
                    result = this.Consumer.Get(this.Uri, "application/xml");
                    XElement xml = XElement.Parse(result);
                    Console.WriteLine(xml);
                    return;
            }

            if (result == "NotFound")
            {
                Console.WriteLine("NotFound");
                return;
            }

            foreach (var item in items)
            {
                Console.WriteLine("{0} {1} {2}", item.Name, item.Country, item.BirthDate);
            }
        }

        public override void GetById(ContentType type, int id)
        {
            var result = string.Empty;

            switch (type)
            {
                case ContentType.Json:
                    result = this.Consumer.Get(this.Uri + "/" + id);
                    var item = JsonConvert.DeserializeObject<ArtistShowModel>(result);
                    Console.WriteLine("{0} {1} {2}", item.Name, item.Country, item.BirthDate);
                    break;
                case ContentType.Xml:
                    result = this.Consumer.Get(this.Uri + "/" + id, "application/xml");
                    XElement xml = XElement.Parse(result);
                    Console.WriteLine(xml);
                    return;
            }

            if (result == "NotFound")
            {
                Console.WriteLine(result);
            }
        }

        public override void Update(int id)
        {
            var song = new ArtistAddModel()
            {
                Name = "Update " + this.Generator.GetRandomString(5, 15),
                Country = "Update " + this.Generator.GetRandomString(5, 15),
                BirthDate = this.Generator.GetRandomDate(before: DateTime.Now, after: new DateTime(1990, 2, 2))
            };

            var songAsJson = JsonConvert.SerializeObject(song);

            var request = this.Consumer.Put(this.Uri + "/" + id, songAsJson);
            Console.WriteLine(request);
        }
    }
}
