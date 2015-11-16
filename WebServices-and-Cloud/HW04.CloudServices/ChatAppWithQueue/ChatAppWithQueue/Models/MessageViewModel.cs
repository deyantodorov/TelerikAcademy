using Newtonsoft.Json;

namespace ChatAppWithQueue.Models
{
    [JsonObject]
    public class MessageViewModel
    {
        public string Message { get; set; }

        public string Ip { get; set; }
    }
}