namespace T03.TvCompany
{
    using System;

    class Path : IComparable<Path>
    {
        public Path(House startHouse, House endHouse, int distance)
        {
            this.StartHouse = startHouse;
            this.EndHouse = endHouse;
            this.Distance = distance;
        }

        public House StartHouse { get; private set; }

        public House EndHouse { get; private set; }

        public int Distance { get; private set; }

        public int CompareTo(Path other)
        {
            return this.Distance.CompareTo(other.Distance);
        }

        public override string ToString()
        {
            return string.Format("({0}, {1}) -> {2}", this.StartHouse, this.EndHouse, this.Distance);
        }
    }
}
