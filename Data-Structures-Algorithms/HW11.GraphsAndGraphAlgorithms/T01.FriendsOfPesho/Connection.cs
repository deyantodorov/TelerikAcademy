namespace T01.FriendsOfPesho
{
    using System;

    public class Connection
    {
        public Connection(Point destination, int distance)
        {
            this.Destination = destination;
            this.Distance = distance;
        }

        public Point Destination { get; private set; }

        public int Distance { get; private set; }
    }
}
