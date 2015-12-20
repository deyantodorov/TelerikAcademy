namespace T03.TvCompany
{
    using System;

    struct House
    {
        public House(string id)
            : this()
        {
            this.ID = id;
        }

        public string ID { get; private set; }

        public override string ToString()
        {
            return this.ID;
        }

        public override bool Equals(object obj)
        {
            return this.ID.Equals(((House)obj).ID);
        }

        public override int GetHashCode()
        {
            return this.ID.GetHashCode();
        }
    }
}
