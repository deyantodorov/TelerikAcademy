namespace T06.Phonebook
{
    using System;

    public class Contact
    {
        private readonly int hash;

        public Contact(string name, string town, string phone)
        {
            this.Name = name;
            this.Nickname = string.Empty;
            this.Town = town;
            this.Phone = phone;

            this.hash = this.MakeHash();
        }

        public string Name { get; set; }

        public string Nickname { get; set; }

        public string Town { get; set; }

        public string Phone { get; set; }

        public override int GetHashCode()
        {
            return this.hash;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", this.Name, this.Nickname, this.Town, this.Phone);
        }

        private int MakeHash()
        {
            return (this.Name.Length ^ DateTime.Now.Millisecond + this.Phone.Length ^ DateTime.Now.Month) & this.Town.Length;
        }
    }
}
