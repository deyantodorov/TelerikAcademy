namespace BridgePattern
{
    public class LocalCabelTv : IVideoSource
    {
        private const string SourceName = "Local Cabel TV";

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
