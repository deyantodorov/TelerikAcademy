namespace BridgePattern
{
    public class LocalDishTv : IVideoSource
    {
        private const string SourceName = "Local DISH TV";

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
