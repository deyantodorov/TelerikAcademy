using System;

namespace BridgePattern
{
    public class MySuperSmartTv
    {
        private IVideoSource currentVideoSource;

        public IVideoSource VideoSource
        {
            get { return this.currentVideoSource; }
            set { this.currentVideoSource = value; }
        }

        public void ShowTvGuide()
        {
            if (this.currentVideoSource != null)
            {
                Console.WriteLine(this.currentVideoSource.GetTvGuide());
            }
            else
            {
                Console.WriteLine("Please select a Video Source to get TV guide from");
            }
        }

        public void PlayTv()
        {
            if (this.currentVideoSource != null)
            {
                Console.WriteLine(this.currentVideoSource.GetTvGuide());
            }
            else
            {
                Console.WriteLine("Please select a Video Source to play");
            }
        }
    }
}
