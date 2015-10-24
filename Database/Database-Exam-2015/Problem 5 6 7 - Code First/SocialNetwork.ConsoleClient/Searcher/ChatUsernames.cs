namespace SocialNetwork.ConsoleClient.Searcher
{
    using Newtonsoft.Json;

    public class ChatUsernames
    {
        [JsonProperty("ChatId")]
        public string ChatId { get; set; }

        [JsonProperty("ChatUsername")]
        public string ChatUsername { get; set; }
    }
}
