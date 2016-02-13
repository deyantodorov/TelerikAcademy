namespace HW6.PingPongWithSignalR.ViewModels.Game
{
    public class Paddle
    {
        public Paddle(int left, int top, int width, int height)
        {
            this.Left = left;
            this.Top = top;
            this.Width = width;
            this.Height = height;
        }

        public int Left { get; set; }

        public int Top { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }
    }
}
