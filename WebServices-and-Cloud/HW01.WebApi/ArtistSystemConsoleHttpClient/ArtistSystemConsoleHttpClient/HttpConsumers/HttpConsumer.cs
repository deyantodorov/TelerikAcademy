namespace ArtistSystemConsoleHttpClient.HttpConsumers
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;

    public class HttpConsumer : IHttpConsumer
    {
        private readonly HttpClient client;

        public HttpConsumer(HttpClient client, string serverPath)
        {
            if (client == null)
            {
                throw new ArgumentNullException("client", "HttpClient can't be null");
            }

            if (string.IsNullOrEmpty(serverPath))
            {
                throw new ArgumentNullException("serverPath", "Server path can't be null or empty");
            }

            this.client = client;
            this.client.BaseAddress = new Uri(serverPath);
        }

        public string Get(string uri, string header = "application/json")
        {
            this.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(header));
            var response = this.client.GetAsync(uri).Result;

            if (!response.IsSuccessStatusCode)
            {
                return response.StatusCode.ToString();
            }

            var content = response.Content.ReadAsStringAsync().Result;
            return content;
        }

        public string Post(string uri, string content, string header = "application/json")
        {
            var requestContent = new StringContent(content, Encoding.UTF8, header);

            var request = this.client.PostAsync(uri, requestContent).Result;

            return !request.IsSuccessStatusCode ? request.StatusCode.ToString() : request.IsSuccessStatusCode.ToString();
        }

        public string Put(string uri, string content, string header = "application/json")
        {
            var requestContent = new StringContent(content, Encoding.UTF8, header);

            var request = this.client.PutAsync(uri, requestContent).Result;

            return !request.IsSuccessStatusCode ? request.StatusCode.ToString() : request.IsSuccessStatusCode.ToString();
        }

        public string Delete(string uri)
        {
            var request = this.client.DeleteAsync(uri).Result;

            return !request.IsSuccessStatusCode ? request.StatusCode.ToString() : request.IsSuccessStatusCode.ToString();
        }
    }
}