namespace ArtistSystemConsoleHttpClient.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Linq;
    using ArtistSystemConsoleHttpClient.HttpConsumers;
    using ArtistSystemConsoleHttpClient.Models.Songs;
    using Newtonsoft.Json;

    public class SongCommand : Command, ICommand
    {
        public SongCommand(IHttpConsumer consumer, string uri) :
            base(consumer, uri)
        {
        }

        public override void Add()
        {
            for (int i = 0; i < 10; i++)
            {
                var model = new SongAddModel()
                {
                    Genre = this.Generator.GetRandomString(5, 25),
                    Title = this.Generator.GetRandomString(10, 75),
                    Year = this.Generator.GetRandomNumber(2000, 2015)
                };

                var json = JsonConvert.SerializeObject(model);
                this.Consumer.Post(this.Uri, json);
            }
        }

        public override void Get(ContentType type)
        {
            var result = string.Empty;
            var items = new List<SongShowModel>();

            switch (type)
            {
                case ContentType.Json:
                    result = this.Consumer.Get(this.Uri);
                    items = JsonConvert.DeserializeObject<List<SongShowModel>>(result);
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
                Console.WriteLine("{0} {1} {2}", item.Title, item.Year, item.Genre);
            }
        }

        public override void GetById(ContentType type, int id)
        {
            var result = string.Empty;

            switch (type)
            {
                case ContentType.Json:
                    result = this.Consumer.Get(this.Uri + "/" + id);
                    var song = JsonConvert.DeserializeObject<SongShowModel>(result);
                    Console.WriteLine("{0} {1} {2}", song.Title, song.Year, song.Genre);
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
            var song = new SongAddModel()
            {
                Genre = "Update " + this.Generator.GetRandomString(5, 15),
                Title = "Update " + this.Generator.GetRandomString(5, 15),
                Year = this.Generator.GetRandomNumber(1980, 2000)
            };

            var songAsJson = JsonConvert.SerializeObject(song);

            var request = this.Consumer.Put(Uri + "/" + id, songAsJson);
            Console.WriteLine(request);
        }
    }
}
