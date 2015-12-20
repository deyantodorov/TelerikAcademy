namespace T01.FriendsOfPesho
{
    using System;

    public class Point : IComparable<Point>
    {
        public Point(string id, bool isHospital)
        {
            this.ID = id;
            this.IsHospital = isHospital;
        }

        public string ID { get; private set; }

        public int DijkstraDistance { get; set; }

        public bool IsHospital { get; set; }

        public int CompareTo(Point other)
        {
            return this.DijkstraDistance.CompareTo(other.DijkstraDistance);
        }

        public override bool Equals(object obj)
        {
            return this.ID == (obj as Point).ID;
        }

        public override int GetHashCode()
        {
            return this.ID.GetHashCode();
        }
    }
}
