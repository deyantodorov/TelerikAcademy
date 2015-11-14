using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Xml;

namespace HW02.ConsumingWebServices
{
    public class GoogleSearch
    {
        public void Start()
        {
            while (true)
            {
                Console.WriteLine("Search for some news or type 'End' to quit: ");
                var search = Console.ReadLine();

                if (search != null && search.ToLower() == "end")
                {
                    break;
                }

                var news = this.GetNewsAbout(search);

                if (!news.Any())
                {
                    Console.WriteLine("No results...");
                }
                else
                {
                    foreach (var article in news)
                    {
                        Console.WriteLine(article);
                    }
                }
            }
        }

        private List<Article> GetNewsAbout(string search)
        {
            var news = new List<Article>();
            var root = this.GetXmlContent(search);

            if (root == null)
            {
                return news;
            }

            var nodes = root.SelectNodes("/rss/channel/item");

            if (nodes == null)
            {
                return news;
            }

            news.AddRange(from XmlNode node in nodes
                          let title = node.SelectSingleNode("title")
                          let link = node.SelectSingleNode("link")
                          let guid = node.SelectSingleNode("guid")
                          let pubDate = node.SelectSingleNode("pubDate")
                          let description = node.SelectSingleNode("description")
                          where title != null && link != null && guid != null && pubDate != null && description != null
                          select new Article()
                          {
                              Description = description.InnerText,
                              Guid = guid.InnerText,
                              Link = link.InnerText,
                              PubDate = DateTime.Parse(pubDate.InnerText),
                              Title = title.InnerText
                          });

            return news;
        }

        private XmlElement GetXmlContent(string search)
        {
            search = search ?? string.Empty;
            var content = this.GetContent("http://news.google.com/news/section?q=" + search + "&output=rss");

            var doc = new XmlDocument();
            doc.LoadXml(content.Result);
            var root = doc.DocumentElement;
            return root;
        }

        private async Task<string> GetContent(string path)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(path),
            };

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/xml"));

            var response = await client.GetAsync(client.BaseAddress);

            return await response.Content.ReadAsStringAsync();
        }
    }
}
