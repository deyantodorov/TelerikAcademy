using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HW03.ProcessingJsonInDotNet
{
    /// <summary>
    /// Using JSON.NET and the Telerik Academy Youtube RSS feed, implement the following:
    ///     The RSS feed is located at https://www.youtube.com/feeds/videos.xml?channel_id=UCLC-vbm7OWvpbqzXaoAMGGw
    ///     Download the content of the feed programatically
    ///     You can use WebClient.DownloadFile()
    ///     Parse the XML from the feed to JSON
    ///     Using LINQ-to-JSON select all the video titles and print the on the console
    ///     Parse the videos' JSON to POCO
    ///     Using the POCOs create a HTML page that shows all videos from the RSS Use <iframe> Provide a links, that nagivate to their videos in YouTube
    /// </summary>
    public class ProcessingJson
    {
        private const string RssFilePath = "https://www.youtube.com/feeds/videos.xml?channel_id=UCLC-vbm7OWvpbqzXaoAMGGw";
        private const string XmlFilePath = @"../../YouTube.xml";
        private const string JsonFilePath = @"../../YouTube.json";
        private const string HtmlFilePath = @"../../YouTube.html";

        private static void Main()
        {
            DownloadFile(RssFilePath, XmlFilePath);
            ConvertXmlToJson(XmlFilePath, JsonFilePath);
            PrintVideoTitlesOnConsole(JsonFilePath);
            var videos = ExtractVideosWithId(JsonFilePath);

            BuildHtmlFile(videos);
        }

        private static void BuildHtmlFile(IEnumerable<Video> videos)
        {
            var builder = new StringBuilder();
            builder.Append("<html>");
            builder.Append("<head>");
            builder.Append("<meta http-equiv=\"Content-Type\" content=\"text/html; charset = utf-8\" />");
            builder.Append("<title>Teleric Videos</title>");
            builder.Append("</head>");
            builder.Append("<body>");

            foreach (var video in videos)
            {
                builder.Append($"<h1><a href=\"https://www.youtube.com/watch?v={video.Id}\" target=\"_blank\">{video.Name}</a></h1>");
                builder.Append($"<iframe width='560' height='315' src='https://www.youtube.com/embed/{video.Id}' frameborder='0' allowfullscreen></iframe>");
            }

            builder.Append("</body>");
            builder.Append("</html>");

            File.WriteAllText(HtmlFilePath, builder.ToString());
        }

        private static IEnumerable<Video> ExtractVideosWithId(string path)
        {
            using (StreamReader jsonFile = new StreamReader(path))
            {
                var jsonObject = JObject.Parse(jsonFile.ReadToEnd());
                var videoSet = jsonObject["feed"]["entry"];

                var videos = videoSet.Select(video => JsonConvert.DeserializeObject<Video>(video.ToString())).ToList();

                return videos;
            }
        }

        private static void PrintVideoTitlesOnConsole(string path)
        {
            using (StreamReader jsonFile = new StreamReader(path))
            {
                var jsonObject = JObject.Parse(jsonFile.ReadToEnd());
                var titles = jsonObject.Descendants()
                    .OfType<JProperty>()
                    .Where(p => p.Name == "media:title").ToList();

                titles.ForEach(title => Console.WriteLine("Video name: {0}", title.Value));
            }
        }

        private static void ConvertXmlToJson(string path, string saveTo)
        {
            var xml = XDocument.Load(path);
            var json = JsonConvert.SerializeXNode(xml, Formatting.Indented);

            SaveJsonToFile(saveTo, json);
        }

        private static void SaveJsonToFile(string saveTo, string json)
        {
            using (StreamWriter writer = new StreamWriter(saveTo))
            {
                writer.Write(json.ToCharArray());
            }
        }

        private static void DownloadFile(string source, string saveTo)
        {
            using (var client = new WebClient())
            {
                client.DownloadFile(source, saveTo);
            }
        }
    }
}
