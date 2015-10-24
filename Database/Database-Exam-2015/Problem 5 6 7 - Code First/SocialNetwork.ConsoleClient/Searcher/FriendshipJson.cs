namespace SocialNetwork.ConsoleClient.Searcher
{
    using Newtonsoft.Json;

    public class FriendshipJson
    {
        [JsonProperty("FirstUserUsername")]
        public string FirstUserUsername { get; set; }

        [JsonProperty("FirstUserImage")]
        public string FirstUserImage { get; set; }

        [JsonProperty("SecondUserUsername")]
        public string SecondUserUsername { get; set; }

        [JsonProperty("SecondUserImage")]
        public string SecondUserImage { get; set; }
    }
}
