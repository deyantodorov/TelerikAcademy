namespace T06.Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Phonebook
    {
        private readonly ICollection<Contact> contacts;

        public Phonebook()
        {
            this.contacts = new HashSet<Contact>();
        }

        public int Count
        {
            get { return this.contacts.Count(); }
        }

        public void Add(Contact contact)
        {
            this.ChechFoNullValue(contact, "Contact");
            this.contacts.Add(contact);
        }

        public void Remove(Contact contact)
        {
            this.ChechFoNullValue(contact, "Contact");
            this.contacts.Remove(contact);
        }

        public ICollection<Contact> FindByName(string name)
        {
            this.ChechFoNullValue(name, "Name");

            var fName = name.Split(' ');

            var found = this.contacts
                        .Where(x => x.Name.Contains(name) || x.Nickname.Contains(name))
                        .ToList();

            return found;
        }

        public ICollection<Contact> FindByNameAndTownd(string name, string town)
        {
            this.ChechFoNullValue(name, "Name");
            this.ChechFoNullValue(town, "Town");

            var found = this.contacts
                        .Where(x => x.Town.Contains(town))
                        .Where(x => x.Name.Contains(name))
                        .ToList();

            return found;
        }

        private void ChechFoNullValue(object obj, string name)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(name, "Can't be null");
            }
        }
    }
}
