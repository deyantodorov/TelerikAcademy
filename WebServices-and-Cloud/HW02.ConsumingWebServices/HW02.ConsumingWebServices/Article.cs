using System;
using System.Text;
using System.Xml.Serialization;

namespace HW02.ConsumingWebServices
{
    [XmlRootAttribute("rss")]
    public class Article
    {
        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("link")]
        public string Link { get; set; }

        [XmlElement("guid")]
        public string Guid { get; set; }

        [XmlElement("pubDate")]
        public DateTime PubDate { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.AppendLine(string.Format("{0}", this.Title));
            builder.AppendLine(string.Format("{0}", this.PubDate));
            builder.AppendLine(string.Format("{0}", this.Link));
            builder.AppendLine();

            return builder.ToString();
        }
    }
}