namespace SocialNetwork.ConsoleClient.Searcher
{
    using System;
    using Newtonsoft.Json;

    public class UsersTagged
    {
        [JsonProperty("Username")]
        public string Username { get; set; }

        [JsonProperty("PostedOn")]
        public DateTime PostedOn { get; set; }

        [JsonProperty("Content")]
        public string Content { get; set; }

        [JsonProperty("UsernamesOfTaggedUsers")]
        public int UsernamesOfTaggedUsers { get; set; }
    }
}
