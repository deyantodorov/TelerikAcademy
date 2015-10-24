namespace SocialNetwork.ConsoleClient.Searcher
{
    using System;
    using Newtonsoft.Json;

    public class UsersAfterCertainDate
    {
        [JsonProperty("Username")]
        public string Username { get; set; }

        [JsonProperty("FirstName")]
        public string FirstName { get; set; }

        [JsonProperty("LastName")]
        public string LastName { get; set; }

        [JsonProperty("NumberOfImages")]
        public int NumberOfImages { get; set; }

        [JsonProperty("RegistrationDate")]
        public DateTime RegistrationDate { get; set; }
    }
}
