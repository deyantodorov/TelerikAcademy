using Newtonsoft.Json;

namespace HW03.ProcessingJsonInDotNet
{
    public class Video
    {
        [JsonProperty("title")]
        public string Name { get; set; }

        [JsonProperty("yt:videoId")]
        public string Id { get; set; }
    }
}
