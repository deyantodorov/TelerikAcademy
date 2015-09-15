namespace BridgePattern
{
    public class IptvService : IVideoSource
    {
        private const string SourceName = "IP TV";

        public string GetTvGuide()
        {
            return $"Getting TV guide from - {SourceName}";
        }

        public string PlayVideo()
        {
            return $"Playing - {SourceName}";
        }
    }
}
